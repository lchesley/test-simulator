using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestSimulator;

namespace SimulatorTests
{
    [TestClass]
    public class Sub50Progress
    {
        int crafterLevel;        
        double craftsmanship;

        [TestInitialize]
        public void Initialize()
        {
            crafterLevel = 50;            
            craftsmanship = 395;
        }

        [TestMethod]
        public void CalculateProgress_100_Recipe_Six_Levels_Higher_Than_Crafter()
        {
            //Arrange                        
            double expected = 47;
            int recipeLevel = 110;

            //Act
            var result = Calc.Progress(recipeLevel, crafterLevel, craftsmanship);

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
            var result = Calc.Progress(recipeLevel, crafterLevel, craftsmanship) * progressMultiplier;

            //Assert
            Assert.AreEqual<double>(expected, Math.Round(result, 0, MidpointRounding.ToEven));
        }

        [TestMethod]
        public void CalculateProgress_100_Recipe_Five_Levels_Higher_Than_Crafter()
        {
            //Arrange                        
            double expected = 52;
            int recipeLevel = 55;

            //Act
            var result = Calc.Progress(recipeLevel, crafterLevel, craftsmanship);

            //Assert
            Assert.AreEqual<double>(expected, Math.Round(result, 0, MidpointRounding.ToEven));
        }

        [TestMethod]
        public void CalculateProgress_120_Recipe_Five_Levels_Higher_Than_Crafter()
        {
            //Arrange                        
            double expected = 62;
            int recipeLevel = 55;
            double progressMultiplier = 1.2;

            //Act
            var result = Calc.Progress(recipeLevel, crafterLevel, craftsmanship) * progressMultiplier;

            //Assert
            Assert.AreEqual<double>(expected, Math.Round(result, 0, MidpointRounding.ToEven));
        }

        [TestMethod]
        public void CalculateProgress_100_EvenLevel()
        {
            //Arrange                        
            double expected = 87;
            int recipeLevel = 50;            

            //Act
            var result = Calc.Progress(recipeLevel, crafterLevel, craftsmanship);

            //Assert
            Assert.AreEqual<double>(expected, Math.Round(result, 0, MidpointRounding.ToEven));
        }

        [TestMethod]
        public void CalculateProgress_120_EvenLevel()
        {
            //Arrange                        
            double expected = 104;
            int recipeLevel = 50;            
            double progressMultiplier = 1.2;

            //Act
            var result = Calc.Progress(recipeLevel, crafterLevel, craftsmanship) * progressMultiplier;

            //Assert
            Assert.AreEqual<double>(expected, Math.Round(result, 0, MidpointRounding.ToEven));
        }

        [TestMethod]
        public void CalculateProgress_100_Recipe_One_Level_Lower_Than_Crafter()
        {
            //Arrange                        
            double expected = 91;
            int recipeLevel = crafterLevel - 1;            

            //Act
            var result = Calc.Progress(recipeLevel, crafterLevel, craftsmanship);

            //Assert
            Assert.AreEqual<double>(expected, Math.Round(result, 0, MidpointRounding.ToEven));
        }

        [TestMethod]
        public void CalculateProgress_120__Recipe_One_Level_Lower_Than_Crafter()
        {
            //Arrange                        
            double expected = 109;
            int recipeLevel = crafterLevel - 1;                        
            double progressMultiplier = 1.2;

            //Act
            var result = Calc.Progress(recipeLevel, crafterLevel, craftsmanship) * progressMultiplier;

            //Assert
            Assert.AreEqual<double>(expected, Math.Round(result, 0, MidpointRounding.ToEven));
        }

        [TestMethod]
        public void CalculateProgress_100_Recipe_Two_Levels_Lower_Than_Crafter()
        {
            //Arrange                        
            double expected = 95;
            int recipeLevel = crafterLevel - 2;            

            //Act
            var result = Calc.Progress(recipeLevel, crafterLevel, craftsmanship);

            //Assert
            Assert.AreEqual<double>(expected, Math.Round(result, 0, MidpointRounding.ToEven));
        }

