using ChessValidator.core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessValidator.core.Files
{
    public class MovementParser
    {
        public Piece GetNewPiece(string position)
        {
            var builder = new StringBuilder();

            if (position[0] == 'C')
            {
                builder.Append(position[1]);
                builder.Append(position[2]);
                return new Piece("Caballo", 'C', builder.ToString());
            }

            if(position[0] == 'T')
            {
                builder.Append(position[1]);
                builder.Append(position[2]);
                return new Piece("Torre", 'T', builder.ToString());
            }

            builder.Append(position[0]);
            builder.Append(position[1]);
            return new Piece("Peon", ' ', builder.ToString());
        }

        public Movement GetNewMovement(string movement)
        {
            var start = new StringBuilder();
            var end = new StringBuilder();

            if (movement[0] == 'C')
            {
                start.Append(movement[1]);
                start.Append(movement[2]);
                
                end.Append(movement[4]);
                end.Append(movement[5]);
                return new Movement(start.ToString(), end.ToString());
            }

            if (movement[0] == 'T')
            {
                start.Append(movement[1]);
                start.Append(movement[2]);

                end.Append(movement[4]);
                end.Append(movement[5]);
                return new Movement(start.ToString(), end.ToString());
            }

            start.Append(movement[0]);
            start.Append(movement[1]);

            end.Append(movement[3]);
            end.Append(movement[4]);

            return new Movement(start.ToString(), end.ToString());
        }
    }
}
