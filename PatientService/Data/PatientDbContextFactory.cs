using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace PatientService.Data
{
    public class PatientDbContextFactory : IDesignTimeDbContextFactory<PatientDbContext>
    {
        public PatientDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<PatientDbContext>();

            optionsBuilder.UseSqlServer(
                "Server=tcp:hospitalserver.database.windows.net,1433;Initial Catalog=patientdb;Persist Security Info=False;User ID=hospitaladmin;Password=admin@123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
            );

            return new PatientDbContext(optionsBuilder.Options);
        }
    }
}
