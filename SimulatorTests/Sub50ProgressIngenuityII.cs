using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestSimulator;

namespace SimulatorTests
{    
    [TestClass]
    public class Sub50ProgressIngenuityII
    {
        int crafterLevel;
        int ingenuityFactor;
        double craftsmanship;

        [TestInitialize]        
        public void Initialize()
        {
            crafterLevel = 50;
            ingenuityFactor = 8;
            craftsmanship = 395;            
        }

        [TestMethod]
        public void CalculateProgress_100_Recipe_Six_Levels_Higher_Than_Crafter()
        {
            //Arrange                        
            double expected = 47;
            int recipeLevel = 110;

            //Act
            var result = Calc.Progress(recipeLevel - ingenuityFactor, crafterLevel, craftsmanship);

            //Assert
            Assert.AreEqual<double>(expected, Math.Round(result, 0, MidpointRounding.ToEven));
        }

        [TestMethod]
        public void CalculateProgress_120_Recipe_Six_Levels_Higher_Than_Crafter()
        {
            //Arrange                        
            double expected = 57;
            int recipeLevel = 110;
            double progressMultiplier = 1.2;

            //Act
            var result = Calc.Progress(recipeLevel - ingenuityFactor, crafterLevel, craftsmanship) * progressMultiplier;

            //Assert
            Assert.AreEqual<double>(expected, Math.Round(result, 0, MidpointRounding.ToEven));
        }

        [TestMethod]
        public void CalculateProgress_100_Recipe_Five_Levels_Higher_Than_Crafter()
        {
            //Arrange                        
            double expected = 99;
            int recipeLevel = 55;

            //Act
            var result = Calc.Progress(recipeLevel - ingenuityFactor, crafterLevel, craftsmanship);

            //Assert
            Assert.AreEqual<double>(expected, Math.Round(result, 0, MidpointRounding.ToEven));
        }

        [TestMethod]
        public void CalculateProgress_120_Recipe_Five_Levels_Higher_Than_Crafter()
        {
            //Arrange                        
            double expected = 119;
            int recipeLevel = 55;
            double progressMultiplier = 1.2;

            //Act
            var result = Calc.Progress(recipeLevel - ingenuityFactor, crafterLevel, craftsmanship) * progressMultiplier;

            //Assert
            Assert.AreEqual<double>(expected, Math.Round(result, 0, MidpointRounding.ToEven));
        }

        [TestMethod]
        public void CalculateProgress_100_EvenLevel()
        {
            //Arrange            
            double expected = 114;
            int recipeLevel = crafterLevel;                        

            //Act
            var result = Calc.Progress(recipeLevel - ingenuityFactor, crafterLevel, craftsmanship);

            //Assert
            Assert.AreEqual<double>(expected, Math.Round(result, 0, MidpointRounding.ToEven));
        }

        [TestMethod]
        public void CalculateProgress_120_EvenLevel()
        {
            //Arrange                        
            double expected = 136;
            int recipeLevel = crafterLevel;            
            double progressMultiplier = 1.2;

            //Act
            var result = Calc.Progress(recipeLevel - ingenuityFactor, crafterLevel, craftsmanship) * progressMultiplier;

            //Assert
            Assert.AreEqual<double>(expected, Math.Round(result, 0, MidpointRounding.ToEven));
        }

        [TestMethod]
        public void CalculateProgress_100_Recipe_One_Level_Lower_Than_Crafter()
        {
            //Arrange                        
            double expected = 116;
            int recipeLevel = crafterLevel - 1;            

            //Act
            var result = Calc.Progress(recipeLevel - ingenuityFactor, crafterLevel, craftsmanship);

            //Assert
            Assert.AreEqual<double>(expected, Math.Round(result, 0, MidpointRounding.ToEven));
        }

        [TestMethod]
        public void CalculateProgress_120__Recipe_One_Level_Lower_Than_Crafter()
        {
            //Arrange                        
            double expected = 138;
            int recipeLevel = crafterLevel - 1;                        
            double progressMultiplier = 1.2;

            //Act
            var result = Calc.Progress(recipeLevel - ingenuityFactor, crafterLevel, craftsmanship) * progressMultiplier;

            //Assert
            Assert.AreEqual<double>(expected, Math.Round(result, 0, MidpointRounding.ToEven));
        }

