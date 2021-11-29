namespace Tetris.Code;

public class Round {
    public static bool isGameOver(List<Cell> grid) {
        return Grid.grid[20 * 4].val != 0;
    }
}