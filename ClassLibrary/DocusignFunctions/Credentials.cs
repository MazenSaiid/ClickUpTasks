using DocuSign.CodeExamples.Authentication;
using DocuSign.CodeExamples.Common;
using DocuSign.eSign.Api;
using DocuSign.eSign.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.DocusignFunctions
{
    public static class Credentials
    {
        public static string ClientId = "b23ec65d-86b3-49e5-af73-b7a1890647ed";
        public static string AuthServer = "account.docusign.com";
        public static string ImpersonatedUserID = "126532c2-730f-4e61-9a01-09f2aeaa4df2";
        //public static string PrivateKeyFile =@"C:\Users\josep\source\repos\HCSIntegrations\WebIntegrations\private.key";
        public static string PrivateKeyFile = @"C:\inetpub\HCSChampion\private.key";
        public static string AccountId = "0d54d0a7-9600-460c-a46d-daf12d331d25";
        public static string apiBase = "https://na4.docusign.net/restapi";

        public static EnvelopesApi InitilizeRequest()
        {

            var docuSignClient = new DocuSignClient(Credentials.apiBase);
            var envelopesApi = new EnvelopesApi(docuSignClient);

            string accsesCode = JWTAuth.AuthenticateWithJWT("ESignature", Credentials.ClientId, Credentials.ImpersonatedUserID, Credentials.AuthServer, DSHelper.ReadFileContent(Credentials.PrivateKeyFile)).access_token;

            docuSignClient.Configuration.DefaultHeader.Add("Authorization", "Bearer " + accsesCode);

            return envelopesApi;
        }
    }
}
