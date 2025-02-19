using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace learn_crud.Models
{
    //Model class để tạo bảng Product trong database
    public class Product
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; } = "";
        [MaxLength(100)]
        public string Brand { get; set; } = "";
        [MaxLength(100)]
        public string Category { get; set; } = "";
        [Precision(16, 2)]
        public decimal Price { get; set; } = 0;
        [MaxLength(500)]
        public string Description { get; set; } = "";
        [MaxLength(100)]
        public string ImageFileName { get; set;} = "";
        public DateTime CreateDate { get; set; } = DateTime.Now;
    }
}
