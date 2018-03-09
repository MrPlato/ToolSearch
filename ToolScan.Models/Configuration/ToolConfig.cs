using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolScan.Models.Configuration
{
    public class ToolConfig:EntityTypeConfiguration<ToolsEntity>
    {
        public ToolConfig()
        {
            ToTable("Tool");
            HasKey(item => item.Id);
            Property(item => item.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
        }
    }
}
