using System.Diagnostics;
using System.Threading.Tasks;
using Session04C_AdvancedG01.Helpers;
using Session04C_AdvancedG02.Helpers;

namespace Session04C_AdvancedG02
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            #region Part 01 

            #region Problem with Synchronous Code
            //SyncDataService syncData = new();
            //Stopwatch SW = Stopwatch.StartNew();
            //Console.WriteLine("Executing 3 Operations Synchronously");
            //string Result01 = syncData.FetchDataFromDatabase();// Block 2 s
            //string Result02 = syncData.FetchDataFromApi();// Block 1.5
            //string Result03 = syncData.ProcessData(Result01); //1 s

            //SW.Stop();
            //Console.WriteLine($"Total Time:{SW.ElapsedMilliseconds}MS");
            ////2000+1000+1500 (Thread Is Blocked (Can Not Do Ay Thing)
            //// UI Freezes In Desktop Apps




            #endregion

            #region The Solution: async/await

            //AsyncDataService asyncData = new();
            //Stopwatch SW = Stopwatch.StartNew();
            //Console.WriteLine("Executing Operations Asynchronsuly");
            //string AsyncResult01 = await asyncData.FetchDataFromDatabaseAsync();
            //string AsyncResult02 = await asyncData.FetchDataFromApiAsync();
            //string AsyncResult03 = await asyncData.ProcessDataAsync(AsyncResult01);

            //SW.Stop();

            //Console.WriteLine($"Total Time:{SW.ElapsedMilliseconds}ms");
            //// Thread Was Free To Do Other Work  While  Waiting
            // // This Is Async  But Not Parallel

            #endregion

            #endregion

            #region Part 02 - Task

            #region Task in .NET
            //TaskExamples taskExamples = new();
            //Console.WriteLine("Task(No Return Value):");
            //await taskExamples.DoWorkAsync();

            //Console.WriteLine("Task<int>(Returns Int)");
            //int Sum = await taskExamples.CalculateAsync(5, 3);
            //Console.WriteLine($"CalculateAsync(5,3)= {Sum}");

            //Console.WriteLine("ValueTask<string>");
            //Stopwatch SW = Stopwatch.StartNew();
            //string Cashed = await taskExamples.GetCachedValueAsync(100);
            //Console.WriteLine($"GetCashedValueAsync(Cashed)={Cashed}");
            //SW.Stop();
            //Console.WriteLine($"Total Time:{SW.ElapsedMilliseconds}ms");
            //SW.Restart();
            //Cashed = await taskExamples.GetCachedValueAsync(10);
            //Console.WriteLine($"GetCashedValueAsync(Cashed)={Cashed}");
            //SW.Stop();
            //Console.WriteLine($"Total Time:{SW.ElapsedMilliseconds}ms");


            #endregion

            #region Task States
            //Task<int> FirstTask = Task.Run(async () =>
            //{
            //    await Task.Delay(100);
            //    return 42;

            //});
            //Console.WriteLine($"Task Status:{FirstTask.Status}");
            //await FirstTask;
            //Console.WriteLine($"Task Status:{FirstTask.Status}");
            //Console.WriteLine($"Is Compleleted:{FirstTask.IsCompleted}");
            //Console.WriteLine($"Is CompleletedSuccessFully:{FirstTask.IsCompletedSuccessfully}");
            //Console.WriteLine($"Result:{FirstTask.Result}");
            #endregion

            #endregion

            #region Part 03 - Async and await
            //Console.WriteLine($"[{Environment.CurrentManagedThreadId}]Before await");
            //string Greeting = await GetGreetingAsync("World");
            //Console.WriteLine($"[{Environment.CurrentManagedThreadId}]After await");
            //Console.WriteLine($"Result:{Greeting}");

            ////-----------------------------
            //Console.WriteLine("========================");
            //Console.WriteLine($"[{Environment.CurrentManagedThreadId}] Before await");
            //Task Greeting02 = GetGreetingAsync("World");// Task Started But We didn't
            //Console.WriteLine($"Result:{Greeting02}");
            //Console.WriteLine($"Task.IsCompleleted:{Greeting02.IsCompleted}");

            #endregion

            #region Part 04 Task Advanced Patterns

            #region Task.WhenAll - Parallel Execution
            //AsyncDataService asyncData = new();
            //Stopwatch SW = Stopwatch.StartNew();

            //Console.WriteLine("Executing Operations asyncronounsly");
            //Console.WriteLine("Sequential Execution(One After Another)");

            //string AsyncResult01 = await asyncData.FetchDataFromDatabaseAsync();
            //string AsyncResult02 = await asyncData.FetchDataFromApiAsync();
            //string AsyncResult03 = await asyncData.ProcessDataAsync(AsyncResult01);

            //SW.Stop();
            //Console.WriteLine($"Sequential Total Time:{SW.ElapsedMilliseconds}ms");
            //Console.WriteLine("Results");
            //Console.WriteLine(AsyncResult01);
            //Console.WriteLine(AsyncResult02);
            //Console.WriteLine(AsyncResult03);
            //// Thread Was Free To Do Other  Work While Waiting
            //// This Is async But Not Parallel
            //SW.Restart();
            //Console.WriteLine("Parallel Execution With  Task.WhenAll");
            //Task<string> Task01 = asyncData.FetchDataFromDatabaseAsync();
            //Task<string> Task02 = asyncData.FetchDataFromApiAsync();
            //Task<string> Task03 = asyncData.ProcessDataAsync(AsyncResult01);

            //string[] Results = await Task.WhenAll(Task01, Task02, Task03);
            //Console.WriteLine($"Parallel Time:{SW.ElapsedMilliseconds}ms");
            //Console.WriteLine("Results");
            //Console.WriteLine(Results[0]);
            //Console.WriteLine(Results[1]);
            //Console.WriteLine(Results[2]);
            #endregion

            #region Task.WhenAny - First to Complete
            //AsyncDataService asyncData = new();
            //Task<string> Server01 = asyncData.DownloadImageAsync("Server01.Com", 1500);
            //Task<string> Server02 = asyncData.DownloadImageAsync("Server02.Com", 800);
            //Task<string> Server03 = asyncData.DownloadImageAsync("Server03.Com", 1200);
            //Task<string> Winner = await Task.WhenAny(Server01, Server02, Server03);
            //Console.WriteLine($"Winner:{await Winner}");
            ////---------------------
            //Console.WriteLine("=======================");
            //Console.WriteLine("TimeOut Pattern");
            //Task<string> SlowTask = asyncData.DownloadImageAsync("Slow.Com", 5000);
            //Task TimeOutTask = Task.Delay(1000);
            //Task CompleletedTask = await Task.WhenAny(SlowTask, TimeOutTask);
            // if(CompleletedTask==TimeOutTask)
            //{
            //    Console.WriteLine("Operation Timed Out");
            //}
            //else
            //{
            //    Console.WriteLine($"Compleleted:{await SlowTask}");
            //}
            #endregion

            #region Exception Handling in Async
            //try
            //{
            //    await ThrowingMethodsAsync();
            //}
            // catch(InvalidOperationException Ex)
            //{
            //    Console.WriteLine($"Caught:{Ex.Message}");
            //}
            //// Checking Task .Exception Directly
            //Task FaultedTask = ThrowingMethodsAsync();
            //try
            //{
            //    await FaultedTask;
            //}catch
            //{
            //    Console.WriteLine($"Task.IsFaulted:{FaultedTask.IsFaulted}");
            //    Console.WriteLine($"Exception:{FaultedTask.Exception?.InnerException?.Message}");

            //}

            #endregion

            #region WhenAll Exception Handling
            //Task task01 = Task.Run(() => throw new InvalidOperationException("Error01"));
            //Task task02 = Task.Run(() => throw new ArgumentException("Error02"));
            //Task task03 = Task.Delay(100);

            //Task allTasks = Task.WhenAll(task01, task02, task03);
            //try
            //{
            //    await allTasks;
            //}
            //catch(Exception ex)
            //{
            //    Console.WriteLine($"Caught:{ex.GetType().Name}-{ex.Message}");
            //    Console.WriteLine("All Exceptions From Task.Exception:");
            //    if(allTasks.Exception!=null)
            //    {
            //        foreach (var inner in allTasks.Exception.InnerExceptions) 
            //        {
            //            Console.WriteLine($"{inner.GetType().Name}:{inner.Message}");
            //        }
            //    }
            //}

            #endregion

            #endregion

            #region Part 05 CancellationToken
            #endregion
        }
        #region Helper
        static async Task ThrowingMethodsAsync()
        {
            await Task.Delay(100);
            throw new InvalidOperationException("SomeThing Went Wrong");


        }
        static async Task<string>GetGreetingAsync(string Name)
        {
            await Task.Delay(100);
            return $"Hello:{Name}";
        }

        #endregion
    }
}
