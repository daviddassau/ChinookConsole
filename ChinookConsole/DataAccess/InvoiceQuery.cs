using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using ChinookConsole.DataAccess.Models;

namespace ChinookConsole.DataAccess
{
    class InvoiceQuery
    {
        readonly string _connectionString = ConfigurationManager.ConnectionStrings["Chinook"].ConnectionString;

        public List<SalesAgent> GetInvoiceWithSalesAgentName()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                
                var cmd = connection.CreateCommand();
                cmd.CommandText = @"select e.FirstName + ' ' + e.LastName Name, i.InvoiceId
                                    from Employee e
                                        join customer c on c.SupportRepId = e.EmployeeId
                                        join invoice i on i.CustomerId = c.CustomerId";

                connection.Open();

                var reader = cmd.ExecuteReader();

                var employees = new List<SalesAgent>();

                while (reader.Read())
                {
                    var employee = new SalesAgent
                    {
                        Name = reader["Name"].ToString(),
                        InvoiceId = int.Parse(reader["InvoiceId"].ToString())
                    };

                    employees.Add(employee);
                }

                return employees;
            }
        }

        public List<InvoiceData> GetInvoiceTotalCustomerNameCountryAndSalesAgent()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandText = @"select c.FirstName + ' ' + c.LastName Name, 
	                                       c.Country,
	                                       i.Total,
	                                       e.FirstName + ' ' + e.LastName as [Sales Agent]
                                    from Customer c
                                        join Invoice i on i.CustomerId = c.CustomerId
                                        join Employee e on e.EmployeeId = c.SupportRepId";
            }
        }
    }
}
