﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unicom_TIC_Management.Models
{
    internal class User: Model_Parent
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public int ReferenceId { get; set; }
    }
}
