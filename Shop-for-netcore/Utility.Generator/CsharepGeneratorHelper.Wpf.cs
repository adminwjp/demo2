using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Generator
{
    public partial class CsharepGeneratorHelper
    {
        public static Dictionary<Type, string> WpfStringCodes = new Dictionary<Type, string>(100);
        public static string WpfStringCode = string.Empty;

        public static void EntityToWpf()
        {
            if (Classes.Count > 0)
            {
                var builder = StringPools.Get();
                foreach (var it in Classes)
                {
                    if (it.Value.Count > 0)
                    {
                        foreach (var pro in it.Value)
                        {

                        }
                    }
                }
                StringPools.Release(builder);
            }
        }
    }
}
