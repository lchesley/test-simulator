using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSimulator
{
    public class Controller
    {
        private static Controller theController;

        private Controller()
        {
            actionStack = new List<IAction>();
            modifierStack = new List<IModifier>();
            rng = new Random();
            condition = Calc.GetCondition(rng);
            PopulateActionList();
            PopulateModifierList();
        }

        public static Controller TheController
        {
            get
            {
                if (theController == null)
                    theController = new Controller();

                return theController;
            }
        }

        private Conditions condition;
        private List<IAction> actionStack;
        private List<IModifier> modifierStack;
        private Random rng;
        private List<string> actionList;
        private List<string> modifierList;

        public Conditions Condition
        {
            get { return condition; }
        }

        public List<IAction> ActionStack
        {
            get { return actionStack; }
        }

        public List<IModifier> ModifierStack
        {
            get { return ModifierStack;  }
        }

        public string ExecuteCommand(string command)
        {
            string result = String.Empty;

            if (!actionList.Contains(command) && !modifierList.Contains(command))
            {
                result += command + " does not exist.  Please choose a valid action.";
            }
            else
            {
                if (actionList.Contains(command))
                {
                    actionStack.Add(Factory.GetAction(command));
                    result += DoAction();
                }
                else                
                {
                    var modifier = Factory.GetModifier(command);
                    modifierStack.Add(modifier);
                    result += DoModifier(modifier);
                }
            }

            UpdateAtEndOfStep();
            result += ShowModifierStatus();
            UpdateCondition();

            return result;
        }

        private string ShowModifierStatus()
        {
            string result = String.Empty;

            foreach (IModifier modifier in modifierStack)
            {
                if(modifier.StepsRemaining > 0)
                {
                    result += modifier.ShowCurrentStatus() + Environment.NewLine;
                }
            }

            return result;
        }

        private string DoAction()
        {
            string result = String.Empty;

            foreach(IAction action in actionStack)
            {
                if(!action.ActionUsed)
                {
                    result += ApplyModifiersToAction(action);
                    result += action.ExecuteAction(Craft.TheCraft, Crafter.TheCrafter, modifierStack, rng, condition) + Environment.NewLine;
                    result += ApplyModifiersToAction(action);
                    UpdateAfterSuccessfulQualityIncrease(action);                    
                }
            }            

            return result;
        }

        private string DoModifier(IModifier modifier)
        {
            return modifier.ApplyModifier(Crafter.TheCrafter, Craft.TheCraft) + Environment.NewLine; 
        }

        private string ApplyModifiersToAction(IAction action)
        {
            string result = String.Empty;

            foreach(IModifier modifier in modifierStack)
            {
                if(modifier.StepsRemaining > 0)
                {
                    result += modifier.ApplyModifier(action) + Environment.NewLine; 
                }
            }

            return result;
        }

        private void UpdateAfterSuccessfulQualityIncrease(IAction action)
        {
            if(action.WasSuccessful)
            {
                if(action.QualityModifier > 0)
                {
                    foreach(IModifier modifier in modifierStack)
                    {
                        modifier.AfterSuccessfulQualityIncrease(Crafter.TheCrafter);
                    }
                }
            }
        }

        private void UpdateAtEndOfStep()
        {
            foreach(IModifier modifier in modifierStack)
            {
                if(modifier.StepsRemaining >= 0)
                {
                    modifier.AtEndOfStep(Crafter.TheCrafter, Craft.TheCraft);
                }
            }
        }

        private void UpdateCondition()
        {
            condition = Calc.GetCondition(rng, condition);
        }

        private void PopulateActionList()
        {
            actionList = new List<string>();
            actionList.Add(Actions.HastyTouch);
            actionList.Add(Actions.BasicTouch);
            actionList.Add(Actions.PreciseTouch);
            actionList.Add(Actions.StandardTouch);
            actionList.Add(Actions.AdvancedTouch);
            actionList.Add(Actions.ByregotsBlessing);
            actionList.Add(Actions.CarefulSynthesisI);
            actionList.Add(Actions.CarefulSynthesisII);
            actionList.Add(Actions.TricksoftheTrade);
            actionList.Add(Actions.MuscleMemory);
            actionList.Add(Actions.FlawlessSynthesis);
            actionList.Add(Actions.RapidSynthesis);
            actionList.Add(Actions.BasicSynthesis);
            actionList.Add(Actions.StandardSynthesis);
            actionList.Add(Actions.MastersMend);
            actionList.Add(Actions.MastersMendII);
            actionList.Add(Actions.Rumination);
            actionList.Add(Actions.PieceByPiece);
            actionList.Add(Actions.BrandOfEarth);
            actionList.Add(Actions.BrandOfFire);
            actionList.Add(Actions.BrandOfIce);
            actionList.Add(Actions.BrandOfLightning);
            actionList.Add(Actions.BrandOfWater);
            actionList.Add(Actions.BrandOfWind);
        }

        private void PopulateModifierList()
        {
            modifierList = new List<string>();
            modifierList.Add(Modifiers.GreatStrides);
            modifierList.Add(Modifiers.InnerQuiet);
            modifierList.Add(Modifiers.SteadyHand);
            modifierList.Add(Modifiers.SteadyHandII);
            modifierList.Add(Modifiers.Innovation);
            modifierList.Add(Modifiers.WasteNot);
            modifierList.Add(Modifiers.WasteNotII);
            modifierList.Add(Modifiers.Ingenuity);
            modifierList.Add(Modifiers.IngenuityII);
            modifierList.Add(Modifiers.ComfortZone);
            modifierList.Add(Modifiers.MakersMark);
            modifierList.Add(Modifiers.Manipulation);
            modifierList.Add(Modifiers.NameOfEarth);
            modifierList.Add(Modifiers.NameOfFire);
            modifierList.Add(Modifiers.NameOfIce);
            modifierList.Add(Modifiers.NameOfLightning);
            modifierList.Add(Modifiers.NameOfWater);
            modifierList.Add(Modifiers.NameOfWind);
        }
    }
}
