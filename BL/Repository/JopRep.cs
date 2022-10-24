using AutoMapper;
using JobGetter.BL.IRepository;
using JobGetter.DAL;
using JobGetter.DAL.Entities;
using JobGetter.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using JobGetter.Helpers;
using System.Threading.Tasks;

namespace JobGetter.BL.Repository
{
    public class JopRep:IJobRep
    {
        private readonly DataBase _db;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _user;
        public JopRep(DataBase db, IMapper mapper,UserManager<AppUser> user)
        {
            this._db = db;
            this._mapper = mapper;
            this._user = user;
        }
        public static ICollection<JobOpportunityVM> DefaultCollection() => new List<JobOpportunityVM>() { new JobOpportunityVM() { JobName = "update your account infromation to get ytour appropriate job opportunites " } };

        public ICollection<JobOpportunityVM> ReturnTimeLineFromDataList(List<Jobpportunity> MyList)
        {
            if (MyList is null)
                return DefaultCollection(); 
            var jobopportunites = new List<JobOpportunityVM>();
            foreach (var item in MyList)
            {
                var jobopp = _mapper.Map<JobOpportunityVM>(item);
                jobopp.JobName = item.Job.Name;
                jobopp.CityName = item.City.Name;
                jobopp.MilitaryStatusName = item.MilitaryStatus.Name;

                jobopportunites.Add(jobopp);
            }
            return jobopportunites;
        }

        public string AddJobOpprtunity(JobOpportunityVM model)
        {
            try
            {
                var newjob = _mapper.Map<Jobpportunity>(model);
                newjob.OpportunityDate = DateTime.Now;
                _db.Jobpportunitys.Add(newjob);
                _db.SaveChanges();
                return "Good";
            }
            catch
            {
                return "job opprtunity doesn't Save in data base try adding valid values ";
            }
            
        }
        public ICollection<JobOpportunityVM> GetAppropriateJobOpportunitiesToUser(string UserName) {

            var CurrentUser = _user.FindByNameAsync(UserName).Result;
            while (CurrentUser is not null)
            {
                var ourList = _db.Jobpportunitys
                    .Include(i => i.City)
                    .Include(j => j.Job)
                    .Include(m => m.MilitaryStatus)
                    .Where(w => w.IsAvailable == true && (w.JobId == CurrentUser.JobId || w.QualificationId1 == CurrentUser.QualificationId || w.QualificationId2 == CurrentUser.QualificationId))
                    .ToList();
                return ReturnTimeLineFromDataList(ourList);
                
            }
            return DefaultCollection();

        }

        public string RequestJopOpportunity(JobOpportunityRequestVM model )
        {
            try
            {
                var JobRequest = _mapper.Map<JobOpportunityRequest>(model);
                JobRequest.CVName = SaveCVHelper.SaveCV(model.CV);
                _db.JobOpportunityRequests.Add(JobRequest);
                _db.SaveChanges();
                return "Good";
            }
            catch
            {
                return "Request doesn't added ";
            }
         

        }
        public ICollection<JobOpportunityVM> GetOpportunitiesInMyCity(string UserName)
        {
            var CUser = _user.FindByNameAsync(UserName).Result;
            while(CUser is not null)
            {
               
                var ourList = _db.Jobpportunitys
                    .Include(i => i.City)
                    .Include(j => j.Job)
                    .Include(m => m.MilitaryStatus)
                    .Where(w => w.IsAvailable == true && w.CityId == CUser.CityId)
                    .ToList();

               
                return ReturnTimeLineFromDataList(ourList);
            }
            return DefaultCollection();
        }
        public ICollection<JobOpportunityVM> GetOpportunitiesInMyCountry(string UserName)
        {
            var CUser = _user.FindByNameAsync(UserName).Result;
            var CountryUserId = _db.Cities.FirstOrDefault(f => f.Id == CUser.CityId).CountryId;
            while (CUser is not null)
            {
                var ourList = _db.Jobpportunitys
                   .Include(i => i.City)
                   .Include(j => j.Job)
                   .Include(m => m.MilitaryStatus)
                   .Where(w => w.IsAvailable == true && w.City.CountryId == CountryUserId)
                   .ToList();


                return ReturnTimeLineFromDataList(ourList);
            }
            return DefaultCollection();
        }
        public string FinishOpportunity(int Id)
        {
            var oppo = _db.Jobpportunitys.FirstOrDefault(f => f.Id == Id);
            while (oppo is not null)
            {
                try
                {
                    oppo.IsAvailable = false;
                    _db.Update(oppo);
                    _db.SaveChanges();
                    return "Good";

                }
                catch
                {
                    return "can't finished the Opportunity";
                }
            }
            return "No Job Opportunity is not found ";
        }

    }
}
