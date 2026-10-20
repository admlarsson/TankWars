namespace TankWars.Tanks
{

public interface ITank
{
    int GetX();
    int GetY();
    int GetHP();
    
    

    void MoveLeft();
    void MoveRight();
    void Draw();
    void Attack(double power, int angle);
    
}   
}