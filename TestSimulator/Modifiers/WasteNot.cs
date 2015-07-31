using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSimulator
{
    public class WasteNot : IModifier
    {
        private int stepsRemaining;

        public string ModifierName
        {
            get { return "Waste Not"; }
        }

        public int CPCost
        {
            get { return 56; }
        }

        public int DurabilityReturned
        {
            get { return 0; }
        }

        public int StepsActive
        {
            get { return 4; }
        }

        public int StepsRemaining
        {
            get { return stepsRemaining; }
        }

        public int SuccessChanceModifier
        {
            get { return 0; }
        }

        public int ProgressModifier
        {
            get { return 0; }
        }

        public int QualityModifier
        {
            get { return 0; }
        }

        public double DurabilityCostModifier
        {
            get { return 0.5; }
        }

        public double ControlModifier
        {
            get { return 0; }
        }

        public ElementalAffinity Affinity
        {
            get { return ElementalAffinity.None; }
        }

        public WasteNot()
        {
            stepsRemaining = StepsActive + 1;
        }

        public string ApplyModifier(ICrafter crafter, ICraft craft)
        {
            crafter.UpdateCP(CPCost);
            return ModifierName + " applied.";
        }

        public string ApplyModifier(IAction action)
        {
            string result = String.Empty;

            if (!action.ActionUsed)
            {
                action.UpdateDurabilityUsed(Convert.ToInt32(Math.Round(action.DurabilityUsed * DurabilityCostModifier, 0, MidpointRounding.ToEven)));
                result = ModifierName + " applied to " + action.ActionName + " - durability used now " + action.DurabilityUsed;
            }

            return result;
        }

        public void AfterSuccessfulQualityIncrease(ICrafter crafter)
        {
            
        }

        public void AtEndOfStep(ICrafter crafter, ICraft craft)
        {
            if (stepsRemaining > 0)
            {
                stepsRemaining--;
            }
        }

        public string ShowCurrentStatus()
        {
            return ModifierName + " active - " + stepsRemaining + " of " + StepsActive + " steps remaining.";
        }
    }
}
