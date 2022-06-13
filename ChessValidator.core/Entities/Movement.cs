using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessValidator.core.Entities
{
    public class Movement
    {
        public string _startMove;
        public string _endMove;

        public Movement(string startMove, string endMove)
        {
            this._startMove = startMove;
            this._endMove = endMove;
        }
    }
}
