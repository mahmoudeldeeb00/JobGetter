using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobGetter.Models
{
    public class JobOpportunityVM
    {
        public int Id { get; set; }
        public bool IsAvailable { get; set; } = true;
        [Required(ErrorMessage ="this field is required")]
        public string Name { get; set; }
        public DateTime OpportunityDate { get; set; }
        [Required(ErrorMessage = "this field is required")]

        public int JobId { get; set; }
        public string JobName { get; set; }


        public string Salary { get; set; }
        [Required(ErrorMessage = "this field is required")]
        public int QualificationId1 { get; set; }
        public int QualificationId2 { get; set; }
        public int QualificationId3 { get; set; }
      //  public List<string> Qualifications { get; set; }
        [Required(ErrorMessage = "this field is required")]
        public int MilitaryStatusId { get; set; }
        
        public string MilitaryStatusName  { get; set; }
        [Required(ErrorMessage = "this field is required")]
        public int CityId { get; set; }     
        public  string CityName { get; set; }
    }
}
