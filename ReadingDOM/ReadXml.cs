using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace ReadingDOM.Console
{
	public class ReadXml
	{
		static void Main(string[] args)
		{
			XmlReader reader = XmlReader.Create("E:\\Learn_Tech\\Azure_DevOps\\ReadingDOM_HAP\\ReadingDOM\\ReadingDOM\\Persons.xml");
			while (reader.Read())
			{
				if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "Person"))
				{
					if (reader.HasAttributes)
					{
						System.Console.WriteLine("Hello");
						System.Console.WriteLine("FirstName is "+ reader.GetAttribute("firstname"));
						System.Console.WriteLine("End");
					}
				}
			}
			
		}

	}
}
