using System.ComponentModel.DataAnnotations;
namespace Contractr.Models{
  public class Contractrs{
    public int Id {get;set;}
    [Required]
    [MinLength(3)]
    public string Location {get;set;}
    public string Description {get;set;}
  }
}