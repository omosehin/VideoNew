using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VideoRent.Models;

namespace VideoRent.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; } //DateTime is not nullable so we have to make it nullable

        public bool IsSubscribedNewsLetter { get; set; }

        public byte MembershipTypeId { get; set; }


    }
}