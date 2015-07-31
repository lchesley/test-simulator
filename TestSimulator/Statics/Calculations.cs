using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSimulator
{
    public static class Calc
    {                
        public static double Progress(int itemLevel, int crafterLevel, double craftsmanship)
        {
            double baseProgress;
            double levelCorrection = 0;
            int levelDifference = LevelFactor(itemLevel, GetVirtualCrafterLevel(crafterLevel));

            if (crafterLevel > 50)
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

        public static double Quality(double control)
        {
            //return (0.3597402597 * control) + 33.9805194805;
            return (0.36 * control) + 34;
        }
        
        public static double Quality(int itemLevel, int crafterLevel, double control)
        {
            //Quality = round((1 - 0.05 * recipe level difference) * (0.36 * Control + 34)), capped at five?
            //"Base Quality Gain" = 0.36 * (Control) + 34
            //return Quality(control) * (1 + (-0.05 * Math.Min(Math.Max(LevelFactor(itemLevel, crafterLevel), 0), 5)));            
            //double baseQuality = (0.36 * control) + 34;
            double baseQuality;

            if (itemLevel >= 55)
            {
                baseQuality = 23.409673659673096 + 0.26099393438100732 * control + 0.000022405902343322353 * control * control;
            }
            else
            {
                baseQuality = 34.275521095175201 + 0.3558806693020045 * control + 0.000035279187952857053 * control * control;
            }

            if (GetVirtualCrafterLevel(crafterLevel) > 50)
            {
                baseQuality = (-0.0000000000321 * Math.Pow(control, 4)) + (0.000000101831469820255 * Math.Pow(control, 3)) + (-0.0000788982445035823 * Math.Pow(control, 2)) + (0.388500734046211 * control) + 24.85488004;
            }


            //Test ingII
            //baseQuality = 33.468181818145240 + 0.34141636304406126 * control + 0.000034475437808642656 * control * control;
                        
            //double baseQuality = (0.3597402597 * control) + 33.9805194805; 

            int levelDifference = LevelFactor(itemLevel, crafterLevel);
            double levelCorrection = 0;

            //if (levelDifference < -5)
            //{
            //    levelCorrection = -0.25;
            //}

            //if (levelDifference >= -5 && levelDifference < 0)
            //{
            //    levelCorrection = levelDifference * 0.05;
            //}

            return baseQuality * (1 + levelCorrection);
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
