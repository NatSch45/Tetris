namespace Tetris.Code;

using Microsoft.AspNetCore.Components;

/// <summary>Represents the game, associate all classes needed with Game.razor (which inherits this class)</summary>
public class Game : ComponentBase {

    public static Grid gridObject = new Grid();

    /// <value>Boolean for game loop</value>
    public bool isRunning = true;

    /// <value>Boolean for tetrimino drop loop</value>
    public bool isEndOfCourse;

    /// <value>Delay for the execution of timer, in milliseconds</value>
    public int timerDelay = 800;

    public Game() {Tetrimino.initAllTetriminos();}

    /// <summary>Set a tetrimino on the grid and check for all round verifications</summary>
    public void setTetrimino() {
        Round.checkFullLines(Game.gridObject);

        Random rnd = new Random();
        Tetrimino tetrimino = new Tetrimino();
        tetrimino.chooseTetrimino(rnd.Next(Tetrimino.allTetriminos!.Count)); 
        isRunning = !Round.isGameOver(Game.gridObject, tetrimino);
        if (isRunning) {
            Game.gridObject.addTetrimino(tetrimino);
        }
    }

    /// <summary>Move the last tetrimino played on the grid</summary>
    /// <param name="isRight">Tetrimino move right if true and move left otherwise</param>
    public void moveTetrimino(bool isRight) {
        if (Game.gridObject.tetriminos.Any()) {
            Game.gridObject.tetriminos[Game.gridObject.tetriminos.Count - 1].move(Game.gridObject, isRight);
        }
        Game.gridObject.createGrid();
        Game.gridObject.setTetriminosOnGrid();
    }

    /// <summary>Drop the last tetrimino played on grid</summary>
    public void dropTetrimino() {
        if (Game.gridObject.tetriminos.Any()) {
            isEndOfCourse = Game.gridObject.tetriminos[Game.gridObject.tetriminos.Count - 1].drop(Game.gridObject);
        }
        Game.gridObject.createGrid();
        Game.gridObject.setTetriminosOnGrid();
    }

    /// <summary>Rotate the last tetrimino played on grid</summary>
    public void rotateTetrimino() {
        if (Game.gridObject.tetriminos.Any()) {
            Game.gridObject.tetriminos[Game.gridObject.tetriminos.Count - 1].rotate(Game.gridObject);
        }
        Game.gridObject.createGrid();
        Game.gridObject.setTetriminosOnGrid();
    }

    /// <summary>Get grid</summary>
    public List<Cell> getGrid() {
        return Game.gridObject.grid;
    }
}