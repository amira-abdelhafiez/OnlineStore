﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineStore.Web.ViewModels
{
    public class loginVM
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}