using System.ComponentModel.DataAnnotations;

namespace NewsApplication.Core
{
    public class Favourite
    {
        [Key]
        public int Id { get; set; }
        public string News { get; set; }

    }
}
