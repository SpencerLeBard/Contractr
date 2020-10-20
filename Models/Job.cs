using System.ComponentModel.DataAnnotations;
namespace ContractorFile.Models
{
  public class Job
  {
    public int Id { get; set; }
    [Required]
    [MinLength(3)]
    public string Name { get; set; }
    public string Address { get; set; }
    public string Skills { get; set; }
  }
}