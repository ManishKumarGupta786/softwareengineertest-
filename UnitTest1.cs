using ImportSaasProduct;
using NUnit.Framework;

namespace Unit_Test
{
    [TestFixture]
    public class Tests
    {
        
        private static  string _jsonpath;
        private static string _ymalpath;
        [SetUp]
        public void Setup()
        {

            _jsonpath = "D:\\feed-products\\softwareadvice.json";
            _ymalpath= "D:\\feed-products\\capterra.yaml";
        }

        [Test]
        public static void Testsoftwareadvice()
        {
            try
            {
                Program.JsonReader(_jsonpath);
                Assert.IsTrue(true);
            }
            catch (System.Exception)
            {
                Assert.IsTrue(false);
            }
           
        }

        [Test]
        public static void Testcapterra()
        {
            try
            {
                Program.YamlReader(_ymalpath);
                Assert.IsTrue(true);
            }
            catch (System.Exception)
            {
                Assert.IsTrue(false);
            }

        }
    }
}