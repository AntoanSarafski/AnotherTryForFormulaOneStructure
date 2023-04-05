using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Formula1.Core.Contracts;
using Formula1.Models;
using Formula1.Models.Contracts;
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
            if (pilotRepository.FindByName(fullName) != null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.PilotExistErrorMessage, fullName));
            }
            IPilot pilot = new Pilot(fullName);
            pilotRepository.Add(pilot);
            return String.Format(OutputMessages.SuccessfullyCreatePilot, fullName);
        }

        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            IFormulaOneCar car = null;
            if (carRepository.FindByName(model) != null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.CarExistErrorMessage, model));
            }
            if (type == "Ferrari")
            {
                car = new Ferrari(model, horsepower, engineDisplacement);
            }
            else if (type == "Williams")
            {
                car = new Williams(model, horsepower, engineDisplacement);
            }
            else
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidTypeCar, type));
            }

            carRepository.Add(car);
            return String.Format(OutputMessages.SuccessfullyCreateCar, type, model);

        }


        public string CreateRace(string raceName, int numberOfLaps)
        {
            IRace race = null;
            if (raceRepository.FindByName(raceName) != null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceExistErrorMessage, raceName));
            }
            race = new Race(raceName, numberOfLaps);
            raceRepository.Add(race);
            return String.Format(OutputMessages.SuccessfullyCreateRace, raceName);
        }


        public string AddCarToPilot(string pilotName, string carModel)
        {
            IPilot pilot = pilotRepository.FindByName(pilotName);
            IFormulaOneCar car = carRepository.FindByName(carModel);
            if (pilot == null || pilot.Car != null)
            {
                throw new InvalidOperationException
                    (String.Format(ExceptionMessages.PilotDoesNotExistOrHasCarErrorMessage, pilotName));
            }
            if (car == null)
            {
                throw new NullReferenceException(String.Format(ExceptionMessages.CarDoesNotExistErrorMessage, carModel));
            }
            pilot.AddCar(car);
            carRepository.Remove(car);
            return String.Format(OutputMessages.SuccessfullyPilotToCar, pilotName, car.GetType().Name, carModel);
        }






        public string AddPilotToRace(string raceName, string pilotFullName)
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
