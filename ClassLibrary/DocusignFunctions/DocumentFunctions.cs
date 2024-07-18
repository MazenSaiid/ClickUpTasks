using DocuSign.eSign.Api;
using DocuSign.eSign.Client;
using RestSharp.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.DocusignFunctions
{
    public class DocumentFunctions
    {
        
        public static byte[] DownloadDocument(string envelopeId, string documentId)
        {
            EnvelopesApi envelopesApi = Credentials.InitilizeRequest();

            Stream results = envelopesApi.GetDocument(Credentials.AccountId, envelopeId, documentId);

            return results.ReadAsBytes();
        }

       
    }
}
