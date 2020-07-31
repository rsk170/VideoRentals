using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Services.Dto
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter customer's name")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        public byte MembershipTypeId { get; set; }

        public DateTime? Birthdate { get; set; }

    }
}