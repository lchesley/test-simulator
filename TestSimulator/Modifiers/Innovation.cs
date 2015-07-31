using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSimulator
{
    public class Innovation : IModifier
    {
        private int stepsRemaining;
        private bool controlRemoved;

        public string ModifierName
        {
            get { return "Innovation"; }
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
            get { return 0.5; }
        }

        public ElementalAffinity Affinity
        {
            get { return ElementalAffinity.None; }
        }

        public Innovation()
        {
            stepsRemaining = StepsActive + 1;
            controlRemoved = false;
        }

        public string ApplyModifier(ICrafter crafter, ICraft craft)
        {
            crafter.UpdateCP(CPCost);
            crafter.IncreaseControl(crafter.BaseControl * ControlModifier);
            return ModifierName + " is applied.  Control is now " + crafter.Control;
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
                stepsRemaining--;
            }
            else
            {
                if (!controlRemoved)
                {
                    crafter.IncreaseControl(crafter.BaseControl * ControlModifier * -1);
                    controlRemoved = true;
                }
            }
        }

        public string ShowCurrentStatus()
        {
            return ModifierName + " active - " + stepsRemaining + " of " + StepsActive + " steps remaining.";
        }
    }
}
