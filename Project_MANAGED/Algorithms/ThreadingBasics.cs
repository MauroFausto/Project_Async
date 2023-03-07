using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_MANAGED.Algorithms
{
    public class ThreadingBasics : IDisposable
    {
        private bool disposedValue;

        public ThreadingBasics() { }

        public Task<bool> IsRunning { get; set; }

        public void Run()
        {
            Console.WriteLine("Olá mundo assíncrono!\r\n");

            var bgThread = new Thread(() =>
            {
                while (true) 
                {
                    bool isNetworkUp = NetworkInterface.GetIsNetworkAvailable();
                    Console.WriteLine($"A conexão de rede está online? Resposta: {isNetworkUp}");
                    Thread.Sleep( 100 );
                }
            });

            bgThread.IsBackground = true;
            bgThread.Start();

            for (int i = 0; i < 10; i++) 
            {
                Console.WriteLine("Thread principal trabalhando...");
                Task.Delay(500);
            }

            Console.WriteLine("Terminou!");
            Console.ReadKey();
        }

        #region [  Disposable properties and methods  ]

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~ThreadingBasics()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
