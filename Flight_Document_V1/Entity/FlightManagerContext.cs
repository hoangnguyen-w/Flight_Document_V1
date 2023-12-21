using Microsoft.EntityFrameworkCore;

namespace Flight_Document_V1.Entity
#nullable disable
{
    public class FlightManagerContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Document> Documents { get; set; }

        public DbSet<DocumentType> DocumentTypes { get; set; }
         
        public DbSet<Flight> Flights { get; set; }

        public DbSet<Group> Groups { get; set; }

        public DbSet<GroupPermission> GroupPermissions { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Setting> Settings { get; set; }

        public DbSet<History> Histories { get; set; }

        public FlightManagerContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Hàm này để ép dữ liệu mặc định
            this.SeedRoles(modelBuilder);
            this.SeedGroup(modelBuilder);
            this.SeedAccount(modelBuilder);
            this.SeedSetting(modelBuilder);
            this.SeedDocumentType(modelBuilder);
        }

        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<Role>().HasData(new Role()
            {
                RoleID = 1,
                RoleName = "Admin"
            });
            builder.Entity<Role>().HasData(new Role()
            {
                RoleID = 2,
                RoleName = "Staff"
            });
            builder.Entity<Role>().HasData(new Role()
            {
                RoleID = 3,
                RoleName = "Pilot"
            });
            builder.Entity<Role>().HasData(new Role()
            {
                RoleID = 4,
                RoleName = "Stewardess"
            });
        }


        private void SeedGroup(ModelBuilder builder)
        {
            builder.Entity<Group>().HasData(new Group()
            {
                GroupID = 1,
                GroupName = "GroupAdmin",
                Creator = "DEV",
                CreateDateGroup = DateTime.Now,
                Note = "Đây là Group đầu tiên tạo ra cho Database"
            });
        }

        private void SeedAccount(ModelBuilder builder)
        {
            builder.Entity<Account>().HasData(new Account()
            {
                AccountID = 1,
                AccountName = "Admin",
                Password = "admin123",
                Email = "Admin@vietjetair.com",
                StatusTerminate = true,
                RoleID = 1,
            });
        }

        private void SeedSetting(ModelBuilder builder)
        {
            builder.Entity<Setting>().HasData(new Setting()
            {
                Id = 1,
                StatusCapcha = false,
                AccountID = 1,
            });

        }

        private void SeedDocumentType(ModelBuilder builder)
        {
            builder.Entity<DocumentType>().HasData(new DocumentType()
            {
                DocumentTypeID = 1,
                DocumentTypeName = "Load Summary"
            });

            builder.Entity<DocumentType>().HasData(new DocumentType()
            {
                DocumentTypeID = 2,
                DocumentTypeName = "Summary"
            });
            builder.Entity<DocumentType>().HasData(new DocumentType()
            {
                DocumentTypeID = 3,
                DocumentTypeName = "Loading Instruction"
            });
        }
    }
}

