using Microsoft.EntityFrameworkCore;

namespace learn_crud.Services
{
    //ApplicationDbContext giúp Asp.net core giao tiếp với database thông qua Entity Framework Core
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options): base(options)
        {

        }
       
    }
}
