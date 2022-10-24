using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JobGetter.DAL.Entities
{
    public class Jobpportunity
    {
        [Key]
        public int Id { get; set; }
        public bool IsAvailable { get; set; } = true; 

        public string Name { get; set; }
        public DateTime OpportunityDate { get; set; }

        public int JobId { get; set; }
        [ForeignKey("JobId")]
        public Job Job { get; set; }

        public string Salary { get; set; }
        public int QualificationId1 { get; set; }
        public int QualificationId2 { get; set; }
        public int QualificationId3 { get; set; }


        public int? MilitaryStatusId { get; set; }
        [ForeignKey("MilitaryStatusId")]
        public MilitaryStatus MilitaryStatus { get; set; }

       

        public int? CityId { get; set; }
        [ForeignKey("CityId")]
        public City City { get; set; }

    }
}
