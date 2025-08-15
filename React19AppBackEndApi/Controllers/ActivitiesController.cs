using MediatR;
using Microsoft.AspNetCore.Mvc;
using React19AppBackEndApi.Application.Activities.Commands;
using React19AppBackEndApi.Application.Activities.Queries;
using React19AppBackEndApi.Domain;
using React19AppBackEndApi.Persistence;

namespace React19AppBackEndApi.Controllers
{
    public class ActivitiesController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<Activity>>> GetActivities()
        {
            return await Mediator.Send(new GetActivityList.Query());
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<Activity>> GetActivityDetails(string Id)
        {

            return await Mediator.Send(new GetActivitiesDetails.Query { Id = Id });
        }

        [HttpPost]
        public async Task<ActionResult<string>> CreateActivity(Activity activity)
        {
            return await Mediator.Send(new CreateActivity.Command { Activity = activity });
        }

        [HttpPut]
        public async Task<ActionResult> EditActivity(Activity activity)
        {
            await Mediator.Send(new EditActivity.Command { Activity = activity });

            return NoContent();
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteActivity(string Id)
        {

            await Mediator.Send(new DeleteActivity.Command { Id = Id });

            return Ok();
        }
    }
}
