using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Globalization;

namespace DocitcareWebApp.Utilities
{
    public static class ConvetDates
    {
        public static string ConvertToMMDDYYYYFormat(string date)
        {
           var convertedDate= DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture)
                          .ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
            return convertedDate;
        }

        public static DateTime ConvertStringToDate(string date)
        {
            var convertedDate = DateTime.Parse(date);
            return convertedDate;
        }

        public static int SlotCreationGetDays(string startDate,string endDate)
        {
            var convertedStartDate = ConvertToMMDDYYYYFormat(startDate);
            var convertedEndDate = ConvertToMMDDYYYYFormat(endDate);
           var converteddateFormatStartDate = ConvertStringToDate(convertedStartDate);
            var converteddateFormatEndtDate = ConvertStringToDate(convertedEndDate);
            TimeSpan totalDays = (converteddateFormatEndtDate - converteddateFormatStartDate);
            int days = totalDays.Days;
            return days;
        }

        public static DateTime SlotCreationConvertStringToDateTimeMMDDYYFormat(string date)
        {
            var convertedToMonthFormat = ConvertToMMDDYYYYFormat(date);
            var convertToDate = ConvertStringToDate(convertedToMonthFormat);
            return convertToDate;
        }

        public static List<TimeSpan> SlotCreationGetTimeSlots(TimeSpan startTime, TimeSpan endTime, int duration)
        {
            List<TimeSpan> timeSlots = new List<TimeSpan>();
            timeSlots.Add(startTime);
            TimeSpan newSlot = startTime;
            TimeSpan slotDuration = new TimeSpan(0,duration,0);
            while(true)
            {
                if (newSlot < endTime)
                {
                    newSlot = newSlot.Add(slotDuration);
                    timeSlots.Add(newSlot);

                }
                else
                {
                    break;
                }

            }
            

            return timeSlots;

        }
    }
}