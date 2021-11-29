namespace Tetris.Code;

public class Cell {
    public int val = 0;
    public int posX;
    public int posY;

    public Cell(int x, int y) {
        this.posX = x;
        this.posY = y;
    }

    public void fill(int newVal){
        this.val = newVal;
    }
}