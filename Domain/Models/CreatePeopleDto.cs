﻿using System;
namespace Domain.Models
{
	public class CreatePeopleDto
	{
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid CountryId { get; set; }
        public string Gender { get; set; }
    }
}

