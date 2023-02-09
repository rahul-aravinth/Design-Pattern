using System;

namespace AbstractFactoryDesignPattern
{
    class MainApp
    {
        static void Main()
        {
            int i = 0;
            while(i != 3){
                i = VehicleServiceFun();
            }
        }
        private static int VehicleServiceFun(){
            try
            {
                int vehType = 0;
                Console.WriteLine("---Vehicle Service---");
                Console.WriteLine("Which Vehicle \n (1)Bike \n (2)Car \n (3)Exit\nInput:");
                Int32.TryParse(Console.ReadLine(), out vehType);
                VehicleService vehicleService;
                switch (vehType)
                {
                    case 1:
                        vehicleService = new TwoWheeler();
                        break;
                    case 2:
                        vehicleService = new FourWheeler();
                        break;
                    case 3:
                        return 3;
                    default:
                        throw new Exception(" Enter From The Following Options ");
                }
                PrintService(vehicleService);
                Console.WriteLine("----------------");
            }
            catch(NotImplementedException ex){
                Console.WriteLine(ex.Message);
            }
            return 0;
        }
        private static void PrintService(VehicleService vehicleService)
        {
            Console.WriteLine(vehicleService.GetType().Name + " - Services Provided");
            for (int i = 0; i < vehicleService.Service.Count; i++)
            {
                Console.WriteLine("  " + (i + 1) + " - " + vehicleService.Service[i].GetType().Name);
            }
            Console.WriteLine(vehicleService.GetType().Name + " - WaterWash Provided");
            Console.WriteLine("  1 - " + vehicleService.WaterWash.GetType().Name);
        }
    }

    //Abstract Obj
    abstract class Service { }
    abstract class WaterWash { }

    //Abstract Factory class
    abstract class VehicleService
    {
        private List<Service> service = new List<Service>(); // Encap
        public List<Service> Service { get { return service; } } // Encap

        public WaterWash WaterWash { get; set; }

        public VehicleService()
        {
            WaterWash = new ManualWaterWash();
            DoService();
            DoWaterWash();
        }

        public abstract void DoService();
        public abstract void DoWaterWash();
    }

    //Concrete Product
    class TyreInspection : Service { }
    class OilChange : Service { }
    class BrakeAndClutchAdjust : Service { }
    class WiperReplace : Service { }
    class LightsCheck : Service { }

    class ManualWaterWash : WaterWash { }
    class AutomaticWaterWash : WaterWash { }

    //Concrete Factory
    class TwoWheeler : VehicleService
    {
        public override void DoService()
        {
            Service.Add(new TyreInspection());
            Service.Add(new OilChange());
            Service.Add(new BrakeAndClutchAdjust());
        }
        public override void DoWaterWash()
        {
            WaterWash = new ManualWaterWash();
        }
    }
    class FourWheeler : VehicleService
    {
        public override void DoService()
        {
            Service.Add(new TyreInspection());
            Service.Add(new OilChange());
            Service.Add(new BrakeAndClutchAdjust());
            Service.Add(new WiperReplace());
            Service.Add(new LightsCheck());
        }
        public override void DoWaterWash()
        {
            WaterWash = new AutomaticWaterWash();
        }
    }
}