using Furion;
using System.Reflection;

namespace XsoaApi.Web.Entry
{
    public class SingleFilePublish : ISingleFilePublish
    {
        public Assembly[] IncludeAssemblies()
        {
            return Array.Empty<Assembly>();
        }

        public string[] IncludeAssemblyNames()
        {
            return new[]
            {
                "XsoaApi.Application",
                "XsoaApi.Core",
                "XsoaApi.Web.Core"
            };
        }
    }
}