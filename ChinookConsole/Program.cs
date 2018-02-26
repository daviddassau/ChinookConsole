using ChinookConsole.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinookConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var invoiceQuery = new InvoiceQuery();

            var invoices = invoiceQuery.GetInvoiceWithSalesAgentName();

            Console.WriteLine("Here are all the Sales Agents with their respective Invoice IDs");

            foreach (var invoice in invoices)
            {
                Console.WriteLine($"Sales Agent: {invoice.Name}, Invoice Id: {invoice.InvoiceId}");
            }




            Console.ReadLine();
        }
    }
}
