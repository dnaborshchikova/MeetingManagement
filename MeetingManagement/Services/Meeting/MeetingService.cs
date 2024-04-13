using System;
using System.Collections.Generic;

namespace MeetingManagement
{
    public class MeetingService : IMeetingService
    {
        private readonly IMeetingRepository _meetingRepository;

        public MeetingService(IMeetingRepository meetingRepository)
        {
            _meetingRepository = meetingRepository;
        }

        public Meeting GetMeeting(long id)
        {
            return _meetingRepository.GetMeeting(id);
        }

        public List<Meeting> GetTimetable(DateTime date)
        {
            return _meetingRepository.GetMeetings(date);
        }

        public void AddMeeting(string description, DateTime startTime
            , DateTime endTime, DateTime notificationTime)
        {
            var meetingValidationService = new MeetingValidationService();
            var meeting = new Meeting(DateTime.Now.Ticks, description, startTime, endTime
                   , notificationTime);
            meetingValidationService.ValidateMeeting(meeting);

            _meetingRepository.AddMeeting(meeting);
        }

        public void UpdateMeeting(Meeting meeting)
        {
            _meetingRepository.UpdateMeeting(meeting);
        }

        public void DeleteMeeting(long id)
        {
            _meetingRepository.DeleteMeeting(id);
        }
    }
}
