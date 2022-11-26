using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        
        public Car(string model, Engine engine)
        {
            this.Model = model;
            this.Engine = engine;
            this.Weight = 0;
            this.Color = "n/a";
        }
        public Car(string model, Engine engine, int weight) : this(model, engine)
        {
            this.Weight = weight;

        }
        public Car(string model, Engine engine, string color) : this(model, engine)
        {
            this.Color = color;
        }

        public Car(string model, Engine engine, int weight, string color) : this(model, engine)
        {
            this.Weight = weight;
            this.Color = color;
        }

        public string Model { get; set; }

        public Engine Engine { get; set; }

        public int Weight { get; set; }

        public string Color { get; set; }

        public override string ToString()
        {
            StringBuilder st = new StringBuilder();
           
            st.AppendLine(this.Model+":");
            st.AppendLine($"  {this. Engine.Model}:");
            st.AppendLine($"    Power: {this. Engine.Power}");
            if (this.Engine.Displacement == 0)
            {
                st.AppendLine("    Displacement: n/a");
            }
            else
            {
                st.AppendLine($"    Displacement: {this.Engine.Displacement}");
            }
            st.AppendLine($"    Efficiency: {this.Engine.Efficiency}");
            if(this.Weight == 0)
            {
                st.AppendLine("  Weight: n/a");
            }
            else
            {
                st.AppendLine($"  Weight: {this.Weight}");
            }
            st.AppendLine($"  Color: {this.Color}");

            return st.ToString().TrimEnd();
        }

    }
}
