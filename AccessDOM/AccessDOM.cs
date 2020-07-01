using CsvHelper;
using HtmlAgilityPack;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace AccessDOM
{
	public class AccessDOM
	{

		public static void Main(string[] args)
		{
			var csvFile = "E:\\GitHub\\Reading-DOM-HAP\\AccessDOM\\UrlFile.csv";
			var web = new HtmlWeb();
			int counter;

			using (var reader = new StreamReader(csvFile))
			{
				using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
				{
					var records = csv.GetRecords<InputFile>().ToList();
					foreach (var record in records)
					{
						string appUrl = record.Url.ToString();
						var doc = web.Load(appUrl);
						string docContent = doc.DocumentNode
							.SelectNodes("(//span[@class ='nav-line-2 '])[1]")
							.FirstOrDefault().InnerText.ToString().Replace("\n","").Trim();
						Console.WriteLine(record.Url);
						Assert.Multiple(()=> {
							Assert.AreEqual(record.CreateAccount, docContent, "The Account Textis not correct");
						});
						
					}
					
				}
			}
		}
	}
}
