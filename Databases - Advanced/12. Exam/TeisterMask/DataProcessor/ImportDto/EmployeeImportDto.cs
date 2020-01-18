using System;
using System.Collections.Generic;
using System.Text;

namespace TeisterMask.DataProcessor.ImportDto
{
    public class EmployeeImportDto
    {
        public EmployeeImportDto()
        {
            this.Tasks = new List<int>();
        }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public List<int> Tasks { get; set; }
    }
}
