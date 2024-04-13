using System;
using System.Collections.Generic;
using System.IO;

namespace MeetingManagement
{
    public class TimetableExportService : ITimetableExportService
    {
        public void ExportFile(IEnumerable<Meeting> meetings, string fileName)
        {
            var filePath = Path.GetFullPath(AppDomain.CurrentDomain.BaseDirectory
                + $"{fileName}.txt");

            var isFileExist = File.Exists(filePath);
            if (isFileExist)
            {
                File.Delete(filePath);
            }

            using (var streamWriter = File.CreateText(filePath))
            {
                var contentCreator = new TextContentCreator();
                var content = contentCreator.Generate(meetings);
                streamWriter.WriteLine(content);
            }
        }
    }
}