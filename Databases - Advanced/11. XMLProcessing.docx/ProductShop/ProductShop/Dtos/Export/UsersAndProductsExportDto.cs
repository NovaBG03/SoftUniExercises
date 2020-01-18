using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    [XmlType("Users")]
    public class UsersAndProductsExportDto
    {
        public UsersAndProductsExportDto()
        {
            this.Users = new List<UserWithAgeExportDto>();
        }

        [XmlElement("count")]
        public int Count { get; set; }

        [XmlArray("users")]
        public List<UserWithAgeExportDto> Users { get; set; }
    }
}
