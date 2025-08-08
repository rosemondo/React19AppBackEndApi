using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using React19AppBackEndApi.Domain;
using React19AppBackEndApi.Persistence;

namespace React19AppBackEndApi.Controllers
{
    public class ActivitiesController(AppDbContext context) : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<Activity>>> GetActivities()
        {
            return await context.Activities.ToListAsync();
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<Activity>> GetActivityDetails(string Id)
        {
            var activity = await context.Activities.FindAsync(Id);

            if (activity == null) return NotFound();

            return activity;
        }

    }
}
