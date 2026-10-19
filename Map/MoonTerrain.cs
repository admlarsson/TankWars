using System.Text.RegularExpressions;

namespace TankWars.Map

{
    public class MoonTerrain : ITerrainGenerator

    {

        //Gneom en andragradsekvation  så formar vi en mjuk kulle osm är högst i mitten och sluttar nedåt mot sidorna
        public int [] GenerateTerrain(int width, int maxHeight)
        {
            int [] heights = new int[width];

            double peak = maxHeight/3; //Här bestäms kullens högsta punkt En tredje del av maxHeight
            double center = width/2; //Gör så att mitten (Högsta punkten) blir exakt i kartans mittpunkt

            double a = peak / (center * center); //Räknar ut böjningsfaktorn så att kullen ska slutta lagom mycket


            for (int x=0; x<width; x++) //Loopar igneom kartans bredd. 130 gånger ifall kartan är 130 i bredd
            {
                double height = peak - a * Math.Pow(x-center, 2); //

                heights [x] = (int)Math.Max(1, Math.Round(height)); //Tvättar datatn så att terminalen kan rita ut

            }
            return heights;
        }
    }

}