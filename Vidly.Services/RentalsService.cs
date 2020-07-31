using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vidly.Models;

namespace Vidly.Services
{
    class RentalsService
    {
        private ApplicationDbContext _context;

        public RentalsService()
        {
            _context = new ApplicationDbContext();
        }
    }
}
