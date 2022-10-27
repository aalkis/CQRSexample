using CQRS.CQRS.Commands;
using CQRS.Data;
using MediatR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CQRS.CQRS.Handlers
{
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand>
    {
        private readonly StudentContext _context;

        public CreateStudentCommandHandler(StudentContext context)
        {
            _context = context;
        }

        //public void Handle(CreateStudentCommand command)
        //{
        //    _context.Students.Add(new Student { Age = command.Age, Name = command.Name, Surname = command.Surname });
        //    _context.SaveChanges();
        //}

        public async Task<Unit> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            _context.Students.Add(new Student { Age = request.Age, Name = request.Name, Surname = request.Surname });
            await _context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
