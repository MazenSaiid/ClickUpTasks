using ClassLibrary.DocusignFunctions;
using DocuSign.CodeExamples.Authentication;
using DocuSign.CodeExamples.Common;
using System.Text;
using static DocuSign.eSign.Client.Auth.OAuth;

namespace Integrations.DocusignFunctions
{
    public static class GetCode
    {

        public static string getNewAccessToken(string IntegrationKey,string userID)
        {
            //string IntegrationKey = "58cbcaba-e0f8-4bdc-b32b-eb6ceb669f0a";
            //string userID = "14bdf54b-fbff-4790-8e31-25928ba7cf3a";
            OAuthToken accessToken = null;
            string strAccessToken = "";
            
            try
            {
                accessToken = JWTAuth.AuthenticateWithJWT("ESignature", Credentials.ClientId, userID, "account-d.docusign.com", DSHelper.ReadFileContent(Credentials.PrivateKeyFile));
            }
            catch (Exception apiExp)
            {
                
            }
            if (accessToken != null)
            {
                strAccessToken = accessToken.access_token;
            }
            return strAccessToken;


        }
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }







    }
}
