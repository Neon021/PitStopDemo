using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Practice1
{
    class Async
    {
        static async Task Main(string[] args)
        {
            await PitLane();

            Console.WriteLine("Guido, it's your turn");
            Console.WriteLine();

            

            Console.WriteLine();
            Console.WriteLine("Pit stop (in Italian accent)");

        }

        public static async Task<bool> PitLane()
        {
            Console.WriteLine("Car in the pit lane");
            await Task.Delay(5000);
            Console.WriteLine("Car has come");
            return true;
        }

        public static async Task<bool> TyreChanges(IProgress<ProgressReportModel> progress)
        {
            ProgressReportModel reportModel = new ProgressReportModel();

             static async Task<bool> FrontLeftPit()
            {
                Console.WriteLine("Taking out front left tire");
                await Task.Delay(1000);
                Console.WriteLine("Inserting new tire");
                await Task.Delay(1000);
                return true;
            }
             static async Task<bool> RearLeftPit()
            {
                Console.WriteLine("Taking out rear left tire");
                await Task.Delay(1000);
                Console.WriteLine("Inserting new tire");
                await Task.Delay(1000);
                return true;
            }
             static async Task<bool> FrontRightPit()
            {
                Console.WriteLine("Taking out front right tire");
                await Task.Delay(1000);
                Console.WriteLine("Inserting new tire");
                await Task.Delay(1000);
                return true;
            }
             static async Task<bool> RearRightPit()
            {
                Console.WriteLine("Taking out rear right tire");
                await Task.Delay(1000);
                Console.WriteLine("Inserting new tire");
                await Task.Delay(1000);
                return true;
            }

            
            var pitstopTasks = new List<Task> { FrontLeftPit(), RearLeftPit(), FrontRightPit(), RearRightPit() };
            
            await Task.WhenAll(pitstopTasks);

            List<Task> progressBar = new List<Task>();
            progressBar.Add(await Task.WhenAny(pitstopTasks));

            reportModel.PercentageComplete = progressBar.Count * 100 / 4;
            progress.Report(reportModel);

            return true;
        }
 
    }

}
