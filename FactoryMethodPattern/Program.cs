using System;

namespace FactoryMethodDesignPattern
{
    class MainApp
    {
        static void Main()
        {
            CivilEngineer engineer1 = new BeachHouse();
            CivilEngineer engineer2 = new Mansion();

            PrintEngineers(engineer1);
            PrintEngineers(engineer2);
        }
        private static void PrintEngineers(CivilEngineer engineer)
        {
            Console.WriteLine(engineer.GetType().Name + " - Building Guide");
            for (int i = 0; i < engineer.Floors.Count; i++)
            {
                Console.WriteLine("  " + (i + 1) + " - " + engineer.Floors[i].GetType().Name);
            }
        }
    }

    //Product
    abstract class Floor { }

    //Concrete Product
    class Parking : Floor { }
    class SwimmingPool : Floor { }
    class Room : Floor { }
    class Roof : Floor { }

    //Creator
    abstract class CivilEngineer
    {
        private List<Floor> planning = new List<Floor>(); // Encap
        public List<Floor> Floors { get { return planning; } } // Encap
        public CivilEngineer()
        {
            this.Construction();
        }
        //Factory Method
        public abstract void Construction();
    }

    //Concrete Creator
    class BeachHouse : CivilEngineer
    {
        public override void Construction()
        {
            Floors.Add(new SwimmingPool());
            Floors.Add(new Room());
            Floors.Add(new Room());
            Floors.Add(new Roof());
        }
    }
    class Mansion : CivilEngineer
    {
        public override void Construction()
        {
            Floors.Add(new Parking());
            Floors.Add(new Room());
            Floors.Add(new Room());
            Floors.Add(new Room());
            Floors.Add(new Roof());
        }
    }
}