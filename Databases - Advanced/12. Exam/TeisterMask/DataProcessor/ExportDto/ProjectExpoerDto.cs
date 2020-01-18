using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace TeisterMask.DataProcessor.ExportDto
{
    [XmlType("Project")]
    public class ProjectExpoerDto
    {
        public ProjectExpoerDto()
        {
            this.Tasks = new List<TaskSecondExportDto>();
        }

        [XmlAttribute]
        public string TasksCount { get; set; }

        [XmlElement]
        public string ProjectName { get; set; }

        [XmlElement]
        public string HasEndDate { get; set; }

        [XmlArray]
        public List<TaskSecondExportDto> Tasks { get; set; }
    }
}
