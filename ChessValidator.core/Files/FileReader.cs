using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessValidator.core.Files
{
    public class FileReader
    {
        public string[] movements = System.IO.File.ReadAllLines("C:\\Users\\Aaron\\source\\repos\\ChessValidator\\ChessValidator.core\\Files\\movements.txt");

        public void printMovements()
        {
            foreach (string movement in this.movements)
            {
                Console.WriteLine("\t" + movement);
            }
        }

        public List<string> getMovements()
        {
            List<string> movementsList = new List<string>();
            foreach (string movement in this.movements)
            {
                movementsList.Add(movement);
            }
            return movementsList;
        }
    }
}