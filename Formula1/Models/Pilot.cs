using Formula1.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formula1.Models
{
    public class Pilot : IPilot
    {
        public string FullName => throw new NotImplementedException();

        public IFormulaOneCar Car => throw new NotImplementedException();

        public int NumberOfWins => throw new NotImplementedException();

        public bool CanRace => throw new NotImplementedException();

        public void AddCar(IFormulaOneCar car)
        {
            throw new NotImplementedException();
        }

        public void WinRace()
        {
            throw new NotImplementedException();
        }
    }
}
