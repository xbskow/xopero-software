using System;
using System.Collections.Generic;

namespace strona439
{
    class Lumberjack
    {
        private string name;
        public string Name { get { return name; } }
        private Stack<Flapjack> meal;
        
        public Lumberjack(string name)
        {
            this.name = name;
            meal = new Stack<Flapjack>();
        }

        public int FlapjackCount { get { return meal.Count; } }

        public void EatFlapjacks()
        {
            while (meal.Count > 0)
                Console.WriteLine($"{name} je {meal.Pop().ToString().ToLower()} naleśnika");
        }

        public void TakeFlapjacks(Flapjack food, int howMany)
        {
            for (int i = 0; i < howMany; i++)
                meal.Push(food);
        }
    }
}
