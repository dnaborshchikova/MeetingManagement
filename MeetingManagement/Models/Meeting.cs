using System;

namespace MeetingManagement
{
    public class Meeting
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime NotificationTime { get; set; }

        public Meeting(long id, string description, DateTime startTime
            , DateTime endTime, DateTime notificationTime)
        {
            this.Id = id;
            this.Description = description;
            this.StartTime = startTime;
            this.EndTime = endTime;
            this.NotificationTime = notificationTime;
        }
    }
}
