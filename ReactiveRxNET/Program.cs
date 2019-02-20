using System;
using System.Linq;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading;

namespace ReactiveRxNET
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World Reactive Program Rx.NET!");
            // 命令式,声明式,函数式编程
            //Heater heater = new Heater();
            //heater.BoilWater();

            /*
             Reactive Extensions（Rx）是一个为.NET应用提供响应式编程模型的库，
             用来构建异步基于事件流的应用，通过安装System.ReactiveNuget包进行引用。
             Rx将事件流抽象为Observable sequences（可观察序列）表示异步数据流，
             使用LINQ运算符查询异步数据流，并使用Scheduler来控制异步数据流中的并发性。
             简单地说：Rx = Observables + LINQ + Schedulers。
             在软件系统中，事件是一种消息用于指示发生了某些事情。
             事件由Event Source（事件源）引发并由Event Handler（事件处理程序）使用。
             在Rx中，事件源可以由observable表示，事件处理程序可以由observer表示。
             但是应用程序使用的数据如何表示呢，例如数据库中的数据或从Web服务器获取的数据。
             而在应用程序中我们一般处理的数据无外乎两种：静态数据和动态数据。 
             但无论使用何种类型的数据，其都可以作为流来观察。换句话说，数据流本身也是可观察的。
             也就意味着，我们也可以用observable来表示数据流。
             Rx.NET的核心也就一目了然了：
                1.一切皆为数据流
                2.Observable 是对数据流的抽象
                3.Observer是对Observable的响应
             */
            //1.响应式编程
            var observable = Enumerable.Range(1, 100).ToObservable(NewThreadScheduler.Default);//申明可观察序列
            Subject<int> subject = new Subject<int>();//申明Subject
            subject.Subscribe((temperature) => Console.WriteLine($"当前温度：{temperature}"));//订阅subject
            subject.Subscribe((temperature) => Console.WriteLine($"嘟嘟嘟，当前水温：{temperature}"));//订阅subject
            observable.Subscribe(subject);//订阅observable

            Observable.Return("Hello", NewThreadScheduler.Default)
            .Subscribe(str => Console.WriteLine($"{str} on ThreadId：{Thread.CurrentThread.ManagedThreadId}")
            );
            Console.WriteLine($"Current ThreadId：{Thread.CurrentThread.ManagedThreadId}");

            Console.ReadKey();
        }
    }
}
