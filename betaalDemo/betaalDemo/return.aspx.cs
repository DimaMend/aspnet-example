using PAYNLSDK;
using System;

namespace betaalDemo
{
    public partial class _return : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            PAYNLSDK.API.RequestBase.ApiToken = "0940e0c93212f883616e57496288b76fe6cd850d";
            PAYNLSDK.API.RequestBase.ServiceId = "SL-1094-0450";
            PAYNLSDK.API.PaymentMethod.GetAll.Response response = PaymentMethod.GetAll();
            string tranidreader = Request.QueryString["order_id"];
            PAYNLSDK.API.Transaction.Info.Response info = Transaction.Info(tranidreader);
            PAYNLSDK.Enums.PaymentStatus result = info.PaymentDetails.State;

            if (Transaction.IsCancelled(result))
            {
                // This will only happen when the transaction is cancelled
                // TODO: process this in YOUR OWN backend
                Response.Write("False|Something went wrong");

            }
            else
            {
                // This will only happen when the transaction is pending, verified or paid
                // TODO: process this in YOUR OWN backend
                Response.Write("True|Thank you for using our services");
            }
        }
    }
}