using AutoMapper;
using MediatR;
using React19AppBackEndApi.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace React19AppBackEndApi.Application.Activities.Commands
{
    public class DeleteActivity
    {
        public class Command : IRequest
        {
            public required string Id { get; set; }
        }

        public class Handler(AppDbContext db) : IRequestHandler<Command>
        {
            public async Task Handle(Command request, CancellationToken cancellationToken)
            {
                var activity = await db.Activities.FindAsync([request.Id], cancellationToken)
                    ?? throw new Exception("Cannot fin activity");

                db.Remove(activity);

                await db.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
