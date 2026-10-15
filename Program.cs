
using System;
using System.Text;
using TankWars.Game;

namespace TankWars
{
    class Program
    {
        static void Main(string[] args)
        {
            // Tvingar terminalen att förstå specialtecken som █
            Console.OutputEncoding = Encoding.UTF8;
            
            GameManager gameManager = new GameManager();
            gameManager.StartGame();
            
            // Stoppar programmet från att stängas ner direkt så vi hinner se kartan
            Console.ReadLine();

            Console.Clear();
            
        }
    }
}