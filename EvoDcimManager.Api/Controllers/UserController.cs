using Microsoft.AspNetCore.Mvc;

namespace EvoDcimManager.Api.Controllers
{
    [ApiController]
    [Route("/v1/users")]
    public class UserController : ControllerBase
    {
        [Route("")]
        [HttpPost]
        public void Create()
        {

        }

        [Route("")]
        [HttpPut]
        public void Update()
        {

        }

        [Route("")]
        [HttpDelete]
        public void Remove()
        {

        }

        [Route("login")]
        [HttpPost]
        public void Login()
        {

        }
    }
}