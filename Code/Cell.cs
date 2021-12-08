namespace Tetris.Code;

public class Cell {
    public int val; // Value of cell : 0 if belongs to no tetrimino, from 1 to 7 if it does
    public int posX;
    public int posY;

    public string? name; // Name of cell, associate with its value : css use only (as class name)

    public Cell(int x, int y, int val = 0, string name = "none") {
        this.posX = x;
        this.posY = y;
        this.val = val;
        this.name = name;
    }

        public void fill(int newVal){
        if (newVal >= 0 && newVal <= Tetrimino.allTetriminos!.Count) {
            this.val = newVal;
        } else {
            Console.WriteLine("ERROR: Fill value not correct (accepted values from 0 to 7)");
        }
    }
}