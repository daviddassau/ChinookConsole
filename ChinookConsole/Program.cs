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
            var run = true;

            while (run)
            {
                ConsoleKeyInfo userInput = MainMenu();

                switch (userInput.KeyChar)
                {
                    case '0':
                        run = false;
                        break;
                    case '1':
                        Console.Clear();

                        //Provide a query that shows the invoices associated with each sales agent. The resultant table should include the Sales Agent's full name.

                        var invoiceQuery = new InvoiceQuery();

                        var invoices = invoiceQuery.GetInvoiceWithSalesAgentName();

                        Console.WriteLine("Here are all the Sales Agents with their respective Invoice IDs");

                        foreach (var invoice in invoices)
                        {
                            Console.WriteLine($"Sales Agent: {invoice.Name}, Invoice Id: {invoice.InvoiceId}");
                        }

                        Console.WriteLine("Press enter to continue");
                        Console.ReadLine();
                        break;
                }
            }
            
            



            ////Provide a query that shows the Invoice Total, Customer name, Country and Sale Agent name for all invoices.

            //var invoiceQuery = new InvoiceQuery();

            //var invoiceData = invoiceQuery.GetInvoiceTotalCustomerNameCountryAndSalesAgent();

            //Console.WriteLine("Here's a list of customer names, their country, and the sales agent and invoice total");

            //foreach (var data in invoiceData)
            //{
            //    Console.WriteLine($"Invoice Total: {data.InvoiceId}, Customer Name: {data.CustomerName}, Country: {data.BillingCountry}, Sales Agent: {data.SalesAgent}");
            //}


            
        }

        private static ConsoleKeyInfo MainMenu()
        {
            throw new NotImplementedException();
        }
    }
}
