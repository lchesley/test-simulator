using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSimulator
{
    public class CarefulSynthesis2 : IAction
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
            get { return "Careful Synthesis II"; }
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
            get { return 0; }
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

        public CarefulSynthesis2()
        {
            this.progressModifier = 1.2;
            this.qualityModifier = 0;            
            this.durabilityUsed = 10;
            this.actionUsed = false;
        }

        public string ExecuteAction(ICraft craft, ICrafter crafter, List<IModifier> activeModifiers, Random rng, Conditions condition)
        {
            string result = String.Empty;

            //Success!
            wasSuccessful = true;

            double progress = Calc.Progress(craft.RecipeLevel, craft.ItemLevel, crafter.CrafterLevel, crafter.Craftsmanship) * ProgressModifier;
            result = ActionName + " successful!  Progress increased by " + Math.Round(progress, 0, MidpointRounding.ToEven);

            craft.UpdateProgress(progress);            

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
