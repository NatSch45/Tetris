namespace Tetris.Code;

public class Round {
    public static bool isGameOver(Grid gridObject, List<Cell> grid) {
        return gridObject.grid[20 * 4].val != 0;
    }
}