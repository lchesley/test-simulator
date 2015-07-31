using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSimulator
{
    public class MakersMark : IModifier
    {
        private int stepsRemaining;
        private int stepsActive;

        public string ModifierName
        {
            get { return "Maker's Mark"; }
        }

        public int CPCost
        {
            get { return 20; }
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
            get { return 0; }
        }

        public ElementalAffinity Affinity
        {
            get { return ElementalAffinity.None; }
        }

        public MakersMark()
        {

        }

        public string ApplyModifier(ICrafter crafter, ICraft craft)
        {
            string result = String.Empty;

            if (craft.Step == 0)
            {
                crafter.UpdateCP(CPCost);
                this.stepsActive = Convert.ToInt32(Math.Ceiling((double)craft.Difficulty/100));
                this.stepsRemaining = StepsActive + 1;
                result =  ModifierName + " applied.";
            }
            else
            {
                result = ModifierName + " can only be used as the first step.";
            }

            return result;
        }

        public string ApplyModifier(IAction action)
        {
            string result = String.Empty;

            if (!action.ActionUsed && action.ActionName == "Flawless Synthesis")
            {
                action.UpdateDurabilityUsed(0);
                action.UpdateCPCost(0);
                result = action.ActionName + " is now 0 durability cost, and 0 CP.";
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
            return ModifierName + " active - " + StepsRemaining + " of " + StepsActive + " steps remaining.";
        }
    }
}
