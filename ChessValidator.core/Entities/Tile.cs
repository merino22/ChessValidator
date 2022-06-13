using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessValidator.core.Entities
{
    public class Tile
    {
        public Tile(string coordinate)
        {
            _coordinate = coordinate;
            _free = true;
            _piece = new Piece();
        }


        private string _coordinate;
        private bool _free;
        private Piece _piece;

        public string GetCoordinate()
        {
            return this._coordinate;
        }

        public bool GetFree()
        {
            return this._free;
        }

        public void SetFree(bool value)
        {
            this._free = value;
        }

        public Piece GetPiece()
        {
            return this._piece;
        }

        public void SetPiece(Piece piece)
        {
            this._piece = piece;
        }
    }
}
