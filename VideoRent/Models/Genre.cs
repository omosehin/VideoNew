﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VideoRent.Models
{
    public class Genre
    {
        public byte Id { get; set; }

       
        [StringLength(255)]
        public string Name { get; set; }
    }
}