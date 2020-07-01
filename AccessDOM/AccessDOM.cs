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
			var csvFile = "E:\\Learn_Tech\\Azure_DevOps\\ReadingDOM_HAP\\ReadingDOM\\AccessDOM\\SIPUrlFile.csv";
			var web = new HtmlWeb();
			int counter;

			using (var reader = new StreamReader(csvFile))
			{
				using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
				{
					var records = csv.GetRecords<InputFile>().ToList();
					foreach (var url in records)
					{
						//var sipurl = records.Select(x => x.SIPUrl);
						var doc = web.Load(url.SIPUrl);
						string docContent = doc.DocumentNode
							.SelectNodes("//h1[@class = 'tagline']")
							.FirstOrDefault().InnerText.ToString();
						Console.WriteLine(url.SIPUrl);
						Assert.Multiple(()=> {
							Assert.AreEqual(url.Tagline, docContent, "The Tag is not correct");
						});
						
					}
					
				}
			}
		}
	}
}
