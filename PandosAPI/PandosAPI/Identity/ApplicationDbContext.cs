// using Duende.IdentityServer.EntityFramework.Options; // ?????????
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace PandosAPI.Identity
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
