using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSimulator;

namespace SimulatorTests
{
    public class MockCraft : ICraft
    {
        private static MockCraft theMockCraft;

        private MockCraft()
        {
            itemLevel = 0;
            baseItemLevel = 0;
            durability = 0;
            remainingDurability = 0;
            progress = 0;
            difficulty = 0;
            quality = 0;
            itemQuality = 0;
            itemName = String.Empty;
            step = 0;
            affinity = ElementalAffinity.None;
        }

        public static MockCraft TheMockCraft
        {
            get
            {
                if (theMockCraft == null)
                    theMockCraft = new MockCraft();

                return theMockCraft;
            }
        }

        private int recipeLevel;
        private int itemLevel;
        private int baseItemLevel;
        private int durability;
        private int remainingDurability;
        private double progress;
        private int difficulty;
        private double quality;
        private int itemQuality;
        private string itemName;
        private int step;
        private ElementalAffinity affinity;

        public int ItemLevel
        {
            get { return itemLevel; }
        }

        public int RecipeLevel
        {
            get { return recipeLevel; }
        }

        public int BaseItemLevel
        {
            get { return baseItemLevel; }
        }

        public int Durability
        {
            get { return durability; }
        }

        public int RemainingDurability
        {
            get { return remainingDurability; }
        }

        public double Progress
        {
            get { return progress; }
        }

        public int Difficulty
        {
            get { return difficulty; }
        }

        public double Quality
        {
            get { return quality; }
        }

        public int ItemQuality
        {
            get { return itemQuality; }
        }

        public string ItemName
        {
            get { return itemName; }
        }

        public int Step
        {
            get { return step; }
        }

        public ElementalAffinity Affinity
        {
            get { return affinity; }
        }

        public void SetInitialValues(int recipeLevel, int itemLevel, int durability, int difficulty, int itemQuality, string itemName)
        {
            this.recipeLevel = recipeLevel;
            this.itemLevel = itemLevel;
            this.baseItemLevel = itemLevel;
            this.durability = durability;
            this.remainingDurability = durability;
            this.difficulty = difficulty;
            this.itemQuality = itemQuality;
            this.itemName = itemName;
        }

        public void SetInitialValues(int recipeLevel, int itemLevel, int durability, int difficulty, int itemQuality, string itemName, ElementalAffinity affinity)
        {
            this.recipeLevel = recipeLevel;
            this.itemLevel = itemLevel;
            this.baseItemLevel = itemLevel;
            this.durability = durability;
            this.remainingDurability = durability;
            this.difficulty = difficulty;
            this.itemQuality = itemQuality;
            this.itemName = itemName;
            this.affinity = affinity;
        }

        public void UpdateProgress(double progressMade)
        {
            progress += progressMade;
        }

        public void UpdateQuality(double qualityIncrease)
        {
            quality += qualityIncrease;
        }

        public void UpdateDurability(int durabilityLost)
        {
            remainingDurability -= durabilityLost;
        }

        public void SetItemLevel(int itemLevel)
        {
            this.itemLevel = itemLevel;
        }

        public void IncrementStep()
        {
            step++;
        }

        public string ShowStatus()
        {
            string temp = String.Empty;

            temp += ItemName + " (iLvl - " + itemLevel + "):";
            temp += " step " + step;
            temp += " dur " + remainingDurability + "/" + durability;
            temp += " pro " + Math.Round(progress, 0, MidpointRounding.ToEven) + "/" + difficulty;
            temp += " qua " + Math.Round(quality, 0, MidpointRounding.ToEven) + "/" + itemQuality;

            return temp;
        }
    }

}
