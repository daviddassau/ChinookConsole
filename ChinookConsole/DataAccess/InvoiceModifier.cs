using ChinookConsole.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ChinookConsole.DataAccess
{
    class InvoiceModifier
    {
        readonly string _connectionString = ConfigurationManager.ConnectionStrings["Chinook"].ConnectionString;

        public bool AddNewInvoice(string billingAddress, int inputCustomerId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandText = @"INSERT INTO Invoice
                                        (InvoiceId,CustomerId,InvoiceDate,BillingAddress,BillingCity,BillingState,BillingCountry,BillingPostalCode,Total)
                                    VALUES
                                        (@invoiceId,@customerId,2/27/18,@billingAddress,@billingCity,@billingState,'USA',@billingZip,0)";

                connection.Open();

                var invoiceQuery = new InvoiceQuery();
                var invoiceId = invoiceQuery.GetLastInvoice() + 1;

                string[] addressInfo = ParseAddressInfo(billingAddress).Reverse().ToArray();

                var InvoiceData = InvoiceInfo(addressInfo);

                var newInvoiceId = new SqlParameter(@"invoiceId", SqlDbType.Int);
                newInvoiceId.Value = invoiceId;
                cmd.Parameters.Add(newInvoiceId);
                
            }
        }

        string[] ParseAddressInfo(string address)
        {
            throw new NotImplementedException();
        }

        private object InvoiceInfo(string[] addressInfo)
        {
            throw new NotImplementedException();
        }
    }
}
