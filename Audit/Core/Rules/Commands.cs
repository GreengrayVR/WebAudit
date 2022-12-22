using System.Reflection;
using System.Runtime.CompilerServices;

namespace Audit.Core.Rules
{
    public class Commands
    {
        public IEnumerable<IParseRule> Rules { get; set; }

        private readonly string _namespacePath = "Audit.Core.Rules.Command";

        public Commands()
        {
            Rules = GetRules();
        }

        private IEnumerable<IParseRule> GetRules()
        {
            List<IParseRule> objects = new List<IParseRule>();
            foreach (Type type in
                Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.Namespace.StartsWith(_namespacePath))
                .Where(t => t.GetCustomAttribute(typeof(CompilerGeneratedAttribute)) == null))
            {
                objects.Add((IParseRule)Activator.CreateInstance(type, new object[] { }));
            }
            return objects;
        }
    }
}
