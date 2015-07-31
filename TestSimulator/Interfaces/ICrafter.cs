using System;
namespace TestSimulator
{
    public interface ICrafter
    {
        //Properties
        int BaseControl { get; }
        int BaseCP { get; }
        int BaseCraftsmanship { get; }
        double Control { get; }
        int CP { get; }
        int CrafterLevel { get; }
        double Craftsmanship { get; }

        //Methods
        void EatFood();
        void IncreaseControl(double controlIncrease);
        void IncreaseCP(int cpIncrease);
        void IncreaseCraftsmanship(double craftsmanshipIncrease);
        string ShowStatus();
        void UpdateCP(int cpUsed);
    }
}
