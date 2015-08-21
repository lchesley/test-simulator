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
            
            if (crafterLevel > 50)
            {                
                baseProgress = 2.09860E-05 * Math.Pow(craftsmanship, 2) + (0.196184 * craftsmanship) + 2.68452;

                if (levelDifference < 0)
                {                    
                    levelCorrection += 0.0807176 * Math.Max(levelDifference, -5);
                }

                if (levelDifference < -5)
                {                    
                    levelCorrection += 0.0525673 * Math.Max(levelDifference - (-5), -1); 
                }
                                
                if (levelDifference > 0)
                {                
                    levelCorrection += 0.0504824 * Math.Min(levelDifference, 5);
                }
                
                if (levelDifference > 5)
                {
                    levelCorrection += 0.0205906 * Math.Min(levelDifference - 5, 10);
                }
                
                if (levelDifference > 15)
                {
                    levelCorrection += 0.0106398 * Math.Min(levelDifference - 15, 5);
                }
                
                if (levelDifference > 20)
                {                    
                    levelCorrection += 6.69723e-04 * Math.Min(levelDifference - 20, 100);
                }                
            }
            else
            {                
                //baseProgress = (0.224779600835706 * craftsmanship) - 2.27812423237703;
                baseProgress = 0.214959 * craftsmanship + 1.6;

                if (levelDifference < -5)
                {
                    levelCorrection = -0.04878959823 - (5 * 0.08055416534);
                }

                if (levelDifference >= -5 && levelDifference <= 0)
                {
                    levelCorrection = 0.08055416534 * levelDifference;
                }

                //if ((levelDifference < -5))
                //{
                //    levelCorrection = 0.0501 * Math.Max(levelDifference, -9);
                //}
                //else if ((levelDifference >= -5) && (levelDifference < 0))
                //{
                //    levelCorrection = 0.10 * levelDifference;
                //}                

                if (levelDifference > 0)
                {
                    levelCorrection += 0.0495218 * Math.Min(levelDifference, 5);
                }

                if (levelDifference > 5)
                {
                    levelCorrection += 0.0221127 * Math.Min(levelDifference - 5, 10);
                }

                if (levelDifference > 15)
                {
                    levelCorrection += 0.0103120 * Math.Min(levelDifference - 15, 5);
                }

                if (levelDifference > 20)
                {
                    levelCorrection += 6.68438e-4 * Math.Min(levelDifference - 20, 100);
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

            if (itemLevel > 110 && crafterLevel > 50)
            {                
                baseQuality = (3.37576E-05 * Math.Pow(control, 2)) + (0.338835 * control) + 33.1305;

                recipeLevelFactor = 3.37610E-4 * (115 - itemLevel);

                levelDifference = Math.Max(levelDifference, -6);

                if (levelDifference < 0)
                {
                    levelCorrection += 0.0400267 * Math.Max(levelDifference, -3);
                }

                if (levelDifference < -3)
                {
                    levelCorrection += 0.0451309 * Math.Max(levelDifference - (-3), -3);
                }
            }
            else if (itemLevel > 50)
            {                
                baseQuality = 3.46e-5 * Math.Pow(control, 2) + (0.3514 * control) + 34.66;

                levelDifference = Math.Max(levelDifference, -5);                

                if (levelDifference <= -5)
                {
                    levelCorrection = 0.05374 * levelDifference;
                }
                //else
                //{
                //    levelCorrection = 0.05 * -0.5;
                //}
            }
            else
            {                
                baseQuality = 3.46e-5 * Math.Pow(control,2) + (0.3514 * control) + 34.66;

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

        public static int GetIngenuityIItemLevels(int realItemLevel)
        {
            int modifiedItemLevel = realItemLevel;

            Dictionary<int, int> itemLevels = new Dictionary<int, int>();
            itemLevels.Add(40, 36);
            itemLevels.Add(41, 36);
            itemLevels.Add(42, 37);
            itemLevels.Add(43, 38);
            itemLevels.Add(44, 39);
            itemLevels.Add(45, 40);
            itemLevels.Add(46, 41);
            itemLevels.Add(47, 42);
            itemLevels.Add(48, 43);
            itemLevels.Add(49, 44);
            itemLevels.Add(50, 45);
            itemLevels.Add(55, 50);     // 50_1star     *** unverified            
            itemLevels.Add(70, 50);     // 50_2star     *** unverified
            itemLevels.Add(90, 58);     // 50_3star     *** unverified
            itemLevels.Add(110, 58);    // 50_4star     *** unverified
            //itemLevels.Add(115, 100);
            itemLevels.Add(115, 55);
            itemLevels.Add(120, 100);
            itemLevels.Add(130, 110);
            itemLevels.Add(133, 110);
            itemLevels.Add(136, 110);
            itemLevels.Add(139, 124);
            itemLevels.Add(142, 123);
            itemLevels.Add(145, 135);
            itemLevels.Add(148, 139);
            itemLevels.Add(150, 140);
            itemLevels.Add(160, 151);
            //itemLevels.Add(170, 151);
            //itemLevels.Add(180, 151);

            if(itemLevels.TryGetValue(realItemLevel, out modifiedItemLevel))
            {
                return modifiedItemLevel;
            }
            else
            {
                return modifiedItemLevel - 5;
            }            
        }

        public static int GetIngenuityIIItemLevels(int realItemLevel)
        {
            int modifiedItemLevel = realItemLevel;

            Dictionary<int, int> itemLevels = new Dictionary<int, int>();
            itemLevels.Add(40, 33);
            itemLevels.Add(41, 34);
            itemLevels.Add(42, 35);
            itemLevels.Add(43, 36);
            itemLevels.Add(44, 37);
            itemLevels.Add(45, 38);
            itemLevels.Add(46, 39);
            itemLevels.Add(47, 40);
            itemLevels.Add(48, 40);
            itemLevels.Add(49, 41);
            itemLevels.Add(50, 42);
            itemLevels.Add(55, 47);     // 50_1star     *** unverified
            itemLevels.Add(70, 47);     // 50_2star     *** unverified
            itemLevels.Add(90, 56);     // 50_3star     *** unverified
            itemLevels.Add(110, 56);    // 50_4star     *** unverified
            //itemLevels.Add(115, 100);
            itemLevels.Add(115, 54);
            itemLevels.Add(120, 100);
            itemLevels.Add(130, 110);
            itemLevels.Add(133, 110);
            itemLevels.Add(136, 110);
            itemLevels.Add(139, 124);
            itemLevels.Add(142, 123);
            itemLevels.Add(145, 133);
            itemLevels.Add(148, 136);
            itemLevels.Add(150, 139);
            itemLevels.Add(160, 150);
            itemLevels.Add(170, 150);
            itemLevels.Add(180, 150);

            if(itemLevels.TryGetValue(realItemLevel, out modifiedItemLevel))
            {
                return modifiedItemLevel;
            }
            else
            {
                return modifiedItemLevel - 7;
            }            
        }
    }
}
