using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timezone.Main
{
    interface IReader
    {
        List<Tuple<string, string>> Read(string _contents);
    }
}
