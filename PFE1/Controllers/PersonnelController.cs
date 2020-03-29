using Microsoft.AspNetCore.Mvc;
using PFE1.Repository;
using PFE1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PFE1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class   PersonnelController : ControllerBase
    {


        private readonly IPersonnelRepository _dataRepository;

        public PersonnelController(IPersonnelRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET: api/Personnel
        [HttpGet]
            public IEnumerable<Personnel> Get()
            {
                return _dataRepository.GetAll();
            }

            // GET: api/Personnel/5
            [HttpGet("{id}", Name = "Get")]
            public Personnel Get(int id)
            {
                return _dataRepository.Get(id);
            }

            // POST: api/Personnel
            [HttpPost]
            public string Post(Personnel entity)
            {
                return _dataRepository.Add(entity);
            }

            // PUT: api/Personnel/5
            [HttpPut("{id}")]
            public string Put(int id, [FromBody] Personnel entity)
            {
                return _dataRepository.Update(id, entity);


            }

            // DELETE: api/ApiWithActions/5
            [HttpDelete("{id}")]
            public string Delete(int id)
            {
                return _dataRepository.Delete(id);
            }
        }
    }

