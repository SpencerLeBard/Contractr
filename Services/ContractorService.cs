using System;
using System.Collections.Generic;
using ContractorFile.Models;
using ContractorFile.Repositories;

namespace ContractorFile.Services
{
  public class ContractorService
  {
    private readonly ContractorRepository _repo;

    public ContractorService(ContractorRepository repo)
    {
      _repo = repo;
    }
    internal IEnumerable<Contractor> GetAll()
    {
      return _repo.GetAll();
    }
    internal Contractor GetById(int id)
    {
      var data = _repo.GetById(id);
      if (data == null)
      {
        throw new Exception("Invalid Id");
      }
      return data;
    }
    internal Contractor Create(Contractor newContractor)
    {
      return _repo.Create(newContractor);
    }

    internal Contractor Edit(Contractor updated)
    {
      var data = GetById(updated.Id);
      if (data.CreatorId != updated.CreatorId)
      {
        throw new Exception("Invalid Edit Permissions");
      }
      updated.Description = updated.Description != null ? updated.Description : data.Description;
      updated.Location = updated.Location != null && updated.Location.Length > 2 ? updated.Location : data.Location;


      return _repo.Edit(updated);
    }
    //   internal IEnumerable<WishListProductViewModel> GetProductsByListId(int id)
    // {
    //   return _repo.GetProductsByListId(id);
    // }

    internal string Delete(int id, string userId)
    {
      var data = GetById(id);
      _repo.Delete(id);
      if (data.CreatorId != userId)
      {
        throw new Exception("Invalid Edit Permissions");
      }
      return "delorted";
    }
  }
}