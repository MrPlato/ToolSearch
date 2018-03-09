using System.Data.Entity;

namespace ToolScan.Models
{
    public class InitData
    {
        public static void init()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ToolContext,Configuration.Configuration>());
        }
    }
}
