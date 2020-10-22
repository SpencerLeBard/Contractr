using System;
using System.Collections.Generic;

namespace ContractorFile.Models
{
  public class Profile
  {
    public string Id { get; set; }
    //NOTE given to you by network tab under user info
    public string Name { get; set; }
    public string Email { get; set; }
    //NOTE SAME AS USE LOGIN
    public string Picture { get; set; }
  }
}

//NOTE 1.) login get bearer token
//     2.) put bearer token in postman
//     3.) get by profiles
//     4.) Gives you profile id to attach to creator Id
//     5.) use creatorId for contractor profilesetup