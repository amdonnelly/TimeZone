using System;
using System.Collections.Generic;
using System.Linq;

using Timezone.Core.Interfaces;

namespace Timezone.Core
{
    public sealed class Reader : IReader, IDisposable
    {
        public T Read<T>(string _contents) where T : IList<Tuple<string, string>>, new()
        {
            T lReturn = new T();

            if (!String.IsNullOrEmpty(_contents))
            {
                string[] fileParts = _contents.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string part in fileParts)
                {
                    string[] sLineParts = part.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    Tuple<string, string> timeZone = new Tuple<string, string>(sLineParts.First().Trim(), sLineParts.Last().Trim());

                    lReturn.Add(timeZone);
                }
            }

            return lReturn;
        }

        //TODO - find out why this implements IDisposable, seems unnecessary
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
        }
    }
}