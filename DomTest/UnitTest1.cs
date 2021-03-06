﻿using System;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using HtmlAgilityPack;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace DomTest
{
	[TestClass]
	public class UnitTest1
	{
		[Test]
		public void TestMethod1()
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
						Assert.AreEqual(url.Tagline, docContent, "The Tag is not correct");
					}
				}
			}
		}
	}
}
