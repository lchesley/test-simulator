using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSimulator
{
    public class PreciseTouch : IAction
    {
        //Private variables.
        private double progressModifier;
        private double qualityModifier;
        private int successChance;
        private int durabilityUsed;
        private bool actionUsed;
        private bool wasSuccessful;

        public string ActionName
        {
            get { return "Precise Touch"; }
        }

        public double ProgressModifier
        {
            get { return progressModifier; }
        }

        public double QualityModifier
        {
            get { return qualityModifier; }
        }

        public int DurabilityUsed
        {
            get { return durabilityUsed; }
        }

        public int CPCost
        {
            get { return 18; }
        }

        public int SuccessChance
        {
            get { return successChance; }
        }

        public ElementalAffinity Affinity
        {
            get { return ElementalAffinity.None; }
        }

        public bool ActionUsed
        {
            get { return actionUsed; }
        }

        public bool WasSuccessful
        {
            get { return wasSuccessful; }
        }
        
        public string ExecuteAction(ICraft craft, ICrafter crafter, List<IModifier> activeModifiers, Random rng, Conditions condition)
        {
            string result = String.Empty;

            if (condition == Conditions.Good || condition == Conditions.Excellent)
            {
                //Calculate success.
                if (Calc.ActionIsSuccessful(rng, SuccessChance))
                {
                    //Success!
                    wasSuccessful = true;
                    double quality = Calc.ApplyCondition(Calc.Quality(craft.ItemLevel, crafter.CrafterLevel, crafter.Control) * qualityModifier, condition);
                    result = ActionName + " successful!  Quality increased by " + Math.Round(quality, 0, MidpointRounding.ToEven);
                    
                    //Update quality.                
                    craft.UpdateQuality(quality);                    
                }
                else
                {
                    //Failure!
                    wasSuccessful = false;
                    result = ActionName + " failed!";
                }                

                craft.IncrementStep();
                craft.UpdateDurability(DurabilityUsed);
                crafter.UpdateCP(CPCost);

                this.actionUsed = true;
            }
            else
            {
                result = "Condition must be good or excellent to use Precise Touch.";
            }

            return result;
        }

        public PreciseTouch()
        {
            this.progressModifier = 0;
            this.qualityModifier = 1.00;
            this.successChance = 70;
            this.durabilityUsed = 10;
            this.actionUsed = false;
        }

        public void UpdateProgressModifer(double progressModifier)
        {
            this.progressModifier = progressModifier;
        }

        public void UpdateQualityModifier(double qualityModifier)
        {
            this.qualityModifier = qualityModifier;
        }

        public void UpdateSuccessChance(int successChance)
        {
            this.successChance = successChance;
        }

        public void UpdateDurabilityUsed(int durabilityUsed)
        {
            this.durabilityUsed = durabilityUsed;
        }

        public void UpdateCPCost(int cpCost)
        {
            
        }
    }
}
