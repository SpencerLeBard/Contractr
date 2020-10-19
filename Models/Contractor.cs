using System.ComponentModel.DataAnnotations;
namespace Contractr.Models
{
  public class Contractor
  {

    public int Id { get; set; }
    [Required]
    [MinLength(3)]
    public string Location { get; set; }
    public string Description { get; set; }
  }
}