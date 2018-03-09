using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolScan.Models.Configuration
{
    public class ToolLogConfig:EntityTypeConfiguration<ToolLogEntity>
    {
        public ToolLogConfig()
        {
            ToTable("ToolLog");
            HasKey(item => item.Id);
            Property(item => item.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(item => item.ToolId).IsRequired();
            Property(item => item.Status).IsRequired();
            HasRequired(item => item.Tools).WithMany(item => item.ToolLog).HasForeignKey(item => item.ToolId);
        }
    }
}
