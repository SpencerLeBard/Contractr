using System;
using System.Collections.Generic;
using Contractor.Models;
using Contractor.Repositories;

namespace Contractor.Services
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

  }
}