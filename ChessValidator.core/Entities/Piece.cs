using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessValidator.core.Entities
{
    public class Piece
    {
        private string _name;
        private char _code;
        private string _position;

        public Piece(string name, char code, string position)
        {
            _name = name;
            _code = code;
            _position = position;
        }

        public Piece() 
        { 
            _name = "Free";
            _code = ' ';
            _position = "Free";
        }

        public string GetName()
        {
            return _name;
        }

        public void SetName(string name)
        {
            this._name = name;
        }

        public char GetCode()
        {
            return this._code;
        }

        public void SetCode(char code)
        {
            this._code = code;
        }

        public string GetPosition()
        {
            return this._position;
        }

        public void SetPosition(string pos)
        {
            this._position = pos;
        }
    }
}
