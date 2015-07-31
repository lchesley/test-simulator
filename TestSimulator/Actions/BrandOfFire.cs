using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSimulator
{
    public class BrandOfFire : IAction
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
            get { return "Brand Of Fire"; }
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
            get { return 6; }
        }

        public int SuccessChance
        {
            get { return successChance; }
        }

        public ElementalAffinity Affinity
        {
            get { return ElementalAffinity.Fire; }
        }

        public bool ActionUsed
        {
            get { return actionUsed; }
        }

        public bool WasSuccessful
        {
            get { return wasSuccessful; }
        }

        public BrandOfFire()
        {
            this.progressModifier = 1.0;
            this.qualityModifier = 0;
            this.durabilityUsed = 10;
            this.successChance = 90;
            this.actionUsed = false;
        }

        public string ExecuteAction(ICraft craft, ICrafter crafter, List<IModifier> activeModifiers, Random rng, Conditions condition)
        {
            string result = String.Empty;

            //Calculate success.
            if (Calc.ActionIsSuccessful(rng, SuccessChance))
            {
                //Success!
                wasSuccessful = true;

                if(craft.Affinity == ElementalAffinity.Fire)
                {
                    progressModifier = progressModifier * 2;
                }

                double progress = Calc.Progress(craft.ItemLevel, crafter.CrafterLevel, crafter.Craftsmanship) * ProgressModifier;
                result = ActionName + " successful!  Progress increased by " + Math.Round(progress, 0, MidpointRounding.ToEven);

                //Update quality.                
                craft.UpdateProgress(progress);
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
            return result;
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
