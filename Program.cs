internal class Program
{
    private static void Main(string[] args)
    {
        Menu();
    }

    static void Menu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("S = Segundo => Exemplo: 10s = 10 segundos");
            Console.WriteLine("M = Minuto => Exemplo: 1m = 1 minuto");
            Console.WriteLine("0 = Sair");
            Console.Write("Quanto tempo deseja contar?\n");

            string input = Console.ReadLine().ToLower();

            if (string.IsNullOrEmpty(input) || input == "0")
                Environment.Exit(0);

            if (!TryParseInput(input, out int timeInSeconds))
            {
                Console.WriteLine("Entrada inválida. Tente novamente.");
                Thread.Sleep(1000);
                continue;
            }

            PreStart(timeInSeconds);
        }
    }

    static bool TryParseInput(string input, out int timeInSeconds)
    {
        timeInSeconds = 0;

        if (string.IsNullOrWhiteSpace(input) || input.Length < 2)
            return false;

        char type = input[^1];
        string timePart = input.Substring(0, input.Length - 1);

        if (!int.TryParse(timePart, out int time) || time < 0)
            return false;

        int multiplier = type switch
        {
            'm' => 60,
            's' => 1,
            _ => -1
        };

        if (multiplier == -1)
            return false;

        timeInSeconds = time * multiplier;
        return true;
    }

    static void PreStart(int timeInSeconds)
    {
        Console.Clear();
        Console.WriteLine("Preparar...");
        Thread.Sleep(1000);
        Console.WriteLine("Apontar...");
        Thread.Sleep(1000);
        Console.WriteLine("Vai!");
        Thread.Sleep(1000);

        Start(timeInSeconds);
    }

    static void Start(int timeInSeconds)
    {
        for (int elapsed = 0; elapsed < timeInSeconds; elapsed++)
        {
            Console.Clear();
            Console.WriteLine($"{elapsed + 1} segundos");
            Thread.Sleep(1000);
        }

        Console.Clear();
        Console.WriteLine("StopWatch finalizado!");
        Thread.Sleep(1000);
    }
}
