using AutoMapper;
using JobGetter.DAL.Entities;
using JobGetter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobGetter.Helpers
{
    public class DomainProfile:Profile
    {
        public DomainProfile()
        {
            CreateMap<Jobpportunity, JobOpportunityVM>();
            CreateMap<JobOpportunityVM, Jobpportunity>();

            CreateMap<JobOpportunityRequest, JobOpportunityRequestVM>();
            CreateMap<JobOpportunityRequestVM, JobOpportunityRequest>();


        }
    }
}