        [TestMethod]
        public void CalculateProgress_100_Recipe_Two_Levels_Lower_Than_Crafter()
        {
            //Arrange                        
            double expected = 117;
            int recipeLevel = crafterLevel - 2;                                    

            //Act
            var result = Calc.Progress(recipeLevel - ingenuityFactor, crafterLevel, craftsmanship);

            //Assert
            Assert.AreEqual<double>(expected, Math.Round(result, 0, MidpointRounding.ToEven));
        }

        [TestMethod]
        public void CalculateProgress_120__Recipe_Two_Levels_Lower_Than_Crafter()
        {
            //Arrange                        
            double expected = 140;
            int recipeLevel = crafterLevel - 2;                        
            double progressMultiplier = 1.2;

            //Act
            var result = Calc.Progress(recipeLevel - ingenuityFactor, crafterLevel, craftsmanship) * progressMultiplier;

            //Assert
            Assert.AreEqual<double>(expected, Math.Round(result, 0, MidpointRounding.ToEven));
        }

        [TestMethod]
        public void CalculateProgress_100_Recipe_Three_Levels_Lower_Than_Crafter()
        {
            //Arrange                        
            double expected = 119;
            int recipeLevel = crafterLevel - 3;            

            //Act
            var result = Calc.Progress(recipeLevel - ingenuityFactor, crafterLevel, craftsmanship);

            //Assert
            Assert.AreEqual<double>(expected, Math.Round(result, 0, MidpointRounding.ToEven));
        }

        [TestMethod]
        public void CalculateProgress_120__Recipe_Three_Levels_Lower_Than_Crafter()
        {
            //Arrange                        
            double expected = 142;
            int recipeLevel = crafterLevel - 3;            
            double progressMultiplier = 1.2;

            //Act
            var result = Calc.Progress(recipeLevel - ingenuityFactor, crafterLevel, craftsmanship) * progressMultiplier;

            //Assert
            Assert.AreEqual<double>(expected, Math.Round(result, 0, MidpointRounding.ToEven));
        }

        [TestMethod]
        public void CalculateProgress_100_Recipe_Four_Levels_Lower_Than_Crafter()
        {
            //Arrange                        
            double expected = 121;
            int recipeLevel = crafterLevel - 4;            

            //Act
            var result = Calc.Progress(recipeLevel - ingenuityFactor, crafterLevel, craftsmanship);

            //Assert
            Assert.AreEqual<double>(expected, Math.Round(result, 0, MidpointRounding.ToEven));
        }

        [TestMethod]
        public void CalculateProgress_120__Recipe_Four_Levels_Lower_Than_Crafter()
        {
            //Arrange                        
            double expected = 144;
            int recipeLevel = crafterLevel - 4;            
            double progressMultiplier = 1.2;

            //Act
            var result = Calc.Progress(recipeLevel - ingenuityFactor, crafterLevel, craftsmanship) * progressMultiplier;

            //Assert
            Assert.AreEqual<double>(expected, Math.Round(result, 0, MidpointRounding.ToEven));
        }

        [TestMethod]
        public void CalculateProgress_100_Recipe_Five_Levels_Lower_Than_Crafter()
        {
            //Arrange                        
            double expected = 123;
            int recipeLevel = crafterLevel - 5;            

            //Act
            var result = Calc.Progress(recipeLevel - ingenuityFactor, crafterLevel, craftsmanship);

            //Assert
            Assert.AreEqual<double>(expected, Math.Round(result, 0, MidpointRounding.ToEven));
        }

        [TestMethod]
        public void CalculateProgress_120__Recipe_Five_Levels_Lower_Than_Crafter()
        {
            //Arrange                        
            double expected = 147;
            int recipeLevel = crafterLevel - 5;            
            double progressMultiplier = 1.2;

            //Act
            var result = Calc.Progress(recipeLevel - ingenuityFactor, crafterLevel, craftsmanship) * progressMultiplier;

            //Assert
            Assert.AreEqual<double>(expected, Math.Round(result, 0, MidpointRounding.ToEven));
        }

        [TestMethod]
        public void CalculateProgress_100_Recipe_Six_Levels_Lower_Than_Crafter()
        {
            //Arrange                        
            double expected = 125;
            int recipeLevel = crafterLevel - 6;            

            //Act
            var result = Calc.Progress(recipeLevel - ingenuityFactor, crafterLevel, craftsmanship);

            //Assert
            Assert.AreEqual<double>(expected, Math.Round(result, 0, MidpointRounding.ToEven));
        }

