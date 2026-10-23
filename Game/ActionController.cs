using System;
using TankWars.Tanks;
using TankWars.Map;

namespace TankWars.Game
{
    public class ActionController
    {
        public void HandleInput(ITank tank, IMap map, ref bool isTurnActive, ref bool gameRunning)
        {
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.LeftArrow: tank.MoveLeft();
                    map.CheckPowerUpPickup(tank); break;
                case ConsoleKey.RightArrow: tank.MoveRight();
                    map.CheckPowerUpPickup(tank); break;
                case ConsoleKey.Escape: gameRunning = false; break;
                case ConsoleKey.Spacebar:
                    ExecuteShoot(tank, map);
                    isTurnActive = false; 
                    break;
            }
        }

        protected void ExecuteShoot(ITank tank, IMap map)
        {
            Console.SetCursorPosition(0, map.Height + 6);
            
            CombatInput inputHandler = new CombatInput();
            var (angle, power) = inputHandler.GetShootInput();

            tank.Attack(angle, power);
            System.Threading.Thread.Sleep(1000);
        }
    }
}