using HtmlAgilityPack;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FlatRock
{
    public class ParseData
    {
        public ParseData() { }


        public void jsonFormatOutput(string content)
        {
            var products = Parse(content);
            var Output = JsonConvert.SerializeObject(products, Formatting.Indented);
            Console.WriteLine(Output);
        }

        public static List<Product> Parse(string content)
        {
            var products = new List<Product>();
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(content);

            var productNodes = htmlDocument.DocumentNode.SelectNodes("//div[@class='item']");
            foreach (var productNode in productNodes)
            {

                var name = WebUtility.HtmlDecode(productNode.SelectSingleNode(".//h4/a").InnerText.Trim());
                var price = productNode.SelectSingleNode(".//span[@itemprop='price']").FirstChild
                    .InnerHtml.Trim().Replace("$", "").Replace(",", "");

                var rating = NormalizeDecimalRating(productNode.GetAttributeValue("rating", "")).ToString();

                products.Add(new Product { Name = name, Price = price, Rating = rating });
            }

            return products;
        }


        public static decimal NormalizeDecimalRating(string rating)
        {
            if (decimal.TryParse(rating, out decimal normalizedRating))
            {
                if (normalizedRating > 5)
                {
                    return normalizedRating / 2;
                }
                else
                {
                    return normalizedRating;
                }
            }
            return 0;
        }

    }
}
