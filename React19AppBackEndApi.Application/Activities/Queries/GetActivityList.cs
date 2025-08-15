using MediatR;
using Microsoft.EntityFrameworkCore;
using React19AppBackEndApi.Domain;
using React19AppBackEndApi.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace React19AppBackEndApi.Application.Activities.Queries
{
    public class GetActivityList
    {
        public class Query : IRequest<List<Activity>> { }

        public class Handler(AppDbContext db) : IRequestHandler<Query, List<Activity>>
        {
            public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await db.Activities.ToListAsync(cancellationToken);
            }
        }
    }
}
