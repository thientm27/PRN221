using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DemoRequestResponse.Pages
{
    public class demoModel : PageModel
    {
       
        private Student student;

        [BindProperty]
        public Student Student { get => student; set => student = value; }

        public void OnGet()
        {
        }
    }

    public class Student
    {
       public string Id { get; set;}
       public string Name { get; set;}
    }
}


