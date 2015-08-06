using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestSimulator;

namespace SimulatorTests
{    
    [TestClass]
    public class Sub50ProgressIngenuityI
    {
        public class MockCrafter : ICrafter
        {
            private static MockCrafter theMockCrafter;

            private MockCrafter()
            {
                //Craftsmanship
                craftsmanship = 395;
                baseCraftsmanship = 395;
                //Control
                control = 356;
                baseControl = 356;
                //CP
                cp = 349;
                baseCP = 349;
                //Crafter Level
                crafterLevel = 50;
            }

            public static MockCrafter TheMockCrafter
            {
                get
                {
                    if (theMockCrafter == null)
                        theMockCrafter = new MockCrafter();

                    return theMockCrafter;
                }
            }

            private double craftsmanship;
            private int baseCraftsmanship;
            private double control;
            private int baseControl;
            private int cp;
            private int baseCP;
            private int crafterLevel;

            public int CrafterLevel
            {
                get { return crafterLevel; }
            }

            public double Craftsmanship
            {
                get { return craftsmanship; }
            }

            public double Control
            {
                get { return control; }
            }

            public int CP
            {
                get { return cp; }
            }

            public int BaseControl
            {
                get { return baseControl; }
            }

            public int BaseCP
            {
                get { return baseCP; }
            }

            public int BaseCraftsmanship
            {
                get { return baseCraftsmanship; }
            }

            public void IncreaseControl(double controlIncrease)
            {
                control += controlIncrease;
            }

            public void IncreaseCraftsmanship(double craftsmanshipIncrease)
            {
                craftsmanship += craftsmanshipIncrease;
            }

            public void IncreaseCP(int cpIncrease)
            {
                cp += cpIncrease;
            }

            public void UpdateCP(int cpUsed)
            {
                cp -= cpUsed;
            }

            public string ShowStatus()
            {
                string temp = String.Empty;

                temp = "Crafter Level : " + crafterLevel;
                if (craftsmanship != baseCraftsmanship)
                {
                    temp += " craft : " + craftsmanship + "(base : " + baseCraftsmanship + ")";
                }
                else
                {
                    temp += " craft : " + craftsmanship;
                }
                if (Math.Round(control, 0, MidpointRounding.ToEven) != baseControl)
                {
                    temp += " con : " + Math.Round(control, 2, MidpointRounding.ToEven) + "(base : " + baseControl + ")";
                }
                else
                {
                    temp += " con : " + Math.Round(control, 2, MidpointRounding.ToEven);
                }
                temp += " CP : " + cp + "/" + baseCP;

                return temp;
            }

            public void EatFood()
            {
            }
        }
                
        [TestMethod]
        public void CalculateProgress_120_EvenLevel()
        {
            //Arrange                        
            double expected = 130;
            MockCraft.TheMockCraft.SetInitialValues((MockCrafter.TheMockCrafter.CrafterLevel), (MockCrafter.TheMockCrafter.CrafterLevel), 40, 1436, 9999, "");                        
            double progressMultiplier = 1.2;

            //Act
            Ingenuity ing = new Ingenuity();
            string temp = ing.ApplyModifier(MockCrafter.TheMockCrafter, MockCraft.TheMockCraft);
            var result = Calc.Progress(MockCraft.TheMockCraft.RecipeLevel, MockCraft.TheMockCraft.ItemLevel, MockCrafter.TheMockCrafter.CrafterLevel, MockCrafter.TheMockCrafter.Craftsmanship) * progressMultiplier;

            //Assert
            Assert.AreEqual(expected, Math.Round(result, 0, MidpointRounding.ToEven), 1);
        }

        [TestMethod]
        public void CalculateProgress_120__Recipe_One_Level_Lower_Than_Crafter()
        {
            //Arrange                        
            double expected = 132;
            MockCraft.TheMockCraft.SetInitialValues((MockCrafter.TheMockCrafter.CrafterLevel - 1), (MockCrafter.TheMockCrafter.CrafterLevel - 1), 40, 1436, 9999, "");                        
            double progressMultiplier = 1.2;

            //Act
            Ingenuity ing = new Ingenuity();
            string temp = ing.ApplyModifier(MockCrafter.TheMockCrafter, MockCraft.TheMockCraft);
            var result = Calc.Progress(MockCraft.TheMockCraft.RecipeLevel, MockCraft.TheMockCraft.ItemLevel, MockCrafter.TheMockCrafter.CrafterLevel, MockCrafter.TheMockCrafter.Craftsmanship) * progressMultiplier;

            //Assert
            Assert.AreEqual(expected, Math.Round(result, 0, MidpointRounding.ToEven), 1);
        }        

