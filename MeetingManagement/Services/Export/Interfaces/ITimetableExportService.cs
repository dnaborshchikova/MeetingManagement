using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingManagement
{
    public interface ITimetableExportService
    {
        void ExportFile(IEnumerable<Meeting> meetings, string fileName);
    }
}
