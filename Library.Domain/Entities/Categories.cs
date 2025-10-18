using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Library.Domain.Entities;

public class Categories
{
	[Key]
	public int category_id { get; set; }

	[Required(ErrorMessage = "Category name is required.")]
	[StringLength(100, ErrorMessage = "Category name cannot exceed 100 characters.")]
	public string? category_name { get; set; }

	[StringLength(250, ErrorMessage = "Description cannot exceed 250 characters.")]
	public string? description { get; set; }

	[DataType(DataType.Date, ErrorMessage = "Invalid date format.")]
    public DateTime? create_date { get; set; }
	
	[Required(ErrorMessage = "Active status is required.")]
	[DefaultValue(true)]
	public bool active { get; set; }
}