using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShop.Core.Interface
{
    public interface IGameAvailable
    {
        bool IsGameAvailable(Game game);
    }
}
