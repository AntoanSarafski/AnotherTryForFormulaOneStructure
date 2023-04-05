using Formula1.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formula1.Models
{
    public class Race : IRace
    {
        public string RaceName => throw new NotImplementedException();

        public int NumberOfLaps => throw new NotImplementedException();

        public bool TookPlace { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public ICollection<IPilot> Pilots => throw new NotImplementedException();

        public void AddPilot(IPilot pilot)
        {
            throw new NotImplementedException();
        }

        public string RaceInfo()
        {
            throw new NotImplementedException();
        }
    }
}
