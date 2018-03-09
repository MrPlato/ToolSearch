using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolScan.Models;
using ToolSearch.Models;

namespace ToolSearch
{
    public class AutoMapperConfiguration
    {
        public static void Config()
        {
            Mapper.Initialize(x =>
            {
                x.CreateMap<ToolsEntity, ToolsDto>().ForMember(u => u.Status, e => e.MapFrom(s => (MetalStatus)s.Status));
                x.CreateMap<ToolsDto, ToolsDto>().ForMember(u => u.Status, e => e.MapFrom(s => (byte)s.Status));
                x.CreateMap<ToolLogEntity,ToolLogDto>().ForMember(u => u.Status, e => e.MapFrom(s => (MetalStatus)s.Status));
                x.CreateMap<ToolLogDto,ToolLogEntity>().ForMember(u => u.Status, e => e.MapFrom(s => (byte)s.Status));
            });
        }
    }
}
