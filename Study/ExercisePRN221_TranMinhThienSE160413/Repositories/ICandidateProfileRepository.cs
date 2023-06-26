
using BusinessObject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repositories
{
    public interface ICandidateProfileRepository
    {
        public Task<IList<CandidateProfile>> GetAllCandidate();
        public Task<IList<CandidateProfile>> SearchCandidate(string searchValue);
        public  Task<CandidateProfile> FindCandidate(string id);
        public Task DeleteCandidate(string id);
        public Task<IList<JobPosting>> GetAllJobs();
        public Task UpdateCandidate(CandidateProfile newCandidate);
        public Task CreateNew(CandidateProfile newCandidate);
    }
}
