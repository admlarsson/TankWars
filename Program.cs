using System.Text;
using TankWars.Game;

namespace TankWars
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            
            GameManager gameManager = new GameManager();
            gameManager.StartGame();
            
            Console.ReadLine();

            Console.Clear();
        }
    }
}