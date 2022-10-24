using JobGetter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobGetter.BL.IRepository
{
    public interface IJobRep
    {
        public string AddJobOpprtunity(JobOpportunityVM model);
        public ICollection<JobOpportunityVM> GetAppropriateJobOpportunitiesToUser(string UserName );
        public string RequestJopOpportunity(JobOpportunityRequestVM model);
        public ICollection<JobOpportunityVM> GetOpportunitiesInMyCity(string UserName);
        public ICollection<JobOpportunityVM> GetOpportunitiesInMyCountry(string UserName);
        public string FinishOpportunity(int Id);

    }
}
