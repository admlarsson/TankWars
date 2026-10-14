using System.Reflection.Metadata.Ecma335;

public interface ITank
{
    int Health { get; set; }
        
        // Metoder för att röra sig på kartan
        
        void MoveLeft();
        void MoveRight();

        // Metod för att skjuta med det vapen man har
        void FireWeapon();
}