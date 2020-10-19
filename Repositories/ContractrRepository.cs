using System;
using System.Collections.Generic;
using System.Data;
using Contractr.Models;
using Dapper;

namespace Contractr.Repositories
{
  public class ContractrRepository
  {
    private readonly IDbConnection _db;
    public ContractrRepository(IDbConnection db)
    {
      _db = db;
    }
    internal IEnumerable<Contractor> GetAll()
    {
      string sql = "SELECT * FROM contractor";
      return _db.Query<Contractor>(sql);
    }
    internal Contractor GetById(int id)
    {
      string sql = "SELECT * FROM contractor WHERE id = @id";
      return _db.QueryFirstOrDefault<Contractor>(sql, new { id });
    }

  }
}