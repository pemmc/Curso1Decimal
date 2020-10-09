using System;
 
namespace Course.Entities
{
    public class HourContract
    {
        //Atributos
        public DateTime Date { get; set; }
        public double ValuePerHour { get; set; }
        public int Hours { get; set; }

        //Construtores
        public HourContract()
        {
            //Construtor padrão

        }

        public HourContract(DateTime date, double valuePerHour, int hours)
        {
            Date = date;
            ValuePerHour = valuePerHour;
            Hours = hours;

        }

        //Métodos
        public double TotalValue()
        {
           
            return Hours * ValuePerHour;


        }
    }
}
