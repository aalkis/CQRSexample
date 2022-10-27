using CQRS.CQRS.Commands;
using CQRS.CQRS.Handlers;
using CQRS.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        //private readonly GetStudentByIdQueryHandler _getStudentByIdQueryHandler;
        //private readonly GetStudentsQueryHandler _getStudentsQueryHandler;
        //private readonly CreateStudentCommandHandler _createStudentCommandHandler;
        //private readonly RemoveStudentCommandHandler _removeStudentCommandHandler;
        //private readonly UpdateStudentCommandHandler _updateStudentCommandHandler;
        //public StudentsController(GetStudentByIdQueryHandler getStudentByIdQueryHandler, GetStudentsQueryHandler getStudentsQueryHandler,
        //    CreateStudentCommandHandler createStudentCommandHandler, RemoveStudentCommandHandler removeStudentCommandHandler,
        //    UpdateStudentCommandHandler updateStudentCommandHandler)
        //{
        //    _getStudentByIdQueryHandler = getStudentByIdQueryHandler;
        //    _getStudentsQueryHandler = getStudentsQueryHandler;
        //    _createStudentCommandHandler = createStudentCommandHandler;
        //    _removeStudentCommandHandler = removeStudentCommandHandler;
        //    _updateStudentCommandHandler = updateStudentCommandHandler;
        //}
        private readonly IMediator _mediator;

        public StudentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudent(int id)
        {
            var result = await _mediator.Send(new GetStudentByIdQuery(id));
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var result = await _mediator.Send(new GetStudentsQuery());
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent(CreateStudentCommand command)
        {
            await _mediator.Send(command);
            return Created("", command.Name);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            await _mediator.Send(new RemoveStudentCommand(id));
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStudent(UpdateStudentCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
