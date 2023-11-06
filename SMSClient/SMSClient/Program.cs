using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;

namespace SMSClient
{
    class Program
    {
        static void Main(string[] args)
        {
            SendSms();
        }

        static void SendSms()
        {
            string resulttext = string.Empty;
            WebReference.Main ws = new WebReference.Main();
            WebReference.SmsInfo soapin = new WebReference.SmsInfo();


            soapin.OperationId = "0";
            soapin.PhoneNumber = "+994702650543";
            soapin.SmsFrom = "Muganbank";
            soapin.SmsText = "Text";

              System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
            bool smsresult = ws.SendSms(soapin);

            if (smsresult)
            {
                resulttext = "Sent";

            }
            else
            {
                resulttext = "Error";
            }

            Console.WriteLine(resulttext);
            Console.ReadLine();

        }

    }
}
