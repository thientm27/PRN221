using BussinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public class CorrespondingAuthorsDAO
    {
        private static CorrespondingAuthorsDAO instance = null;
        private static object instanceLook = new object();

        public static CorrespondingAuthorsDAO Instance
        {
            get
            {
                lock (instanceLook)
                {
                    if (instance == null)
                    {
                        instance = new CorrespondingAuthorsDAO();
                    }
                    return instance;
                }
            }
        }

        AuthorInstitution2023DBContext context = new AuthorInstitution2023DBContext();

        public List<CorrespondingAuthor> GetCorrespondingAuthors()
        {
            try
            {
                return context.CorrespondingAuthors.ToList();
            }
            catch (Exception)
            {

                throw;
            }
  
        }
    }
}
