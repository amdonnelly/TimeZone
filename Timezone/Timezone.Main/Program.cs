using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using log4net;

using Timezone.Core;
using Timezone.Core.Interfaces;

namespace Timezone.Main
{
    class Program
    {
        private static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        static void Main(string[] args)
        {
            List<Tuple<string, string>> lTimes = new List<Tuple<string, string>>(); ;

            //Fetch contents of timezone embedded file
            StringBuilder _timeZoneFileContents = new StringBuilder();
            try
            {
                _timeZoneFileContents.Append(Timezone.Main.Properties.Resources.ResourceManager.GetObject("TimezoneFile"));
            }
            catch(Exception ex)
            {
                Logger.Error("There was an error reading the Timezone file : " + ex.Message);
            }
            

            //Read entries from text file and populate list
            if (_timeZoneFileContents.Length > 0)
            {
                using (Reader fileReader = new Reader())
                {
                    lTimes = fileReader.Read(_timeZoneFileContents.ToString());
                }
            }





            if (lTimes.Count>0)
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
