using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApplication.Services.ViewModel
{
    public class NewsDataViewModel
    {
        public string title { get; set; }
        public string link { get; set; }
        public string keywords { get; set; }
        public string creator { get; set; }
        public string description { get; set; }

        public string image_url { get; set; }

        public string language { get; set; }
    }

    public class ThirdPartyNewsDataViewModel
    {
        public string title { get; set; }
        public string link { get; set; }
        public string[] keywords { get; set; }
        public string[] creator { get; set; }
        public string description { get; set; }

        public string image_url { get; set; }

        public string language { get; set; }
    }

}
