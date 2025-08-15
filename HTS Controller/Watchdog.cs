using System.Runtime.CompilerServices;
using System.Timers;

public class Watchdog
{
    private Timer _timer;

    public Watchdog(double timeout, ElapsedEventHandler elapsedEventHandler)
    {
        _timer = new Timer(timeout);
        _timer.AutoReset = false; // Set to false to fire only once per timeout
        _timer.Elapsed += elapsedEventHandler;
    }

    public void Start()
    {
        _timer.Start();
    }

    public void Stop()
    {
        _timer.Stop();
    }
}