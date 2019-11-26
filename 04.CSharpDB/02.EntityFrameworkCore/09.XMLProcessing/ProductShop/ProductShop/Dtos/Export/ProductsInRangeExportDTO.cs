﻿using System.Xml.Serialization;
namespace ProductShop.Dtos.Export
{
    [XmlType("Product")]
    public class ProductsInRangeExportDTO
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("price")]
        public decimal Price { get; set; }

        [XmlElement("buyer")]
        public string Buyer { get; set; }
    }
}