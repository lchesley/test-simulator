﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSimulator
{
    public class FlawlessSynthesis : IAction
    {
        //Private variables.
        private double progressModifier;
        private double qualityModifier;
        private int successChance;
        private int durabilityUsed;
        private bool actionUsed;
        private bool wasSuccessful;
        private int cpCost;

        public string ActionName
        {
            get { return "Flawless Synthesis"; }
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
            get { return cpCost; }
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

        public FlawlessSynthesis()
        {
            this.progressModifier = 0;
            this.qualityModifier = 0;
            this.successChance = 90;
            this.durabilityUsed = 10;
            this.actionUsed = false;
            this.cpCost = 15;
        }

        public string ExecuteAction(ICraft craft, ICrafter crafter, List<IModifier> activeModifiers, Random rng, Conditions condition)
        {
            string result = String.Empty;

            if (Calc.ActionIsSuccessful(rng, SuccessChance))
            {
                //Success!
                wasSuccessful = true;
                double progress = 40;         
                result = ActionName + " successful!  Progress increased by " + Math.Round(progress, 0, MidpointRounding.ToEven);

                //Update progress.                
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
            this.cpCost = cpCost;
        }
    }
}