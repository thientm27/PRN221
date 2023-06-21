using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using RazorPagesDemoYoutube.Data;
using RazorPagesDemoYoutube.Models;
using RazorPagesDemoYoutube.ViewModels;

namespace RazorPagesDemoYoutube.Pages.Admin.Categories
{
    public class AddOrEditModel : PageModel
    {
        private readonly CourseDbContext _db;
        private readonly IMapper _mapper;
        private readonly IToastNotification _notify;

        [BindProperty]
        public CategoryViewModel Categ { get; set; }

        public AddOrEditModel(CourseDbContext db, IMapper mapper, IToastNotification notify)
        {
            this._db = db;
            this._mapper = mapper;
            this._notify = notify;
            Categ = new CategoryViewModel();
        }
        public async Task OnGet(string? CategoryId)
        {
            if (CategoryId != null)
            {
                Category CategToEdit = await _db.Category
               .FirstOrDefaultAsync(c => c.CategoryId.ToString() == CategoryId);
                Categ = _mapper.Map<CategoryViewModel>(CategToEdit);
            }
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {  
                Category categToDb = _mapper.Map<Category>(Categ);
                if (Categ.CategoryId == null)
                {
                    // Add operation
                    await _db.Category.AddAsync(categToDb);
                    int res = await _db.SaveChangesAsync();
                    if (res > 0)
                    {
                        _notify.AddSuccessToastMessage("Category created  successfully ");
                        return RedirectToPage("Index");
                    }
                    else
                    {
                        _notify.AddErrorToastMessage("Category not created  successfully ");
                        return Page();
                    }
                }
                else
                {
                    // Update Opeartion 
                    _db.Category.Update(categToDb);
                    await _db.SaveChangesAsync();
                    _notify.AddSuccessToastMessage("Category updated   successfully ");
                    return RedirectToPage("Index");
                }
            }
            return Page();
    }
    public async Task<IActionResult> OnGetDelete(string CategoryId)
    {
        Category? CategToDelete = await _db.Category
            .FirstOrDefaultAsync(c => c.CategoryId.ToString() == CategoryId);
        if (CategToDelete != null)
        {
            _db.Category.Remove(CategToDelete);
            await _db.SaveChangesAsync();
            return RedirectToPage("Index");
        }
        return Page();
    }
}
}
