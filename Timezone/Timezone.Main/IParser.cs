using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timezone.Main
{
    interface IParser
    {
        string DisplayTime(string time, string location);
    }
}
