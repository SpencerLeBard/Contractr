using System.ComponentModel.DataAnnotations;
namespace ContractorFile.Models
{
  public class Review
  {
    public int Id { get; set; }
    [Required]
    [MinLength(3)]
    public string Title { get; set; }
    public string Body { get; set; }
    public string Rating { get; set; }
    public string Datee { get; set; }
    public string ContractorId { get; set; }
  }
}