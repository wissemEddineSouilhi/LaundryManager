﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundryManager.Application.Dtos
{
    public class CreateUserDto
    {
        public string email { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string password { get; set; }
        public string PhoneNumber { get; set; }
    }
}
