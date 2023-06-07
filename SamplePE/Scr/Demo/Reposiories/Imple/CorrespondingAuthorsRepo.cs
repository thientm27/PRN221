using BussinessObjects.Models;
using DataAccessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reposiories.Imple
{
    public class CorrespondingAuthorsRepo : ICorrespondingAuthorsRepo
    {
        public List<CorrespondingAuthor> GetCorrespondingAuthors()
        {
           return CorrespondingAuthorsDAO.Instance.GetCorrespondingAuthors();
        }
    }
}
