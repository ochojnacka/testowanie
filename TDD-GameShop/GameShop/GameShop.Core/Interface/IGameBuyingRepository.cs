using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShop.Core.Interface
{
    public interface IGameBuyingRepository
    {
        void Save(GameBought gameBought);
    }
}
