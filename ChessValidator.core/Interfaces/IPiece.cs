using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessValidator.core.Interfaces
{
    public interface IPiece
    {
        void checkType();
        void movement();
    }
}
