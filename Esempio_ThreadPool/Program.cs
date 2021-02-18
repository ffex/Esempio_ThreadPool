using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Esempio_ThreadPool
{
    class Program
    {

        static void Main(string[] args)
        {
            //Oggetto usato per misurari i tempi di esecuzione
            Stopwatch mywatch = new Stopwatch();
            
            Console.WriteLine("Esecuzione Thread Pool");

            mywatch.Start(); // avvia il cronometro
            UsoThreadPool();
            mywatch.Stop();// stoppa il cronometro

            Console.WriteLine("Tempo ThreadPool usato: " + mywatch.ElapsedTicks.ToString());
            mywatch.Reset();


            Console.WriteLine("Esecuzione Thread");
            
            mywatch.Start();// avvia il cronometro
            UsoThread();
            mywatch.Stop();// stoppa il cronometro

            Console.WriteLine("Tempo Thread usato: " + mywatch.ElapsedTicks.ToString());
            Console.Read();
        }
        static void UsoThread()
        {
            for (int i = 0; i <= 10; i++)
            {
                Thread t1 = new Thread(Ricerca);
                t1.Start();
            }
        }
        static void UsoThreadPool()
        {
            for (int i = 0; i <= 10; i++)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(Ricerca));
            }
        }
        //per usare il metodo nel ThreadPool va intestato il metodo con questo parametro
        static void Ricerca(object callback)
        {
            // qua metto una qualsiasi esecuzione lunga
            
            for (int i = 0; i < 10000; i++)
            {
                //non faccio niente ma un pò di tempo ce lo mette
            }
            
        }

    }
}
