namespace TeisterMask.DataProcessor.ImportDto
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [XmlType("Project")]
    public class ProjectImportDto
    {
        public ProjectImportDto()
        {
            this.Tasks = new List<TaskImportDto>();
        }

        [XmlElement]
        public string Name { get; set; }

        [XmlElement]
        public string OpenDate { get; set; }

        [XmlElement]
        public string DueDate { get; set; }

        [XmlArray]
        public List<TaskImportDto> Tasks { get; set; }
    }
}
