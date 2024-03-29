﻿using Formula1.Models.Contracts;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formula1.Models
{
    public class Race : IRace
    {

        public Race(string raceName, int numberOfLaps)
        {
            RaceName = raceName;
            NumberOfLaps = numberOfLaps;
            pilots = new List<IPilot>();
        }
        private string raceName;

        public string RaceName
        {
            get { return raceName; }
            private set 
            {
                if (String.IsNullOrWhiteSpace(value) || value.Length < 5) //NullOrEmpty? 
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidRaceName, value));
                }
                raceName = value;
            }
        }
        private int numberOfLaps;

        public int NumberOfLaps
        {
            get { return numberOfLaps; }
            private set 
            {
                if (value < 1)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidLapNumbers, value));
                }
                numberOfLaps = value; 
            }
        }


        private bool tookPlace;

        public bool TookPlace
        {
            get { return tookPlace; }
            set { tookPlace = value; }
        }


        private ICollection<IPilot> pilots;

        public ICollection<IPilot> Pilots
        {
            get { return pilots; }
        }



        public void AddPilot(IPilot pilot)
        {
            Pilots.Add(pilot);
        }

        public string RaceInfo()
        {
            string tookedPlace = TookPlace == true ? "Yes" : "No";
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The {RaceName} race has:");
            sb.AppendLine($"Participants: {pilots.Count}");
            sb.AppendLine($"Number of laps: {NumberOfLaps}");
            sb.AppendLine($"Took place: {tookedPlace}");

            return sb.ToString().Trim();
        }
    }
}
