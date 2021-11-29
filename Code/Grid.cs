namespace Tetris.Code;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

public class Grid : ComponentBase {
    public static int width = 10;
    public static int height = 20;
    public static List<Cell> grid = new List<Cell>();

    protected override Task OnInitializedAsync()
    {
        createGrid();
        return base.OnInitializedAsync();
    }

    public void createGrid() {
        grid = new List<Cell>();
        for (int i = 0; i < height; i++)
        {
            for(int j = 0; j < width; j++) {
                Grid.grid.Add(new Cell(i, j));
            }
        }
    }
}