using System.Runtime.InteropServices.JavaScript;

namespace FULLSTACKFURY.EduSpace.API.EventsScheduling.Domain.Model.ValueObjects
{
    public record ReservationDate
    {
        public DateTime Start { get; init; }
        public DateTime End { get; init; }

        public ReservationDate(DateTime start, DateTime end)
        {

            if (Equals(start, end)) throw new ArgumentException("Start and end date cannot be the same");
            if((DateTime.Compare(start,end)) > 0) throw new ArgumentException("Start date cannot be greater than end date");
            if((DateTime.Compare(end, start)) < 0) throw new ArgumentException("End date cannot be less than start date");
            if(start < DateTime.Now || end < DateTime.Now) throw new ArgumentException("Start date or End Date cannot be in the past");
            if ((end - start).TotalHours > 2) throw new ArgumentException("Reservation cannot be more than 2 hours per day");
            
            Start = start;
            End = end;
        }
    }
}