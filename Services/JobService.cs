using System;
using System.Collections.Generic;
using ContractorFile.Models;
using ContractorFile.Repositories;

namespace ContractorFile.Services
{
  public class JobService
  {
    private readonly JobRepository _repo;

    public JobService(JobRepository repo)
    {
      _repo = repo;
    }
    internal IEnumerable<Job> GetAll()
    {
      return _repo.GetAll();
    }
    internal Job GetById(int id)
    {
      var data = _repo.GetById(id);
      if (data == null)
      {
        throw new Exception("Invalid Id");
      }
      return data;
    }
    internal Job Create(Job newJob)
    {
      return _repo.Create(newJob);
    }

    internal Job Edit(Job updated)
    {
      var data = GetById(updated.Id);

      updated.Name = updated.Name != null ? updated.Name : data.Name;

      updated.Skills = updated.Skills != null ? updated.Skills : data.Skills;

      updated.Address = updated.Address != null && updated.Address.Length > 2 ? updated.Address : data.Address;


      return _repo.Edit(updated);
    }
    //   internal IEnumerable<WishListProductViewModel> GetProductsByListId(int id)
    // {
    //   return _repo.GetProductsByListId(id);
    // }

    internal string Delete(int id)
    {
      var data = GetById(id);
      _repo.Delete(id);
      return "delorted";
    }
  }
}