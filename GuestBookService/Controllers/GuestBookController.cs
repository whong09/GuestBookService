using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuestBookService.DataAccess;
using GuestBookService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace GuestBookService.Controllers
{
    [Produces("application/json")]
    [Route("api/GuestBookEntries")]
    public class GuestBookController : Controller
    {
        private IConfiguration _configuration;
        private GuestBookAccess GuestBookAccess;
        public GuestBookController(IConfiguration configuration)
        {
            _configuration = configuration;
            GuestBookAccess = new GuestBookAccess(_configuration.GetConnectionString("DefaultConnection"));
        }

        // GET: api/GuestBookEntries
        [HttpGet]
        public IEnumerable<GuestBookEntry> Get()
        {
            return GuestBookAccess.GetGuestBookEntries();
        }

        // POST: api/GuestBookEntries
        [HttpPost]
        public void Post([FromBody]GuestBookEntry entry)
        {
            entry.CreateDate = DateTime.UtcNow;
            GuestBookAccess.CreateGuestBookEntry(entry);
        }
    }
}
