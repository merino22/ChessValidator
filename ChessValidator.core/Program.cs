// See https://aka.ms/new-console-template for more information
using static ChessValidator.core.Files.FileReader;
using static ChessValidator.core.Files.MovementParser;
using static ChessValidator.core.Entities.Board;

ChessValidator.core.Files.FileReader reader = new ChessValidator.core.Files.FileReader();
reader.printMovements();

List<string> movementList = new List<string>();
movementList = reader.getMovements();

ChessValidator.core.Entities.Board board = new ChessValidator.core.Entities.Board(movementList);
board.printBoard();
