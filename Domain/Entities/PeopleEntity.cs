using System;
namespace Domain.Entities
{
	public class PeopleEntity : BaseEntity
	{
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid CountryId { get; set; }
        public string Gender { get; set; }

        public CountryEntity Country { get; set; } = default!;
    }
}

