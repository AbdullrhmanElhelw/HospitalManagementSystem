using System.Security.Claims;

namespace HospitalManagementSystem.Presentation.Utilites;

public class UserUtility
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserUtility(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string GetUserId()
    {
        return _httpContextAccessor.HttpContext.User?.FindFirst(ClaimTypes.NameIdentifier).Value;
    }

}