        [TestMethod]
        public void CalculateProgress_120__Recipe_Two_Levels_Lower_Than_Crafter()
        {
            //Arrange                        
            double expected = 114;
            int recipeLevel = crafterLevel - 2;            
            double progressMultiplier = 1.2;

            //Act
            var result = Calc.Progress(recipeLevel, crafterLevel, craftsmanship) * progressMultiplier;

            //Assert
            Assert.AreEqual<double>(expected, Math.Round(result, 0, MidpointRounding.ToEven));
        }

        [TestMethod]
        public void CalculateProgress_100_Recipe_Three_Levels_Lower_Than_Crafter()
        {
            //Arrange                        
            double expected = 99;
            int recipeLevel = crafterLevel - 3;            

            //Act
            var result = Calc.Progress(recipeLevel, crafterLevel, craftsmanship);

            //Assert
            Assert.AreEqual<double>(expected, Math.Round(result, 0, MidpointRounding.ToEven));
        }

        [TestMethod]
        public void CalculateProgress_120__Recipe_Three_Levels_Lower_Than_Crafter()
        {
            //Arrange                        
            double expected = 119;
            int recipeLevel = crafterLevel - 3;            
            double progressMultiplier = 1.2;

            //Act
            var result = Calc.Progress(recipeLevel, crafterLevel, craftsmanship) * progressMultiplier;

            //Assert
            Assert.AreEqual<double>(expected, Math.Round(result, 0, MidpointRounding.ToEven));
        }

        [TestMethod]
        public void CalculateProgress_100_Recipe_Four_Levels_Lower_Than_Crafter()
        {
            //Arrange                        
            double expected = 104;
            int recipeLevel = crafterLevel - 4;            

            //Act
            var result = Calc.Progress(recipeLevel, crafterLevel, craftsmanship);

            //Assert
            Assert.AreEqual<double>(expected, Math.Round(result, 0, MidpointRounding.ToEven));
        }

        [TestMethod]
        public void CalculateProgress_120__Recipe_Four_Levels_Lower_Than_Crafter()
        {
            //Arrange                        
            double expected = 124;
            int recipeLevel = crafterLevel - 4;                        
            double progressMultiplier = 1.2;

            //Act
            var result = Calc.Progress(recipeLevel, crafterLevel, craftsmanship) * progressMultiplier;

            //Assert
            Assert.AreEqual<double>(expected, Math.Round(result, 0, MidpointRounding.ToEven));
        }


        [TestMethod]
        public void CalculateProgress_100_Recipe_Five_Levels_Lower_Than_Crafter()
        {
            //Arrange                        
            double expected = 108;
            int recipeLevel = crafterLevel - 5;            

            //Act
            var result = Calc.Progress(recipeLevel, crafterLevel, craftsmanship);

            //Assert
            Assert.AreEqual<double>(expected, Math.Round(result, 0, MidpointRounding.ToEven));
        }

        [TestMethod]
        public void CalculateProgress_120__Recipe_Five_Levels_Lower_Than_Crafter()
        {
            //Arrange                        
            double expected = 130;            
            int recipeLevel = crafterLevel - 5;
            double progressMultiplier = 1.2;

            //Act
            var result = Calc.Progress(recipeLevel, crafterLevel, craftsmanship) * progressMultiplier;

            //Assert
            Assert.AreEqual<double>(expected, Math.Round(result, 0, MidpointRounding.ToEven));
        }

        [TestMethod]
        public void CalculateProgress_100_Recipe_Six_Levels_Lower_Than_Crafter()
        {
            //Arrange                        
            double expected = 110;
            int recipeLevel = crafterLevel - 6;            

            //Act
            var result = Calc.Progress(recipeLevel, crafterLevel, craftsmanship);

            //Assert
            Assert.AreEqual<double>(expected, Math.Round(result, 0, MidpointRounding.ToEven));
        }

        [TestMethod]
        public void CalculateProgress_120__Recipe_Six_Levels_Lower_Than_Crafter()
        {
            //Arrange                        
            double expected = 132;
            int recipeLevel = crafterLevel - 6;            
            double progressMultiplier = 1.2;

            //Act
            var result = Calc.Progress(recipeLevel, crafterLevel, craftsmanship) * progressMultiplier;

            //Assert
            Assert.AreEqual<double>(expected, Math.Round(result, 0, MidpointRounding.ToEven));
        }

