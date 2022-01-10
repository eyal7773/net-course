using System;

namespace Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Builder Example.");
            // Builder  - take the "object creation" logic - outside,
            // So it enable to build customized objects.
            HouseBuilder iglooBuilder = new IglooHouseBuilder();
            iglooBuilder.ConstructHouse();
            House house = iglooBuilder.GetHouse();
            Console.WriteLine("House is ready: " + house);

            // Fluent builder.
            // this is posible but ... not so beatiful
            Burger uglyBurger = new Burger(true, true, false, false, false);

            // This is BETTER
            // This is BETTER
            // This is BETTER
            BurgerBuilder burgerBuilder = new BurgerBuilder();
            Burger awesomeburger = burgerBuilder.WithCheese()
                                                .WithBacon()
                                                .Build();

            
            
            // Example ref: https://medium.com/@martinstm/fluent-builder-pattern-c-4ac39fafcb0b

        }
    }
    public class House
    {
        private string basement;
        private string structure;
        private string roof;
        private string interior;

        public void SetBasement(string basement)
        {
            this.basement = basement;
        }

        public void SetStructure(string structure)
        {
            this.structure = structure;
        }

        public void SetRoof(string roof)
        {
            this.roof = roof;
        }

        public void SetInterior(string interior)
        {
            this.interior = interior;
        }
    }

    public abstract class HouseBuilder
    {
        protected House house;

        public HouseBuilder()
        {
            house = new House();
        }

        public abstract void BuildBasement();

        public abstract void BuildStructure();

        public abstract void BuildInterior();

        public abstract void BuildRoof();

        public void ConstructHouse()
        {
            BuildBasement();
            BuildStructure();
            BuildInterior();
            BuildRoof();
        }

        public House GetHouse()
        {
            return house;
        }
    }

    public class WoodHouseBuilder : HouseBuilder
    {
        public override void BuildBasement()
        {
            house.SetBasement("Wooden Poles");
        }

        public override void BuildStructure()
        {
            house.SetStructure("Wood Logs");
        }

        public override void BuildInterior()
        {
            house.SetInterior("Fire Wood");
        }

        public override void BuildRoof()
        {
            house.SetRoof("Wood, caribou and seal skins");
        }
    }
    public class IglooHouseBuilder : HouseBuilder
    {
        public override void BuildBasement()
        {
            house.SetBasement("Ice Bars");
        }

        public override void BuildStructure()
        {
            house.SetStructure("Ice Blocks");
        }

        public override void BuildInterior()
        {
            house.SetInterior("Ice Carvings");
        }

        public override void BuildRoof()
        {
            house.SetRoof("Ice Dome");
        }
    }

    // =================== fluent builder

    public class Burger
    {
        public int NumPatties { get; set; }
        public bool Cheese { get; set; }
        public bool Bacon { get; set; }
        public bool Pickles { get; set; }
        public bool Letuce { get; set; }
        public bool Tomato { get; set; }
        public Burger(int numPatties = 1)
        {
            NumPatties = numPatties;
        }
        public Burger(bool cheese, bool bacon, bool pickles,
                  bool letuce, bool tomato, int numPatties = 1)
        {
            Cheese = cheese;
            Bacon = bacon;
            Pickles = pickles;
            Letuce = letuce;
            Tomato = tomato;
            NumPatties = numPatties;
        
        }
    }


    public class BurgerBuilder
    {
        private Burger _burger = new Burger();
        public Burger Build() => _burger;
        public BurgerBuilder WithPatties(int num)
        {
            _burger.NumPatties = num;
            return this;
        }
        public BurgerBuilder WithCheese()
        {
            _burger.Cheese = true;
            return this;
        }
        public BurgerBuilder WithBacon()
        {
            _burger.Bacon = true;
            return this;
        }
        //(...)
}
}
