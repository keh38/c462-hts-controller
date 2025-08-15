using System;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

public class Watchdog
{
    private Timer _timer;

    public Watchdog(EventHandler elapsedEventHandler, double timeout = 5)
    {
        _timer = new Timer();
        _timer.Interval = (int)(timeout * 1000);
        _timer.Tick += OnTimerTick;
        _timer.Tick += elapsedEventHandler;
    }

    public void Start()
    {
        _timer.Start();
    }

    public void Stop()
    {
        _timer.Stop();
    }

    private void OnTimerTick(object sender, EventArgs e)
    {
        _timer.Stop();
    }
}