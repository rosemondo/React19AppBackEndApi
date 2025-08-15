using MediatR;
using React19AppBackEndApi.Domain;
using React19AppBackEndApi.Persistence;


namespace React19AppBackEndApi.Application.Activities.Commands
{
    public class CreateActivity
    {
        public class Command : IRequest<string>
        {
            public required Activity Activity { get; set; }
        }

        public class Handler(AppDbContext db) : IRequestHandler<Command, string>
        {
            public async Task<string> Handle(Command request, CancellationToken cancellationToken)
            {
                db.Activities.Add(request.Activity);

                await db.SaveChangesAsync(cancellationToken);

                return request.Activity.Id;
            }
        }
    }
}
