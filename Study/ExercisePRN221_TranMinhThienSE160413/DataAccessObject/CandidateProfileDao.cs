using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class CandidateProfileDao
    {
        private static CandidateProfileDao instance = null;
        private static object instanceLook = new object();

        public static CandidateProfileDao Instance
        {
            get
            {
                lock (instanceLook)
                {
                    if (instance == null)
                    {
                        instance = new CandidateProfileDao();
                    }
                    return instance;
                }
            }
        }
        private CandidateManagementContext _context = new();

        public async Task<IList<CandidateProfile>> GetAllCandidate()
        {
            return await _context.CandidateProfiles
                .Include(c => c.Posting).ToListAsync();
        }

        public async Task<IList<CandidateProfile>> SearchCandidate(string searchValue)
        {
            var data = await _context.CandidateProfiles
                .Include(c => c.Posting).ToListAsync();

            return data.Where(o => o.Fullname.ToUpper().Contains(searchValue.ToUpper())
            || o.ProfileUrl.ToUpper().Contains(searchValue.ToUpper())
            || o.ProfileShortDescription.ToUpper().Contains(searchValue.ToUpper())
            ).ToList();
        }

    }
}
