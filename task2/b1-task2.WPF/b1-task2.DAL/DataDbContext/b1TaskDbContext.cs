using b1_task2.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace b1_task2.DAL.DataDbContext 
{
    public class b1TaskDbContext  : DbContext
    {   
        public DbSet<BalanceSheet> BalanceSheets { get; set; }
        public DbSet<ChartOfAccount> ChartOfAccounts { get; set; }
        public DbSet<BankAccountMovement> BankAccountMovements { get; set; }
        public b1TaskDbContext(DbContextOptions<b1TaskDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            // Seed data for ChartOfAccount
            modelBuilder.Entity<BankAccountMovement>()
                .Property(et => et.BankAccountNumber)
                .ValueGeneratedNever();

            modelBuilder.Entity<ChartOfAccount>().HasData(
                new ChartOfAccount { Id = Guid.NewGuid(), BankAccountNumber = 1, Name = "Денежные средства, драгоценные металлы и межбанковские операции", TypeAccount = "-" },
                new ChartOfAccount { Id = Guid.NewGuid(), BankAccountNumber = 2, Name = "Кредитные и иные активные операции с клиентами", TypeAccount = "-" },
                new ChartOfAccount { Id = Guid.NewGuid(), BankAccountNumber = 3, Name = "Счета по операциям клиентов", TypeAccount = "-" },
                new ChartOfAccount { Id = Guid.NewGuid(), BankAccountNumber = 4, Name = "Ценные бумаги", TypeAccount = "-" },
                new ChartOfAccount { Id = Guid.NewGuid(), BankAccountNumber = 5, Name = "Долгосрочные финансовые вложения в уставные фонды юридических лиц, основные средства и прочее имущество", TypeAccount = "-" },
                new ChartOfAccount { Id = Guid.NewGuid(), BankAccountNumber = 6, Name = "Прочие активы и прочие пассивы", TypeAccount = "-" },
                new ChartOfAccount { Id = Guid.NewGuid(), BankAccountNumber = 7, Name = "Собственный капитал банка", TypeAccount = "-" },
                new ChartOfAccount { Id = Guid.NewGuid(), BankAccountNumber = 8, Name = "Доходы банка", TypeAccount = "-" },
                new ChartOfAccount { Id = Guid.NewGuid(), BankAccountNumber = 9, Name = "Расходы банка", TypeAccount = "-" }
            );
        }

    }
}
