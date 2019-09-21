using IndividualsApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndividualsApi.Models
{
    public class IndividualModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
      
        public string LastName { get; set; }

        public BinarySex Sex { get; set; }

        public string PersonalId { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string City { get; set; }
    }
}
