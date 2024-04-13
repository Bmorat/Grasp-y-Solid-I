//-------------------------------------------------------------------------
// <copyright file="Recipe.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections;

namespace Full_GRASP_And_SOLID.Library
{
    public class Recipe
    {
        private ArrayList steps = new ArrayList();

        public Product FinalProduct { get; set; }

        public void AddStep(Step step)
        {
            this.steps.Add(step);
        }

        public void RemoveStep(Step step)
        {
            this.steps.Remove(step);
        }

        public void PrintRecipe()
        {
            Console.WriteLine($"Receta de {this.FinalProduct.Description}:");
            foreach (Step step in this.steps)
            {
                Console.WriteLine($"{step.Quantity} de '{step.Input.Description}' " +
                    $"usando '{step.Equipment.Description}' durante {step.Time}s");
                                    
            }
            Console.WriteLine($"El costo de produccion es de {GetProductionCost()}");    
        }

        
    
        public double GetProductionCost() // Se calcula el costo de produccion de la receta
        {
            double totalCost = 0;
            foreach (Step step in this.steps)
            {
                totalCost += step.Input.UnitCost; // Se suma el costo unitario de cada insumo
            }
            foreach (Step step in this.steps)
            {
                totalCost += (step.Time/60)/60 * step.Equipment.HourlyCost; // Se suma el costo de cada equipo suponiendo que esta en s 
            }
            return totalCost;
        }




    }
}
/* Añadido el metodo GetProductionCost() lo colocamos en la clase Recipe aplicando el principio EXPERT, dado que la clase recipe
es la que contiene la información necesaria para calcular lo que necesitamos, para eso tomamos cada paso (ingrediente) que se 
agrega a la receta visto que cada uno de los productos tiene un precio asi como tambien los equipos tienen un costo de uso por 
hora; como la clase recipe engloba tanto productos como equipos podemos tomar del array steps de la receta para obtener la 
información y realizar el cálculo del costo de producción de la receta*/