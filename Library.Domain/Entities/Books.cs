using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Library.Domain.Entities;

public class Books
{
	[Key]
	public int book_id { get; set; }

	[Required(ErrorMessage = "Title is required.")]
	[StringLength(100, ErrorMessage = "Title cannot exceed 200 characters.")]
	public string? title { get; set; }

	[StringLength(250, ErrorMessage = "Description cannot exceed 1000 characters.")]
	public string? description { get; set; }

	[Required(ErrorMessage = "Author ID is required.")]
	public int? author_id { get; set; }

	[Required(ErrorMessage = "Category ID is required.")]
	public int? category_id { get; set; }

	[Required(ErrorMessage = "Publisher ID is required.")]
	public int? publisher_id { get; set; }

	[DataType(DataType.Date, ErrorMessage = "Invalid date format.")]
	public DateTime? publish_date { get; set; }
	
	[StringLength(20, ErrorMessage = "ISBN cannot exceed 20 characters.")]
	public string? ISBN { get; set; }

	[Range(0, 10000, ErrorMessage = "Price must be between 0 and 10,000.")]
	public decimal? price { get; set; }

	[DataType(DataType.Date, ErrorMessage = "Invalid date format.")]
    public DateTime? create_date { get; set; }
	
	
	[DefaultValue(true)]
	public bool? active { get; set; }
}