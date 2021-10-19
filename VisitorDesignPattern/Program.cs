using System;
using System.Collections.Generic;

namespace VisitorDesignPattern
{
    public interface IStore
    {
        void Visit(IVisitor visitor);
    }

    public interface IVisitor
    {
        void Accept(Car car);
        void Accept(Bike bike);
    }

    public class Car : IStore
    {
        public string CarName { get; set; }
        public decimal Price { get; set; }
        public string CarType { get; set; }

        public void Visit(IVisitor visitor)
        {
            visitor.Accept(this);
        }
    }

    public class Bike : IStore
    {
        public string BikeName { get; set; }
        public decimal Price { get; set; }
        public string BikeType { get; set; }

        public void Visit(IVisitor visitor)
        {
            visitor.Accept(this);
        }
    }

    public class PriceVisitor : IVisitor
    {
        private const int CAR_DISCOUNT = 5;
        private const int BIKE_DISCOUNT = 2;

        public void Accept(Car car)
        {
            decimal carPriceAfterDicount = car.Price - ((car.Price / 100) * CAR_DISCOUNT);
            Console.WriteLine("Car {0} price: {1}", car.CarName, carPriceAfterDicount);
        }

        public void Accept(Bike bike)
        {
            decimal bikePriceAfterDicount = bike.Price - ((bike.Price / 100) * BIKE_DISCOUNT);
            Console.WriteLine("Bike {0} price: {1}", bike.BikeName, bikePriceAfterDicount);
        }
    }

    //Other visitor
    public class WeightVisitor : IVisitor
    {
        public void Accept(Car car)
        {
            switch (car.CarType)
            {
                case "Mercedes":
                    Console.WriteLine("Car {0} weight: {1} KG", car.CarName, 1750);
                    break;
                case "Normal":
                    Console.WriteLine("Car {0} weight: {1} KG", car.CarName, 750);
                    break;
            }
        }

        public void Accept(Bike bike)
        {
            switch (bike.BikeType)
            {
                case "Bullet":
                    Console.WriteLine("Bike {0} weight: {1} KG", bike.BikeName, 300);
                    break;
                case "Normal":
                    Console.WriteLine("Bike {0} weight: {1} KG", bike.BikeName, 100);
                    break;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<IStore> store = new List<IStore>();
            store.Add(new Car() { CarName = "A1", Price = 200M, CarType = "Mercedes" });
            store.Add(new Car() { CarName = "A2", Price = 100M, CarType = "Normal" });

            store.Add(new Bike() { BikeName = "B1", Price = 50M, BikeType = "Bullet" });
            store.Add(new Bike() { BikeName = "B2", Price = 30M, BikeType = "Normal" });

            //Show price 
            PriceVisitor priceVisitor = new PriceVisitor();
            foreach (var element in store)
            {
                element.Visit(priceVisitor);
            }
            Console.WriteLine();
            //Show weight 
            WeightVisitor weightVisitor = new WeightVisitor();
            foreach (var element in store)
            {
                element.Visit(weightVisitor);
            }

            Console.ReadLine();
        }
    }
}
