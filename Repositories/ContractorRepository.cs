using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
      string sql = @"
      SELECT
      con.*,
      prof.*
      FROM contractors con
      JOIN profiles prof ON con.creatorId = prof.id
      ";
      return _db.Query<Contractor, Profile, Contractor>(sql, (contractor, profile) =>
    {
      contractor.Creator = profile;
      return contractor;
    }, splitOn: "id");
    }
    internal Contractor GetById(int id)
    {
      string sql = @"
      SELECT
      con.*,
      prof.*
      FROM contractors con
      JOIN profiles prof ON con.creatorId = prof.id
      WHERE con.id = @id";
      //NOTE 'WHERE' LINE YOU SPECIFIY WHERE FIRST ID IS REFERRING TO (CONTRACTORS) cont.id = @id
      return _db.Query<Contractor, Profile, Contractor>(sql, (contractor, profile) =>
          {
            contractor.Creator = profile;
            return contractor;
          }, new { id }, splitOn: "id").FirstOrDefault();
    }
    internal Contractor Create(Contractor newContractor)
    {//NOTE why is this working?
      string sql = @"
      INSERT INTO contractors 
      (loaction, description, creatorId, creatorId) 
      VALUES 
      (@Location, @Description, @creatorId);
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