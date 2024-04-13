using System;
using System.Linq;

namespace MeetingManagement
{
    public class MeetingValidationService : IMeetingValidationService
    {
        private readonly MeetingService _meetingService;

        public MeetingValidationService() 
        {
            var meetingRepository = MeetingRepository.GetInstance();
            _meetingService = new MeetingService(meetingRepository);
        }

        public void ValidateMeeting(Meeting meeting)
        {
            ValiidateIntersectedMeetings(meeting);
            ValidationDate(meeting);
        }

        private void ValiidateIntersectedMeetings(Meeting meeting)
        {
            var startTime = meeting.StartTime;
            var endTime = meeting.EndTime;
            var meetings = _meetingService.GetTimetable(startTime);

            var intersectMeeting = meetings.ToList().Find(m 
                => DateTime.Compare(startTime, m.StartTime) > 0
                   && DateTime.Compare(startTime, m.EndTime) < 0
                      || DateTime.Compare(endTime, m.StartTime) > 0 
                         && DateTime.Compare(endTime, m.EndTime) < 0
            );

            if (intersectMeeting != null)
            {
                throw new Error.MeetingsIntersects();
            }
        }

        private void ValidationDate(Meeting meeting)
        {
            var isMeetingOnFuture = meeting.StartTime > DateTime.Now;
            if (!isMeetingOnFuture)
            {
                throw new Error.MeetingOnFuture();
            }
        }
    }
}
