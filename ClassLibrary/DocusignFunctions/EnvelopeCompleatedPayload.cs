using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.DocusignFunctions.EnvelopeCompleatedPayload
{
    public class EnvelopeCompleatedPayload
    {

        public string @event { get; set; }
        public string apiVersion { get; set; }
        public string uri { get; set; }
        public int retryCount { get; set; }
        public int configurationId { get; set; }
        public DateTime generatedDateTime { get; set; }
        public Data data { get; set; }
    }
    public class CheckboxTab
    {
        public string name { get; set; }
        public string tabLabel { get; set; }
        public string selected { get; set; }
        public string selectedOriginal { get; set; }
        public string shared { get; set; }
        public string requireInitialOnSharedChange { get; set; }
        public string font { get; set; }
        public string fontColor { get; set; }
        public string fontSize { get; set; }
        public string required { get; set; }
        public string locked { get; set; }
        public string documentId { get; set; }
        public string recipientId { get; set; }
        public string pageNumber { get; set; }
        public string xPosition { get; set; }
        public string yPosition { get; set; }
        public string width { get; set; }
        public string height { get; set; }
        public string tabId { get; set; }
        public string templateRequired { get; set; }
        public string conditionalParentLabel { get; set; }
        public string conditionalParentValue { get; set; }
        public string tabType { get; set; }
        public List<string> tabGroupLabels { get; set; }
    }

    public class CustomFields
    {
        public List<TextCustomField> textCustomFields { get; set; }
        public List<object> listCustomFields { get; set; }
    }

    public class Data
    {
        public string accountId { get; set; }
        public string userId { get; set; }
        public string envelopeId { get; set; }
        public EnvelopeSummary envelopeSummary { get; set; }
    }

    public class DateSignedTab
    {
        public string name { get; set; }
        public DateTime value { get; set; }
        public string tabLabel { get; set; }
        public string font { get; set; }
        public string fontColor { get; set; }
        public string fontSize { get; set; }
        public LocalePolicy localePolicy { get; set; }
        public string documentId { get; set; }
        public string recipientId { get; set; }
        public string pageNumber { get; set; }
        public string xPosition { get; set; }
        public string yPosition { get; set; }
        public string width { get; set; }
        public string height { get; set; }
        public string tabId { get; set; }
        public string templateRequired { get; set; }
        public string tabType { get; set; }
    }

    public class EnvelopeDocument
    {
        public string documentId { get; set; }
        public string documentIdGuid { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string uri { get; set; }
        public string order { get; set; }
        public List<Page> pages { get; set; }
        public string display { get; set; }
        public string includeInDownload { get; set; }
        public string signerMustAcknowledge { get; set; }
        public string templateRequired { get; set; }
        public string authoritativeCopy { get; set; }
        public string PDFBytes { get; set; }
    }

    public class EnvelopeMetadata
    {
        public string allowAdvancedCorrect { get; set; }
        public string enableSignWithNotary { get; set; }
        public string allowCorrect { get; set; }
    }

    public class EnvelopeSummary
    {
        public string status { get; set; }
        public string documentsUri { get; set; }
        public string recipientsUri { get; set; }
        public string attachmentsUri { get; set; }
        public string envelopeUri { get; set; }
        public string emailSubject { get; set; }
        public string envelopeId { get; set; }
        public string signingLocation { get; set; }
        public string customFieldsUri { get; set; }
        public string notificationUri { get; set; }
        public string enableWetSign { get; set; }
        public string allowMarkup { get; set; }
        public string allowReassign { get; set; }
        public DateTime createdDateTime { get; set; }
        public DateTime lastModifiedDateTime { get; set; }
        public DateTime deliveredDateTime { get; set; }
        public DateTime initialSentDateTime { get; set; }
        public DateTime sentDateTime { get; set; }
        public DateTime completedDateTime { get; set; }
        public DateTime statusChangedDateTime { get; set; }
        public string documentsCombinedUri { get; set; }
        public string certificateUri { get; set; }
        public string templatesUri { get; set; }
        public string expireEnabled { get; set; }
        public DateTime expireDateTime { get; set; }
        public string expireAfter { get; set; }
        public Sender sender { get; set; }
        public List<Folder> folders { get; set; }
        public CustomFields customFields { get; set; }
        public Recipients recipients { get; set; }
        public List<EnvelopeDocument> envelopeDocuments { get; set; }
        public string purgeState { get; set; }
        public string envelopeIdStamping { get; set; }
        public string is21CFRPart11 { get; set; }
        public string signerCanSignOnMobile { get; set; }
        public string autoNavigation { get; set; }
        public string isSignatureProviderEnvelope { get; set; }
        public string hasFormDataChanged { get; set; }
        public string allowComments { get; set; }
        public string hasComments { get; set; }
        public string allowViewHistory { get; set; }
        public EnvelopeMetadata envelopeMetadata { get; set; }
        public object anySigner { get; set; }
        public string envelopeLocation { get; set; }
        public string isDynamicEnvelope { get; set; }
        public string burnDefaultTabData { get; set; }
    }

    public class Folder
    {
        public string name { get; set; }
        public string type { get; set; }
        public Owner owner { get; set; }
        public string folderId { get; set; }
        public string uri { get; set; }
    }

    public class LocalePolicy
    {
    }

    public class Owner
    {
        public string userId { get; set; }
        public string email { get; set; }
    }

    public class Page
    {
        public string pageId { get; set; }
        public string sequence { get; set; }
        public string height { get; set; }
        public string width { get; set; }
        public string dpi { get; set; }
    }

    public class Recipients
    {
        public List<Signer> signers { get; set; }
        public List<object> agents { get; set; }
        public List<object> editors { get; set; }
        public List<object> intermediaries { get; set; }
        public List<object> carbonCopies { get; set; }
        public List<object> certifiedDeliveries { get; set; }
        public List<object> inPersonSigners { get; set; }
        public List<object> seals { get; set; }
        public List<object> witnesses { get; set; }
        public List<object> notaries { get; set; }
        public string recipientCount { get; set; }
        public string currentRoutingOrder { get; set; }
    }

    public class Sender
    {
        public string userName { get; set; }
        public string userId { get; set; }
        public string accountId { get; set; }
        public string email { get; set; }
        public string ipAddress { get; set; }
    }

    public class Signer
    {
        public Tabs tabs { get; set; }
        public string creationReason { get; set; }
        public string canSignOffline { get; set; }
        public string isBulkRecipient { get; set; }
        public string requireUploadSignature { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string recipientId { get; set; }
        public string recipientIdGuid { get; set; }
        public string requireIdLookup { get; set; }
        public string userId { get; set; }
        public string routingOrder { get; set; }
        public string note { get; set; }
        public string roleName { get; set; }
        public string status { get; set; }
        public string completedCount { get; set; }
        public DateTime signedDateTime { get; set; }
        public DateTime deliveredDateTime { get; set; }
        public DateTime sentDateTime { get; set; }
        public string deliveryMethod { get; set; }
        public string totalTabCount { get; set; }
        public string recipientType { get; set; }
    }

    public class SignHereTab
    {
        public string stampType { get; set; }
        public string name { get; set; }
        public string tabLabel { get; set; }
        public string scaleValue { get; set; }
        public string optional { get; set; }
        public string documentId { get; set; }
        public string recipientId { get; set; }
        public string pageNumber { get; set; }
        public string xPosition { get; set; }
        public string yPosition { get; set; }
        public string tabId { get; set; }
        public string templateRequired { get; set; }
        public string status { get; set; }
        public string tabType { get; set; }
        public string tooltip { get; set; }
    }

    public class TabGroup
    {
        public string groupLabel { get; set; }
        public string minimumRequired { get; set; }
        public string maximumAllowed { get; set; }
        public string groupRule { get; set; }
        public string tabScope { get; set; }
        public string documentId { get; set; }
        public string recipientId { get; set; }
        public string pageNumber { get; set; }
        public string xPosition { get; set; }
        public string yPosition { get; set; }
        public string tabId { get; set; }
        public string templateRequired { get; set; }
        public string tabType { get; set; }
    }

    public class Tabs
    {
        public List<SignHereTab> signHereTabs { get; set; }
        public List<DateSignedTab> dateSignedTabs { get; set; }
        public List<TextTab> textTabs { get; set; }
        public List<CheckboxTab> checkboxTabs { get; set; }
        public List<TabGroup> tabGroups { get; set; }
    }

    public class TextCustomField
    {
        public string fieldId { get; set; }
        public string name { get; set; }
        public string show { get; set; }
        public string required { get; set; }
        public string value { get; set; }
    }

    public class TextTab
    {
        public string validationPattern { get; set; }
        public string validationMessage { get; set; }
        public string shared { get; set; }
        public string requireInitialOnSharedChange { get; set; }
        public string requireAll { get; set; }
        public string value { get; set; }
        public string required { get; set; }
        public string locked { get; set; }
        public string concealValueOnDocument { get; set; }
        public string disableAutoSize { get; set; }
        public string maxLength { get; set; }
        public string tabLabel { get; set; }
        public string font { get; set; }
        public string fontColor { get; set; }
        public string fontSize { get; set; }
        public LocalePolicy localePolicy { get; set; }
        public string documentId { get; set; }
        public string recipientId { get; set; }
        public string pageNumber { get; set; }
        public string xPosition { get; set; }
        public string yPosition { get; set; }
        public string width { get; set; }
        public string height { get; set; }
        public string tabId { get; set; }
        public string templateRequired { get; set; }
        public string tabType { get; set; }
        public string originalValue { get; set; }
    }
}


