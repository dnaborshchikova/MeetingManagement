using System;
using System.Collections.Generic;

namespace MeetingManagement
{
    public interface IMeetingService
    {
        Meeting GetMeeting(long id);
        List<Meeting> GetTimetable(DateTime date);
        void AddMeeting(string description, DateTime startTime
            , DateTime endTime, DateTime notificationTime);
        void DeleteMeeting(long id);
        void UpdateMeeting(Meeting meeting);
    }
}
