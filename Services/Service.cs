using App.Controllers.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Services
{
    interface Service
    {
        UserStatusResource GenarateTimeType(UserStatusResource userStatusResource);
    }
}
