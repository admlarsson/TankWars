using System.Text;
using TankWars.Menu;

public class MapMenu : IMenu<string>
{
    public string RunMenu()
    {
        Console.Clear();
        Console.WriteLine("1. Spela på Träningsbana");
        Console.WriteLine("2. Spela på Jorden");
        Console.WriteLine("3. Spela på Månen");
        Console.WriteLine("4. Avsluta spelet");
        Console.Write("\nVälj ett alternativ (1-4): ");

        return Console.ReadLine();
    }

}