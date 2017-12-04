using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timezone.Main
{
    class Parser : IParser
    {


        /// <summary>
        /// Returns the timezone name for the provided location
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        private string GetTimeZoneName(string location)
        {
            StringBuilder _result = new StringBuilder();

            switch (location)
            {
                case "Amsterdam":
                    _result.Append("W. Europe Standard Time");
                    break;
                case "Minsk":
                    _result.Append("Russian Standard Time");
                    break;
                case "Samoa":
                    _result.Append("UTC-11");
                    break;
                case "London":
                    _result.Append("GMT Standard Time");
                    break;
                case "Dublin":
                    _result.Append("GMT Standard Time");
                    break;
                case "Hawaii":
                    _result.Append("Hawaiian Standard Time");
                    break;
                case "Alaska":
                    _result.Append("Alaskan Standard Time");
                    break;
                case "Arizona":
                    _result.Append("Pacific Standard Time");
                    break;
                default:
                    _result.Append(string.Empty);
                    break;
            }

            return _result.ToString();
        }


        /// <summary>
        /// Returns DateTime object based on todays date and the supplied time
        /// </summary>
        /// <param name="time">Time string in format HH:MM</param>
        /// <returns></returns>
        private DateTime? GetDateTime(string time)
        {
            String[] _timeParts = time.Split(':');


            if (_timeParts.Length == 2)
            {
                int _hour, _minute = 0;

                if (int.TryParse(_timeParts[0], out _hour) && int.TryParse(_timeParts[1], out _minute))
                {
                    DateTime _newDateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, _hour, _minute, 0);

                    return _newDateTime;
                }

            }

            return null;

        }


        /// <summary>
        /// Return a string containing the UK date and converted date for the selected location
        /// </summary>
        /// <param name="time"></param>
        /// <param name="timezone"></param>
        /// <returns></returns>
        public string DisplayTime(string time, string location)
        {
            string _timeZoneName = GetTimeZoneName(location);

            if (!String.IsNullOrEmpty(_timeZoneName))
            {
                TimeZoneInfo _timezone = TimeZoneInfo.FindSystemTimeZoneById(_timeZoneName);


                if (_timezone != null)
                {
                    DateTime? _dateTime = GetDateTime(time);
                    if (_dateTime != null)
                    {
                        DateTime _ukDateTime = (DateTime)_dateTime;
                        DateTime _convertedDateTime = TimeZoneInfo.ConvertTime(_ukDateTime, _timezone);


                        string _result = $"The time in the UK is {_ukDateTime.Hour}:{_ukDateTime.Minute} and the time in {_timeZoneName} is {_convertedDateTime.Hour}:{_convertedDateTime.Minute}";

                        return _result;
                    }
                }

            }


            return null;
        }
    }
}
