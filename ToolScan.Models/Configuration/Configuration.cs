using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolScan.Models.Configuration
{
    internal sealed class Configuration:DbMigrationsConfiguration<ToolContext>
    {
        private readonly DateTime now = new DateTime(2018, 3, 3, 12, 0, 0);
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }
        protected override void Seed(ToolContext context)
        {
            base.Seed(context);
        }
    }
}
