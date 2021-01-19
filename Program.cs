using System;
using System.Linq;
using CarDealership_EfCore.Data;
using CarDealership_EfCore.Domain.Models;
using static System.Console;
namespace CarDealership_EfCore
{
    class Program
    {

        private static CarDealerShipContext context = new CarDealerShipContext();
        static void Main(string[] args)
        {
            Program.Menu();

        }


        private static void Menu()
        {
            bool shouldNotExit = true;

            while (shouldNotExit)
            {



                WriteLine("1.Registrera bil");
                WriteLine("2.Lista bilar");
                WriteLine("3.Avsluta");

                System.ConsoleKeyInfo keyPressed = ReadKey(true);

                Clear();

                switch (keyPressed.Key)
                {

                    case System.ConsoleKey.D1:

                        RegisterCar();

                        break;

                    case System.ConsoleKey.D2:

                        ListRegisterdCars();
                        break;

                    case System.ConsoleKey.D3:

                        shouldNotExit = false;

                        break;

                }

            }
        }

        private static void ListRegisterdCars()
        {
            var cars = context.Car;
            bool exitLoop = false;
            Func<Car, bool> sortCritera = car => car == car;

            string brand;


            do
            {

                Console.WriteLine("Reg. nr  Märke     Model    Tillv.år Pris");
                Console.WriteLine("-----------------------------------------");



                foreach (var car in cars.Where(sortCritera))

                {

                    Console.WriteLine($"{car.RegistrationNumber}    {car.Brand}     {car.Model}     {car.Price}");

                }

                Console.WriteLine("(A)lla (M)ärke");

                ConsoleKeyInfo input = ReadKey(true);
                bool isValidKey;

                do
                {

                    input = ReadKey(true);

                    isValidKey = input.Key == ConsoleKey.A || input.Key == ConsoleKey.M || input.Key == ConsoleKey.Escape;


                } while (!isValidKey);

                if (input.Key == ConsoleKey.A)
                {
                   sortCritera = car => car == car;

                }
                if (input.Key == ConsoleKey.M)
                {

                    Console.WriteLine("Märke>");
                    brand = Console.ReadLine();
                    sortCritera = car => car.Brand.ToLower().Contains(brand);
                }

                if (input.Key == ConsoleKey.Escape)
                {
                    exitLoop = true;
                }


            } while (!exitLoop);

        }

        private static void RegisterCar()
        {
            bool isCorrect = false;

            Car car = null;

            do
            {
                Clear();

                WriteLine("Registreringsnummer: ");
                string registrationNumber = ReadLine();
                WriteLine("Märke: ");
                string brand = ReadLine();
                WriteLine("Model: ");
                string model = ReadLine();
                WriteLine("Produktions år: ");
                string productionYear = ReadLine();
                WriteLine("Pris: ");
                string price = ReadLine();



                Console.WriteLine("Är detta korrekt? (J)a (N)ej");

                ConsoleKeyInfo input = ReadKey(true);
                bool isValidKey;

                do
                {

                    input = ReadKey(true);

                    isValidKey = input.Key == ConsoleKey.J || input.Key == ConsoleKey.N;


                } while (!isValidKey);



                if (input.Key == ConsoleKey.J)
                {
                    isCorrect = true;


                    car = new Car(registrationNumber, brand, model, productionYear, price);

                    SaveCar(car);

                    Console.WriteLine("Bil registrerad");

                }




            } while (!isCorrect);
        }

        private static void SaveCar(Car car)
        {

            context.Car.Add(car);
            context.SaveChanges();

        }


    }
}