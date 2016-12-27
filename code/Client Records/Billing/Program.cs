using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing
{
    class Program
    {
        static BusinessLogic db = new BusinessLogic();

        static void Main(string[] args)
        {

            Customer egyikJoska = new Customer();
            egyikJoska.Name = "Jozsegg";
            egyikJoska.Address = "Principala 1";

            db.InsertCustomer(egyikJoska);

            Customer masikJoska = new Customer();
            masikJoska.Name = "JozseggDva";
            masikJoska.Address = "Principala 2 (szomszed)";
            db.InsertCustomer(masikJoska);

            db.Write();

            db.Read();

            //Console.WriteLine("Customer name: {0}, Customer address: {1}", Joska.Name , Joska.Address);

            //Bill bill = new Bill();
            //bill.Customer = Joska;
            //bill.Date = DateTime.Now.Date; //new DateTime(1982, 08, 11);
            //Console.WriteLine("Customer name: {0}, Customer address: {1}, Bill date: {2}", bill.Customer.Name, bill.Customer.Address, bill.Date);


            //string[] lines = { Joska.Name, Joska.Address, DateToString(bill.Date), bill.Customer.Name };
            //System.IO.File.WriteAllLines(@"C:\test\WriteLines.txt", lines);






            //Console.ReadLine();
        }

   

    }
}
