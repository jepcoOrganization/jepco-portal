using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteWare.Entity.Common.Enums
{
    public enum AuthenticationResults
    {
        Denied = 1,
        Disabled = 2,
        Allowed = 3,
        MaxNumberOfAttemptsReached = 4,
        WorngUsernameOrPassword = 5
    }
}
