using System;
using System.Collections.Generic;

namespace VirusPrototype
{
    // Клас Virus являє собою прототип для клонування
    class Virus : ICloneable
    {
        public int Weight { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public List<Virus> Children { get; set; }

        public Virus(int weight, int age, string name, string type)
        {
            Weight = weight;
            Age = age;
            Name = name;
            Type = type;
            Children = new List<Virus>();
        }

        // Метод для додавання дитини
        public void AddChild(Virus child)
        {
            Children.Add(child);
        }

        // Метод для клонування віруса та всіх його дітей
        public object Clone()
        {
            Virus clone = new Virus(Weight, Age, Name, Type);
            foreach (var child in Children)
            {
                clone.AddChild((Virus)child.Clone());
            }
            return clone;
        }

        // Перевизначення методу ToString для зручного виводу
        public override string ToString()
        {
            return $"Name: {Name}, Type: {Type}, Weight: {Weight}, Age: {Age}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Створення родини вірусів
            Virus grandparent = new Virus(10, 2, "Grandparent", "Flu");
            Virus parent1 = new Virus(8, 1, "Parent 1", "Cold");
            Virus parent2 = new Virus(9, 1, "Parent 2", "Fever");

            Virus child1 = new Virus(5, 0, "Child 1", "Cough");
            Virus child2 = new Virus(6, 0, "Child 2", "Sore Throat");
            Virus child3 = new Virus(7, 0, "Child 3", "Headache");

            grandparent.AddChild(parent1);
            grandparent.AddChild(parent2);
            parent1.AddChild(child1);
            parent1.AddChild(child2);
            parent2.AddChild(child3);

            // Клонування вірусів
            Virus grandparentClone = (Virus)grandparent.Clone();

            // Виведення інформації про клон та його дітей
            Console.WriteLine("Cloned Virus Family:");
            Console.WriteLine("Grandparent Clone: " + grandparentClone.ToString());
            foreach (var parent in grandparentClone.Children)
            {
                Console.WriteLine("Parent: " + parent.ToString());
                foreach (var child in parent.Children)
                {
                    Console.WriteLine("Child: " + child.ToString());
                }
            }

            // Затримка консолі
            Console.ReadLine();
        }
    }
}
