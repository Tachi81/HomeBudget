﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeBudget.Business_Logic
{
    public class AuthorizationLogic
    {
        public bool IsUserAuthorized()
        {
            return HttpContext.Current.User.Identity.IsAuthenticated;
        }
    }
}