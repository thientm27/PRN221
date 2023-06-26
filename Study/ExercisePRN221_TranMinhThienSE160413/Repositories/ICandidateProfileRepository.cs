
using BusinessObject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repositories
{
    public interface ICandidateProfileRepository
    {
        public Task<IList<CandidateProfile>> GetAllCandidate();
        public Task<IList<CandidateProfile>> SearchCandidate(string searchValue);
    }
}
