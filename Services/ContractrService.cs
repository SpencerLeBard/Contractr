using System;
using System.Collections.Generic;
using Contractr.Models;
using Contractr.Repositories;

namespace Contractr.Services
{
  public class ContractrService
  {
    private readonly ContractrRepository _repo;

    public ContractrService(ContractrRepository repo)
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