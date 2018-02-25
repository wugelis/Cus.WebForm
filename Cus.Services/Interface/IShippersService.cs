using Cus.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cus.Services.Interface
{
    public interface IShippersService
    {
        IEnumerable<ShipperViewModel> GetShippers();
    }
}

