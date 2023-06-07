using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using SimpleShoppingCartSession.Models;
using System.Linq;

namespace SimpleShoppingCartSession.Pages
{
    public class CartModel : PageModel
    {
        public List<Item> cart { get; set; }
        public double Total { get; set; }

        public void OnGet()
        {
            cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            Total = cart.Sum(i => i.Product.Price * i.Quantity);
        }

        // Khi nhận được on get "buynow"
        public IActionResult OnGetBuyNow(string id)
        {
            var productModel = new ProductList(); // khởi tạo list chứa product
            cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart"); // lấy từ session xem có cart cũ không
            if (cart == null) // trường hợp ếu có cart cũ
            {
                cart = new List<Item>(); // tạo cart mới
                cart.Add(new Item // thêm mới
                {
                    Product = productModel.find(id),
                    Quantity = 1
                });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart); // gán gược vào 
            }
            else // có sẵn cart rồi
            {
                int index = Exists(cart, id); // check xem đã có chưa
                if (index == -1) // không có thêm mới
                {
                    cart.Add(new Item
                    {
                        Product = productModel.find(id),
                        Quantity = 1
                    });
                }
                else
                {
                    cart[index].Quantity++;
                }

                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart); // lưu lại
            }

            return RedirectToPage("Cart"); // reload trang
        }

        // Khi nhận được on get "delete"
        public IActionResult OnGetDelete(string id)
        {
            cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            int index = Exists(cart, id);
            cart.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToPage("Cart");
        }

        public IActionResult OnPostUpdate(int[] quantities)
        {
            cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            for (var i = 0; i < cart.Count; i++)
            {
                cart[i].Quantity = quantities[i];
            }

            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToPage("Cart"); // REload
        }

        private int Exists(List<Item> cart, string id)
        {
            for (var i = 0; i < cart.Count; i++)
            {
                if (cart[i].Product.Id == id)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}