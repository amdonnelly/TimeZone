using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timezone.Core.Interfaces
{
    interface IReader
    {
        T Read<T>(string _contents) where T : IList<Tuple<string, string>>, new();
    }
}
