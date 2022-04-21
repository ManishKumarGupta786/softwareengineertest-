using System;
using System.IO;
using System.Text;
using System.Text.Json;
using YamlDotNet.RepresentationModel;

namespace ImportSaasProduct
{
    public class Program
    {
       
        public static void JsonReader(string path)
        {
            using (StreamReader file = new StreamReader(path))
            {
                try
                {
                    var json = file.ReadToEnd();
                    var options = new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                    var sofwareProducts = JsonSerializer.Deserialize<SofwareProducts>(json, options);

                    foreach (var item in sofwareProducts.products)
                    {
                        Console.WriteLine(
                             String.Format("importing:Name: {0}; Categories: {1}; Twitter: {2}",
                                 item.title, String.Join(",", item.categories.ToArray()), item.twitter

                             )
                         );
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                }
            }
        }

        public static void Main(string[] args)
        {
            Console.Write("$ ");
            string input = Console.ReadLine();
            var inputArray = input.Split("/");
            switch (inputArray[1])
            {
                case "capterra.yaml":
                    YamlReader("D:\\feed-products\\" + inputArray[1]);
                    Console.Read();

                    break;
                case "softwareadvice.json":
                    JsonReader("D:\\feed-products\\" + inputArray[1]);
                    Console.Read();
                    break;
                default:
                    break;
            }
        }

        public static void YamlReader(string path)
        {
            try
            {
                using (var reader = new StreamReader(path))
                {
                    var output = new StringBuilder();
                    // Load the stream
                    var yaml = new YamlStream();
                    yaml.Load(reader);
                    var items = (YamlSequenceNode)yaml.Documents[0].RootNode;
                    foreach (YamlMappingNode item in items)
                    {
                        Console.WriteLine(
                            String.Format("importing:Name: {0}; Categories: {1}; Twitter: {2}",
                                item.Children[new YamlScalarNode("name")],
                                item.Children[new YamlScalarNode("tags")],
                                  item.Children[new YamlScalarNode("twitter")]
                            )
                        );
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}