        [TestMethod]
        public void CalculateProgress_120__Recipe_Six_Levels_Lower_Than_Crafter()
        {
            //Arrange                        
            double expected = 149;
            int recipeLevel = crafterLevel - 6;                        
            double progressMultiplier = 1.2;

            //Act
            var result = Calc.Progress(recipeLevel - ingenuityFactor, crafterLevel, craftsmanship) * progressMultiplier;

            //Assert
            Assert.AreEqual<double>(expected, Math.Round(result, 0, MidpointRounding.ToEven));
        }

        [TestMethod]
        public void CalculateProgress_100_Recipe_Seven_Levels_Lower_Than_Crafter()
        {
            //Arrange                        
            double expected = 127;
            int recipeLevel = crafterLevel - 7;            

            //Act
            var result = Calc.Progress(recipeLevel - ingenuityFactor, crafterLevel, craftsmanship);

            //Assert
            Assert.AreEqual<double>(expected, Math.Round(result, 0, MidpointRounding.ToEven));
        }

        [TestMethod]
        public void CalculateProgress_120__Recipe_Seven_Levels_Lower_Than_Crafter()
        {
            //Arrange                        
            double expected = 151;
            int recipeLevel = crafterLevel - 7;                        
            double progressMultiplier = 1.2;

            //Act
            var result = Calc.Progress(recipeLevel - ingenuityFactor, crafterLevel, craftsmanship) * progressMultiplier;

            //Assert
            Assert.AreEqual<double>(expected, Math.Round(result, 0, MidpointRounding.ToEven));
        }

        [TestMethod]
        public void CalculateProgress_100_Recipe_Eight_Levels_Lower_Than_Crafter()
        {
            //Arrange                        
            double expected = 128;
            int recipeLevel = crafterLevel - 8;            

            //Act
            var result = Calc.Progress(recipeLevel - ingenuityFactor, crafterLevel, craftsmanship);

            //Assert
            Assert.AreEqual<double>(expected, Math.Round(result, 0, MidpointRounding.ToEven));
        }

        [TestMethod]
        public void CalculateProgress_120__Recipe_Eight_Levels_Lower_Than_Crafter()
        {
            //Arrange                        
            double expected = 153;
            int recipeLevel = crafterLevel - 8;            
            double progressMultiplier = 1.2;

            //Act
            var result = Calc.Progress(recipeLevel - ingenuityFactor, crafterLevel, craftsmanship) * progressMultiplier;

            //Assert
            Assert.AreEqual<double>(expected, Math.Round(result, 0, MidpointRounding.ToEven));
        }

        [TestMethod]
        public void CalculateProgress_100_Recipe_Nine_Levels_Lower_Than_Crafter()
        {
            //Arrange                        
            double expected = 129;
            int recipeLevel = crafterLevel - 9;                                                

            //Act
            var result = Calc.Progress(recipeLevel - ingenuityFactor, crafterLevel, craftsmanship);

            //Assert
            Assert.AreEqual<double>(expected, Math.Round(result, 0, MidpointRounding.ToEven));
        }

        [TestMethod]
        public void CalculateProgress_120__Recipe_Nine_Levels_Lower_Than_Crafter()
        {
            //Arrange                        
            double expected = 153;
            int recipeLevel = crafterLevel - 9;                                    
            double progressMultiplier = 1.2;

            //Act
            var result = Calc.Progress(recipeLevel - ingenuityFactor, crafterLevel, craftsmanship) * progressMultiplier;

            //Assert
            Assert.AreEqual<double>(expected, Math.Round(result, 0, MidpointRounding.ToEven));
        }

        [TestMethod]
        public void CalculateProgress_100_Recipe_Ten_Levels_Lower_Than_Crafter()
        {
            //Arrange                        
            double expected = 128;
            int recipeLevel = crafterLevel - 10;                        

            //Act
            var result = Calc.Progress(recipeLevel - ingenuityFactor, crafterLevel, craftsmanship);

            //Assert
            Assert.AreEqual<double>(expected, Math.Round(result, 0, MidpointRounding.ToEven));
        }

        [TestMethod]
        public void CalculateProgress_120__Recipe_Ten_Levels_Lower_Than_Crafter()
        {
            //Arrange                        
            double expected = 154;
            int recipeLevel = crafterLevel - 10;            
            double progressMultiplier = 1.2;

            //Act
            var result = Calc.Progress(recipeLevel - ingenuityFactor, crafterLevel, craftsmanship) * progressMultiplier;

            //Assert
            Assert.AreEqual<double>(expected, Math.Round(result, 0, MidpointRounding.ToEven));
        }
    }
}
