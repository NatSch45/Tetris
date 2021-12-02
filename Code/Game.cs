namespace Tetris.Code;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
public class Game : ComponentBase {

    public Grid gridObject = new Grid();

    public Game() {}

    protected override Task OnInitializedAsync()
    {
        return base.OnInitializedAsync();
    }

    public void setTetrimino() {
        Random rnd = new Random();
        Tetrimino tetrimino = new Tetrimino();
        tetrimino.chooseTetrimino(rnd.Next(7));

        this.gridObject.addTetrimino(tetrimino);
    }

    public void moveTetrimino(bool isRight) {
        if (this.gridObject.tetriminos.Any()) {
            this.gridObject.tetriminos[this.gridObject.tetriminos.Count - 1].moveX(gridObject, isRight);
        }
    }

    public List<Cell> getGrid() {
        return this.gridObject.grid;
    }
}