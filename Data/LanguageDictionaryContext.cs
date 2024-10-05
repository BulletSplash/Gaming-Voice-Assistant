using Gaming_Voice_Assistant.Models;
using Microsoft.EntityFrameworkCore;

namespace Gaming_Voice_Assistant.Data
{
    public class LanguageDictionaryContext : DbContext
    {
        public DbSet<Command> Commands { get; set; } = null!;

        //Release_Context
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer($@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\LB\GVA\Command_Dictionary.mdf"";Integrated Security=True");

        //Debug_Context
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\blasc\source\repos\Gaming Voice Assistant\Data\Command_Dictionary.mdf"";Integrated Security=True");
    }
}