        [TestMethod]
        public void CalculateProgress_120__Recipe_Two_Levels_Lower_Than_Crafter()
        {
            //Arrange                        
            double expected = 134;
            MockCraft.TheMockCraft.SetInitialValues((MockCrafter.TheMockCrafter.CrafterLevel - 2), (MockCrafter.TheMockCrafter.CrafterLevel - 2), 40, 1436, 9999, "");                        
            double progressMultiplier = 1.2;

            //Act
            Ingenuity ing = new Ingenuity();
            string temp = ing.ApplyModifier(MockCrafter.TheMockCrafter, MockCraft.TheMockCraft);
            var result = Calc.Progress(MockCraft.TheMockCraft.RecipeLevel, MockCraft.TheMockCraft.ItemLevel, MockCrafter.TheMockCrafter.CrafterLevel, MockCrafter.TheMockCrafter.Craftsmanship) * progressMultiplier;

            //Assert
            Assert.AreEqual(expected, Math.Round(result, 0, MidpointRounding.ToEven), 1);
        }        

        [TestMethod]
        public void CalculateProgress_120__Recipe_Three_Levels_Lower_Than_Crafter()
        {
            //Arrange                        
            double expected = 136;
            MockCraft.TheMockCraft.SetInitialValues((MockCrafter.TheMockCrafter.CrafterLevel - 3), (MockCrafter.TheMockCrafter.CrafterLevel - 3), 40, 1436, 9999, "");                        
            double progressMultiplier = 1.2;

            //Act
            Ingenuity ing = new Ingenuity();
            string temp = ing.ApplyModifier(MockCrafter.TheMockCrafter, MockCraft.TheMockCraft);
            var result = Calc.Progress(MockCraft.TheMockCraft.RecipeLevel, MockCraft.TheMockCraft.ItemLevel, MockCrafter.TheMockCrafter.CrafterLevel, MockCrafter.TheMockCrafter.Craftsmanship) * progressMultiplier;

            //Assert
            Assert.AreEqual(expected, Math.Round(result, 0, MidpointRounding.ToEven), 1);
        }        

        [TestMethod]
        public void CalculateProgress_120__Recipe_Four_Levels_Lower_Than_Crafter()
        {
            //Arrange                        
            double expected = 138;
            MockCraft.TheMockCraft.SetInitialValues((MockCrafter.TheMockCrafter.CrafterLevel - 4), (MockCrafter.TheMockCrafter.CrafterLevel - 4), 40, 1436, 9999, "");                        
            double progressMultiplier = 1.2;

            //Act
            Ingenuity ing = new Ingenuity();
            string temp = ing.ApplyModifier(MockCrafter.TheMockCrafter, MockCraft.TheMockCraft);
            var result = Calc.Progress(MockCraft.TheMockCraft.RecipeLevel, MockCraft.TheMockCraft.ItemLevel, MockCrafter.TheMockCrafter.CrafterLevel, MockCrafter.TheMockCrafter.Craftsmanship) * progressMultiplier;

            //Assert
            Assert.AreEqual(expected, Math.Round(result, 0, MidpointRounding.ToEven), 1);
        }
       
        [TestMethod]
        public void CalculateProgress_120__Recipe_Five_Levels_Lower_Than_Crafter()
        {
            //Arrange                        
            double expected = 140;
            MockCraft.TheMockCraft.SetInitialValues((MockCrafter.TheMockCrafter.CrafterLevel - 5), (MockCrafter.TheMockCrafter.CrafterLevel - 5), 40, 1436, 9999, "");                        
            double progressMultiplier = 1.2;

            //Act
            Ingenuity ing = new Ingenuity();
            string temp = ing.ApplyModifier(MockCrafter.TheMockCrafter, MockCraft.TheMockCraft);
            var result = Calc.Progress(MockCraft.TheMockCraft.RecipeLevel, MockCraft.TheMockCraft.ItemLevel, MockCrafter.TheMockCrafter.CrafterLevel, MockCrafter.TheMockCrafter.Craftsmanship) * progressMultiplier;

            //Assert
            Assert.AreEqual(expected, Math.Round(result, 0, MidpointRounding.ToEven), 1);
        }

        [TestMethod]
        public void CalculateProgress_120__Recipe_Six_Levels_Lower_Than_Crafter()
        {
            //Arrange                        
            double expected = 143;
            MockCraft.TheMockCraft.SetInitialValues((MockCrafter.TheMockCrafter.CrafterLevel - 6), (MockCrafter.TheMockCrafter.CrafterLevel - 6), 40, 1436, 9999, "");                        
            double progressMultiplier = 1.2;

            //Act
            Ingenuity ing = new Ingenuity();
            string temp = ing.ApplyModifier(MockCrafter.TheMockCrafter, MockCraft.TheMockCraft);
            var result = Calc.Progress(MockCraft.TheMockCraft.RecipeLevel, MockCraft.TheMockCraft.ItemLevel, MockCrafter.TheMockCrafter.CrafterLevel, MockCrafter.TheMockCrafter.Craftsmanship) * progressMultiplier;

            //Assert
            Assert.AreEqual(expected, Math.Round(result, 0, MidpointRounding.ToEven), 1);
        }

