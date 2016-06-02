using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PAYNLSDK;
using System.Diagnostics;

namespace betaalDemo
{
    public partial class Default : System.Web.UI.Page
    {

        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            PAYNLSDK.API.RequestBase.ApiToken = "0940e0c93212f883616e57496288b76fe6cd850d";
            PAYNLSDK.API.RequestBase.ServiceId = "SL-1094-0450";
            PAYNLSDK.API.PaymentMethod.GetAll.Response response = PaymentMethod.GetAll();


            PAYNLSDK.API.Transaction.Start.Request request = Transaction.CreateTransactionRequest("127.0.0.1", "http://example.org/visitor-return-after-payment");
            request.Amount = 666;

            // Transaction data
            request.Transaction = new PAYNLSDK.Objects.TransactionData();
            request.Transaction.Currency = "EUR";
            request.Transaction.CostsVat = null;
            request.Transaction.OrderExchangeUrl = "http://localhost:54949/exchange.aspx";
            request.ReturnUrl = "http://localhost:54949/return.aspx";
            request.Transaction.Description = "TEST PAYMENT";
            request.Transaction.ExpireDate = DateTime.Now.AddDays(14);

            // Optional Stats data
            request.StatsData = new PAYNLSDK.Objects.StatsDetails();
            request.StatsData.Info = "your information";
            request.StatsData.Tool = "C#.NET";
            request.StatsData.Extra1 = "X";
            request.StatsData.Extra2 = "Y";
            request.StatsData.Extra3 = "Z";

            // Initialize Salesdata

            request.SalesData = new PAYNLSDK.Objects.SalesData();
            request.SalesData.InvoiceDate = DateTime.Now;
            request.SalesData.DeliveryDate = DateTime.Now;
            request.SalesData.OrderData = new System.Collections.Generic.List<PAYNLSDK.Objects.OrderData>();
            request.PaymentOptionId = 136;

            // Add products
            request.SalesData.OrderData.Add(new PAYNLSDK.Objects.OrderData("SKU-8489", "Testproduct 1", 2995, "H", 1));
            request.SalesData.OrderData.Add(new PAYNLSDK.Objects.OrderData("SKU-8421", "Testproduct 2", 995, "H", 1));
            request.SalesData.OrderData.Add(new PAYNLSDK.Objects.OrderData("SKU-2359", "Testproduct 3", 2589, "H", 1));
            request.SalesData.OrderData.Add(new PAYNLSDK.Objects.OrderData("SKU-2359", "Testproduct 3", 2589, "H", 1));
            request.SalesData.OrderData.Add(new PAYNLSDK.Objects.OrderData("SKU-2359", "Testproduct 3", 2589, "H", 1));
            request.SalesData.OrderData.Add(new PAYNLSDK.Objects.OrderData("SKU-2359", "Testproduct 3", 2589, "H", 1));
            request.SalesData.OrderData.Add(new PAYNLSDK.Objects.OrderData("SKU-2359", "Testproduct 3", 2589, "H", 1));

            // enduser
            request.Enduser = new PAYNLSDK.Objects.EndUser();
            request.Enduser.Language = "NL";
            request.Enduser.Initials = TxtTussen.Text;
            request.Enduser.Lastname = TxtAchternaam.Text;
            request.Enduser.Gender = PAYNLSDK.Enums.Gender.Male;
            request.Enduser.BirthDate = new DateTime(1991, 1, 23, 0, 0, 0, DateTimeKind.Local);
            request.Enduser.PhoneNumber = TxtTel.Text;
            request.Enduser.EmailAddress = TxtEmail.Text;
            request.Enduser.BankAccount = "";
            request.Enduser.IBAN = TxtIban.Text;
            request.Enduser.BIC = "";
            request.Enduser.SendConfirmMail = true;


            // enduser address
            request.Enduser.Address = new PAYNLSDK.Objects.Address();
            request.Enduser.Address.StreetName = TxtStraat.Text;
            request.Enduser.Address.StreetNumber = TxtHuisnummer.Text;
            request.Enduser.Address.ZipCode = TxtPostcode.Text;
            request.Enduser.Address.City = TxtStad.Text;
            request.Enduser.Address.CountryCode = "NL";

            // invoice address
            request.Enduser.InvoiceAddress = new PAYNLSDK.Objects.Address();
            request.Enduser.InvoiceAddress.Initials = "J.";
            request.Enduser.InvoiceAddress.LastName = "Jansen";
            request.Enduser.InvoiceAddress.Gender = PAYNLSDK.Enums.Gender.Male;
            request.Enduser.InvoiceAddress.StreetName = "InvoiceStreetname";
            request.Enduser.InvoiceAddress.StreetNumber = "10";
            request.Enduser.InvoiceAddress.ZipCode = "1234BC";
            request.Enduser.InvoiceAddress.City = "City";
            request.Enduser.InvoiceAddress.CountryCode = "NL";
            PAYNLSDK.API.Transaction.Start.Response responseBak = PAYNLSDK.Transaction.Start(request);

            if (responseBak.Request.Result)
            {
                Response.Redirect(responseBak.Transaction.PaymentURL);
            }
            //instatieren return.apsx en doorvoeren response
            // todo:
            // redirect if payment creation was successfull (of hoe je dat ook schrijft)
            // Wanneer dit niet gelukt is:
            // Show message dat het doen van een betaling momenteel niet gaat


            // Perform transaction to get response object. Alternately, you could work with a stored ID.


            PAYNLSDK.API.Transaction.Info.Response info = PAYNLSDK.Transaction.Info(responseBak.Transaction.TransactionId);
            PAYNLSDK.Enums.PaymentStatus result = info.PaymentDetails.State;

            Debug.WriteLine(responseBak.ToString());
        }

        }
    }
