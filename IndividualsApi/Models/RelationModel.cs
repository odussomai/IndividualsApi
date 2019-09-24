using IndividualsApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndividualsApi.Models
{
    public class RelationModel
    {
        public RelationType Type { get; set; }

        public IndividualModel Related { get; set; }
    }
}
