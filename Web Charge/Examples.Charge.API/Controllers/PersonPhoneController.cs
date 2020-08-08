using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Examples.Charge.Application.Interfaces;
using Examples.Charge.Application.Messages.Request;
using Examples.Charge.Application.Messages.Response;
using System.Threading.Tasks;

namespace Examples.Charge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonPhoneController : BaseController
    {
        private IPersonPhoneFacade _facade;

        public PersonPhoneController(IPersonPhoneFacade facade, IMapper mapper)
        {
            _facade = facade;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<PersonPhoneListResponse>> List() => Response(await _facade.FindAllAsync());

        [HttpGet("{phoneNumber}")]
        public async Task<ActionResult<PersonPhoneResponse>> ListByPhoneNumber(string phoneNumber)
        {
            return Response(await _facade.FindPersonPhoneNumberByNumberAsync(phoneNumber));
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<PersonPhoneResponse>> Add([FromBody] PersonPhoneRequest request)
        {
            return Response(await _facade.AddAsync(request));
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<PersonPhoneResponse>> Update([FromBody] PersonPhoneUpdateRequest requestUpdate)
        {
            return Response(await _facade.UpdateAsync(requestUpdate));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Delete([FromBody] PersonPhoneRequest request)
        {
            await _facade.DeleteAsync(request);
            return Response(null);
        }
    }
}
