namespace Tetris.Code;

/// <summary>Represents a tetrimino, composed by a list of cells, and contains all actions and mouvements of it</summary>
public class Tetrimino {
    /// <value>List of cells contained in the tetrimino</value>
    public List<Cell>? tetriminoCells;

    // Coordinates of center of tetrimino, used for rotation
    public double tetriminoCenterX;
    public double tetriminoCenterY;
    /// <value>List of all 7 tetriminos in their initialized coordinates</value>
    public static List<Tetrimino>? allTetriminos;

    public Tetrimino() {
        this.tetriminoCells = new List<Cell>();
    }

    public Tetrimino(List<Cell> cells, double bcx, double bcy) {
        this.tetriminoCells = cells;
        this.tetriminoCenterX = bcx;
        this.tetriminoCenterY = bcy;
    }

    /// <summary>Pick informations of a random tetrimino in allTetriminos</summary>
    /// <param name="index">Random value from 0 to 6</param>
    public void chooseTetrimino(int index) {
        this.tetriminoCells = allTetriminos![index].tetriminoCells!;
        this.tetriminoCenterX = allTetriminos![index].tetriminoCenterX;
        this.tetriminoCenterY = allTetriminos![index].tetriminoCenterY;
    }

    public void sendToGrid(Grid grid) {
        grid.addTetrimino(this);
    }

    /// <summary>Initialize list of allTetriminos variable</summary>
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

    /// <summary>Move tetrimino in horizontal directions one cell (on x axis)</summary>
    /// <param name="gridObject">Grid that contains the tetrimino</param>
    /// <param name="isRight">Equals to true if tetrimino vove to right, false otherwise</param>
    public void move(Grid gridObject, bool isRight) { 
        bool isGoodMove = true;
        foreach (var cell in tetriminoCells!)
        {
            if((isRight && cell.posY >= gridObject.getWidth() - 1) || (!isRight && cell.posY <= 0)) {
                isGoodMove = false;
                break;
            }
        }
        this.tetriminoCells.ForEach(cell => {
            if(gridObject.grid[cell.posX*10 + cell.posY + (isRight ? 1 : -1)].getValue() != 0 && !tetriminoCells.Contains(gridObject.grid[cell.posX *10 + cell.posY + (isRight ? 1 : -1)])) {
                isGoodMove = false;
            }
        });
        if (isGoodMove && isRight) {
            tetriminoCells.ForEach(cell => cell.posY++);
            tetriminoCenterY++;
        } else if (isGoodMove && !isRight) {
            tetriminoCells.ForEach(cell => cell.posY--);
            tetriminoCenterY--;
        }
    }

    /// <summary>Drop tetrimino one cell</summary>
    /// <param name="gridObject">Grid that contains the tetrimino</param>
    /// <returns>true if drop does not success, false otherwise</returns>
    public bool drop(Grid gridObject) {
        bool isGoodDrop = true;
        int gridWidth = gridObject.getWidth();
        int gridHeight = gridObject.getHeight();

        foreach (var cell in tetriminoCells!) {
            if (cell.posX *gridWidth + cell.posY + gridWidth < gridWidth*gridHeight) {
                if (gridObject.grid[cell.posX *gridWidth + cell.posY + gridWidth].getValue() != 0 && !tetriminoCells.Contains(gridObject.grid[cell.posX *gridWidth + cell.posY + gridWidth])) {
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
            tetriminoCenterX++;
            return false;
        }
        return true;
    }

    /// <summary>Rotate tetrimino from 90 degrees right</summary>
    /// <param name="gridObject">Grid that contains the tetrimino</param>
    public void rotate(Grid gridObject) {
        int gridWidth = gridObject.getWidth();
        int gridHeight = gridObject.getHeight();
        double angle = Math.PI/2; // 90° right angle value

        List<Cell> testCells = new List<Cell>();
        foreach (var cell in this.tetriminoCells!)
        {
            double valX = cell.posX - tetriminoCenterX;
            double valY = cell.posY - tetriminoCenterY;
            valY = -valY;
            int testX = (int)Math.Round((valX * Math.Cos(angle) - valY * Math.Sin(angle))+tetriminoCenterX);
            int testY = (int)Math.Round((-(valX * Math.Sin(angle) + valY * Math.Cos(angle)))+tetriminoCenterY);
            if (!(testX >= 0 && testX <= (gridHeight-1)) || !(testY >= 0 && testY <= (gridWidth-1))) {
                return;
            } else {
                testCells.Add(new Cell(testX, testY, cell.getValue(), cell.name!));
            }
        }
        testCells.ForEach(cell => {
            if (cell.posX*gridWidth + cell.posY <= gridWidth+gridHeight) {
                if (gridObject.grid[cell.posX*gridWidth + cell.posY].getValue() != 0 && !tetriminoCells.Contains(gridObject.grid[cell.posX *gridWidth + cell.posY])) {
                    return;
                }
            }
        });
        this.tetriminoCells = testCells;
    }
}