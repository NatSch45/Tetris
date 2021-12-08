namespace Tetris.Code;

/// <summary>Contains static methods to use every round</summary>
public class Round {

    public Round(){}
    
    /// <summary>Check if the grid is full and so the game is over</summary>
    /// <param name="gridObject">Grid to check</param>
    /// <param name="tetrimino">Last tetrimino to set on the grid</param>
    /// <returns>true if the game is over, else otherwise</returns>
    public static bool isGameOver(Grid gridObject, Tetrimino tetrimino) {
        bool igo = false;
        foreach (var cell in tetrimino.tetriminoCells!)
        {
            if (gridObject.grid[cell.posX * gridObject.getWidth() + cell.posY].getValue() != 0) {
                igo = !igo;
            }
        }
        return igo;
    }

    /// <summary>Check if lines are full, if it is, delete lines and drop lines above</summary>
    /// <param name="gridObject">Grid to check</param>
    public static void checkFullLines(Grid gridObject) {
        List<Cell> subList = new List<Cell>();
        int index = 0;
        bool isFull = true;

        foreach (var cell in gridObject.grid)
        {
            if (subList.Count == gridObject.getWidth()) {
                subList.ForEach(cell => {
                    if (cell.getValue() == 0) {
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
            if (cell.getValue() == 0) {
                isFull = false;
            }
        });

        if (isFull) {
            removeLine(gridObject, index);
            return;
        }
    }

    /// <summary></summary>
    /// <param name="gridObject">Grid that contains lines to remove</param>
    /// <param name="index">Index of the line to remove</param>
    public static void removeLine(Grid gridObject, int index) {
        Console.WriteLine("Remove line at {0}", index);
        int gridWidth = gridObject.getWidth();

        gridObject.grid.Reverse();
        foreach (var cell in gridObject.grid)
        {
            int pos = cell.posX*gridWidth + cell.posY - gridWidth;

            if(cell.posX == index || cell.posX == 0) {
                cell.fill(0);
                cell.name = "none";
            } else if (cell.posX < index) {
                gridObject.grid[pos].fill(cell.getValue());
                gridObject.grid[pos].name = cell.name;
            }
        }
        gridObject.grid.Reverse();
    }
}