namespace Tetris.Code;
public class Timer {
    private static System.Timers.Timer? timer;

    public static void RunTimer()
    {
        SetTimer();

        Console.WriteLine("\nPress the Enter key to exit the game...\n");
        // Console.ReadLine();
        // timer!.Stop();
        // timer.Dispose();
        
        // Console.WriteLine("Terminating the game...");
    }
    private static void SetTimer()
    {
        // Create a timer with a four seconds interval.
        timer = new System.Timers.Timer(4000);
        // Hook up the Elapsed event for the timer. 
        timer.Elapsed += dropTetrimino!;
        timer.AutoReset = true;
        timer.Enabled = true;
    }

    private static void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e) {
        Console.WriteLine("The Elapsed event was raised at {0:HH:mm:ss.fff}", e.SignalTime);
    }

    private static void dropTetrimino(Object source, System.Timers.ElapsedEventArgs e) {
        if (Game.gridObject.tetriminos.Any()) {
            Game.gridObject.tetriminos[Game.gridObject.tetriminos.Count - 1].drop(Game.gridObject);
        }
        Game.gridObject.createGrid();
        Game.gridObject.setTetriminosOnGrid();
        Console.WriteLine("Drop");
        timer!.Stop();
        timer.Dispose();
    }
}