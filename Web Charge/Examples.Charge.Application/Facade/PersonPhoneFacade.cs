using AutoMapper;
using Examples.Charge.Application.Dtos;
using Examples.Charge.Application.Interfaces;
using Examples.Charge.Application.Messages.Request;
using Examples.Charge.Application.Messages.Response;
using Examples.Charge.Domain.Aggregates.PersonAggregate;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.Application.Facade
{
    public class PersonPhoneFacade : IPersonPhoneFacade
    {
        private IPersonPhoneService _personService;
        private IMapper _mapper;

        public PersonPhoneFacade(IPersonPhoneService personService, IMapper mapper)
        {
            _personService = personService;
            _mapper = mapper;
        }

        public async Task<PersonPhoneListResponse> FindPersonPhoneNumberByNumberAsync(string phoneNumber)
        {
            var result = await _personService.FindPersonPhoneNumberByNumberAsync(phoneNumber);
            var response = new PersonPhoneListResponse();
            response.PersonPhoneObjects = new List<PersonPhoneDto>();
            response.PersonPhoneObjects.AddRange(result.Select(x => _mapper.Map<PersonPhoneDto>(x)));
            return response;
        }

        public async Task<PersonPhoneListResponse> FindAllAsync()
        {
            var result = await _personService.FindAllAsync();
            var response = new PersonPhoneListResponse();
            response.PersonPhoneObjects = new List<PersonPhoneDto>();
            response.PersonPhoneObjects.AddRange(result.Select(x => _mapper.Map<PersonPhoneDto>(x)));
            return response;
        }

        public async Task<PersonPhoneResponse> AddAsync(PersonPhoneRequest personPhoneRequest)
        {
            var pesonPhone = _mapper.Map<PersonPhone>(personPhoneRequest);
            var result = await _personService.AddAsync(pesonPhone);
            var response = new PersonPhoneResponse();
            response.PersonPhone = _mapper.Map<PersonPhoneDto>(result);
            return response;
        }

        public async Task<PersonPhoneResponse> UpdateAsync(PersonPhoneUpdateRequest personUpdatePhoneRequest)
        {
            var oldPersonPhone = _mapper.Map<PersonPhone>(personUpdatePhoneRequest.OldPersonPhone);
            var nwePersonPhone = _mapper.Map<PersonPhone>(personUpdatePhoneRequest.NewPersonPhone);
            var result = await _personService.UpdateAsync(oldPersonPhone, nwePersonPhone);
            var response = new PersonPhoneResponse();
            response.PersonPhone = _mapper.Map<PersonPhoneDto>(result);
            return response;
        }

        public async Task DeleteAsync(PersonPhoneRequest personPhoneRequest)
        {
            var pesonPhone = _mapper.Map<PersonPhone>(personPhoneRequest);
            await _personService.DeleteAsync(pesonPhone);
        }
    }
}
