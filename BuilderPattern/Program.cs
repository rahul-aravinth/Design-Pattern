using System;

namespace BuilderDesignPattern
{
    class Ibaco
    {
        static void Main()
        {
            ServingBuilder servingBuilder;
            SelfServingMachine selfServingMachine = new SelfServingMachine();
            servingBuilder = new StrawberryChoco();
            selfServingMachine.CreateIceCream(servingBuilder);
            servingBuilder.IceCream.Serve();
            Console.ReadKey();
        }
    }

    // Director
    class SelfServingMachine{
        public void CreateIceCream(ServingBuilder servingBuilder){
            servingBuilder.AddTypeofPlate();
            servingBuilder.AddTypeofIceCream();
            servingBuilder.AddTypeofTopping();
        }
    }

    // Product
    class IceCream{
        private string iceCreamType;
        public IceCream(string iceCreamType){
            this.iceCreamType = iceCreamType;
        }
        private Dictionary<string, string> steps = new Dictionary<string, string>();
        public string this[string key]{
            get { return steps[key]; }
            set { steps[key] = value; }
        }
        public void Serve(){
            Console.WriteLine("IceCream: " + iceCreamType);
            Console.WriteLine(" Plate: " + steps["plate"]);
            Console.WriteLine(" IceCream: " + steps["icecream"]);
            Console.WriteLine(" Topping: " + steps["topping"]);
        }
    }

    // Builder
    abstract class ServingBuilder{
        protected IceCream iceCream = new IceCream("");
        public IceCream IceCream{
            get { return iceCream; }
        }
        public abstract void AddTypeofPlate();
        public abstract void AddTypeofIceCream();
        public abstract void AddTypeofTopping();
    }

    // Concreate Builder
    class StrawberryChoco : ServingBuilder{
        public StrawberryChoco(){
            iceCream = new IceCream("StrawberryChoco");
        }
        public override void AddTypeofPlate()
        {
            iceCream["plate"] = "Small Bowl";
        }
        public override void AddTypeofIceCream()
        {
            iceCream["icecream"] = "Strawberry IceCream Scoop";
        }
        public override void AddTypeofTopping()
        {
            iceCream["topping"] = "Chocolate Curls";
        }
    }
}