using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSimulator
{
    public class Crafter : ICrafter
    {
        private static Crafter theCrafter;

        private Crafter()
        {
            //Craftsmanship
            craftsmanship = Convert.ToInt32(ConfigurationManager.AppSettings["craftsmanship"]);
            baseCraftsmanship = Convert.ToInt32(ConfigurationManager.AppSettings["craftsmanship"]);
            //Control
            control = Convert.ToDouble(ConfigurationManager.AppSettings["control"]);
            baseControl = Convert.ToInt32(ConfigurationManager.AppSettings["control"]); ;
            //CP
            cp = Convert.ToInt32(ConfigurationManager.AppSettings["cp"]);
            baseCP = Convert.ToInt32(ConfigurationManager.AppSettings["cp"]);
            //Crafter Level
            crafterLevel = Convert.ToInt32(ConfigurationManager.AppSettings["crafterLevel"]);
        }

        public static Crafter TheCrafter
        {
            get
            {
                if (theCrafter == null)
                    theCrafter = new Crafter();

                return theCrafter;
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
}
