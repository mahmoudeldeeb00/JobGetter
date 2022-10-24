using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobGetter.Models
{
    public class RegisterModel
    {
        [Required, StringLength(20)]
        public string FirstName { get; set; }
        [Required, StringLength(20)]
        public string LastName { get; set; }
        [Required, StringLength(50)]
        public string UserName { get; set; }
        [Required, StringLength(50)]
        public string Email { get; set; }
        [Required, StringLength(20)]
        public string Pasword { get; set; }
        public DateTime DateOfBirth { get; set; }
        public float? ExpertYears { get; set; }
        public int? JobId { get; set; }
        public int? QualificationId { get; set; }
        public int? MilitaryStatusId { get; set; }
        public int? CityId { get; set; }
    }
}