        [TestMethod]
        public void CalculateProgress_100_Recipe_Seven_Levels_Lower_Than_Crafter()
        {
            //Arrange                        
            double expected = 112;
            int recipeLevel = crafterLevel - 7;            

            //Act
            var result = Calc.Progress(recipeLevel, crafterLevel, craftsmanship);

            //Assert
            Assert.AreEqual<double>(expected, Math.Round(result, 0, MidpointRounding.ToEven));
        }

        [TestMethod]
        public void CalculateProgress_120__Recipe_Seven_Levels_Lower_Than_Crafter()
        {
            //Arrange                        
            double expected = 134;
            int recipeLevel = crafterLevel - 7;            
            double progressMultiplier = 1.2;

            //Act
            var result = Calc.Progress(recipeLevel, crafterLevel, craftsmanship) * progressMultiplier;

            //Assert
            Assert.AreEqual<double>(expected, Math.Round(result, 0, MidpointRounding.ToEven));
        }

        [TestMethod]
        public void CalculateProgress_100_Recipe_Eight_Levels_Lower_Than_Crafter()
        {
            //Arrange                        
            double expected = 114;
            int recipeLevel = crafterLevel - 8;            

            //Act
            var result = Calc.Progress(recipeLevel, crafterLevel, craftsmanship);

            //Assert
            Assert.AreEqual<double>(expected, Math.Round(result, 0, MidpointRounding.ToEven));
        }

        [TestMethod]
        public void CalculateProgress_120__Recipe_Eight_Levels_Lower_Than_Crafter()
        {
            //Arrange                        
            double expected = 136;
            int recipeLevel = crafterLevel - 8;            
            double progressMultiplier = 1.2;

            //Act
            var result = Calc.Progress(recipeLevel, crafterLevel, craftsmanship) * progressMultiplier;

            //Assert
            Assert.AreEqual<double>(expected, Math.Round(result, 0, MidpointRounding.ToEven));
        }

        [TestMethod]
        public void CalculateProgress_100_Recipe_Nine_Levels_Lower_Than_Crafter()
        {
            //Arrange                        
            double expected = 116;
            int recipeLevel = crafterLevel - 9;            

            //Act
            var result = Calc.Progress(recipeLevel, crafterLevel, craftsmanship);

            //Assert
            Assert.AreEqual<double>(expected, Math.Round(result, 0, MidpointRounding.ToEven));
        }

        [TestMethod]
        public void CalculateProgress_120__Recipe_Nine_Levels_Lower_Than_Crafter()
        {
            //Arrange                        
            double expected = 139;
            int recipeLevel = crafterLevel - 9;            
            double progressMultiplier = 1.2;

            //Act
            var result = Calc.Progress(recipeLevel, crafterLevel, craftsmanship) * progressMultiplier;

            //Assert
            Assert.AreEqual<double>(expected, Math.Round(result, 0, MidpointRounding.ToEven));
        }

        [TestMethod]
        public void CalculateProgress_100_Recipe_Ten_Levels_Lower_Than_Crafter()
        {
            //Arrange                        
            double expected = 117;
            int recipeLevel = crafterLevel - 10;            

            //Act
            var result = Calc.Progress(recipeLevel, crafterLevel, craftsmanship);

            //Assert
            Assert.AreEqual<double>(expected, Math.Round(result, 0, MidpointRounding.ToEven));
        }

        [TestMethod]
        public void CalculateProgress_120__Recipe_Ten_Levels_Lower_Than_Crafter()
        {
            //Arrange                        
            double expected = 141;
            int recipeLevel = crafterLevel - 10;            
            double progressMultiplier = 1.2;

            //Act
            var result = Calc.Progress(recipeLevel, crafterLevel, craftsmanship) * progressMultiplier;

            //Assert
            Assert.AreEqual<double>(expected, Math.Round(result, 0, MidpointRounding.ToEven));
        }
    }
}
