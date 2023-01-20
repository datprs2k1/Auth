using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace POST.Data
{
    public class PostContext : IdentityDbContext<ApplicationUser>
    {
        public PostContext(DbContextOptions<PostContext> options) : base(options) { }
    }
}
