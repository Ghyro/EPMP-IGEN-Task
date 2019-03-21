using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter
{
    /// <summary>
    /// Finds the degree angle of the values of the corresponding NN: MM, where HH is the hour, MM is the minutes.
    /// </summary>
    public class TimeConvert
    {
        #region Entities
        /// <summary>
        /// Number of degrees in one hour.
        /// </summary>
        private const int ONE_HOUR_DEGREES = 30;

        /// <summary>
        /// Number of minutes in one hour.
        /// </summary>
        private const int MINUTES_IN_HOUR = 60;

        /// <summary>
        /// Number of degrees of a circle.
        /// </summary>
        private const int DEGREES_OF_CIRCLE = 360;

        /// <summary>
        /// Number of hours.
        /// </summary>
        private static double hour = 0;

        /// <summary>
        /// Number of minutes.
        /// </summary>
        private static double minutes = 0;
        #endregion

        #region Method
        /// <summary>
        /// Finds the degree angle of time.
        /// </summary>
        /// <param name="time">Input time.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="time"/> if equals NULL or empty.
        /// </exception>
        /// <exception cref="FormatException">
        /// <paramref name="time"/> if doesn't have ':'.
        /// </exception>
        /// <returns>Degrees</returns>
        public double Convert(string time)
        {
            #region ServiceValid
            if (string.IsNullOrEmpty(time))
            {
                throw new ArgumentNullException($"{nameof(time)} cannot be as NULL or empty");
            }

            if (time[1] == ':')
            {
                hour = int.Parse(time.Substring(0, 1));
                minutes = int.Parse(time.Substring(2));
            }
            else if (time[2] == ':')
            {
                hour = int.Parse(time.Substring(0, 2));
                minutes = int.Parse(time.Substring(3));
            }
            else
            {
                throw new FormatException($"{nameof(time)} must have element for TimeFormat - ':'");
            }

            isMatched(hour, minutes);
            hour = minutes == 60 ? ++hour : hour;
            hour = HourFormatCheck(hour);
            minutes = MinutesFormatCheck(minutes);
            #endregion

            #region Algorithm
            double degreesForHour = hour * ONE_HOUR_DEGREES;
            double degreesForTime = ONE_HOUR_DEGREES * minutes / MINUTES_IN_HOUR;
            double arrowPosition = degreesForHour + degreesForTime;
            double degreesMinuteArrow = DEGREES_OF_CIRCLE * minutes / MINUTES_IN_HOUR;
            double degrees = arrowPosition - degreesMinuteArrow;
            double result = degrees < 0 ? degrees * -1 : degrees;
            #endregion

            return result;
            
        }
        #endregion

        #region Checkers
        /// <summary>
        /// Checks for valid input.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="hour"/> if less than 0 and bigger than 24.
        /// <paramref name="minutes"/> if less than 0 and bigger than 59.
        /// </exception>
        /// <param name="hour">Input hour.</param>
        /// <param name="minutes">Input minutes.</param>
        public static void isMatched(double hour, double minutes)
        {
            if (hour < 0 || hour > 24)
            {
                throw new ArgumentOutOfRangeException($"{nameof(hour)} must not be less than 0 and bigger than 24.");
            }
            else if (minutes < 0 || minutes > 60)
            {
                throw new ArgumentOutOfRangeException($"{nameof(minutes)} must not be less than 0 and bigger than 24.");
            }
        }

        /// <summary>
        /// Converts hour to 12-hour clock format.
        /// </summary>
        /// <param name="hour">Input hour.</param>
        /// <returns>Hour in 12-hour clock format.</returns>
        public static double HourFormatCheck(double hour)
        {
            double x = hour;

            switch (x)
            {
                case 13: return 1;
                case 14: return 2;
                case 15: return 3;
                case 16: return 4;
                case 17: return 5;
                case 18: return 6;
                case 19: return 7;
                case 20: return 8;
                case 21: return 9;
                case 22: return 10;
                case 23: return 11;
                case 24: return 12;
                case 0:  goto case 24;
                default: break;                
            }

            return x;
        }

        /// <summary>
        /// Checks for the presence of the sixtieth minute.
        /// </summary>
        /// <param name="minutes">Input minutes.</param>
        /// <returns>Minutes.</returns>
        public static double MinutesFormatCheck(double minutes)
        {
            double x = minutes;

            switch (x)
            {
                case 60: return 0;
                default: break;
            }

            return x;
        }
        #endregion
    }
}
