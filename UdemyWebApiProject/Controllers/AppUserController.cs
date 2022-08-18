using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UdemyWebApiProject.Data;
using UdemyWebApiProject.Entities;

namespace UdemyWebApiProject.Controllers
{
    public class AppUserController : BaseApiController
    {
        private readonly DataContext _context;

        public AppUserController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> Get([FromRoute]int id, CancellationToken ct)
        {
            var reponse = await _context.AppUser.FirstOrDefaultAsync(x => x.Id == id, ct);
            return Ok(reponse);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll(CancellationToken ct)
        {
            var reponse = await _context.AppUser.ToListAsync(ct);
            return Ok(reponse);
        }

    }
}
