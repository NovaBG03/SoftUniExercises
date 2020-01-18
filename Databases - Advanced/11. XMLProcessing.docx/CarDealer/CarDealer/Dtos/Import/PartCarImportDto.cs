using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer.Dtos.Import
{
    [XmlType("partId")]
    public class PartCarImportDto
    {
        [XmlAttribute("id")]
        public int PartId { get; set; }
    }

    public class PartCarComperarer : IEqualityComparer<PartCarImportDto>
    {
        public bool Equals(PartCarImportDto x, PartCarImportDto y)
            => x.PartId.Equals(y.PartId);

        public int GetHashCode(PartCarImportDto obj)
            => obj.PartId.GetHashCode();
    }
}
