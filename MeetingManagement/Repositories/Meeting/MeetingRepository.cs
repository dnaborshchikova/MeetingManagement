using System;
using System.Collections.Generic;
using System.Linq;

namespace MeetingManagement
{
    public class MeetingRepository : IMeetingRepository
    {
        private List<Meeting> meetings = new List<Meeting>();

        private static MeetingRepository instance;

        private MeetingRepository()
        {

        }

        public static MeetingRepository GetInstance()
        {
            if (instance == null)
            {
                instance = new MeetingRepository();
            }
            return instance;
        }

        public Meeting GetMeeting(long id)
        {
            return meetings.Find(m => m.Id == id);
        }

        public List<Meeting> GetMeetings(DateTime date)
        {
            return meetings.Where(m
                => m.StartTime.DayOfYear == date.DayOfYear
                   && m.StartTime.Year == date.Year).ToList();
        }

        public void AddMeeting(Meeting meeting)
        {
            meetings.Add(meeting);
        }

        public void UpdateMeeting(Meeting meeting)
        {
            var oldMeeting = GetMeeting(meeting.Id);

            oldMeeting.Description = meeting.Description;
            oldMeeting.NotificationTime = meeting.NotificationTime;
            oldMeeting.StartTime = meeting.StartTime;
            oldMeeting.EndTime = meeting.EndTime;
        }

        public void DeleteMeeting(long id)
        {
            var deletedMeeting = GetMeeting(id);
            meetings.Remove(deletedMeeting);
        }
    }
}
