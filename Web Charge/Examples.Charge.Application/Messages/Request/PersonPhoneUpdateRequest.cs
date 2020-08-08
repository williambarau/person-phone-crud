using Examples.Charge.Application.Dtos;

namespace Examples.Charge.Application.Messages.Request
{
    public class PersonPhoneUpdateRequest
    {
        public PersonPhoneDto OldPersonPhone { get; set; }
        public PersonPhoneDto NewPersonPhone { get; set; }
    }
}
