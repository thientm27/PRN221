using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BussinessObjects.Models;
using Reposiories;
using Reposiories.Imple;

namespace RazorPages.Pages.AuthorInstitution2023DB
{
    public class IndexModel : PageModel
    {
        private ICorrespondingAuthorsRepo _correspondingAuthorsRepo = new CorrespondingAuthorsRepo();

        public IList<CorrespondingAuthor> CorrespondingAuthor { get; set; }
        public async Task OnGetAsync()
        {
            CorrespondingAuthor = _correspondingAuthorsRepo.GetCorrespondingAuthors();
        }
    }
}
