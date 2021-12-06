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

}