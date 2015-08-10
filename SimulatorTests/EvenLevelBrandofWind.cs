using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestSimulator;
using System.Collections.Generic;

namespace SimulatorTests
{
    [TestClass]
    public class EvenLevelBrandofWind
    {
        public class MockCrafter : ICrafter
        {
            private static MockCrafter theMockCrafter;

            private MockCrafter()
            {
                //Craftsmanship
                craftsmanship = 601;
                baseCraftsmanship = 601;
                //Control
                control = 555;
                baseControl = 555;
                //CP
                cp = 364;
                baseCP = 364;
                //Crafter Level
                crafterLevel = 60;
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
        public void CalculateProgress_BrandOfWind_NoNameOfWind_NoWindAffinity()
        {
            //Arrange                        
            double expected = 128;
            MockCraft.TheMockCraft.SetInitialValues(60, 150, 70, 956, 9999, "");            

            //Act
            BrandOfWind brand = new BrandOfWind();
            string temp = brand.ExecuteAction(MockCraft.TheMockCraft, MockCrafter.TheMockCrafter, new List<IModifier>(), new Random(), Conditions.Normal);
            var result = MockCraft.TheMockCraft.Progress;

            //Assert
            Assert.AreEqual(expected, Math.Round(result, 0, MidpointRounding.ToEven), 1);
        }

        [TestMethod]
        public void CalculateProgress_BrandOfWind_NameOfWind_NoWindAffinity_128ProgressMade()
        {
            //Arrange                        
            double expected = 351;
            MockCraft.TheMockCraft.SetInitialValues(60, 150, 70, 956, 9999, "");
            MockCraft.TheMockCraft.UpdateProgress(128);
            List<IModifier> modifiers = new List<IModifier>();
            modifiers.Add(new NameOfWind());

            //Act
            BrandOfWind brand = new BrandOfWind();            
            string temp = brand.ExecuteAction(MockCraft.TheMockCraft, MockCrafter.TheMockCrafter, modifiers, new Random(), Conditions.Normal);
            var result = MockCraft.TheMockCraft.Progress;

            //Assert
            Assert.AreEqual(expected, Math.Round(result, 0, MidpointRounding.ToEven), 1);
        }
    }
}
