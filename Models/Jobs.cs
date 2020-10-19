using System.ComponentModel.DataAnnotations;
namespace Contractr.Models{
  public class Jobs{
    public int Id {get;set;}
    [Required]
    [MinLength(3)]
    public string Name {get;set;}
    public string Adress {get;set;}
    public string Skills {get;set;}
  }
}