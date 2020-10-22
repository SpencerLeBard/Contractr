using System.ComponentModel.DataAnnotations;

namespace ContractorFile.Models
{
  public class Contractor
  {

    public int Id { get; set; }
    [Required]
    [MinLength(3)]
    public string Location { get; set; }
    public string Description { get; set; }
    public string CreatorId { get; set; }
    //NOTE this comes from GET profiles in postman, id in JSON 
    public Profile Creator { get; set; }
    //NOTE profile info on contractor profile
  }
}