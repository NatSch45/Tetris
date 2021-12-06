namespace Tetris.Code;

public class Cell {
    public int val = 0;
    public int posX;
    public int posY;

    public string? name;

    public Cell(int x, int y, int val = 0, string name = "none") {
        this.posX = x;
        this.posY = y;
        this.val = val;
        this.name = name;
    }

    public void fill(int newVal){
        this.val = newVal;
    }
}