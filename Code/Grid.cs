namespace Tetris.Code;

/// <summary>Represents a grid that contains all cells and actions to use on it</summary>
public class Grid{
    private int width = 10;
    private int height = 20;
    /// <value>List of cells that represent the grid</value>
    public List<Cell> grid = new List<Cell>();
    /// <value>List of tetriminos associated to grid</value>
    public List<Tetrimino> tetriminos = new List<Tetrimino>();

    public Grid() {
        createGrid();
        Tetrimino.initAllTetriminos();
    }

    /// <summary>Set the tetrimino passed as parameter on the grid</summary>
    /// <param name="tetrimino">New tetrimino which be added to grid</param>
    public void addTetrimino(Tetrimino tetrimino) {
        this.createGrid();
        this.tetriminos.Add(tetrimino);
        this.setTetriminosOnGrid();
    }

    /// <summary>Create and so initialize grid with empty cells</summary>
    public void createGrid() {
        grid = new List<Cell>();
        for (int i = 0; i < height; i++)
        {
            for(int j = 0; j < width; j++) {
                this.grid.Add(new Cell(i, j));
            }
        }
    }

    /// <summary>Set tetriminos of "tetriminos" property on the grid</summary>
    public void setTetriminosOnGrid() {
        foreach (var tetrimino in this.tetriminos)
        {
            foreach (var cell in tetrimino.tetriminoCells!)
            {
                this.grid[cell.posX*width + cell.posY] = cell;
            }
        }
    }

    /// <summary>Get height of grid</summary>
    public int getHeight() {
        return this.height;
    }

    /// <summary>Get width of grid</summary>
    public int getWidth() {
        return this.width;
    }
}