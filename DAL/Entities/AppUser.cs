using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JobGetter.DAL.Entities
{
    public class AppUser:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public float? ExpertYears { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int? JobId { get; set; }
        [ForeignKey("JobId")]
        public Job Job { get; set; }

        public int? QualificationId { get; set; }
        [ForeignKey("QualificationId")]
        public Qualification Qualification { get; set; }
       
        public int? MilitaryStatusId { get; set; }
        [ForeignKey("MilitaryStatusId")]
        public MilitaryStatus MilitaryStatus { get; set; }

        public int? CityId { get; set; }
        [ForeignKey("CityId")]
        public City City { get; set; }
    }
}
