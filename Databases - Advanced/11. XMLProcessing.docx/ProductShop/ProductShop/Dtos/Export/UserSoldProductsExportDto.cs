using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    [XmlType("User")]
    public class UserSoldProductsExportDto
    {
        public UserSoldProductsExportDto()
        {
            this.ProductsSold = new List<ProductExportDto>();
        }

        [XmlElement("firstName")]
        public string FirstName { get; set; }

        [XmlElement("lastName")]
        public string LastName { get; set; }

        [XmlArray("soldProducts")]
        public List<ProductExportDto> ProductsSold { get; set; }
    }
}
