using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSimulator
{
    public class Manipulation : IModifier
    {
        private int stepsRemaining;

        public string ModifierName
        {
            get { return "Manipulation"; }
        }

        public int CPCost
        {
            get { return 88; }
        }

        public int DurabilityReturned
        {
            get { return 10; }
        }

        public int StepsActive
        {
            get { return 3; }
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

        public Manipulation()
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
            return String.Empty;
        }

        public void AfterSuccessfulQualityIncrease(ICrafter crafter)
        {
            
        }

        public void AtEndOfStep(ICrafter crafter, ICraft craft)
        {
            if (stepsRemaining > 0)
            {
                //Don't give dur back on first step
                if (!(stepsRemaining > StepsActive))
                {
                    craft.UpdateDurability(DurabilityReturned * -1);
                }

                stepsRemaining--;
            }
        }

        public string ShowCurrentStatus()
        {
            return ModifierName + " active - " + stepsRemaining + " of " + StepsActive + " steps remaining.";
        }
    }
}
