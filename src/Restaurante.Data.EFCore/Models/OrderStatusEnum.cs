using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Data.EFCore.Models
{
    public enum OrderStatusEnum
    {
        Created,
        Pending,
        Paid,
        OnTheWay,
        Closed
    }
}
