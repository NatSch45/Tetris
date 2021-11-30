namespace Tetris.Code;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

public class Grid : ComponentBase {
    private int width = 10;
    private int height = 20;
    public List<Cell> grid = new List<Cell>();

    public List<Tetrimino> tetriminos = new List<Tetrimino>();

    public Grid() : base() {
    }

    protected override Task OnInitializedAsync()
    {
        createGrid();
        return base.OnInitializedAsync();
    }

    public void addTetrimino(Tetrimino tetrimino) {
        this.tetriminos.Add(tetrimino);
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

    public int getHeight() {
        return this.height;
    }

    public int getWidth() {
        return this.width;
    }
}