using System.ComponentModel.DataAnnotations;

namespace Library.Domain.Entities;

public class Countries
{
    [Key]
    public int country_id { get; set; }
    public string? country_name { get; set; }
    public string? nationality { get; set; }
    public string? calling_code { get; set; }
}