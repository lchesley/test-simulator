using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSimulator
{
    public class MuscleMemory : IAction
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
            get { return "Muscle Memory"; }
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
            get { return 100; }
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

        public MuscleMemory()
        {
            this.progressModifier = 1.00;
            this.qualityModifier = 0;
            this.durabilityUsed = 10;
            this.actionUsed = false;
        }

        public string ExecuteAction(ICraft craft, ICrafter crafter, List<IModifier> activeModifiers, Random rng, Conditions condition)
        {
            string result = String.Empty;

            if (craft.Step == 0)
            {
                //Success!
                wasSuccessful = true;

                double progress = craft.Difficulty * 0.33;
                result = ActionName + " successful!  Progress increased by " + Math.Round(progress, 0, MidpointRounding.ToEven);

                craft.UpdateProgress(progress);

                craft.IncrementStep();
                craft.UpdateDurability(DurabilityUsed);
                crafter.UpdateCP(CPCost);

                this.actionUsed = true;
            }
            else
            {
                result = ActionName + " can only be used on the first step.";
            }

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
