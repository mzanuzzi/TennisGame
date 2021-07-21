using System;
using System.Threading.Tasks;
using YOOX.TennisGame.Sdk;

namespace YOOX.TennisGame.Batch
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var match = new Match(new Player { Name = "Pete", Surname = "Sampras" }, new Player { Name = "Boris", Surname = "Becker" });
            var scorer = new TennisGameScorer(match);
            Console.WriteLine(scorer.PrintScore());
            match.Start();
            Console.WriteLine(scorer.PrintScore());

            while (true)
            {
                try
                {
                    if (match.Status == MatchStatus.Finished)
                        break;

                    string value = await Task.Run(() =>
                    {
                        Console.WriteLine("Enter 1 for server score, 2 for receiver score or q to exit");
                        Console.Write("> ");
                        return Console.ReadLine();
                    });

                    if ("q".Equals(value, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine("The match is suspended");
                        break;
                    }

                    if ("1".Equals(value, StringComparison.OrdinalIgnoreCase))
                    {
                        match.ServerScoresPoint();
                        Console.WriteLine(scorer.PrintScore());
                        continue;
                    }

                    if ("2".Equals(value, StringComparison.OrdinalIgnoreCase))
                    {
                        match.ReceiverScoresPoint();
                        Console.WriteLine(scorer.PrintScore());
                        continue;
                    }
                    Console.WriteLine("Invalid value. The referee warned you...");
                }
                catch(TennisGameException ex)
                {
                    Console.WriteLine($"Error occurred: {ex.Message}");
                    break;
                }
            }

        }
    }
}
