﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer_DAL_;

public class TokenDto
{
    public string Token { get; set; }
    public DateTime  Expiration { get; set; }
}
