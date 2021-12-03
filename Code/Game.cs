namespace Tetris.Code;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
public class Game : ComponentBase {

    public static Grid gridObject = new Grid();

    public bool isEndOfCourse;

    public Game() {}

    public void setTetrimino() {
        Tetrimino.initAllTetriminos();
        Random rnd = new Random();
        Tetrimino tetrimino = new Tetrimino();
        tetrimino.chooseTetrimino(rnd.Next(7));

        Game.gridObject.addTetrimino(tetrimino);
        Round.checkFullLines(gridObject);
    }

    public void moveTetrimino(bool isRight) {
        if (Game.gridObject.tetriminos.Any()) {
            Game.gridObject.tetriminos[Game.gridObject.tetriminos.Count - 1].move(Game.gridObject, isRight);
        }
        Game.gridObject.createGrid();
        Game.gridObject.setTetriminosOnGrid();
    }

    public void dropTetrimino() {
        if (Game.gridObject.tetriminos.Any()) {
            isEndOfCourse = Game.gridObject.tetriminos[Game.gridObject.tetriminos.Count - 1].drop(Game.gridObject);
        }
        Game.gridObject.createGrid();
        Game.gridObject.setTetriminosOnGrid();
    }

    public void rotateTetrimino() {
        if (Game.gridObject.tetriminos.Any()) {
            Game.gridObject.tetriminos[Game.gridObject.tetriminos.Count - 1].rotate(Game.gridObject);
        }
        Game.gridObject.createGrid();
        Game.gridObject.setTetriminosOnGrid();
    }

    public List<Cell> getGrid() {
        return Game.gridObject.grid;
    }
}