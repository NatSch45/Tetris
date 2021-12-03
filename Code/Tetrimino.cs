using System.Numerics;
namespace Tetris.Code;

public class Tetrimino {
    public List<Cell>? tetriminoCells;
    public bool isDropped;
    public static List<Tetrimino>? allTetriminos;
    public Vector2 Position;

    public Tetrimino() {
        this.tetriminoCells = new List<Cell>();
    }

    public Tetrimino(List<Cell> cells) {
        this.tetriminoCells = cells;
    }

    public void chooseTetrimino(int index) {
        tetriminoCells = allTetriminos![index].tetriminoCells;
    }

    public void sendToGrid(Grid grid) {
        grid.addTetrimino(this);
    }

    public static void initAllTetriminos() {
        Tetrimino.allTetriminos = new List<Tetrimino>() {
            new Tetrimino(new List<Cell>() {
                new Cell(0,3,1,"I"), new Cell(0,4,1,"I"), new Cell(0,5,1,"I"), new Cell(0,6,1,"I")
            }),
            new Tetrimino(new List<Cell>() {
                new Cell(1,4,2,"O"), new Cell(0,4,2,"O"), new Cell(0,5,2,"O"), new Cell(1,5,2,"O")
            }),
            new Tetrimino(new List<Cell>() {
                new Cell(1,3,3,"T"), new Cell(0,4,3,"T"), new Cell(1,5,3,"T"), new Cell(1,4,3,"T")
            }),
            new Tetrimino(new List<Cell>() {
                new Cell(1,3,4,"L"), new Cell(1,4,4,"L"), new Cell(1,5,4,"L"), new Cell(0,5,4,"L")
            }),
            new Tetrimino(new List<Cell>() {
                new Cell(1,3,5,"J"), new Cell(1,4,5,"J"), new Cell(1,5,5,"J"), new Cell(0,3,5,"J")
            }),
            new Tetrimino(new List<Cell>() {
                new Cell(0,3,6,"Z"), new Cell(0,4,6,"Z"), new Cell(1,4,6,"Z"), new Cell(1,5,6,"Z")
            }),
            new Tetrimino(new List<Cell>() {
                new Cell(1,3,7,"S"), new Cell(1,4,7,"S"), new Cell(0,4,7,"S"), new Cell(0,5,7,"S")
            }),
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

    public void MoveAt(int pX, int pY)
    {
        Position = new Vector2(pX, pY);
    }
    //* public void rotate() {

    //* }
}