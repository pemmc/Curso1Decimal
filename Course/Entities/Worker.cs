using System.Collections.Generic;
 
using Course.Entities.Enums;

namespace Course.Entities
{
    public class Worker
    {

        //Atributos
        public string Name { get; set; }
        public WorkerLevel Level { get; set; }
        public double BaseSalary { get; set; }
        public Departament Departament { get; set; }
        public List<HourContract> Contracts { get; set; } = new List<HourContract>();

        //Construtores
        public Worker()
        {
            //Padrão

        }

        public Worker(string name, WorkerLevel level, double baseSalary, Departament departament)
        {

            Name = name;
            Level = level;
            BaseSalary = baseSalary;
            Departament = departament;

        }

        //Métodos
        public void AddContract(HourContract contract)
        {

            Contracts.Add(contract);

        }

        public void RemoveContract(HourContract contract)
        {

            Contracts.Remove(contract);

        }

        public double Income(int month, int year)
        {
             
            //Salário base do trabalhador, mesmo que sem contrato
            double sum = BaseSalary;

            //Listas de contratos
            foreach(HourContract contract in Contracts)
            {
                if (contract.Date.Year == year && contract.Date.Month == month)
                {

                    sum += contract.TotalValue();


                }

            }

            return sum;
        }
    }
}
