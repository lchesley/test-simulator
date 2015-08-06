using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSimulator
{
    public static class Calc
    {                
        public static double Progress(int recipeLevel, int itemLevel, int crafterLevel, double craftsmanship)
        {
            double baseProgress;
            double levelCorrection = 0;
            int levelDifference = LevelFactor(itemLevel, GetVirtualCrafterLevel(crafterLevel));

            //if (crafterLevel > 50)
            if (itemLevel > 110)
            {
                baseProgress = (0.216733026952621 * craftsmanship) - 2.12243052267693;

                if (levelDifference < -5)
                {
                    levelCorrection = -0.0487895982311992 - (5 * 0.0805541653384794);
                }

                if (levelDifference >= -5 && levelDifference <= 0)
                {
                    levelCorrection = 0.0805541653384794 * levelDifference;
                }

                if (levelDifference > 0 && levelDifference <= 5)
                {
                    levelCorrection = 0.0511341183416215 * levelDifference;
                }

                if (levelDifference > 5 && levelDifference <= 15)
                {
                    levelCorrection = (0.0200853240962306 * (levelDifference - 5)) + (5 * 0.0511341183416215);
                }

                if (levelDifference > 15 && levelDifference <= 20)
                {
                    levelCorrection = (0.0104175949627843 * (levelDifference - 15)) + (10 * 0.0200853240962306) + (5 * 0.0511341183416215);
                }

                if (levelDifference > 20 && levelDifference <= 120)
                {
                    levelCorrection = (0.000668437771861551 * (levelDifference - 20)) + (5 * 0.0104175949627843) + (10 * 0.0200853240962306) + (5 * 0.0511341183416215);
                }

                if (levelDifference > 120)
                {
                    levelCorrection = (5 * 0.0104175949627843) + (10 * 0.0200853240962306) + (5 * 0.0511341183416215) + (100 * 0.000668437771861551);
                }
            }
            else
            {
                baseProgress = (0.224779600835706 * craftsmanship) - 2.27812423237703;

                if (levelDifference < -5)
                {
                    levelCorrection = -0.04878959823 - (5 * 0.08055416534);
                }

                if (levelDifference >= -5 && levelDifference <= 0)
                {
                    levelCorrection = 0.08055416534 * levelDifference;
                }

                if (levelDifference > 0 && levelDifference <= 5)
                {
                    levelCorrection = 0.0495215482164759 * levelDifference;                 
                }

                if (levelDifference > 5 && levelDifference <= 15)
                {
                    levelCorrection = (0.0221128799787351 * (levelDifference - 5)) + (5 * 0.0495215482164759);                 
                }

                if (levelDifference > 15 && levelDifference <= 20)
                {
                    levelCorrection = (0.0103120386197622 * (levelDifference - 15)) + (10 * 0.0221128799787351) + (5 * 0.0495215482164759);                 
                }

                if (levelDifference > 20 && levelDifference <= 120)
                {
                    levelCorrection = (0.000663858826373767 * (levelDifference - 20)) + (5 * 0.0103120386197622) + (10 * 0.0221128799787351) + (5 * 0.0495215482164759);                 
                }

                if (levelDifference > 120)
                {
                    levelCorrection = (5 * 0.0103120386197622) + (10 * 0.0221128799787351) + (5 * 0.0495215482164759) + (100 * 0.000663858826373767);                 
                }
            }

            return (baseProgress * (1 + levelCorrection));
        }
        
        public static double Quality(int recipeLevel, int itemLevel, int crafterLevel, double control)
        {            
            double baseQuality;
            int levelDifference = LevelFactor(itemLevel, GetVirtualCrafterLevel(crafterLevel));
            double levelCorrection = 0;
            double recipeLevelFactor = 0;

            if(itemLevel >= 115)
            {
                baseQuality = (0.000033942184008444 * Math.Pow(control, 2)) + (0.338497036226036 * control) + 33.3016915279868;

                recipeLevelFactor = 0.000342807 * (115 - itemLevel);

                levelDifference = Math.Max(levelDifference, -6);

                if (levelDifference < 0)
                {
                    levelCorrection = 0.0407512 * levelDifference;
                }
            }
            else if (itemLevel > 50)
            {
                baseQuality = 0.0000346 * Math.Pow(control, 2) + (0.34 * control) + 34.66;

                levelDifference = Math.Max(levelDifference, -5);

                if (levelDifference <= -5)
                {
                    levelCorrection = 0.05374 * levelDifference;
                }
                else
                {
                    levelCorrection = 0.05 * -0.5;
                }
            }
            else
            {
                baseQuality = 0.0000346 * Math.Pow(control, 2) + (0.34 * control) + 34.66;

                levelDifference = Math.Max(levelDifference, -5);

                if (levelDifference < 0)
                {
                    levelCorrection = 0.05 * levelDifference;
                }                
            }                        

            return baseQuality * (1 + levelCorrection) * (1 + recipeLevelFactor);
        }

        public static int LevelFactor(int itemLevel, int crafterLevel)
        {            
            return crafterLevel - itemLevel;
        }

        public static bool ActionIsSuccessful(Random rng, int chanceOfSuccess)
        {
            if (rng.Next(1, 101) <= chanceOfSuccess)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static Conditions GetCondition(Random rng, Conditions previousCondition)
        {
            if(previousCondition == Conditions.Excellent)
            {
                return Conditions.Poor;
            }

            if(previousCondition == Conditions.Good || previousCondition == Conditions.Poor)
            {
                return Conditions.Normal;
            }

            int seed = rng.Next(1, 101);

            if(seed > 75)
            {
                if(seed > 98)
                {
                    return Conditions.Excellent;
                }
                else
                {
                    return Conditions.Good;
                }
            }
            else
            {
                return Conditions.Normal;
            }
        }

        public static Conditions GetCondition(Random rng)
        {            
            return Conditions.Normal;
        }

        public static double ApplyCondition(double quality, Conditions condition)
        {
            switch(condition)
            {   
                case Conditions.Poor:
                    {
                        return quality * 0.5;
                    }
                case Conditions.Normal:
                    {
                        return quality * 1;
                    }
                case Conditions.Good:
                    {
                        return quality * 1.5;
                    }
                case Conditions.Excellent:
                    {
                        return quality * 4;
                    }
                default:
                    {
                        return quality * 1;
                    }
            }
        }

        public static int GetVirtualCrafterLevel(int realCrafterLevel)
        {
            int virtualCrafterLevel = realCrafterLevel;

            Dictionary<int, int> crafterLevels = new Dictionary<int, int>();
            crafterLevels.Add(51, 120);
            crafterLevels.Add(52, 125);
            crafterLevels.Add(53, 130);
            crafterLevels.Add(54, 133);
            crafterLevels.Add(55, 136);
            crafterLevels.Add(56, 139);
            crafterLevels.Add(57, 142);
            crafterLevels.Add(58, 145);
            crafterLevels.Add(59, 148);
            crafterLevels.Add(60, 150);

            if (realCrafterLevel > 50)
            {
                if(crafterLevels.TryGetValue(realCrafterLevel, out virtualCrafterLevel))
                {
                    return virtualCrafterLevel;
                }                
            }

            return virtualCrafterLevel;
        }
    }
}
