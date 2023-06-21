using AutoMapper;
using RazorPagesDemoYoutube.Models;
using RazorPagesDemoYoutube.ViewModels;

namespace RazorPagesDemoYoutube.Utility
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryViewModel>().ReverseMap();
            CreateMap<AppUser, UserInputVeiwModel>().ReverseMap();
            CreateMap<Course, CourseViewModel>().ReverseMap();  
        }
    }
}
