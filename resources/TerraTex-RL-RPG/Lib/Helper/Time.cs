using System;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;

namespace TerraTex_RL_RPG.Lib.Helper
{
    public class TimeHelperException : Exception
    {
        public TimeHelperException(string msg) : base(msg)
        {
        }

        protected TimeHelperException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }

    public static class Timehelper
    {
        /// <summary>
        ///  Converts a timestring to a TimeSpan<br/>
        /// A Timestring contains a numbers followed by a letter. Example: 12h10m5s<br/>
        /// - Possible Letters: <br/>
        /// <li>d - days</li>
        /// <li>h - hours</li>
        /// <li>m - minutes</li>
        /// <li>s - seconds</li>
        /// </summary>
        /// <param name="timestring"></param>
        /// <exception cref="TimeHelperException">TimeHelperException</exception>
        /// <returns></returns>
        public static TimeSpan GetTimeSpanFromTimeString(string timestring)
        {
            if (ValidateTimeString(timestring))
            {
                Regex splitRegex = new Regex("(?<time>[0-9]{1,})(?<unit>[dhms])", RegexOptions.IgnoreCase);
                MatchCollection splits = splitRegex.Matches(timestring);

                int days = 0;
                int hours = 0;
                int minutes = 0;
                int seconds = 0;
                foreach (Match match in splits)
                {
                    switch (match.Groups["unit"].ToString().ToLower())
                    {
                        case "d":
                            days += Int32.Parse(match.Groups["time"].ToString());
                            break;
                        case "h":
                            hours += Int32.Parse(match.Groups["time"].ToString());
                            break;
                        case "m":
                            minutes += Int32.Parse(match.Groups["time"].ToString());
                            break;
                        case "s":
                            seconds += Int32.Parse(match.Groups["time"].ToString());
                            break;
                    }
                }

                return new TimeSpan(days, hours, minutes, seconds);
            }
            throw new TimeHelperException(timestring + " is not a valid timestring!");
        }

        private static bool ValidateTimeString(string timestring)
        {
            Regex regex = new Regex("^([0-9]{1,}[dhms]){1,}$");
            return regex.IsMatch(timestring);
        }

    }
}