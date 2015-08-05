﻿using System;
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
        public void CalculateProgress_120_EvenLevel()
        {
            //Arrange                        
            double expected = 104;
            int recipeLevel = 50;
            int itemLevel = 50;
            double progressMultiplier = 1.2;

            //Act
            var result = Calc.Progress(recipeLevel, itemLevel, crafterLevel, craftsmanship) * progressMultiplier;

            //Assert
            Assert.AreEqual(expected, Math.Round(result, 0, MidpointRounding.ToEven), 1);
        }

        [TestMethod]
        public void CalculateProgress_120__Recipe_One_Level_Lower_Than_Crafter()
        {
            //Arrange                        
            double expected = 109;
            int recipeLevel = crafterLevel - 1;
            int itemLevel = recipeLevel;
            double progressMultiplier = 1.2;

            //Act
            var result = Calc.Progress(recipeLevel, itemLevel, crafterLevel, craftsmanship) * progressMultiplier;

            //Assert
            Assert.AreEqual(expected, Math.Round(result, 0, MidpointRounding.ToEven), 1);
        }
        
        [TestMethod]
        public void CalculateProgress_120__Recipe_Two_Levels_Lower_Than_Crafter()
        {
            //Arrange                        
            double expected = 114;
            int recipeLevel = crafterLevel - 2;
            int itemLevel = recipeLevel;
            double progressMultiplier = 1.2;

            //Act
            var result = Calc.Progress(recipeLevel, itemLevel, crafterLevel, craftsmanship) * progressMultiplier;

            //Assert
            Assert.AreEqual(expected, Math.Round(result, 0, MidpointRounding.ToEven), 1);
        }

        [TestMethod]
        public void CalculateProgress_120__Recipe_Three_Levels_Lower_Than_Crafter()
        {
            //Arrange                        
            double expected = 119;
            int recipeLevel = crafterLevel - 3;
            int itemLevel = recipeLevel;
            double progressMultiplier = 1.2;

            //Act
            var result = Calc.Progress(recipeLevel, itemLevel, crafterLevel, craftsmanship) * progressMultiplier;

            //Assert
            Assert.AreEqual(expected, Math.Round(result, 0, MidpointRounding.ToEven), 1);
        }
        
        [TestMethod]
        public void CalculateProgress_120__Recipe_Four_Levels_Lower_Than_Crafter()
        {
            //Arrange                        
            double expected = 124;
            int recipeLevel = crafterLevel - 4;
            int itemLevel = recipeLevel;
            double progressMultiplier = 1.2;

            //Act
            var result = Calc.Progress(recipeLevel, itemLevel, crafterLevel, craftsmanship) * progressMultiplier;

            //Assert
            Assert.AreEqual(expected, Math.Round(result, 0, MidpointRounding.ToEven), 1);
        }

        [TestMethod]
        public void CalculateProgress_120__Recipe_Five_Levels_Lower_Than_Crafter()
        {
            //Arrange                        
            double expected = 130;            
            int recipeLevel = crafterLevel - 5;
            int itemLevel = recipeLevel;
            double progressMultiplier = 1.2;

            //Act
            var result = Calc.Progress(recipeLevel, itemLevel, crafterLevel, craftsmanship) * progressMultiplier;

            //Assert
            Assert.AreEqual(expected, Math.Round(result, 0, MidpointRounding.ToEven), 1);
        }

        [TestMethod]
        public void CalculateProgress_120__Recipe_Six_Levels_Lower_Than_Crafter()
        {
            //Arrange                        
            double expected = 132;
            int recipeLevel = crafterLevel - 6;
            int itemLevel = recipeLevel;
            double progressMultiplier = 1.2;

            //Act
            var result = Calc.Progress(recipeLevel, itemLevel, crafterLevel, craftsmanship) * progressMultiplier;

            //Assert
            Assert.AreEqual(expected, Math.Round(result, 0, MidpointRounding.ToEven), 1);
        }

        [TestMethod]
        public void CalculateProgress_120__Recipe_Seven_Levels_Lower_Than_Crafter()
        {
            //Arrange                        
            double expected = 134;
            int recipeLevel = crafterLevel - 7;
            int itemLevel = recipeLevel;
            double progressMultiplier = 1.2;

            //Act
            var result = Calc.Progress(recipeLevel, itemLevel, crafterLevel, craftsmanship) * progressMultiplier;

            //Assert
            Assert.AreEqual(expected, Math.Round(result, 0, MidpointRounding.ToEven), 1);
        }

        [TestMethod]
        public void CalculateProgress_120__Recipe_Eight_Levels_Lower_Than_Crafter()
        {
            //Arrange                        
            double expected = 136;
            int recipeLevel = crafterLevel - 8;
            int itemLevel = recipeLevel;
            double progressMultiplier = 1.2;

            //Act
            var result = Calc.Progress(recipeLevel, itemLevel, crafterLevel, craftsmanship) * progressMultiplier;

            //Assert
            Assert.AreEqual(expected, Math.Round(result, 0, MidpointRounding.ToEven), 1);
        }

        [TestMethod]
        public void CalculateProgress_120__Recipe_Nine_Levels_Lower_Than_Crafter()
        {
            //Arrange                        
            double expected = 139;
            int recipeLevel = crafterLevel - 9;
            int itemLevel = recipeLevel;
            double progressMultiplier = 1.2;

            //Act
            var result = Calc.Progress(recipeLevel, itemLevel, crafterLevel, craftsmanship) * progressMultiplier;

            //Assert
            Assert.AreEqual(expected, Math.Round(result, 0, MidpointRounding.ToEven), 1);
        }

        [TestMethod]
        public void CalculateProgress_120__Recipe_Ten_Levels_Lower_Than_Crafter()
        {
            //Arrange                        
            double expected = 141;
            int recipeLevel = crafterLevel - 10;
            int itemLevel = recipeLevel;
            double progressMultiplier = 1.2;

            //Act
            var result = Calc.Progress(recipeLevel, itemLevel, crafterLevel, craftsmanship) * progressMultiplier;

            //Assert
            Assert.AreEqual(expected, Math.Round(result, 0, MidpointRounding.ToEven), 1);
        }
    }
}
