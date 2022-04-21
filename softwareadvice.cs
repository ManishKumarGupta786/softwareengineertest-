using System.Collections.Generic;

namespace ImportSaasProduct
{

    public class SofwareProducts
    {

        public List<softwareadvice> products  { get; set; }
    }

    public class softwareadvice
    {
        public string title { get; set; }
        public string twitter { get; set; }
        public List<string> categories { get; set; }
    }

}