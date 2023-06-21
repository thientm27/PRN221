using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using NToastNotify;
using RazorPagesDemoYoutube.Data;
using RazorPagesDemoYoutube.Models;
using RazorPagesDemoYoutube.Utility;
using RazorPagesDemoYoutube.ViewModels;

namespace RazorPagesDemoYoutube.Pages.Admin.Courses
{
    public class AddOrEditModel : PageModel
    {

        [BindProperty]
        public CourseViewModel CourseViewModel { get; set; }
        public IEnumerable<SelectListItem> CategoryList { get; set; }
        public IEnumerable<SelectListItem> AuthorList { get; set; }
        private readonly CourseDbContext _db;
        private readonly IMapper _mapper;
        private readonly IToastNotification _notify;
        private readonly IWebHostEnvironment _host;

        public AddOrEditModel(CourseDbContext db, IMapper mapper,
            IToastNotification notify,
            IWebHostEnvironment host
            )
        {
            this._db = db;
            this._mapper = mapper;
            this._notify = notify;
            this._host = host;
        }
        public async Task OnGet(string? CourseId)
        {
            if (CourseId != null)
            {
                Course? course = await _db.Course.FirstOrDefaultAsync(c => c.CourseId == Guid.Parse(CourseId));
                CourseViewModel = _mapper.Map<CourseViewModel>(course);
            }

            CategoryList = _db.Category.Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.CategoryId.ToString()
            });

            AuthorList = _db.AppUser.Select(u => new SelectListItem
            {
                Text = u.FullName,
                Value = u.Id
            });
        }


        public async Task<IActionResult> OnPost()
        {
            string webroot = _host.WebRootPath;
            var files = HttpContext.Request.Form.Files;
            string ImageFolder = @"Images\Courses";
            string UploadFolder = Path.Combine(webroot, ImageFolder);

            if (ModelState.IsValid)
            {
                if (CourseViewModel.CourseId == null)
                {
                    // Add Action 
                    Course course = _mapper.Map<Course>(CourseViewModel);
                    if (files.Count > 0)
                    {
                        string fileNewName = await FileManager.CopyFile(files[0], UploadFolder);
                        course.ImageUrl = Path.Combine(ImageFolder, fileNewName);
                    }

                    await _db.Course.AddAsync(course);
                    bool res = await _db.SaveChangesAsync() > 0;
                    if (res)
                    {
                        _notify.AddSuccessToastMessage("Course created successfully");
                        return RedirectToPage("Index");
                    }
                    else
                    {
                        _notify.AddSuccessToastMessage("Course not created !!!");
                    }
                }
                else
                {
                    // Update Action 
                    Course course = _mapper.Map<Course>(CourseViewModel);
                    if (files.Count > 0)
                    {
                        // delete old image
                        if (CourseViewModel.ImageUrl != null)
                        {
                            var oldImage = Path.Combine(_host.WebRootPath, CourseViewModel.ImageUrl);
                            FileManager.Deletefile(oldImage);
                        }
                        String newFileImage = await FileManager.CopyFile(files[0], UploadFolder);
                        course.ImageUrl = Path.Combine(ImageFolder, newFileImage);
                    }

                    _db.Course.Update(course);
                    bool res = await _db.SaveChangesAsync() > 0;
                    if (res)
                    {
                        _notify.AddSuccessToastMessage("Course updated successfully");
                        return RedirectToPage("Index");
                    }
                    else
                    {
                        _notify.AddSuccessToastMessage("Course not updated  !!!");
                    }
                }
            }
            return Page();
        }
        public async Task<IActionResult> OnGetDelete(string CourseId)
        {
            Course course = await _db.Course.FirstOrDefaultAsync(c => c.CourseId == Guid.Parse(CourseId));
            if (course != null)
            {
                _db.Course.Remove(course);
                if (await _db.SaveChangesAsync() > 0)
                {
                    string _webroot = _host.WebRootPath;
                    string imageFile = Path.Combine(_webroot, course.ImageUrl);
                    FileManager.Deletefile(imageFile);
                    // return RedirectToPage("Index");
                    return new JsonResult(new { msg = "ok" });
                }
                else
                {
                    return new JsonResult(new { msg = "no" });
                }
            }
            return new JsonResult(new { msg = "no" });
        }

        public async Task<IActionResult> OnGetPublish(string CourseId, string PublishDate)
        {
            Course course = await _db.Course.FirstOrDefaultAsync(c => c.CourseId == Guid.Parse(CourseId));
            if (course != null)
            {
                course.PublishedDate = DateTime.Parse(PublishDate);
                await _db.SaveChangesAsync();
                return new JsonResult(new { msg = "ok" });
            }
            return new JsonResult(new { msg = "no" });
        }
    }
}
