using DevExpress.Mvvm;
using System;
using System.Threading;

namespace CatalogCars.DesktopApplication.Services
{
    public class ImportTimer : BindableBase
    {
        private bool _isTick;
        private Thread _thread;

        public DateTime StartDateTime { get; private set; }

        public TimeSpan Duration { get; private set; }

        public ImportTimer()
        {
            _isTick = false;
            _thread = new Thread(new ThreadStart(Tick));

            StartDateTime = new DateTime();
            Duration = new TimeSpan();
        }

        private void Reset()
        {
            _isTick = false;

            Duration = new TimeSpan();
        }

        private void Tick()
        {
            _isTick = true;

            StartDateTime = DateTime.Now;

            while (_thread.ThreadState == ThreadState.Running)
            {
                if (_isTick)
                {
                    Duration = DateTime.Now - StartDateTime;

                    Thread.Sleep(50);
                }
                else
                {
                    break;
                }
            }
        }

        public void Start()
        {
            _thread.Start();
        }

        public void Stop()
        {
            Reset();
        }
    }
}
