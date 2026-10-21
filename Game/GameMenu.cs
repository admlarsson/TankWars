using System;
namespace TankWars.Game;
public class GameMenu
{
    public int GameModeChoice()
    {
        Console.Clear();
        Console.WriteLine("--- HUVUDMENY ---");
        Console.WriteLine("1. Människa vs Dator");
        Console.WriteLine("2. Människa vs Människa");
        Console.WriteLine("3. Dator vs Dator");
        Console.WriteLine("4. Avsluta spelet");
        Console.Write("\nDitt val (1-4): ");
        
        string input = Console.ReadLine();
        
        if (input == "2") return 2;
        if (input == "3") return 3;
        if (input == "4") return 4; // 4 = Avsluta
        
        return 1; // Standard om de trycker fel
    }
    public string GetMapChoice()
    {
        Console.Clear();
        Console.WriteLine("1. Spela på Träningsbana");
        Console.WriteLine("2. Spela på Jorden");
        Console.WriteLine("3. Spela på Månen");
        Console.WriteLine("4. Avsluta spelet");
        Console.Write("\nVälj ett alternativ (1-4): ");

        return Console.ReadLine();
    }

    // Meny 3: Välj vapen
    public (string, string) GetWeaponChoice(string playerName)
    {
        Console.Clear();
        Console.WriteLine($"--- {playerName.ToUpper()}: BYGG DITT VAPEN ---");
        
        Console.WriteLine("Steg 1: Välj Ammunitionstyp");
        Console.WriteLine("1. Normal (Liten träffyta, 50 Skada)");
        Console.WriteLine("2. Explosiv (Stor träffyta, 25 Skada)");
        Console.Write("Val (1-2): ");
        string bulletChoice = Console.ReadLine();

        Console.WriteLine("\nSteg 2: Välj Flygstil");
        Console.WriteLine("1. Standard (Vanlig kastbana)");
        Console.WriteLine("2. Guidad (Tryck SPACE i luften för att störtdyka)");
        Console.Write("Val (1-2): ");
        string flightChoice = Console.ReadLine();

        return (bulletChoice, flightChoice);
    }



}