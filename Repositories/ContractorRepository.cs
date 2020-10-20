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
      string sql = "SELECT * FROM contractor WHERE id = @id LIMIT 1";
      return _db.QueryFirstOrDefault<Contractor>(sql, new { id });
    }
    internal Contractor Create(Contractor newContractor)
    {
      string sql = @"
      INSERT INTO contractor 
      (location, description) 
      VALUES 
      (@Location, @Description);
      SELECT LAST_INSERT_ID();";
      int id = _db.ExecuteScalar<int>(sql, newContractor);
      newContractor.Id = id;
      return newContractor;
    }
    internal Contractor Edit(Contractor updated)
    {
      string sql = @"
        UPDATE contractor
        SET
         location = @Location,
         description = @Description,
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
      string sql = "DELETE FROM contractors WHERE id = @id";
      _db.Execute(sql, new { id });
    }
  }
}