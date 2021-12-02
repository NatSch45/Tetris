namespace Tetris.Code;
public class Timer {
    private static System.Timers.Timer? timer;

    public static void RunTimer()
    {
        SetTimer();

        Console.WriteLine("\nPress the Enter key to exit the application...\n");
        Console.WriteLine("The application started at {0:HH:mm:ss.fff}", DateTime.Now);
        Console.ReadLine();
        timer!.Stop();
        timer.Dispose();
        
        Console.WriteLine("Terminating the application...");
    }
    private static void SetTimer()
    {
        // Create a timer with a two second interval.
        timer = new System.Timers.Timer(2000);
        // Hook up the Elapsed event for the timer. 
        timer.Elapsed += OnTimedEvent!;
        timer.AutoReset = true;
        timer.Enabled = true;
    }

    private static void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e) {
        Console.WriteLine("The Elapsed event was raised at {0:HH:mm:ss.fff}", e.SignalTime);
    }
}