using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyWebApiProject.Data;
using UdemyWebApiProject.Entities;
using UdemyWebApiProject.Interfaces;

namespace UdemyWebApiProject.Controllers
{
    [Route("[controller]")]
    public class AppUserController : BaseController
    {
        private readonly IAppUserRepository _repository;
        public AppUserController(IAppUserRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute]int id, CancellationToken ct)
        {
            var reponse = await _repository.Get(x => x.Id == id, ct);
            return Ok(reponse);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken ct)
        {
            var reponse = await _repository.GetAll(ct);
            return Ok(reponse);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]AppUser appUser, CancellationToken ct)
        {
            var reponse = await _repository.Create(appUser, ct);
            return Created("Create", reponse);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody]AppUser appUser, CancellationToken ct)
        {
            var response = await _repository.Update(appUser, ct);
            return Ok(response);
        }

    }
}
