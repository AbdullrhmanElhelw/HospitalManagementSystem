using HospitalManagementSystem.Core.CQRS.Admin.Commands.Models;
using HospitalManagementSystem.DataService.DTOs.User;
using HospitalManagementSystem.Entites.Entites;
using HospitalManagementSystem.Entites.Roles;
using HospitalManagementSystem.Presentation.Utilites;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;

namespace HospitalManagementSystem.Presentation.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configration;
        private readonly IMediator _mediator;
        private readonly UserUtility _userUtility;

        public UserController
            (UserManager<ApplicationUser> userManager,
            IConfiguration configuration, RoleManager<IdentityRole> roleManager,
            IMediator mediator, UserUtility userUtility)
        {
            _userManager = userManager;
            _configration = configuration;
            _roleManager = roleManager;
            _mediator = mediator;
            _userUtility = userUtility;
        }

        [HttpPost]
        public ActionResult<string> Register(UserRegisterDTO registerDTO)
        {
            var user = new ApplicationUser
            {
                Email = registerDTO.Email,
                UserName = new MailAddress(registerDTO.Email).User
            };

            var result = _userManager.CreateAsync(user, registerDTO.Password).Result;
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Email,registerDTO.Email),
                new Claim(JwtRegisteredClaimNames.Jti , Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role, nameof(RolesEnum.User))

            };

            var clamisResult = _userManager.AddClaimsAsync(user, claims).Result;

            if (!clamisResult.Succeeded)
            {
                return BadRequest(clamisResult.Errors);
            }
            var roleResult = _userManager.AddToRoleAsync(user, nameof(RolesEnum.User)).Result;
            if (!roleResult.Succeeded)
            {
                return BadRequest(roleResult.Errors);
            }
            return Ok("done");
        }

        [HttpPost]
        public ActionResult<string> Login(UserLoginDTO userLoginDTO)
        {
            var user = _userManager.FindByEmailAsync(userLoginDTO.Email).Result;
            if (user == null)
            {
                return BadRequest("Invalid Email");
            }

            var result = _userManager.CheckPasswordAsync(user, userLoginDTO.Password).Result;
            if (!result)
            {
                return BadRequest("Invalid Password");
            }

            var userIdentity = _userManager.GetUserIdAsync(user).Result;
            var claims = _userManager.GetClaimsAsync(user).Result;
            claims.Add(new Claim(ClaimTypes.NameIdentifier, userIdentity));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configration["Jwt:Key"]));
            var credintials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _configration["Jwt:Issuer"],
                _configration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credintials
                    );

            return Ok(
                new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                }
                );
        }

        [HttpPost]
        [Authorize(Roles = nameof(RolesEnum.Admin))]
        public ActionResult<string> CreateAdmin(UserRegisterDTO registerDTO)
        {
            var user = new HospitalAdmin
            {
                Email = registerDTO.Email,
                UserName = new MailAddress(registerDTO.Email).User
            };

            var result = _userManager.CreateAsync(user, registerDTO.Password).Result;
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            var claims = new List<Claim>()
            {
                new (ClaimTypes.Email,registerDTO.Email),
                new (JwtRegisteredClaimNames.Jti , Guid.NewGuid().ToString()),
                new (ClaimTypes.Role, nameof(RolesEnum.Admin))
            };

            var clamisResult = _userManager.AddClaimsAsync(user, claims).Result;
            if (!clamisResult.Succeeded)
            {
                return BadRequest(clamisResult.Errors);
            }

            return Ok("done");
        }

        [HttpPost]
        [Authorize(Roles = nameof(RolesEnum.Admin))]
        public IActionResult CreateRole()
        {
            var roles = new List<IdentityRole>()
            {
                new IdentityRole(nameof(RolesEnum.Admin)),
                new IdentityRole(nameof(RolesEnum.Relative)),
                new IdentityRole(nameof(RolesEnum.User))
            };

            foreach (var role in roles)
            {
                var result = _roleManager.CreateAsync(role).Result;
                if (!result.Succeeded)
                {
                    return BadRequest(result.Errors);
                }
            }
            return Ok();
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _userManager.Users.ToList();
            var usersDTO = new List<UserReadDTO>();
            foreach (var user in users)
            {
                var userDTO = new UserReadDTO(user.Id, user.Email, user.UserName,
                    _userManager.GetRolesAsync(user).Result.FirstOrDefault());
                usersDTO.Add(userDTO);
            }
            return Ok(usersDTO);
        }

        [HttpPost]
        [Authorize(Roles = nameof(RolesEnum.Admin))]
        public IActionResult UploadMRI(IFormFile mri)
        {
            try
            {
                if (mri == null || mri.Length == 0)
                {
                    return BadRequest("Invalid file");
                }

                using var memoryStream = new MemoryStream();
                mri.CopyTo(memoryStream);

                var MRIDto = new MRIUploadDTO(memoryStream.ToArray())
                {
                    FileExtension = Path.GetExtension(mri.FileName),
                    FileName = mri.FileName,
                    FileType = mri.ContentType,
                    HospitalAdminId = _userUtility.GetUserId()
                };

                var result = _mediator.Send(new UploadMRICommand(MRIDto)).Result;

                return result.IsSuccess ? Ok(result) : BadRequest(result.Error);
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes
                Console.WriteLine(ex);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet]
        public ActionResult<string> GetId()
        {
            var userId = _userUtility.GetUserId();
            return Ok(userId);
        }

    }
}