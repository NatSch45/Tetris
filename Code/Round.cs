namespace Tetris.Code;

public class Round {

    public Round(){}
    public static bool isGameOver(Grid gridObject) {
        return gridObject.grid[20 * 4].val != 0;
    }

    public static void checkFullLines(Grid gridObject) {
        List<Cell> subList = new List<Cell>();
        int index = 0;
        bool isFull = true;

        foreach (var cell in gridObject.grid)
        {
            if (subList.Count == 10) {
                subList.ForEach(cell => {
                    Console.WriteLine(cell.val);
                    if (cell.val == 0) {
                        isFull = false;
                    }
                });
                Console.WriteLine();

                if (isFull) {
                    Console.WriteLine("Here");
                    removeLine(gridObject, index);
                    checkFullLines(gridObject);
                }
                subList = new List<Cell>();
            } else {
                subList.Add(cell);
            }
            index++;
        }
    }

    public static void removeLine(Grid gridObject, int index) {
        foreach (var cell in gridObject.grid)
        {
            if(cell.posX == index) {
                cell.name = "none";
                cell.val = 0;
            } else if (cell.posX > index) {
                gridObject.grid[cell.posX*10 + cell.posY - 10].val = cell.val;
                gridObject.grid[cell.posX*10 + cell.posY - 10].name = cell.name;
            }
        }
    }
}