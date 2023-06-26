using BusinessObject.Models;
using DataAccessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Implementations
{
    public class CandidateProfileRepository : ICandidateProfileRepository
    {
        public Task CreateNew(CandidateProfile newCandidate)
        {
            return CandidateProfileDao.Instance.CreateNew(newCandidate);
        }

        public Task DeleteCandidate(string id)
        {
            return CandidateProfileDao.Instance.DeleteCandidate(id);
        }

        public Task<CandidateProfile> FindCandidate(string id)
        {
            return CandidateProfileDao.Instance.FindCandidate( id);
        }

        public Task<IList<CandidateProfile>> GetAllCandidate()
        {
           return CandidateProfileDao.Instance.GetAllCandidate();
        }

        public Task<IList<JobPosting>> GetAllJobs()
        {
            return CandidateProfileDao.Instance.GetAllJobs();
        }

        public Task<IList<CandidateProfile>> SearchCandidate(string searchValue)
        {
            return CandidateProfileDao.Instance.SearchCandidate(searchValue);
        }

        public Task UpdateCandidate(CandidateProfile newCandidate)
        {
            return CandidateProfileDao.Instance.UpdateCandidate( newCandidate);
        }
    }
}
