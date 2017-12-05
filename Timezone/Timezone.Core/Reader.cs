using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Timezone.Core.Interfaces;

namespace Timezone.Core
{
	public class Reader : IReader, IDisposable
    {
        public List<Tuple<string, string>> Read(string _contents)
        {
            List<Tuple<string, string>> lReturn = new List<Tuple<string, string>>();


            if (!String.IsNullOrEmpty(_contents))
            {
                string[] fileParts = _contents.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string part in fileParts)
                {
                    string[] sLineParts = part.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    Tuple<string, string> timeZone = new Tuple<string, string>(sLineParts.First(), sLineParts.Last());

                    lReturn.Add(timeZone);
                }
            }



            return lReturn;
        }
        public void Dispose()
        {
        }
    }
}
