using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VideoRent.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Please enter customer's name")]
        [StringLength(255)] 
        public string Name { get; set; }
        [Display(Name ="Date of Birth")]
        [Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; } //DateTime is not nullable so we have to make it nullable

        public bool IsSubscribedNewsLetter { get; set; }
       [Display(Name ="Membership Type")]
        public MembershipType MembershipType { get; set; }

        public byte MembershipTypeId { get; set; }

    }
}