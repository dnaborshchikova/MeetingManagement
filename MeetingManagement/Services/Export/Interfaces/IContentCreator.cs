using System.Collections.Generic;

namespace MeetingManagement
{
    public interface IContentCreator
    {
        string Generate(IEnumerable<Meeting> meetings);
    }
}
