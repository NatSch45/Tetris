namespace Tetris.Code;

public class Round {

    public Round(){}
    public static bool isGameOver(Grid gridObject, Tetrimino tetrimino) {
        bool igo = false;
        foreach (var cell in tetrimino.tetriminoCells!)
        {
            if (gridObject.grid[cell.posX * gridObject.getWidth() + cell.posY].val != 0) {
                igo = !igo;
            }
        }
        return igo;
    }

    public static void checkFullLines(Grid gridObject) {
        List<Cell> subList = new List<Cell>();
        int index = 0;
        bool isFull = true;

        foreach (var cell in gridObject.grid)
        {
            if (subList.Count == gridObject.getWidth()) {
                subList.ForEach(cell => {
                    if (cell.val == 0) {
                        isFull = false;
                    }
                });

                if (isFull) {
                    Console.WriteLine("A line is full");
                    removeLine(gridObject, index);
                    checkFullLines(gridObject);
                }
                subList = new List<Cell>();
                isFull = true;
                index++;
            }
            subList.Add(cell);
        }
        
        subList.ForEach(cell => {
            if (cell.val == 0) {
                isFull = false;
            }
        });

        if (isFull) {
            removeLine(gridObject, index);
            return;
        }
    }

    public static void removeLine(Grid gridObject, int index) {
        Console.WriteLine("Remove line at {0}", index);
        int gridWidth = gridObject.getWidth();

        gridObject.grid.Reverse();
        foreach (var cell in gridObject.grid)
        {
            int pos = cell.posX*gridWidth + cell.posY - gridWidth;

            if(cell.posX == index || cell.posX == 0) {
                cell.val = 0;
                cell.name = "none";
            } else if (cell.posX < index) {
                gridObject.grid[pos].val = cell.val;
                gridObject.grid[pos].name = cell.name;
            }
        }
        gridObject.grid.Reverse();
    }
}