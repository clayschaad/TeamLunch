using System;

namespace Schaad.TeamLunch.WebUi.Helper
{
    public class SprintHelper
    {
        public static readonly int SprintLength = 14;

        private static readonly int referenceSprint = 213;

        private static readonly DateTime referenceSprintStart = new DateTime(2019, 3, 7);

        public static int GetNextSprint()
        {
            var diff = CetNow() - referenceSprintStart;
            var days = diff.Days / SprintLength;

            if (IsPlanningDay())
            {
                return referenceSprint + days;
            }

            return referenceSprint + days + 1;
        }

        /// <summary>
        /// Wheeltime is Planning Day after 10am
        /// </summary>
        /// <returns></returns>
        public static bool IsWheelTime()
        {
            var isWheelTime = CetNow().Hour >= 10 && IsPlanningDay();
            return isWheelTime;
        }

        private static bool IsPlanningDay()
        {
            var diff = CetNow() - referenceSprintStart;
            var isPlanningDay = diff.Days % SprintLength == 0;
            return isPlanningDay;
        }

        public static DateTime CetNow()
        {
            var now = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("Central European Standard Time"));
            return now;
        }
    }
}