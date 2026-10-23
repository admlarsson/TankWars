namespace TankWars.Tanks
{

public interface ITank
{
    int X { get; }
    int Y { get; }
    int HP { get; }
    
    

    void MoveLeft();
    void MoveRight();
    void Draw();
    void Attack(int angle, double power);
    bool IsHitAt(int projectileX, int projectileY);
    void TakeDamage(int amount);
    void Heal(int amount);
    
}   
}