using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSimulator
{
    public class InnerQuiet : IModifier
    {
        private int stepsActive;
        private int stepsRemaining;

        public string ModifierName
        {
            get { return "Inner Quiet"; }
        }

        public int CPCost
        {
            get { return 18; }
        }

        public int DurabilityReturned
        {
            get { return 0; }
        }

        public int StepsActive
        {
            get { return stepsActive; }
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
            get { return 0.2; }
        }

        public ElementalAffinity Affinity
        {
            get { return ElementalAffinity.None; }
        }

        public InnerQuiet()
        {
            stepsActive = 1;
            stepsRemaining = 1;
        }

        public string ApplyModifier(ICrafter crafter, ICraft craft)
        {
            crafter.UpdateCP(CPCost);
            return ModifierName + " applied.";
        }

        public string ApplyModifier(IAction action)
        {
            string result = String.Empty;

            if (action.ActionUsed && action.WasSuccessful)
            {
                //If Precise Touch, add another stack.
                if (action.ActionName == "Precise Touch")
                {
                    stepsActive++;
                    result = "Extra stack of Inner Quiet added.";
                }
            }

            return result;
        }

        public void AfterSuccessfulQualityIncrease(ICrafter crafter)
        {
            if (stepsRemaining > 0)
            {
                crafter.IncreaseControl(crafter.BaseControl * ControlModifier);
                stepsActive++;
            }
        }

        public void AtEndOfStep(ICrafter crafter, ICraft craft)
        {
            if(stepsRemaining == 0 && stepsActive > 0)
            {
                crafter.IncreaseControl((crafter.BaseControl * ControlModifier) * (StepsActive - 1) * -1);
                stepsActive = 0;
            }
        }

        public void ConsumeStacks()
        {
            stepsRemaining = 0;         
        }

        public string ShowCurrentStatus()
        {
            return ModifierName + " active - " + StepsActive + " stacks.";
        }
    }
}
