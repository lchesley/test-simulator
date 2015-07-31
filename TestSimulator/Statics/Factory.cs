using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSimulator
{
    public static class Factory
    {
        public static IAction GetAction(string command)
        {
            switch (command)
            {
                case Actions.AdvancedTouch:
                    {
                        return new AdvancedTouch();
                    }
                case Actions.BasicTouch:
                    {
                        return new BasicTouch();                        
                    }
                case Actions.HastyTouch:
                    {
                        return new HastyTouch();
                    }
                case Actions.StandardTouch:
                    {
                        return new StandardTouch();
                    }
                case Actions.PreciseTouch:
                    {
                        return new PreciseTouch();
                    }
                case Actions.ByregotsBlessing:
                    {
                        return new ByregotsBlessing();
                    }
                case Actions.CarefulSynthesisI:
                    {
                        return new CarefulSynthesis();
                    }
                case Actions.CarefulSynthesisII:
                    {
                        return new CarefulSynthesis2();
                    }
                case Actions.TricksoftheTrade:
                    {
                        return new TricksoftheTrade();
                    }
                case Actions.MuscleMemory:
                    {
                        return new MuscleMemory();
                    }
                case Actions.FlawlessSynthesis:
                    {
                        return new FlawlessSynthesis();
                    }
                case Actions.RapidSynthesis:
                    {
                        return new RapidSynthesis();
                    }
                case Actions.BasicSynthesis:
                    {
                        return new BasicSynthesis();
                    }
                case Actions.StandardSynthesis:
                    {
                        return new StandardSynthesis();
                    }
                case Actions.MastersMend:
                    {
                        return new MastersMend();
                    }
                case Actions.MastersMendII:
                    {
                        return new MastersMend2();
                    }
                case Actions.Rumination:
                    {
                        return new Rumination();
                    }
                case Actions.PieceByPiece:
                    {
                        return new PieceByPiece();
                    }
                case Actions.BrandOfEarth:
                    {
                        return new BrandOfEarth();
                    }
                case Actions.BrandOfFire:
                    {
                        return new BrandOfFire();
                    }
                case Actions.BrandOfIce:
                    {
                        return new BrandOfIce();
                    }
                case Actions.BrandOfLightning:
                    {
                        return new BrandOfLightning();
                    }
                case Actions.BrandOfWater:
                    {
                        return new BrandOfWater();
                    }
                case Actions.BrandOfWind:
                    {
                        return new BrandOfWind();
                    }
                default:
                    {
                        return new BasicTouch();
                    }
            }
        }

        public static IModifier GetModifier(string command)
        {
            switch(command)
            {
                case Modifiers.GreatStrides:
                    {
                        return new GreatStrides();   
                    }
                case Modifiers.InnerQuiet:
                    {
                        return new InnerQuiet();
                    }
                case Modifiers.SteadyHand:
                    {
                        return new SteadyHand();
                    }
                case Modifiers.SteadyHandII:
                    {
                        return new SteadyHand2();
                    }
                case Modifiers.Innovation:
                    {
                        return new Innovation();
                    }
                case Modifiers.WasteNot:
                    {
                        return new WasteNot();
                    }
                case Modifiers.WasteNotII:
                    {
                        return new WasteNot2();
                    }
                case Modifiers.Ingenuity:
                    {
                        return new Ingenuity();
                    }
                case Modifiers.IngenuityII:
                    {
                        return new Ingenuity2();
                    }
                case Modifiers.ComfortZone:
                    {
                        return new ComfortZone();
                    }
                case Modifiers.MakersMark:
                    {
                        return new MakersMark();
                    }
                case Modifiers.Manipulation:
                    {
                        return new Manipulation();
                    }
                case Modifiers.NameOfEarth:
                    {
                        return new NameOfEarth();
                    }
                case Modifiers.NameOfFire:
                    {
                        return new NameOfFire();
                    }
                case Modifiers.NameOfIce:
                    {
                        return new NameOfIce();
                    }
                case Modifiers.NameOfLightning:
                    {
                        return new NameOfLightning();
                    }
                case Modifiers.NameOfWater:
                    {
                        return new NameOfWater();
                    }
                case Modifiers.NameOfWind:
                    {
                        return new NameOfWind();
                    }
                default:
                    {
                        return new InnerQuiet();
                    }
            }
        }
    }
}
