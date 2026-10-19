using System.Text.RegularExpressions;

namespace TankWars.Map

{
    public class MoonTerrain : ITerrainGenerator

    {

        //Genom en andragradsekvation så formaterar vi en mjuk kulle som är högst i mitten och sluttar nedåt mot sidorna
        public int [] GenerateTerrain(int width, int maxHeight)
        {
            int [] heights = new int[width];

            double peak = maxHeight/3; //Här bestäms kullens högsta punkt En tredje del av maxHeight
            double center = width/2; //Gör så att mitten (Högsta punkten) blir exakt i kartans mittpunkt

            double a = peak / (center * center); //Räknar ut böjningsfaktorn så att kullen ska slutta lagom mycket

            for (int x=0; x<width; x++) //Loopar igneom kartans bredd. 130 gånger ifall ex, kartan är 130 i bredd
            {
                // Räknar ut markhöjden för just denna X-koordinat baserat på dess avstånd från mitten
                double height = peak - a * Math.Pow(x-center, 2); 

                //Tvättar datan (Avrundar och sätter lägsta värde till 1) så att terminalen kan rita ut hela block
                heights [x] = (int)Math.Max(1, Math.Round(height)); 

            }
            return heights;
        }
    }

}