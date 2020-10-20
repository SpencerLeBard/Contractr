using System;
using System.Collections.Generic;
using System.Data;
using ContractorFile.Models;
using Dapper;

namespace ContractorFile.Repositories
{
  public class ContractorRepository
  {
    private readonly IDbConnection _db;
    public ContractorRepository(IDbConnection db)
    {
      _db = db;
    }
    internal IEnumerable<Contractor> GetAll()
    {
      string sql = "SELECT * FROM contractor";
      var contractors = _db.Query<Contractor>(sql);
      return contractors;
    }
    internal Contractor GetById(int id)
    {
      string sql = "SELECT * FROM contractor WHERE id = @id";
      return _db.QueryFirstOrDefault<Contractor>(sql, new { id });
    }

  }
}