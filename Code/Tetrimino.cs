using System.Numerics;
namespace Tetris.Code;

public class Tetrimino {
    public List<Cell>? tetriminoCells;

    public double brickCenterX;
    public double brickCenterY;
    public static List<Tetrimino>? allTetriminos;
    public Vector2 Position;

    public Tetrimino() {
        this.tetriminoCells = new List<Cell>();
    }

    public Tetrimino(List<Cell> cells, double bcx, double bcy) {
        
        this.tetriminoCells = cells;
        this.brickCenterX = bcx;
        this.brickCenterY = bcy;
    }

    public void chooseTetrimino(int index) {
        this.tetriminoCells = allTetriminos![index].tetriminoCells!;
        this.brickCenterX = allTetriminos![index].brickCenterX;
        this.brickCenterY = allTetriminos![index].brickCenterY;
    }

    public void sendToGrid(Grid grid) {
        grid.addTetrimino(this);
    }

    public static void initAllTetriminos() {
        Tetrimino.allTetriminos = new List<Tetrimino>() {
            new Tetrimino(new List<Cell>() {
                new Cell(0,3,1,"I"), new Cell(0,4,1,"I"), new Cell(0,5,1,"I"), new Cell(0,6,1,"I")
            }, 0.5, 4.5),
            new Tetrimino(new List<Cell>() {
                new Cell(1,4,2,"O"), new Cell(0,4,2,"O"), new Cell(0,5,2,"O"), new Cell(1,5,2,"O")
            }, 0.5, 4.5),
            new Tetrimino(new List<Cell>() {
                new Cell(1,3,3,"T"), new Cell(0,4,3,"T"), new Cell(1,5,3,"T"), new Cell(1,4,3,"T")
            }, 1, 4),
            new Tetrimino(new List<Cell>() {
                new Cell(1,3,4,"L"), new Cell(1,4,4,"L"), new Cell(1,5,4,"L"), new Cell(0,5,4,"L")
            }, 1, 4),
            new Tetrimino(new List<Cell>() {
                new Cell(1,3,5,"J"), new Cell(1,4,5,"J"), new Cell(1,5,5,"J"), new Cell(0,3,5,"J")
            }, 1, 4),
            new Tetrimino(new List<Cell>() {
                new Cell(0,3,6,"Z"), new Cell(0,4,6,"Z"), new Cell(1,4,6,"Z"), new Cell(1,5,6,"Z")
            }, 1, 4),
            new Tetrimino(new List<Cell>() {
                new Cell(1,3,7,"S"), new Cell(1,4,7,"S"), new Cell(0,4,7,"S"), new Cell(0,5,7,"S")
            }, 1, 4),
        };
    }

    public void move(Grid grid, bool isRight) {
        bool isGoodMove = true;
        foreach (var cell in tetriminoCells!)
        {
            if((isRight && cell.posY >= grid.getWidth() - 1) || (!isRight && cell.posY <= 0)) {
                isGoodMove = false;
                break;
            }
        }
        this.tetriminoCells.ForEach(cell => {
            if (isRight) {
                cell.posY++;
                if (cell.val != 0) {
                    cell.posY--;
                    return;
                }
                cell.posY--;
            } else {
                cell.posY--;
                if (cell.val != 0) {
                    cell.posY++;
                    return;
                }
                cell.posY++;
            }
        });
        if (isGoodMove && isRight) {
            tetriminoCells.ForEach(cell => cell.posY++);
            brickCenterY++;
        } else if (isGoodMove && !isRight) {
            tetriminoCells.ForEach(cell => cell.posY--);
            brickCenterY--;
        }
    }

    public bool drop(Grid grid) {
        bool isGoodDrop = true;

        foreach (var cell in tetriminoCells!) {
            if (cell.posX *10 + cell.posY + 10 <= 200) {
                if (grid.grid[cell.posX *10 + cell.posY + 10].val != 0 && !tetriminoCells.Contains(grid.grid[cell.posX *10 + cell.posY + 10])) {
                    isGoodDrop = false;
                    break;
                }
            } else {
                isGoodDrop = false;
                break;
            }
        }
        if (isGoodDrop) {
            tetriminoCells.ForEach(cell => cell.posX++);
            brickCenterX++;
            return false;
        }
        return true;
    }

    public void rotate(Grid grid) {
        List<Cell> testCells = new List<Cell>();
        foreach (var cell in this.tetriminoCells!)
        {
            double valX = cell.posX - brickCenterX;
            double valY = cell.posY - brickCenterY;
            valY *= -1;
            int testX = (int)Math.Round((valX * Math.Cos(Math.PI/2) - valY * Math.Sin(Math.PI/2))+brickCenterX);
            int testY = (int)Math.Round(((valX * Math.Sin(Math.PI/2) + valY * Math.Cos(Math.PI/2)) * -1)+brickCenterY);
            if (!(testX >= 0 && testX <= 19) || !(testY >= 0 && testY <= 9)) {
                return;
            } else {
                testCells.Add(new Cell(testX, testY, cell.val, cell.name!));
            }
        }
        testCells.ForEach(cell => {
            if (cell.posX*10 + cell.posY <= 200) {
                if (grid.grid[cell.posX*10 + cell.posY].val != 0) {
                    return;
                }
            }
        });
        this.tetriminoCells = testCells;
    }
}