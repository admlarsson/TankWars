namespace TankWars.Tanks
{

public interface ITank
{
    int X { get; }
    int Y { get; }
    int HP { get; }
    int Direction {get; } //Anger vilket håll tanks tittar åt
    

    void MoveLeft();
    void MoveRight();
    void Draw();
    void Attack(double power, int angle);
    void TakeTurn();
}   
}