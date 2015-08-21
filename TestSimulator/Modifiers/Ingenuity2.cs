using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSimulator
{
    public class Ingenuity2 : IModifier
    {
        private int stepsRemaining;
        private bool baseItemLevelRestored;

        public string ModifierName
        {
            get { return "Ingenuity II"; }
        }

        public int CPCost
        {
            get { return 32; }
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

        public Ingenuity2()
        {
            stepsRemaining = StepsActive + 1;
            baseItemLevelRestored = false;
        }

        public string ApplyModifier(ICrafter crafter, ICraft craft)
        {
            crafter.UpdateCP(CPCost);            

            craft.SetItemLevel(Calc.GetIngenuityIIItemLevels(craft.ItemLevel));
            
            return ModifierName + " is applied.  Item Level is now " + craft.ItemLevel;
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
                if (!baseItemLevelRestored)
                {
                    craft.SetItemLevel(craft.BaseItemLevel);
                }
            }
        }

        public string ShowCurrentStatus()
        {
            return ModifierName + " active - " + stepsRemaining + " of " + StepsActive + " steps remaining.";
        }
    }
}
