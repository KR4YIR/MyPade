﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Sal
    {
        [Key]
        public int PostID { get; set; }

        public string Image { get; set; }
        public int UserId { get; set; }
        public AdminUser User { get; set; }

        public string Category { get; set; }
        public string City { get; set; }
       
    }
}