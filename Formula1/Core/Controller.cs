using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Formula1.Core.Contracts;
using Formula1.Models;
using Formula1.Repositories;
using Formula1.Utilities;

namespace Formula1.Core
{
    public class Controller : IController
    {
        private PilotRepository pilotRepository;
        private RaceRepository raceRepository;
        private FormulaOneCarRepository carRepository;


        public string CreatePilot(string fullName)
        {
            if (pilotRepository.Models.FirstOrDefault(p => p.FullName == fullName) != null)
            {
                pilotRepository.Add(new Pilot(fullName));
                return String.Format(OutputMessages.SuccessfullyCreatePilot, fullName);
            }
            else
            {
                return String.Format(ExceptionMessages.PilotExistErrorMessage, fullName);
            }
        }

        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {

            if (carRepository.Models.FirstOrDefault(c => c.Model == type) != null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.CarExistErrorMessage, type));
            }
            switch (type)
            {
                case "Ferrari":
                    carRepository.Add(new Ferrari(model, horsepower, engineDisplacement));
                    return String.Format(OutputMessages.SuccessfullyCreateCar, typeof(Ferrari).FullName, model);
                case "Williams":
                    carRepository.Add(new Williams(model, horsepower, engineDisplacement));
                    return String.Format(OutputMessages.SuccessfullyCreateCar, typeof(Williams).FullName, model);
                default:
                    throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidF1CarModel, type));
            }

        }


        public string AddCarToPilot(string pilotName, string carModel)
        {
            throw new NotImplementedException();
        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            throw new NotImplementedException();
        }





        public string CreateRace(string raceName, int numberOfLaps)
        {
            throw new NotImplementedException();
        }

        public string PilotReport()
        {
            throw new NotImplementedException();
        }

        public string RaceReport()
        {
            throw new NotImplementedException();
        }

        public string StartRace(string raceName)
        {
            throw new NotImplementedException();
        }
    }
}
