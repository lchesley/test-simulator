using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSimulator
{
    public interface IModifier
    {
        //Properties
        string ModifierName
        {
            get;
        }

        int CPCost
        {
            get;
        }

        int DurabilityReturned
        {
            get;
        }

        int StepsActive
        {
            get;
        }

        int StepsRemaining
        {
            get;
        }

        int SuccessChanceModifier
        {
            get;
        }

        int ProgressModifier
        {
            get;
        }

        int QualityModifier
        {
            get;
        }

        double DurabilityCostModifier
        {
            get;
        }

        double ControlModifier
        {
            get;
        }

        ElementalAffinity Affinity
        {
            get;
        }

        //Methods
        string ApplyModifier(ICrafter crafter, ICraft craft);
        string ApplyModifier(IAction action);
        void AfterSuccessfulQualityIncrease(ICrafter crafter);
        void AtEndOfStep(ICrafter crafter, ICraft craft);
        string ShowCurrentStatus();
    }
}
