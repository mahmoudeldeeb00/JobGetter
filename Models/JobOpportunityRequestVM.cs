using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobGetter.Models
{
    public class JobOpportunityRequestVM
    {
        public int? Id { get; set; }       
        public string UserId { get; set; }
        [Required(ErrorMessage ="jop opprtunity is required ")]
        public int JobOpportunityId { get; set; }     
        public DateTime RequestDate { get; set; }
        public string CVName { get; set; }
        [Required(ErrorMessage ="jop opprtunity is required ")]
        public IFormFile CV { get; set; }
    }
}
