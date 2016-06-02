using PAYNLSDK;
using System;
using System.Diagnostics;

namespace betaalDemo
{
    public partial class exchange : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // PAYNLSDK.API.RequestBase.ApiToken = "Your APITOKEN";
            // PAYNLSDK.API.RequestBase.ServiceId = "Your service ID";

     
            if (String.IsNullOrEmpty(Request.QueryString["order_id"]))
            {
                Response.Write("false|unable to process");
                return;
            }


            PAYNLSDK.API.PaymentMethod.GetAll.Response response = PaymentMethod.GetAll();

            Debug.WriteLine(Request.QueryString);
            string tranidreader = Request.QueryString["order_id"];
            if(tranidreader != null)
            {
                Response.Write("Param is");
                Response.Write(tranidreader);
            }
          
            PAYNLSDK.API.Transaction.Info.Response info = Transaction.Info(tranidreader);
            PAYNLSDK.Enums.PaymentStatus result = info.PaymentDetails.State;
            Debug.WriteLine(result);

            if (PAYNLSDK.Transaction.IsPaid(result))
            {
                // This will only happen when the transaction is paid
                // TODO: process this in YOUR OWN backend
                Response.Write("true|Processed");
                
            }
            else if (PAYNLSDK.Transaction.IsCancelled(result))
            {
                // Process the cancel
                Response.Write("true|processed cancel correctly");
            }
            else
            {
                // Process this in your own backend (
                Response.Write("true|Processed (probably pending??)");
            }
        }
    }
}