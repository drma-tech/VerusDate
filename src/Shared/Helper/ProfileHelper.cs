using System;
using VerusDate.Shared.Enum;

namespace VerusDate.Shared.Helper
{
    public static class ProfileHelper
    {
        public enum DistanceType
        {
            Km,
            Mile
        }

        public static int GetAge(this DateTime date)
        {
            int years = DateTime.UtcNow.Year - date.Year;
            if (date.Month > DateTime.UtcNow.Month || date.Month == DateTime.UtcNow.Month && date.Day > DateTime.UtcNow.Day)
                years--;

            return years;
        }

        public static int GetDaysPassed(this DateTime date)
        {
            const int SECOND = 1;
            const int MINUTE = 60 * SECOND;
            const int HOUR = 60 * MINUTE;

            var ts = new TimeSpan(DateTime.UtcNow.Ticks - date.ToLocalTime().Ticks);
            double delta = Math.Abs(ts.TotalSeconds);

            if (delta < 24 * HOUR)
                return 0;

            if (delta < 48 * HOUR)
                return 1;

            return ts.Days;
        }

        /// <summary>
        /// must be in meters
        /// </summary>
        /// <param name="distance"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetDistanceExtension(this double distance, DistanceType type)
        {
            if (distance < 0.5) distance = 0.5;

            return type switch
            {
                DistanceType.Km => $"{distance} km",
                DistanceType.Mile => $"{distance} mile",
                _ => $"null",
            };
        }

        /// <summary>
        /// must be in years
        /// </summary>
        /// <param name="age"></param>
        /// <returns></returns>
        public static string GetAgeExtension(int age)
        {
            return age + " Anos";
        }

        public static double GetDistance(double lat1, double lat2, double lon1, double lon2, DistanceType type)
        {
            // The math module contains a function named toRadians which converts from degrees to radians.
            lon1 = ToRadians(lon1);
            lon2 = ToRadians(lon2);
            lat1 = ToRadians(lat1);
            lat2 = ToRadians(lat2);

            // Haversine formula
            double dlon = lon2 - lon1;
            double dlat = lat2 - lat1;
            double a = Math.Pow(Math.Sin(dlat / 2), 2) +
                       Math.Cos(lat1) * Math.Cos(lat2) *
                       Math.Pow(Math.Sin(dlon / 2), 2);

            double c = 2 * Math.Asin(Math.Sqrt(a));

            double RadiusKm = 6371;
            double RadiusMile = 3956;

            return type switch
            {
                DistanceType.Km => c * RadiusKm,
                DistanceType.Mile => c * RadiusMile,
                _ => 0,
            };
        }

        public static string GetElapsedTime(this DateTime date)
        {
            const int SECOND = 1;
            const int MINUTE = 60 * SECOND;
            const int HOUR = 60 * MINUTE;
            const int DAY = 24 * HOUR;
            const int MONTH = 30 * DAY;

            var ts = new TimeSpan(DateTime.UtcNow.ToLocalTime().Ticks - date.ToLocalTime().Ticks);
            double delta = Math.Abs(ts.TotalSeconds);

            if (delta < 1 * MINUTE)
                return ts.Seconds <= 1 ? "Agora" : ts.Seconds + " segundos atrás";

            if (delta < 2 * MINUTE)
                return "Um minuto atrás";

            if (delta < 45 * MINUTE)
                return ts.Minutes + " minutos atrás";

            if (delta < 90 * MINUTE)
                return "Uma hora atrás";

            if (delta < 24 * HOUR)
                return ts.Hours + " horas atrás";

            if (delta < 48 * HOUR)
                return "ontem";

            if (delta < 30 * DAY)
                return ts.Days + " dias atrás";

            if (delta < 12 * MONTH)
            {
                int months = Convert.ToInt32(Math.Floor((double)ts.Days / 30));
                return months <= 1 ? "Um mês atrás" : months + " meses atrás";
            }
            else
            {
                int years = Convert.ToInt32(Math.Floor((double)ts.Days / 365));
                return years <= 1 ? "Um ano atrás" : years + " anos atrás";
            }
        }

        public static string GetResume(this string text, int count)
        {
            if (text.Length > count)
            {
                return text.Substring(0, count) + "...";
            }
            else
            {
                return text;
            }
        }

        public static Zodiac GetZodiac(this DateTime date)
        {
            if (date.Month == 12)
            {
                if (date.Day < 22)
                    return Zodiac.Sagittarius;
                else
                    return Zodiac.Capricorn;
            }
            else if (date.Month == 1)
            {
                if (date.Day < 20)
                    return Zodiac.Capricorn;
                else
                    return Zodiac.Aquarius;
            }
            else if (date.Month == 2)
            {
                if (date.Day < 19)
                    return Zodiac.Aquarius;
                else
                    return Zodiac.Pisces;
            }
            else if (date.Month == 3)
            {
                if (date.Day < 21)
                    return Zodiac.Pisces;
                else
                    return Zodiac.Aries;
            }
            else if (date.Month == 4)
            {
                if (date.Day < 20)
                    return Zodiac.Aries;
                else
                    return Zodiac.Taurus;
            }
            else if (date.Month == 5)
            {
                if (date.Day < 21)
                    return Zodiac.Taurus;
                else
                    return Zodiac.Gemini;
            }
            else if (date.Month == 6)
            {
                if (date.Day < 21)
                    return Zodiac.Gemini;
                else
                    return Zodiac.Cancer;
            }
            else if (date.Month == 7)
            {
                if (date.Day < 23)
                    return Zodiac.Cancer;
                else
                    return Zodiac.Leo;
            }
            else if (date.Month == 8)
            {
                if (date.Day < 23)
                    return Zodiac.Leo;
                else
                    return Zodiac.Virgo;
            }
            else if (date.Month == 9)
            {
                if (date.Day < 23)
                    return Zodiac.Virgo;
                else
                    return Zodiac.Libra;
            }
            else if (date.Month == 10)
            {
                if (date.Day < 23)
                    return Zodiac.Libra;
                else
                    return Zodiac.Scorpio;
            }
            else if (date.Month == 11)
            {
                if (date.Day < 22)
                    return Zodiac.Scorpio;
                else
                    return Zodiac.Sagittarius;
            }
            else
            {
                throw new InvalidOperationException("GetZodiac");
            }
        }

        private static double ToRadians(double angleIn10thofaDegree)
        {
            // Angle in 10th of a degree
            return (angleIn10thofaDegree * Math.PI) / 180;
        }
    }
}