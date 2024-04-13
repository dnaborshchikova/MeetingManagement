using System;
using System.Collections.Generic;

namespace MeetingManagement
{
    public interface IMeetingRepository
    {
        Meeting GetMeeting(long id);
        List<Meeting> GetMeetings(DateTime date);
        void AddMeeting(Meeting meeting);
        void UpdateMeeting(Meeting meeting);
        void DeleteMeeting(long id);
    }
}
