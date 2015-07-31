using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSimulator
{
    public interface IAction 
    {       
        //Properties.           
        string ActionName
        {
            get;
        } 

        double ProgressModifier
        {
            get;
        }

        double QualityModifier
        {
            get;
        }

        int DurabilityUsed
        {
            get;
        }

        int CPCost
        {
            get;
        }

        int SuccessChance
        {
            get;
        }

        ElementalAffinity Affinity
        {
            get;
        }

        bool ActionUsed
        {
            get;
        }

        bool WasSuccessful
        {
            get;
        }

        //Methods
        string ExecuteAction(ICraft craft, ICrafter crafter, List<IModifier> activeModifiers, Random rng, Conditions condition);        
        void UpdateProgressModifer(double progressModifier);
        void UpdateQualityModifier(double qualityModifier);
        void UpdateSuccessChance(int successChance);
        void UpdateDurabilityUsed(int durabilityUsed);
        void UpdateCPCost(int cpCost);
    }
}
