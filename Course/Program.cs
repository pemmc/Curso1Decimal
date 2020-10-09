using System;
using System.Globalization;

using Course.Entities;
using Course.Entities.Enums;

namespace Course
{
    class Program
    {
        static void Main(string[] args)
        {
            //Estas linhas fazem a mudança para o PORTUGUÊS BRASIL
            //CultureInfo culture = new CultureInfo("pt-BR");
            //Console.WriteLine(culture.Name);
            //LINHA ADICIONADA EM 09/10/2020, testando o github desktop


            Console.WriteLine("Digite o departamento: ");
            string depName = Console.ReadLine();

            Console.WriteLine("--- Digite os dados do trabalhador ---");

            Console.WriteLine("Nome:");
            string name = Console.ReadLine();

            Console.WriteLine("Nível: (Junior/MidLevel/Senior):");
            //Converter a string digitada para ENUM
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());

            Console.WriteLine("Salário Base:");
            double baseSalary = double.Parse(Console.ReadLine(), new CultureInfo("pt-BR").NumberFormat);

            //Instanciamento dos objetos WORKER e DEPARTAMENT
            Departament dept = new Departament(depName);
            Worker worker = new Worker(name, level, baseSalary, dept);

            Console.WriteLine("Quantos contratos irá cadastrar para este trabalhador?");

            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Entre #{i} contrato data: ");

                Console.WriteLine("Data (DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("Valor por hora: ");
                double valuePerHour = double.Parse(Console.ReadLine(), new CultureInfo("pt-BR").NumberFormat);

                Console.WriteLine("Duração em horas: ");
                int hours = int.Parse(Console.ReadLine());

                HourContract contract = new HourContract(date, valuePerHour, hours);

                //Adicionando o contrato ao trabalhador
                worker.AddContract(contract);


            }

            Console.WriteLine();

            Console.WriteLine("Entre com o mês e o ano (MM/YYYY): ");
            string monthAndYear = Console.ReadLine();

            int month = int.Parse(monthAndYear.Substring(0, 2));
            int year = int.Parse(monthAndYear.Substring(3));

            Console.WriteLine("Trabalhador : " + worker.Name);
            Console.WriteLine("Departamento: " + worker.Departament.Name);

            Console.WriteLine("Para o mês: " + monthAndYear + ": " + worker.Income(month, year).ToString("C", new CultureInfo("pt-BR").NumberFormat));

        }

    }
}
