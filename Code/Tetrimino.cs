namespace Tetris.Code;

public class Tetrimino {
    public Cell[] tetriminoCells;
    public bool isDropped;
    public static Tetrimino[][] allTetriminos;

    public void moveX(bool isRight) {
        foreach (var cell in this.tetriminoCells)
        {
            if(isRight && cell.posX < Grid.width) {
                cell.posX--;
            } else if (cell.posX > 0) {
                cell.posX++;
            }
        }
    }

    public void rotate() {

    }
}