using System;
using System.Collections.Generic;
using System.Data;
using ContractorFile.Models;
using Dapper;

namespace ContractorFile.Repositories
{
  public class JobRepository
  {
    private readonly IDbConnection _db;
    public JobRepository(IDbConnection db)
    {
      _db = db;
    }
    internal IEnumerable<Job> GetAll()
    {
      string sql = "SELECT * FROM jobs";
      var jobs = _db.Query<Job>(sql);
      return jobs;
    }
    internal Job GetById(int id)
    {
      string sql = "SELECT * FROM jobs WHERE id = @id LIMIT 1";
      return _db.QueryFirstOrDefault<Job>(sql, new { id });
    }
    internal Job Create(Job newJob)
    {
      string sql = @"
      INSERT INTO jobs 
      (name, address, skills) 
      VALUES 
      (@Name, @Address, @Skills);
      SELECT LAST_INSERT_ID();";
      int id = _db.ExecuteScalar<int>(sql, newJob);
      newJob.Id = id;
      return newJob;
    }
    internal Job Edit(Job updated)
    {
      string sql = @"
        UPDATE jobs
        SET
         name = @Name,
         address = @Address,
         skills = @Skills,
        WHERE id = @Id;";
      _db.Execute(sql, updated);
      return updated;
    }
    //   internal IEnumerable<WishListProductViewModel> GetProductsByListId(int id)
    // {
    //   string sql = @"
    //   SELECT p.*, wlp.id AS WishListProductId
    //   FROM wishlistproducts wlp
    //   JOIN products p ON p.id = wlp.productId
    //   WHERE wishlistId = @id
    //   ";
    //   return _db.Query<WishListProductViewModel>(sql, new { id });
    // }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM jobs WHERE id = @id";
      _db.Execute(sql, new { id });
    }
  }
}