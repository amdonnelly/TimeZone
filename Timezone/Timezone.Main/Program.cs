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
    internal class Program
    {
        private static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private static void Main(string[] args)
        {
            //Fetch contents of timezone embedded file
            string timeZoneFileContents = ReadTextFileContents("TimezoneFile");

            //Read entries from text file and populate list
            List<Tuple<string, string>> lTimes = GetLocationTimes(timeZoneFileContents.ToString());

            List<string> results = ParseResults(lTimes);

            DisplayResults(results);

            Console.ReadKey();
        }

        /// <summary>
        /// Read contents from text file resource
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private static string ReadTextFileContents(string fileName)
        {
            StringBuilder timeZoneFileContents = new StringBuilder();
            try
            {
                timeZoneFileContents.Append(Timezone.Main.Properties.Resources.ResourceManager.GetObject(fileName));
            }
            catch (Exception ex)
            {
                Logger.Error("There was an error reading the Timezone file : " + ex.Message);
            }

            return timeZoneFileContents.ToString();
        }

        /// <summary>
        /// Extract timezone entries into a list
        /// </summary>
        /// <param name="timeZoneFileContents"></param>
        /// <returns></returns>
        private static List<Tuple<string, string>> GetLocationTimes(string timeZoneFileContents)
        {
            List<Tuple<string, string>> lTimes = new List<Tuple<string, string>>();

            if (!String.IsNullOrEmpty(timeZoneFileContents))
            {
                using (Reader fileReader = new Reader())
                {
                    try
                    {
                        lTimes = fileReader.Read<List<Tuple<string, string>>>(timeZoneFileContents.ToString());
                    }
                    catch (Exception ex)
                    {
                        Logger.Error("There was an error reading the Timezone data : " + ex.Message);
                    }
                }
            }

            return lTimes;
        }

        /// <summary>
        /// Create result string for each timezone entry
        /// </summary>
        /// <param name="lTimes"></param>
        /// <returns></returns>
        private static List<string> ParseResults(List<Tuple<string, string>> lTimes)
        {
            List<string> results = new List<string>();

            if (lTimes.Count > 0)
            {
                Parser timeZoneParser = new Parser();

                //iterate through list and generate result for each entry
                foreach (Tuple<string, string> _timeZone in lTimes)
                {
                    try
                    {
                        string _result = timeZoneParser.DisplayTime(_timeZone.Item1, _timeZone.Item2);

                        if (!String.IsNullOrEmpty(_result))
                        {
                            results.Add(_result);
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.Error("There was an error parsing the results : " + ex.Message);
                    }
                }
            }

            return results;
        }

        private static void DisplayResults(List<string> results)
        {
            if (results.Count > 0)
            {
                foreach (string result in results)
                {
                    Console.WriteLine(result);
                }
            }
            else
            {
                Console.WriteLine("No results to display");
            }
        }
    }
}