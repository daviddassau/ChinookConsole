using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ChinookConsole.DataAccess
{
    class InvoiceQuery
    {
        readonly string _connectionString = ConfigurationManager.ConnectionStrings["Chinook"].ConnectionString;

        public List<Invoice> GetInvoiceWithSalesAgentName()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = @"select e.FirstName + ' ' + e.LastName Name, i.InvoiceId
                                    from Employee e
                                        join customer c on c.SupportRepId = e.EmployeeId
                                        join invoice i on i.CustomerId = c.CustomerId";



                var reader = cmd.ExecuteReader();

                var invoices = new List<Invoice>();

                while (reader.Read())
                {
                    var invoice = new Invoice
                    {

                    }
                }
            }
        }
    }
}
