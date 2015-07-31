using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSimulator
{
    public class TricksoftheTrade : IAction
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
            get { return "Tricks of the Trade"; }
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
            get { return -20; }
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

        public TricksoftheTrade()
        {
            this.progressModifier = 0;
            this.qualityModifier = 0;
            this.successChance = 100;
            this.durabilityUsed = 0;
            this.actionUsed = false;
        }

        public string ExecuteAction(ICraft craft, ICrafter crafter, List<IModifier> activeModifiers, Random rng, Conditions condition)
        {
            string result = String.Empty;

            if (condition == Conditions.Good || condition == Conditions.Excellent)
            {
                wasSuccessful = true;
                result = ActionName + " successful!  CP increased by 20.";                    
                craft.IncrementStep();
                craft.UpdateDurability(DurabilityUsed);
                crafter.UpdateCP(CPCost);

                this.actionUsed = true;
            }
            else
            {
                result = "Condition must be good or excellent to use Tricks of the Trade.";
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
