using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PopulationHouseholdWebAPI.Model
{
    public class Actucals
    {
        [Key]
        public int ID { get; set; }
        public int State { get; set; }
        public int Districts { get; set; }
        public int Population { get; set; }
        public int Households { get; set; }
    }
    public class Estimates
    {
        [Key]
        public int ID { get; set; }
        public int State { get; set; }
        public int Districts { get; set; }
        public int Population { get; set; }
        public int Households { get; set; }
    }
}
