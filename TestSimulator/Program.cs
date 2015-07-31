using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            bool userExitRequested = false;

            Craft.TheCraft.SetInitialValues(151, 70, 1436, 9999, "");            

            while (!userExitRequested)
            {
                Console.WriteLine("Inner Quiet (iq) | Steady Hand (sh) | Steady Hand II (s2) | Great Strides (gs) | Innovation (in) | Ingenuity (ig) | Ingenuity II (i2) | Maker's Mark (ma)");
                Console.WriteLine("Hasty Touch (ht) | Basic Touch (bt) | Precise Touch (pt) | Standard Touch (st) | Advanced Touch (at) | Byregot's Blessing (bb) | Tricks of the Trade (tt)");
                Console.WriteLine("Synthesis : Basic (bs) | Standard (ss) | Careful (cs) | Careful II (c2) | Rapid (rs) | Flawless (fs) | Muscle Memory (mu) | Piece By Piece (pp)");
                Console.WriteLine("Master's Mend (mm) | Master's Mend II (m2) | Rumination (ru) | Manipulation (mn)");
                Console.WriteLine("Brand Of : Earth (be) | Fire (bf) | Ice (bi) | Lightning (bl) | Water (ba) | Wind (bw)");
                Console.WriteLine("Name Of : Earth (ne) | Fire (nf) | Ice (ni) | Lightning (nl) | Water (na) | Wind (nw)");
                Console.WriteLine(); 
                
                Console.WriteLine("Condition is {0}.", Controller.TheController.Condition);                
                Console.WriteLine(Controller.TheController.ExecuteCommand(Console.ReadLine()));

                //Show stats.
                Console.WriteLine(Craft.TheCraft.ShowStatus());
                Console.WriteLine(Crafter.TheCrafter.ShowStatus());
                Console.WriteLine();
            }            
        }
    }
}
