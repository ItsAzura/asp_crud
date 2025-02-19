﻿using learn_crud.Models;
using learn_crud.Services;
using Microsoft.AspNetCore.Mvc;

namespace learn_crud.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext context; //DbContext để truy cập và thao tác với database
        private readonly IWebHostEnvironment environment; //Để xác định nơi lưu trữ file
        public ProductController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            this.context = context; 
            this.environment = environment;
        }

        //Action trả về view chứa danh sách sản phẩm
        public IActionResult Index()
        {
            //Lấy danh sách sản phẩm từ database và sắp xếp theo Id giảm dần
            var products = context.Products.OrderByDescending(p => p.Id ).ToList();

            //Trả về view và truyền danh sách sản phẩm vào view
            return View(products);
        }

         //Action trả về view để tạo mới sản phẩm
        public IActionResult Create()
        {
            return View();
        }

        //Action xử lý request post khi người dùng tạo mới sản phẩm
        [HttpPost] //Action này chỉ xử lý request post
        public IActionResult Create(ProductDto productDto)
        {
            //Kiểm tra user có tải ảnh lên không?
            if(productDto.ImageFile == null)
            {
                ModelState.AddModelError("ImageFile", "The image is required");
            }

            //Kiểm tra dữ liệu nhập vào có hợp lệ không?
            if (!ModelState.IsValid)
            {
                return View(productDto);
            }

            //Tạo file name
            string newFileName = DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(productDto.ImageFile!.FileName);

            //Tạo đường dẫn lưu file wwwroot/products/fileName
            string imagePath = environment.WebRootPath + "/products/" + newFileName;

            //Lưu file vào đường dẫn vừa tạo
            using(var stream = System.IO.File.Create(imagePath))
            {
                productDto.ImageFile.CopyTo(stream);
            }

            //Tạo đối tượng Product từ ProductDto
            Product product = new Product()
            {
                Name = productDto.Name,
                Brand = productDto.Brand,
                Category = productDto.Category,
                Price = productDto.Price,
                Description = productDto.Description,
                ImageFileName = newFileName,
                CreateDate = DateTime.Now
            };

            //Thêm vào database
            context.Products.Add(product);
            //Lưu thay đổi vào database
            context.SaveChanges();

            //Chuyển hướng sau khi thêm thành công
            return RedirectToAction("Index", "Product");
        }
    }
}
