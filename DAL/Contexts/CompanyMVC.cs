using DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL.Contexts
{
	public class CompanyMVC : IdentityDbContext<ApplicationUser>
	{
		public CompanyMVC(DbContextOptions<CompanyMVC> options) : base(options)
		{ }

		//protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		//{
		//    optionsBuilder.UseSqlServer("Server = LAPTOP-1TU092KA\\SQLEXPRESS ; Database = CompanyMVC ; Trusted_Connection = true");
		//}

		public DbSet<Department> Department { get; set; }

		public DbSet<Empolyee> Empolyee { get; set; }
	}
}