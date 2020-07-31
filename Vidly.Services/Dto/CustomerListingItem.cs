using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vidly.Services.Dto
{
    public class CustomerListingItem
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string MembershipType { get; set; }
    }
}
