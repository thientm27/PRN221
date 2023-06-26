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
        public Task<IList<CandidateProfile>> GetAllCandidate()
        {
           return CandidateProfileDao.Instance.GetAllCandidate();
        }

        public Task<IList<CandidateProfile>> SearchCandidate(string searchValue)
        {
            return CandidateProfileDao.Instance.SearchCandidate(searchValue);
        }
    }
}
