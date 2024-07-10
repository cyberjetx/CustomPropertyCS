﻿using System;
using System.Xml;

namespace CodeSmith.Xamples
{
    public class ColumnConfigurationSerializer
    {
        public string Serialize(ColumnConfiguration column)
        {
            var xmlDoc = new XmlDocument();
            XmlElement root = xmlDoc.CreateElement("Columns");
            xmlDoc.AppendChild(root);

            XmlElement columnElement = xmlDoc.CreateElement(column.ColumnName);
            root.AppendChild(columnElement);

            XmlElement typeElement = xmlDoc.CreateElement("Type");
            typeElement.InnerText = column.Type;
            columnElement.AppendChild(typeElement);

            XmlElement altNameElement = xmlDoc.CreateElement("AlternateName");
            altNameElement.InnerText = column.AlternateName;
            columnElement.AppendChild(altNameElement);

            XmlElement oneClickElement = xmlDoc.CreateElement("OneClick");
            oneClickElement.InnerText = column.OneClick.ToString();
            columnElement.AppendChild(oneClickElement);

            return xmlDoc.OuterXml;
        }
    }
}
