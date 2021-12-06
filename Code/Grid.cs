namespace Tetris.Code;

public class Grid{
    private int width = 10;
    private int height = 20;
    public List<Cell> grid = new List<Cell>();

    public List<Tetrimino> tetriminos = new List<Tetrimino>();

    public Grid() {
        createGrid();
        Tetrimino.initAllTetriminos();
    }

    public void addTetrimino(Tetrimino tetrimino) {
        this.createGrid();
        this.tetriminos.Add(tetrimino);
        this.setTetriminosOnGrid();
        // Tetrimino.allTetriminos!.ForEach(tetrimino => tetrimino.tetriminoCells!.ForEach(cell => Console.WriteLine("({0}, {1})", cell.posX, cell.posY)));
    }

    public void createGrid() {
        grid = new List<Cell>();
        for (int i = 0; i < height; i++)
        {
            for(int j = 0; j < width; j++) {
                this.grid.Add(new Cell(i, j));
            }
        }
    }

    public void setTetriminosOnGrid() {
        foreach (var tetrimino in this.tetriminos)
        {
            foreach (var cell in tetrimino.tetriminoCells!)
            {
                this.grid[cell.posX*10 + cell.posY] = cell;
            }
        }
    }

    public int getHeight() {
        return this.height;
    }

    public int getWidth() {
        return this.width;
    }

    public int GetFullLine() {
        bool lineFull = true;
        grid = new List<Cell>();
        for (int line = width - 1; line >= 0; line--) 
        {
        lineFull = true;
            for (int col = 0; col < height; col++)
                {
                    int ID = height;
                    if (ID == -1)
                        lineFull = false;
                }
                if (lineFull)
                    return line;
            }
        return "is full"
    }
}