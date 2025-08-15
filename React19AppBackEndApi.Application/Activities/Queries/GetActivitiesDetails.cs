using MediatR;
using React19AppBackEndApi.Domain;
using React19AppBackEndApi.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace React19AppBackEndApi.Application.Activities.Queries
{
    public class GetActivitiesDetails
    {
        public class Query : IRequest<Activity>
        {
            public required string Id { get; set; }
        }

        public class Handler(AppDbContext db) : IRequestHandler<Query, Activity>
        {
            public async Task<Activity> Handle(Query request, CancellationToken cancellationToken)
            {
                var activity = await db.Activities.FindAsync([request.Id], cancellationToken);

                if (activity == null) throw new Exception("Activity not found");

                return activity;
            }
        }
    }
}
