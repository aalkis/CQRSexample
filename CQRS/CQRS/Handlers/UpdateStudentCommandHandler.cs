using CQRS.CQRS.Commands;
using CQRS.Data;
using MediatR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CQRS.CQRS.Handlers
{
    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand>
    {
        private readonly StudentContext _context;

        public UpdateStudentCommandHandler(StudentContext context)
        {
            _context = context;
        }
        //public void Handle(UpdateStudentCommand command)
        //{
        //    var updatedStudent = _context.Students.Find(command.Id);
        //    updatedStudent.Name = command.Name;
        //    updatedStudent.Surname = command.Surname;
        //    updatedStudent.Age = command.Age;
        //    _context.SaveChanges();
        //}

        public async Task<Unit> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var updatedStudent = _context.Students.Find(request.Id);
            updatedStudent.Name = request.Name;
            updatedStudent.Surname = request.Surname;
            updatedStudent.Age = request.Age;
            await _context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
