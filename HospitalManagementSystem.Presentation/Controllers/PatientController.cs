using HospitalManagementSystem.Core.CQRS.Patient.Commands.Models;
using HospitalManagementSystem.Core.CQRS.Patient.Queries.Models;
using HospitalManagementSystem.Core.Helper;
using HospitalManagementSystem.DataService.DTOs.Patient;
using HospitalManagementSystem.Entites.Roles;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.Presentation.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = nameof(RolesEnum.Admin))]
    public class PatientController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PatientController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<PatientReadDTO>> GetPatient(int id)
        {
            var result = await _mediator.Send(new GetPatientQuery(id));
            return result.IsSuccess ? Ok(result.Data) : NotFound(result.Error);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public ActionResult<PatientCreateDTO> CreatePatient(PatientCreateDTO patientCreateDTO) =>
            Ok(_mediator.Send(new CreatePatientCommand(patientCreateDTO)));

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public ActionResult<string> DeletePatient(int id) =>
            Ok(_mediator.Send(new DeletePatientCommand(id)));

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public ActionResult<PatientUpdateDTO> UpdatePatient(int id, PatientUpdateDTO patientUpdateDTO) =>
            Ok(_mediator.Send(new UpdatePatientCommand(id, patientUpdateDTO)));

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<PatientReadDTO> GetAllPatients() =>
            Ok(_mediator.Send(new GetAllPatientsQuery()));

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<PatientReadDTO>> GetPatientByName(string name)
        {
            var result = await _mediator.Send(new GetPatientByNameQuery(name));
            return result.IsSuccess ? Ok(result.Data) : NotFound(result.Error);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateProfilePicture(int id, IFormFile file)
        {
            if (file is null || file.Length == 0)
            {
                return BadRequest("File is null");
            }
            using var memoryStream = new MemoryStream();
            file.CopyTo(memoryStream);
            var patientProfilePictureCreateDTO = new PatientProfilePictureCreateDTO(memoryStream.ToArray())
            {
                PatientId = id,
                FileExtension = Path.GetExtension(file.FileName),
                FileName = file.FileName,
                FileType = file.ContentType
            };
            return Ok(_mediator.Send(new CreatePatientProfilePictureCommand(patientProfilePictureCreateDTO)));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GenerateReport(int id, [FromQuery] ReportBody report)
        {
            var result = await _mediator.Send(new CreateReportQuery(id, report));
            // return file as excel
            return result.IsSuccess ?
                File(result.Data, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "PatientReport.xlsx") : NotFound(result.Error);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<string>> CreateMultiPatients([FromBody] List<PatientCreateDTO> patientCreateDTOs)
        {
            var result = await _mediator.Send(new CreateMulitPatientsCommand(patientCreateDTOs));
            return result.IsSuccess ? Ok($"{patientCreateDTOs.Count()} Patients Added Successfully") : NotFound(result.Error);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GeneratePdfReport(int id, [FromQuery] ReportBody report)
        {
            var result = await _mediator.Send(new CreatePDFReportQuery(id, report));
            return result.IsSuccess ?
                File(result.Data, "application/pdf", "PatientReport.pdf") : NotFound(result.Error);
        }


    }
}
