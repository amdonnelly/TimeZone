using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using log4net;

namespace Timezone.Main
{
    class Program
    {
        private static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        static void Main(string[] args)
        {
            List<Tuple<string, string>> lTimes;

            //Fetch contents of timezone embedded file
            string _timeZoneFileContents = Timezone.Main.Properties.Resources.TimezoneFile;

            //Read entries from text file and populate list
            using (Reader fileReader = new Reader())
            {
                lTimes = fileReader.Read(_timeZoneFileContents);
            }


            
            if (lTimes != null)
            {
                Parser timeZoneParser = new Parser();

                //iterate through list and generate result for each entry
                foreach (Tuple<string, string> _timeZone in lTimes)
                {
                    string _result = timeZoneParser.DisplayTime(_timeZone.Item1, _timeZone.Item2);

                    if (!String.IsNullOrEmpty(_result))
                    {
                        Console.WriteLine(_result);
                    }

                }
            }


            Console.ReadKey();
        }
    }
}
