using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Library.Domain.Entities;

namespace Library.Application.DTOs
{
    // DTO for creating a new book
    public class BookCreateDto
    {
        [Required]
        [StringLength(200)]
        public string? title { get; set; }

        [StringLength(250)]
        public string? description { get; set; }

        public int? author_id { get; set; }
        public int? category_id { get; set; }
        public int? publisher_id { get; set; }

        [DataType(DataType.Date)]
        public DateTime? publish_date { get; set; }


        [StringLength(13, MinimumLength = 10)]
        public string? isbn { get; set; }

        [Range(0, 9999.99)]
        public decimal? price { get; set; }

        public bool? active { get; set; }
    }

    // DTO for reading/fetching book data
    public class BookReadDto
    {
        public int book_id { get; set; }

        public string? title { get; set; }

        public string? description { get; set; }

        public int? author_id { get; set; }

        public int? category_id { get; set; }

        public int? publisher_id { get; set; }


        public DateTime? publish_date { get; set; }

        public string? isbn { get; set; }

        public decimal? price { get; set; }

        public bool? active { get; set; }

        public DateTime? create_date { get; set; }

        // Optional related names
        public string? author_name { get; set; }

        public string? category_name { get; set; }

        public string? publisher_name { get; set; }

    }

}