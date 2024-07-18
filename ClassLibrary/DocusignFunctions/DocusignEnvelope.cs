using DocuSign.eSign.Model;
using DocuSign.eSign.Client;
using DocuSign.eSign.Api;
using Microsoft.VisualBasic;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using ClassLibrary.ErrorHandler;
using static DocuSign.eSign.Client.Auth.OAuth.UserInfo;
using RestSharp.Extensions;
using ClassLibrary.DocusignFunctions;
using static DocuSign.eSign.Model.Tabs;

namespace Integrations.DocusignFunctions
{
    public class DocusignEnvelope
    {
        UsingInfo info = new UsingInfo();
        public DocusignEnvelope() { }
        public DocusignEnvelope(string templateId, string EmailSubject)
        {
            info.Envelope.TemplateId = templateId;
            info.EmailSubject = EmailSubject;
            info.accountId = Credentials.AccountId;
            info.basePath = Credentials.apiBase;
        }
        public void AddRole(string clientRole, string clientEmail, string ClientName, Tabs tabs)
        {
            TemplateRole client = new TemplateRole();
            client.RoleName = clientRole;
            client.Email = clientEmail;
            client.Name = ClientName;
            client.Tabs = new DocuSign.eSign.Model.Tabs();
            client.Tabs = tabs;
            info.Envelope.TemplateRoles = new List<TemplateRole>();
            info.Envelope.TemplateRoles.Add(client);
        }

        public Tabs FillTabs(List<Text> listOfTextTabs)
        {

            Tabs tabs = new Tabs();

            foreach (Text text in listOfTextTabs)
            {
                tabs.TextTabs = new List<Text>();
                tabs.TextTabs.Add(text);
            }
            return tabs;
        }
        public static Tabs FillTabs(List<Text> listOfTextTabs,List<RadioGroup> listOfRadioGroupTabs)
        {

            Tabs tabs = new Tabs();
            tabs.TextTabs = new List<Text>();
            tabs.RadioGroupTabs = new List<RadioGroup>();

            foreach (Text text in listOfTextTabs)
            {
                
                tabs.TextTabs.Add(text);
            }
            foreach (RadioGroup group in listOfRadioGroupTabs)
            {
                
                tabs.RadioGroupTabs.Add(group);
            }


            return tabs;
        }


        public string SendDoc()
        {
            var envelopesApi = Credentials.InitilizeRequest();
            EnvelopeDefinition envelope = info.Envelope;
            envelope.EmailSubject = info.EmailSubject;
            try
            {
                envelope.Status = "sent";
                EnvelopeSummary result = envelopesApi.CreateEnvelope(info.accountId, envelope);
                return result.EnvelopeId;

            }
            catch (Exception ex)
            {
                ErrorEmail.SendEmail("Joseph@uptodateteam.com", "HCS Intagrations Throw An Error", "The DocusignEnvelope controller throw an error, " + Environment.NewLine + "The error message is: " + Environment.NewLine + ex);
                return ex.Message;
            }
        }
        private class UsingInfo
        {
            public string accessToken { get; set; } = "";
            public string basePath { get; set; } = "";
            public string accountId { get; set; } = "";
            public EnvelopeDefinition Envelope { get; set; } = new EnvelopeDefinition();
            public string EmailSubject { get; set; } = "";
        }
    }
}
