namespace Tetris.Code;

public class Tetrimino {
    public List<Cell>? tetriminoCells;

    public double brickCenterX;
    public double brickCenterY;
    public static List<Tetrimino>? allTetriminos; // List of all 7 tetriminos in their initialized coordinates 

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

    public static void initAllTetriminos() { // Initialize list of allTetriminos variable
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
            if(grid.grid[cell.posX*10 + cell.posY + (isRight ? 1 : -1)].val != 0 && !tetriminoCells.Contains(grid.grid[cell.posX *10 + cell.posY + (isRight ? 1 : -1)])) {
                isGoodMove = false;
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

    public bool drop(Grid gridObject) {
        bool isGoodDrop = true;
        int gridWidth = gridObject.getWidth();
        int gridHeight = gridObject.getHeight();

        foreach (var cell in tetriminoCells!) {
            if (cell.posX *gridWidth + cell.posY + gridWidth < gridWidth*gridHeight) {
                if (gridObject.grid[cell.posX *gridWidth + cell.posY + gridWidth].val != 0 && !tetriminoCells.Contains(gridObject.grid[cell.posX *gridWidth + cell.posY + gridWidth])) {
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

    public void rotate(Grid gridObject) {
        int gridWidth = gridObject.getWidth();
        int gridHeight = gridObject.getHeight();
        double angle = Math.PI/2;

        List<Cell> testCells = new List<Cell>();
        foreach (var cell in this.tetriminoCells!)
        {
            double valX = cell.posX - brickCenterX;
            double valY = cell.posY - brickCenterY;
            valY = -valY;
            int testX = (int)Math.Round((valX * Math.Cos(angle) - valY * Math.Sin(angle))+brickCenterX);
            int testY = (int)Math.Round((-(valX * Math.Sin(angle) + valY * Math.Cos(angle)))+brickCenterY);
            if (!(testX >= 0 && testX <= (gridHeight-1)) || !(testY >= 0 && testY <= (gridWidth-1))) {
                return;
            } else {
                testCells.Add(new Cell(testX, testY, cell.val, cell.name!));
            }
        }
        testCells.ForEach(cell => {
            if (cell.posX*gridWidth + cell.posY <= gridWidth+gridHeight) {
                if (gridObject.grid[cell.posX*gridWidth + cell.posY].val != 0 && !tetriminoCells.Contains(gridObject.grid[cell.posX *gridWidth + cell.posY])) {
                    return;
                }
            }
        });
        this.tetriminoCells = testCells;
    }
}