        [TestMethod]
        public void CalculateProgress_120__Recipe_Seven_Levels_Lower_Than_Crafter()
        {
            //Arrange                        
            double expected = 145;
            MockCraft.TheMockCraft.SetInitialValues((MockCrafter.TheMockCrafter.CrafterLevel - 7), (MockCrafter.TheMockCrafter.CrafterLevel - 7), 40, 1436, 9999, "");                        
            double progressMultiplier = 1.2;

            //Act
            Ingenuity ing = new Ingenuity();
            string temp = ing.ApplyModifier(MockCrafter.TheMockCrafter, MockCraft.TheMockCraft);
            var result = Calc.Progress(MockCraft.TheMockCraft.RecipeLevel, MockCraft.TheMockCraft.ItemLevel, MockCrafter.TheMockCrafter.CrafterLevel, MockCrafter.TheMockCrafter.Craftsmanship) * progressMultiplier;

            //Assert
            Assert.AreEqual(expected, Math.Round(result, 0, MidpointRounding.ToEven), 1);
        }

        [TestMethod]
        public void CalculateProgress_120__Recipe_Eight_Levels_Lower_Than_Crafter()
        {
            //Arrange                        
            double expected = 147;
            MockCraft.TheMockCraft.SetInitialValues((MockCrafter.TheMockCrafter.CrafterLevel - 8), (MockCrafter.TheMockCrafter.CrafterLevel - 8), 40, 1436, 9999, "");                        
            double progressMultiplier = 1.2;

            //Act
            Ingenuity ing = new Ingenuity();
            string temp = ing.ApplyModifier(MockCrafter.TheMockCrafter, MockCraft.TheMockCraft);
            var result = Calc.Progress(MockCraft.TheMockCraft.RecipeLevel, MockCraft.TheMockCraft.ItemLevel, MockCrafter.TheMockCrafter.CrafterLevel, MockCrafter.TheMockCrafter.Craftsmanship) * progressMultiplier;

            //Assert
            Assert.AreEqual(expected, Math.Round(result, 0, MidpointRounding.ToEven), 1);
        }

        [TestMethod]
        public void CalculateProgress_120__Recipe_Nine_Levels_Lower_Than_Crafter()
        {
            //Arrange                        
            double expected = 149;
            MockCraft.TheMockCraft.SetInitialValues((MockCrafter.TheMockCrafter.CrafterLevel - 9), (MockCrafter.TheMockCrafter.CrafterLevel - 9), 40, 1436, 9999, "");                        
            double progressMultiplier = 1.2;

            //Act
            Ingenuity ing = new Ingenuity();
            string temp = ing.ApplyModifier(MockCrafter.TheMockCrafter, MockCraft.TheMockCraft);
            var result = Calc.Progress(MockCraft.TheMockCraft.RecipeLevel, MockCraft.TheMockCraft.ItemLevel, MockCrafter.TheMockCrafter.CrafterLevel, MockCrafter.TheMockCrafter.Craftsmanship) * progressMultiplier;

            //Assert
            Assert.AreEqual(expected, Math.Round(result, 0, MidpointRounding.ToEven), 1);
        }

        [TestMethod]
        public void CalculateProgress_120__Recipe_Ten_Levels_Lower_Than_Crafter()
        {
            //Arrange                        
            double expected = 151;
            MockCraft.TheMockCraft.SetInitialValues((MockCrafter.TheMockCrafter.CrafterLevel - 10), (MockCrafter.TheMockCrafter.CrafterLevel - 10), 40, 1436, 9999, "");                        
            double progressMultiplier = 1.2;

            //Act
            Ingenuity ing = new Ingenuity();
            string temp = ing.ApplyModifier(MockCrafter.TheMockCrafter, MockCraft.TheMockCraft);
            var result = Calc.Progress(MockCraft.TheMockCraft.RecipeLevel, MockCraft.TheMockCraft.ItemLevel, MockCrafter.TheMockCrafter.CrafterLevel, MockCrafter.TheMockCrafter.Craftsmanship) * progressMultiplier;

            //Assert
            Assert.AreEqual(expected, Math.Round(result, 0, MidpointRounding.ToEven), 1);
        }
    }
}
