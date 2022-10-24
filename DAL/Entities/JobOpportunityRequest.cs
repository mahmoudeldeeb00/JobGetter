using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JobGetter.DAL.Entities
{
    public class JobOpportunityRequest
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public AppUser AppUser { get; set; }

        public int JobOpportunityId { get; set; }
        [ForeignKey("JobOpprtunityId")]
        public Jobpportunity JobOpportunity { get; set; }
        public DateTime RequestDate { get; set; }
        public string CVName { get; set; }

    }
}
