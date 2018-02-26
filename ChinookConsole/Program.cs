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
            //Provide a query that shows the invoices associated with each sales agent. The resultant table should include the Sales Agent's full name.

            var invoiceQuery = new InvoiceQuery();

            var invoices = invoiceQuery.GetInvoiceWithSalesAgentName();

            Console.WriteLine("Here are all the Sales Agents with their respective Invoice IDs");

            foreach (var invoice in invoices)
            {
                Console.WriteLine($"Sales Agent: {invoice.Name}, Invoice Id: {invoice.InvoiceId}");
            }



            //Provide a query that shows the Invoice Total, Customer name, Country and Sale Agent name for all invoices.






            Console.ReadLine();
        }
    }
}
