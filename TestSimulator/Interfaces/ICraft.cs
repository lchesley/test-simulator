using System;
namespace TestSimulator
{
    public interface ICraft
    {
        //Properties
        ElementalAffinity Affinity { get; }
        int Difficulty { get; }
        int Durability { get; }
        void IncrementStep();
        int ItemLevel { get; }
        int BaseItemLevel { get; }
        string ItemName { get; }
        int ItemQuality { get; }
        double Progress { get; }
        double Quality { get; }
        int RemainingDurability { get; }        
        string ShowStatus();
        int Step { get; }

        //Methods
        void UpdateDurability(int durabilityLost);
        void UpdateProgress(double progressMade);
        void UpdateQuality(double qualityIncrease);
        void SetItemLevel(int itemLevel);
        void SetInitialValues(int itemLevel, int durability, int difficulty, int itemQuality, string itemName);
        void SetInitialValues(int itemLevel, int durability, int difficulty, int itemQuality, string itemName, ElementalAffinity affinity);
    }
}
