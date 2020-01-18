namespace TeisterMask.DataProcessor.ImportDto
{
    using System;
    using System.Xml.Serialization;

    using TeisterMask.Data.Models.Enums;

    [XmlType("Task")]
    public class TaskImportDto
    {
        [XmlElement]
        public string Name { get; set; }

        [XmlElement]
        public string OpenDate { get; set; }

        [XmlElement]
        public string DueDate { get; set; }

        [XmlElement]
        public int ExecutionType { get; set; }

        [XmlElement]
        public int LabelType { get; set; }
    }
}
