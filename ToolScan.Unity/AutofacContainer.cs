using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ToolScan.Dao;
using ToolScan.IDao;

namespace ToolScan.Unity
{
    public class AutofacContainer
    {
        private Autofac.IContainer container;
        private static AutofacContainer autofacContainer = null;
        public static AutofacContainer GetInstance()
        {
            if (autofacContainer == null)
            {
                Interlocked.CompareExchange<AutofacContainer>(ref autofacContainer, new AutofacContainer(), null);
            }
            return autofacContainer;
        }
        private AutofacContainer() => container = BuildAutofacContainer();
        private Autofac.IContainer BuildAutofacContainer()
        {
            try
            {
                var builder = new ContainerBuilder();
                RegisterTypes(builder);
                var container = builder.Build(Autofac.Builder.ContainerBuildOptions.None);
                return container;
            }catch(Exception ex)
            {
                throw ex;
            }
        }
        private static void RegisterTypes(ContainerBuilder builder)
        {
            builder.RegisterType<ToolDao>().As<IToolDao>();
        }
        public T GetObject<T>() => container.Resolve<T>();
        public T GetObject<T>(string name) => container.ResolveNamed<T>(name);
    }
}
