using System.ComponentModel.DataAnnotations;

namespace coremvc.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
    public class Book
    {
        public string Genre { get; set; }
        public string Name { get; set; }
        public int PageCount { get; set; }
    }
    public class Item
    {
        [Required]
        [StringLength(15, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [Range(0, 1000)]
        public int Count { get; set; }
    }
}

