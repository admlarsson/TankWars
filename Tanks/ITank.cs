namespace TankWars.Tanks
{

public interface ITank
{
    int X { get; }
    int Y { get; }
    int HP { get; }
    int MinX { get; }    
    int MaxX { get; }
    

    void MoveLeft();
    void MoveRight();
    void Draw();
    void Attack(int angle, double power);
    bool IsHitAt(int projectileX, int projectileY);
    int TakeDamage(int amount);
    void Heal(int amount);
    void BoostNextShot();
    void ActivateShield();

}   
}