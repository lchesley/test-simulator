using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSimulator
{
    public class Rumination : IAction
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
            get { return "Rumination"; }
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

        public Rumination()
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

            //If Inner Quiet active, set quality modifier.
            var innerQuiet = activeModifiers.Where(o => o.ModifierName == "Inner Quiet" && o.StepsRemaining > 0).FirstOrDefault() as InnerQuiet;
            if (innerQuiet != null && innerQuiet.StepsActive > 0)
            {
                //Success!
                wasSuccessful = true;
                double cpRestored = ((21 * innerQuiet.StepsActive) - Math.Pow(innerQuiet.StepsActive, 2) + 10) / 2;
                result = ActionName + " successful!  " + cpRestored + " CP restored!";

                //Update quality.                                            
                craft.IncrementStep();
                craft.UpdateDurability(DurabilityUsed);
                crafter.UpdateCP(Convert.ToInt32(cpRestored * -1));

                innerQuiet.ConsumeStacks();

                this.actionUsed = true;
            }
            else
            {
                result = "Inner Quiet stacks not available, cannot use " + ActionName + ".";
            }

            return result;
        }

        public void UpdateProgressModifer(double progressModifier)
        {
            
        }

        public void UpdateQualityModifier(double qualityModifier)
        {
            
        }

        public void UpdateSuccessChance(int successChance)
        {
            
        }

        public void UpdateDurabilityUsed(int durabilityUsed)
        {
            
        }

        public void UpdateCPCost(int cpCost)
        {
            
        }
    }
}
