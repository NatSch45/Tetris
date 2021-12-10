namespace Tetris.Code;

/// <summary>Base element, used to construct grids or tetriminos</summary>
public class Cell {
    public int posX;
    public int posY;

    /// <value>Value of cell : 0 if belongs to no tetrimino, from 1 to 7 if it does</value>
    private int value;

    /// <value>Name of cell, associate with its value : css use only (as class name)</value>
    public string? name;

    public Cell(int x, int y, int val = 0, string name = "none") {
        this.posX = x;
        this.posY = y;
        this.value = val;
        this.name = name;
    }

    /// <summary>Fill the value property of Cell</summary>
    /// <param name="newValue">New value assigned to cell</param>
    public void fill(int newValue){
        if (newValue >= 0 && newValue <= Tetrimino.allTetriminos!.Count) {
            this.value = newValue;
        } else {
            Console.WriteLine("ERROR: Fill value not correct (accepted values from 0 to 7)");
        }
    }

    /// <summary>Get value of grid</summary>
    public int getValue() {
        return this.value;
    }
}