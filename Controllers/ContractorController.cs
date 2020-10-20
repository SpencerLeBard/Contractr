using System;
using ContractorFile.Models;
using ContractorFile.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContractorFile.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ContractorController : ControllerBase
  {
    private readonly ContractorService _service;
    public ContractorController(ContractorService ps)
    {
      _service = ps;
    }

    [HttpGet]
    public ActionResult<Contractor> Get()

    {
      try
      {
        return Ok(_service.GetAll());
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}")]
    public ActionResult<Contractor> Get(int id)
    {
      try
      {
        return Ok(_service.GetById(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}