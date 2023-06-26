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
        public async Task<IList<JobPosting>> GetAllJobs()
        {
            return await _context.JobPostings.ToListAsync();
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
        public async Task DeleteCandidate(string id)
        {

            var CandidateProfile = await _context.CandidateProfiles.FindAsync(id);

            if (CandidateProfile != null)
            {
                _context.CandidateProfiles.Remove(CandidateProfile);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<CandidateProfile> FindCandidate(string id)
        {

           return await _context.CandidateProfiles
               .Include(c => c.Posting).FirstOrDefaultAsync(m => m.CandidateId == id);

        }
        public async Task UpdateCandidate(CandidateProfile newCandidate)
        {
            var currentCandidate = await FindCandidate(newCandidate.CandidateId);
            if (currentCandidate != null)
            {
                _context.Entry(currentCandidate).CurrentValues.SetValues(newCandidate);
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }

        }  
        public async Task CreateNew(CandidateProfile newCandidate)
        {
            var maxId = _context.CandidateProfiles.Max(c => c.CandidateId);
            newCandidate.CandidateId = maxId + 1;

            _context.CandidateProfiles.Add(newCandidate);
            await _context.SaveChangesAsync();
        }
    }
}
