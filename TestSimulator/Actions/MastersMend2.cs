using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSimulator
{
    public class MastersMend2 : IAction
    {
        //Private variables.
        private double progressModifier;
        private double qualityModifier;
        private int successChance;        
        private bool actionUsed;
        private bool wasSuccessful;

        public string ActionName
        {
            get { return "Master's Mend II"; }
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
            get { return -60; }
        }

        public int CPCost
        {
            get { return 160; }
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

        public MastersMend2()
        {
            this.progressModifier = 0;
            this.qualityModifier = 0;            
            this.successChance = 100;
            this.actionUsed = false;
        }

        public string ExecuteAction(ICraft craft, ICrafter crafter, List<IModifier> activeModifiers, Random rng, Conditions condition)
        {
            string result = String.Empty;

            //Success!
            wasSuccessful = true;
            
            result = ActionName + " used!  " + Math.Abs(DurabilityUsed) + " durability restored.";            

            craft.IncrementStep();
            craft.UpdateDurability(DurabilityUsed);
            crafter.UpdateCP(CPCost);

            this.actionUsed = true;
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
