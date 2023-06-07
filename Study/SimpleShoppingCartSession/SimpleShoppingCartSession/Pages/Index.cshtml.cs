using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimpleShoppingCartSession.Models;

namespace SimpleShoppingCartSession.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        //public void OnGet()
        //{
        //    HttpContext.Session.SetString("SessionName", "aaa");
        //    HttpContext.Session.SetInt32("SessionYear", 2024);
        //    ViewData["SessionName"] = HttpContext.Session.GetString("SessionName");
        //}

        public List<Product> Products;

        // Su kien xay ra khi yeu cau gui toi la get
        public void OnGet()
        {
            ProductList productModel = new ProductList();
            Products = productModel.findAll();
        }
    }
}
