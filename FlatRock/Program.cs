using HtmlAgilityPack;
using System;
using Newtonsoft.Json;
using FlatRock;

namespace WebScrapper
{
    class Program
    {
        static void Main(string[] args)
        {
            string htmlFilePath = @"..\..\..\Task.html";
            string htmlContent = File.ReadAllText(htmlFilePath);

            ParseData parseData = new ParseData();

            parseData.jsonFormatOutput(htmlContent);





            Console.ReadKey();
        }
    }
}
