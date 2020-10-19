using System;
using System.Collections.Generic;
using System.Data;
using AmaZen.Models;
using Dapper;

namespace Contractr.Repositories{
  public class ContractrRepository{
    private readonly IdbConnection _db;
    public ContractrRepository(IDbConnection db){
      _db = db;
    }
    internal IEnumerable<Contractor> GetAll(){
      
    }
  }
}