namespace Tetris.Code;

public class Tetrimino {
    public List<Cell> tetriminoCells;
    public bool isDropped;
    public static List<List<Tetrimino>>? allTetriminos;

    public Tetrimino(int index) {
        tetriminoCells = allTetriminos![index][0].tetriminoCells;
    }

    public void SendToGrid(Grid grid) {
        grid.addTetrimino(this);
    }

    public void initAllTetriminos() {
        Tetrimino.allTetriminos = new List<List<Tetrimino>>() {
            new List<Tetrimino>() {

            },
        };
    }

    public void moveX(Grid grid, bool isRight) {
        foreach (var cell in tetriminoCells!)
        {
            if(isRight && cell.posX < grid.getWidth()) {
                cell.posX--;
            } else if (cell.posX > 0) {
                cell.posX++;
            }
        }
    }

    //* public void rotate() {

    //* }
}