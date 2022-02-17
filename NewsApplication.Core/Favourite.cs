using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewsApplication.Core
{
    public class Favourite
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string title { get; set; }
        public string link { get; set; }
        public string keywords { get; set; }
        public string creator { get; set; }
        public string description { get; set; }

        public string image_url { get; set; }

        public string language { get; set; }

    }
}
