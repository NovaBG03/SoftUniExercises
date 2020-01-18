using System.Collections.Generic;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    [XmlType("SoldProducts")]
    public class SoldProductsCountExportDto
    {
        public SoldProductsCountExportDto()
        {
            this.Products = new List<ProductExportDto>();
        }

        [XmlElement("count")]
        public int Count { get; set; }

        [XmlArray("products")]
        public List<ProductExportDto> Products { get; set; }
    }
}