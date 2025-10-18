
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Library.Domain.Entities;

public class Authors
{
    [Key]
    public int author_id { get; set; }


    [Required(ErrorMessage = "Author name is required.")]
    [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters.")]
    public string? author_name { get; set; }

    [Required(ErrorMessage = "Country is required.")]
    [StringLength(2, ErrorMessage = "Country code must be 2 characters.")]
    public string? country { get; set; }

    [Required(ErrorMessage = "Address is required.")]
    [StringLength(250, ErrorMessage = "Address cannot exceed 250 characters.")]
    public string? address { get; set; }

    [Required(ErrorMessage = "Phone number is required.")]
    [StringLength(20, ErrorMessage = "Phone number cannot exceed 20 characters.")]
    public string? phone { get; set; }

    [StringLength(200)]
    [EmailAddress(ErrorMessage = "Invalid email format.")]
    public string? email { get; set; }

    [DataType(DataType.Date, ErrorMessage = "Invalid date format.")]
    public DateTime? create_date { get; set; }

    
    [DefaultValue(true)]
    public bool active { get; set; }
}
