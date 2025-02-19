using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace learn_crud.Models
{
    //Tạo 1 Dto class để validate dữ liệu trước khi thêm vào database
    public class ProductDto
    {
        [Required ,MaxLength(100)]
        public string Name { get; set; } = "";
        [Required, MaxLength(100)]
        public string Brand { get; set; } = "";
        [Required, MaxLength(100)]
        public string Category { get; set; } = "";
        [Required]
        public decimal Price { get; set; } = 0;
        [Required]
        public string Description { get; set; } = "";
        public IFormFile? ImageFile { get; set; }
    }
}
