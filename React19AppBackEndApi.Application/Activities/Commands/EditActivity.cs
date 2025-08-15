using AutoMapper;
using MediatR;
using React19AppBackEndApi.Domain;
using React19AppBackEndApi.Persistence;


namespace React19AppBackEndApi.Application.Activities.Commands
{
    public class EditActivity
    {
        public class Command : IRequest
        {
            public required Activity Activity { get; set; }
        }

        public class Handler(AppDbContext db, IMapper mapper) : IRequestHandler<Command>
        {
            public async Task Handle(Command request, CancellationToken cancellationToken)
            {
                var activity = await db.Activities
                    .FindAsync([request.Activity.Id], cancellationToken)
                        ?? throw new Exception("Cannot fin activity");

                mapper.Map(request.Activity, activity);

                await db.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
