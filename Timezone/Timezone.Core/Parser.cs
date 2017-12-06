using log4net;
using System;
using System.Text;
using Timezone.Core.Interfaces;

namespace Timezone.Core
{
    public class Parser : IParser
    {
        private static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Returns the timezone name for the provided location
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        private string GetTimeZoneName(string location)
        {
            StringBuilder result = new StringBuilder();

            switch (location)
            {
                case "Amsterdam":
                    result.Append("W. Europe Standard Time");
                    break;

                case "Minsk":
                    result.Append("Russian Standard Time");
                    break;

                case "Samoa":
                    result.Append("Samoa Standard Time");
                    break;

                case "London":
                    result.Append("GMT Standard Time");
                    break;

                case "Dublin":
                    result.Append("GMT Standard Time");
                    break;

                case "Hawaii":
                    result.Append("Hawaiian Standard Time");
                    break;

                case "Alaska":
                    result.Append("Alaskan Standard Time");
                    break;

                case "Arizona":
                    result.Append("US Mountain Standard Time");
                    break;

                default:
                    result.Append(string.Empty);
                    break;
            }

            if (result.Length == 0)
            {
                Logger.Info("No timezone name for " + location);
            }

            return result.ToString();
        }

        /// <summary>
        /// Returns DateTime object based on todays date and the supplied time
        /// </summary>
        /// <param name="time">Time string in format HH:MM</param>
        /// <returns></returns>
        private DateTime? GetDateTime(string time)
        {
            String[] timeParts = time.Split(':');

            if (timeParts.Length == 2)
            {
                int _hour, _minute = 0;

                if (int.TryParse(timeParts[0], out _hour) && int.TryParse(timeParts[1], out _minute))
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
            string timeZoneName = GetTimeZoneName(location);

            if (!String.IsNullOrEmpty(timeZoneName))
            {
                TimeZoneInfo _timezone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneName);

                if (_timezone != null)
                {
                    DateTime? dateTime = GetDateTime(time);
                    if (dateTime != null)
                    {
                        DateTime ukDateTime = (DateTime)dateTime;
                        DateTime convertedDateTime = TimeZoneInfo.ConvertTime(ukDateTime, _timezone);

                        string result = $"The time in the UK is {ukDateTime.ToString("HH:mm")} and the time in {location} is {convertedDateTime.ToString("HH:mm")}";

                        return result;
                    }
                }
            }

            return null;
        }
    }
}