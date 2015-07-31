using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSimulator
{
    public class SteadyHand : IModifier
    {
        private int stepsRemaining;

        public string ModifierName
        {
            get { return "Steady Hand"; }
        }

        public int CPCost
        {
            get { return 22; }
        }

        public int DurabilityReturned
        {
            get { return 0; }
        }

        public int StepsActive
        {
            get { return 5; }
        }

        public int StepsRemaining
        {
            get { return stepsRemaining; }
        }

        public int SuccessChanceModifier
        {
            get { return 20; }
        }

        public int QualityModifier
        {
            get { return 0; }
        }

        public int ProgressModifier
        {
            get { return 0; }
        }

        public double DurabilityCostModifier
        {
            get { return 0; }
        }

        public double ControlModifier
        {
            get { return 0; }
        }

        public ElementalAffinity Affinity
        {
            get { return ElementalAffinity.None; }
        }

        public SteadyHand()
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
                action.UpdateSuccessChance(action.SuccessChance + SuccessChanceModifier);
                result = action.ActionName + " chance for success increased to " + action.SuccessChance + "%.";
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
