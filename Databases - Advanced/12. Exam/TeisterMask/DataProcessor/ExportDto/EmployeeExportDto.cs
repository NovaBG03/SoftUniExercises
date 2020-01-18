using System;
using System.Collections.Generic;
using System.Text;

namespace TeisterMask.DataProcessor.ExportDto
{
    public class EmployeeExportDto
    {
        public EmployeeExportDto()
        {
            this.Tasks = new List<TaskExportDto>();
        }

        public string Username { get; set; }

        public List<TaskExportDto> Tasks { get; set; }
    }
}
