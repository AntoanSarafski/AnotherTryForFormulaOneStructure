using Formula1.Models.Contracts;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formula1.Models
{
    public class Pilot : IPilot
    {
        private string fullName;
        private IFormulaOneCar car;
        private int numberOfWins;
        private bool canRace;

        public Pilot(string fullName)
        {
            FullName = fullName;
        }

        public string FullName
        {
            get { return fullName; }
            private set
            {
                if (String.IsNullOrWhiteSpace(value) || value.Length < 5) //NullOrEmpty? 
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidPilot, value));
                }
                fullName = value;
            }
        }

        

        public IFormulaOneCar Car
        {
            get { return car; }
            private set 
            { 
                if (value == null) 
                {
                    throw new NullReferenceException(String.Format(ExceptionMessages.InvalidCarForPilot, value));
                }
                car = value; 
            }
        }

       

        public int NumberOfWins
        {
            get { return numberOfWins; }
            private set { numberOfWins = value; }
        }

        

        public bool CanRace
        {
            get { return canRace; }
            private set { canRace = value; }
        }

        

        public void AddCar(IFormulaOneCar car)
        {
            Car = car;
            CanRace = true;
        }

        public void WinRace()
        {
            NumberOfWins++;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Pilot {FullName} has {NumberOfWins} wins.");
            return sb.ToString().Trim();
        }
    }
}
