using BussinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reposiories
{
    public interface ICorrespondingAuthorsRepo
    {
        public List<CorrespondingAuthor> GetCorrespondingAuthors();
    }
}
