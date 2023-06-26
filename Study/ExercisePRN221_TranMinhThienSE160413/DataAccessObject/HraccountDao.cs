using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class HraccountDao
    {
        private static HraccountDao instance = null;
        private static object instanceLook = new object();

        public static HraccountDao Instance
        {
            get
            {
                lock (instanceLook)
                {
                    if (instance == null)
                    {
                        instance = new HraccountDao();

                    }
                    return instance;
                }
            }
        }
        private CandidateManagementContext _context = new();
        public Hraccount Login(string email, string password)
        {
           var profile =  _context.Hraccounts.Where(o => o.Email.ToUpper().Equals(email.ToUpper()) && o.Password.Equals(password)).FirstOrDefault();
            if (profile != null)
            {
                return profile;
            }
            else
            {
                return null;
            }
        }
    }
}
