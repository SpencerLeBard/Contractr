using System;
using Contractr.Models;
using Contractr.Services;
using Microsoft.AspNetCore.Mvc;

namespace Contractr.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ContractrController : ControllerBase
  {
    private readonly ContractrService _service;
    public ContractrController(ContractrService ps)
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