namespace WebSiteParser
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please write the URL:");
            var url = Console.ReadLine();

            var index = 1;
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(x => x.GetTypes())
                .Where(x => !x.IsInterface)
                .Where(x => typeof(IStrategy).IsAssignableFrom(x))
                .ToDictionary(x => index++, x => x);

            Console.WriteLine("Please choose your strategy:");

            foreach (var typeInfo in types)
            {
                Console.WriteLine($"{typeInfo.Key} - {typeInfo.Value.Name}");
            }

            var strategyNumber = Convert.ToInt32(Console.ReadLine());
            var type = types.Where(x => x.Key == strategyNumber).Single().Value;
            var instance = Activator.CreateInstance(type);

            var parse = new Parse((IStrategy)instance);
            var results = parse.Execute(url);

            foreach (var result in results)
            {
                Console.WriteLine(result);
            }
        }
    }
}
