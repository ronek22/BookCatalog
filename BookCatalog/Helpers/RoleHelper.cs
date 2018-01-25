﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCatalog.Helpers
{
    public class RoleHelper
    {
        public const string Administrator = "Administrator";
        public const string Moderator = "Moderator";
        public const string User = "User";

        public static string Normalize(string roleName)
        {
            return roleName.ToUpper();
        }
    }
}
