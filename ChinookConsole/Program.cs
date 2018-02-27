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
                        var invoiceDetails = invoiceQuery.GetInvoiceTotalCustomerNameCountryAndSalesAgent();

                        Console.WriteLine("Here are all the Sales Agents with their respective Invoice IDs");

                        foreach (var invoice in invoices)
                        {
                            Console.WriteLine($"Sales Agent: {invoice.Name}, Invoice Id: {invoice.InvoiceId}");
                        }

                        Console.WriteLine("Press enter to continue");
                        Console.ReadLine();
                        break;
                    case '2':
                        //Provide a query that shows the Invoice Total, Customer name, Country and Sale Agent name for all invoices.
                        Console.Clear();
                        Console.WriteLine("Here's a list of customer names, their country, and the sales agent and invoice total");

                        invoiceQuery = new InvoiceQuery();
                        invoices = invoiceQuery.GetInvoiceWithSalesAgentName();
                        invoiceDetails = invoiceQuery.GetInvoiceTotalCustomerNameCountryAndSalesAgent();

                        foreach (var data in invoiceDetails)
                        {
                            Console.WriteLine($"Invoice Total: {data.Total}, Customer Name: {data.CustomerName}, Country: {data.BillingCountry}, Sales Agent: {data.SalesAgent}");
                        }

                        Console.WriteLine("Press enter to continue");
                        Console.ReadLine();
                        break;
                    case '3':
                        // Looking at the InvoiceLine table, provide a query that COUNTs the number 
                        // of line items for an Invoice with a parameterized Id from user input
                        Console.Clear();
                        Console.WriteLine("Enter in the Invoice ID to see all the line items associated with that ID");

                        var invoiceInput = Console.ReadLine();
                        invoiceQuery = new InvoiceQuery();
                        var lineItems = invoiceQuery.GetInvoiceLineItems(int.Parse(invoiceInput));

                        Console.WriteLine($"For Invoice ID {invoiceInput}, there are {lineItems} line items");
                        Console.WriteLine("Press enter to continue");
                        Console.ReadLine();
                        break;
                }
            }

            ConsoleKeyInfo MainMenu()
            {
                View mainMenu = new View()
                        .AddMenuOption("Show the invoices associated with each sales agent")
                        .AddMenuOption("Show a list of each customer name and their country, along with their respective sales agent and invoice total")
                        .AddMenuOption("Enter an Invoice ID to see the number of line items")
                        .AddMenuText("Press 0 to exit");

                Console.Write(mainMenu.GetFullMenu());
                ConsoleKeyInfo userOption = Console.ReadKey();
                return userOption;
            }
        }
    }
}
