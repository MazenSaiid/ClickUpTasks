using ClassLibary.ClickUp.Webhook;
using ClassLibrary.ClickUp.DTO;
using ClassLibrary.ErrorHandler;
using DocuSign.eSign.Model;
using Newtonsoft.Json;
using Org.BouncyCastle.Asn1.X9;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.AccessControl;

#pragma warning disable
namespace ClassLibrary.ClickUp.Functions
{
    public class CU_Functions
    {

        public RestClient RestClient = new RestClient("https://api.clickup.com/api/v2/");

        public RestRequest RestRequest { get; set; }
        public RestResponse RestResponse { get; set; }

        private string Authorization;

        public CU_Functions() { }

        public CU_Functions(string autorizetion) 
        { Authorization = autorizetion; }
        
        public class custom_field_filter
        {
            public string field_id { get; set; }

            public string @operator { get; set; }
            public object value { get; set; }

            public custom_field_filter(string fi_id, string ope, object val)
            {
                field_id = fi_id;
                @operator = ope;
                value = val;
            }
        }
      

        private RestRequest newRestRequest()
        {
            RestRequest restRequest = new RestRequest();
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddHeader("Authorization", Authorization);

            return restRequest;
        }

        private void InitilizeRequest(string url, Method method)
        {
            RestClient = new RestClient("https://api.clickup.com/api/v2/" + url);
            RestRequest = new RestRequest();
            RestRequest.Method = method;
            RestRequest.AddHeader("Content-Type", "application/json");
            RestRequest.AddHeader("Authorization", Authorization);
        }

        public CU_Task GetTask(string id)
        {
            InitilizeRequest("task/" + id, Method.GET);
            RestResponse = (RestResponse)RestClient.Execute(RestRequest);

            if (RestResponse.StatusCode != HttpStatusCode.OK)
                ErrorEmail.SendEmail("","Phone Response System Error", "The recording system throw an error in  'Get Task'  " + RestResponse.Content);

            CU_Task cU_Task = JsonConvert.DeserializeObject<CU_Task>(RestResponse.Content);

            return cU_Task; 
        }
        public List<CU_Task> Get_Tasks(string listId, bool subtasks)
        {
            RestClient.BaseUrl = new Uri("https://api.clickup.com:443/api/v2/" + "list/" + listId + "/task");

            int page = 0;
            var continu = true;

            List<CU_Task> filteredTasks = new List<CU_Task>();

            while (continu)
            {
                RestRequest = newRestRequest();
                RestRequest.Method = Method.GET;

                //include subtasks
                if(subtasks)
                RestRequest.AddParameter("subtasks", subtasks);

                RestRequest.AddParameter("page", page);
                RestResponse response = (RestResponse)RestClient.Execute(RestRequest);

                if (response.StatusCode != HttpStatusCode.OK)
                    throw new Exception(response.Content);

                CU_Tasks cU_Tasks = JsonConvert.DeserializeObject<CU_Tasks>(response.Content);

                if (cU_Tasks.Tasks.Length != 0)
                {
                    filteredTasks.AddRange(cU_Tasks.Tasks);
                }

                else
                    continu = false;
                Console.WriteLine(filteredTasks.Count);

                page++;

            };
            return filteredTasks;

        }

        public List<CU_Task> GetTasksByPage(string listId, bool subtasks, string filter, int page)
        {
            List<CU_Task> filteredTasks = new List<CU_Task>();

                InitilizeRequest("list/" + listId + "/task", Method.GET);
                RestRequest.Method = Method.GET;

                //include subtasks
                if (subtasks)
                    RestRequest.AddParameter("subtasks", subtasks);
                RestRequest.AddParameter("page", page);
                RestRequest.AddParameter("custom_fields", filter);
                RestResponse response = (RestResponse)RestClient.Execute(RestRequest);

                if (response.StatusCode != HttpStatusCode.OK)
                    throw new Exception(response.Content);

                CU_Tasks cU_Tasks = JsonConvert.DeserializeObject<CU_Tasks>(response.Content);

                if (cU_Tasks.Tasks.Length != 0)
                {
                    filteredTasks.AddRange(cU_Tasks.Tasks);
                }

            return filteredTasks;
        }

        public List<CU_Task> Get_Tasks(string listId, bool subtasks, string filter, bool includeClosed = false)
        {
            int page = 0;
            var continu = true;

            List<CU_Task> filteredTasks = new List<CU_Task>();

            while (continu)
            {
                InitilizeRequest("list/" + listId + "/task", Method.GET);
                RestRequest.Method = Method.GET;

                //include subtasks
                if (subtasks)
                    RestRequest.AddParameter("subtasks", subtasks);
                if(includeClosed)
                    RestRequest.AddParameter("include_closed", includeClosed);

                RestRequest.AddParameter("page", page);
                RestRequest.AddParameter("custom_fields", $"[{filter}]");
                RestResponse = (RestResponse)RestClient.Execute(RestRequest);

                if (RestResponse.StatusCode != HttpStatusCode.OK)
                    throw new Exception(RestResponse.Content);

                CU_Tasks cU_Tasks = JsonConvert.DeserializeObject<CU_Tasks>(RestResponse.Content);

                if (cU_Tasks.Tasks.Length != 0)
                {
                    filteredTasks.AddRange(cU_Tasks.Tasks);
                }

                else
                    continu = false;
                Console.WriteLine(filteredTasks.Count);
                page++;

            };
            return filteredTasks;
        }

        public List<CU_Task> GetTeamTasks(string teamId, bool subtasks, string filter, string SpaceID = null)
        {
            RestClient.BaseUrl = new Uri(RestClient.BaseUrl.OriginalString + "list/" + teamId + "/task");

            int page = 0;
            var continu = true;

            List<CU_Task> filteredTasks = new List<CU_Task>();

            while (continu)
            {
                InitilizeRequest("team/" + teamId + "/task", Method.GET);
                RestRequest.Method = Method.GET;

                //include subtasks
                if (subtasks)
                    RestRequest.AddParameter("subtasks", subtasks);
                RestRequest.AddParameter("page", page);
                RestRequest.AddParameter("custom_fields", filter);
                if(SpaceID != null)
                {
                    RestRequest.AddParameter("space_ids[]", SpaceID);
                }
                RestResponse response = (RestResponse)RestClient.Execute(RestRequest);

                if (response.StatusCode != HttpStatusCode.OK)
                    throw new Exception(response.Content);

                CU_Tasks cU_Tasks = JsonConvert.DeserializeObject<CU_Tasks>(response.Content);

                if (cU_Tasks.Tasks.Length != 0)
                {
                    filteredTasks.AddRange(cU_Tasks.Tasks);
                }

                else
                    continu = false;
                Console.WriteLine(filteredTasks.Count);

                page++;

            };
            return filteredTasks;
        }
       
        public List<CU_Task> GetSubtasks(string teamId, string taskId, bool include_closed = false, string filter = null)
        {
            InitilizeRequest("team/" + teamId + "/task", Method.GET);
            RestRequest.AddParameter("parent", taskId);

            if (include_closed)
            {
                RestRequest.AddParameter("include_closed", include_closed);

            }
            if (filter != null)
            {
                RestRequest.AddParameter("custom_fields", filter);
            }

            RestResponse = (RestResponse)RestClient.Execute(RestRequest);

            if (RestResponse.StatusCode != HttpStatusCode.OK)
                throw new Exception(RestResponse.Content);

            CU_Tasks cU_Tasks = JsonConvert.DeserializeObject<CU_Tasks>(RestResponse.Content);

            var tasks = new List<CU_Task>();
            tasks.AddRange(cU_Tasks.Tasks);
            return tasks;
        }

        public List<CU_Task> GetViewTasks(string viewId, bool subtasks)
        {
            int page = 0;
            var continu = true;

            List<CU_Task> viewTasks = new List<CU_Task>();

            while (continu)
            {
                InitilizeRequest("view/" + viewId + "/task", Method.GET);
                RestRequest.AddParameter("subtasks", subtasks);
                RestRequest.AddParameter("page", page);

                RestResponse = (RestResponse)RestClient.Execute(RestRequest);

                if (RestResponse.StatusCode != HttpStatusCode.OK)
                    throw new Exception(RestResponse.Content);

                CU_Tasks cU_Tasks = JsonConvert.DeserializeObject<CU_Tasks>(RestResponse.Content);

                if (cU_Tasks.Tasks.Length != 0)
                {
                    viewTasks.AddRange(cU_Tasks.Tasks);
                }

                else
                    continu = false;
                Console.WriteLine(viewTasks.Count);

                page++;

            };

            return viewTasks;
        }

        public CU_Task CreateTask(string listId, CreateTask.Task task)
        {
            InitilizeRequest("list/" + listId + "/task", Method.POST);
            RestRequest.AddParameter("application/json", JsonConvert.SerializeObject(task), ParameterType.RequestBody);
            RestResponse = (RestResponse)RestClient.Execute(RestRequest);

            if (RestResponse.StatusCode != HttpStatusCode.OK)
                throw new Exception(RestResponse.Content);

            CU_Task newTask = JsonConvert.DeserializeObject<CU_Task>(RestResponse.Content)?? new CU_Task();

            return newTask;
        }

       
        public CU_Task CreateTaskFromTemplate(string listId, string templateID, string name)
        {
            InitilizeRequest("list/" + listId + "/taskTemplate/" + templateID, Method.POST);
            RestRequest.AddParameter("application/json", name, ParameterType.RequestBody);
            RestResponse = (RestResponse)RestClient.Execute(RestRequest);

            if (RestResponse.StatusCode != HttpStatusCode.OK)
                throw new Exception(RestResponse.Content);

            CU_Task newTask = JsonConvert.DeserializeObject<CU_Task>(RestResponse.Content) ?? new CU_Task();

            return newTask;
        }

        public CU_Task UpdateTask(string taskId, string body)
        {
            InitilizeRequest("task/" + taskId, Method.PUT);
            RestRequest.AddParameter("application/json", body, ParameterType.RequestBody);
            RestResponse = (RestResponse)RestClient.Execute(RestRequest);

            if (RestResponse.StatusCode != HttpStatusCode.OK)
                ErrorEmail.SendEmail("", "Phone Response System Error", "The recording system throw an error in  'UpdateTask'" + RestResponse.Content);
            
            CU_Task newTask = JsonConvert.DeserializeObject<CU_Task>(RestResponse.Content) ?? new CU_Task();

            return newTask;
        }


        public string GetTextFieldValue(List<DTO.CustomField> custom_fields, string fieldID)
        {
            string valueTemp = "";
            DTO.CustomField textField = custom_fields.Where(i => i.id == fieldID).FirstOrDefault();
            if (textField != null && textField.value != null)
            {
                valueTemp = textField.value.ToString();
            }
            return valueTemp.Replace("\n", "");
        }

        public string GetDropDownOption(List<DTO.CustomField> custom_fields, string FieldID)
        {
            string option = "";
            var field = custom_fields.Where(i => i.id == FieldID).FirstOrDefault();
            if (field != null && field.value != null && field.type_config.options != null)
            {
                Option options = field.type_config.options[int.Parse(field.value.ToString())];
                option = options.name;
            }
            return option;
        }

        public void assigneChecklist(string taskId, int assignee, string checklistID, string ItemId)
        {
            var json = "{\"assignee\": \"" + assignee + "\"}";
            InitilizeRequest("checklist/" + checklistID + "/checklist_item/" + ItemId, Method.PUT);
            RestRequest.AddParameter("application/json", json, ParameterType.RequestBody);
            RestResponse = (RestResponse)RestClient.Execute(RestRequest);

            if (RestResponse.StatusCode != HttpStatusCode.OK)
                throw new Exception(RestResponse.Content);
        }

        public void assigneChecklistRemove(string taskId, string checklistID, string ItemId)
        {
            var json = "{\"assignee\": null}";
            InitilizeRequest("checklist/" + checklistID + "/checklist_item/" + ItemId, Method.PUT);
            RestRequest.AddParameter("application/json", json, ParameterType.RequestBody);
            RestResponse = (RestResponse)RestClient.Execute(RestRequest);

            if (RestResponse.StatusCode != HttpStatusCode.OK)
                throw new Exception(RestResponse.Content);
        }

        public CU_Task UpdateToSubtask(string taskId, CreateTask.Task task)
        {
            InitilizeRequest("task/" + taskId, Method.PUT);
            RestRequest.AddParameter("application/json", JsonConvert.SerializeObject(task), ParameterType.RequestBody);
            RestResponse = (RestResponse)RestClient.Execute(RestRequest);

            if (RestResponse.StatusCode != HttpStatusCode.OK)
                ErrorEmail.SendEmail("", "Phone Response System Error", "The recording system throw an error in  'UpdateTask'" + RestResponse.Content);

            CU_Task newTask = JsonConvert.DeserializeObject<CU_Task>(RestResponse.Content) ?? new CU_Task();

            return newTask;
        }

        public void SetCFValue(string taskId, string fieldId, string value)
        {
            InitilizeRequest("task/" + taskId + "/field/" + fieldId, Method.POST);
            RestRequest.AddParameter("application/json",value, ParameterType.RequestBody);
            RestResponse =  (RestResponse)RestClient.Execute(RestRequest);

            if (RestResponse.StatusCode != HttpStatusCode.OK)
                throw new Exception(RestResponse.Content);

        }

        public void DeleteCFValue(string taskId, string fieldId)
        {
            InitilizeRequest("task/" + taskId + "/field/" + fieldId, Method.DELETE);
            RestResponse = (RestResponse)RestClient.Execute(RestRequest);

            if (RestResponse.StatusCode != HttpStatusCode.OK)
                throw new Exception(RestResponse.StatusCode.ToString());

        }

        public void AddToList(string taskId, string listId)
        {
            InitilizeRequest("list/" + listId + "/task/" + taskId, Method.POST);
            RestResponse = (RestResponse)RestClient.Execute(RestRequest);

            if (RestResponse.StatusCode != HttpStatusCode.OK)
                throw new Exception(RestResponse.StatusCode.ToString());
        }

        public void AddTagToTask(string taskId, string tagName)
        {
            InitilizeRequest("task/" + taskId + "/tag/" + tagName, Method.POST);
            RestResponse = (RestResponse)RestClient.Execute(RestRequest);

            if (RestResponse.StatusCode != HttpStatusCode.OK)
                throw new Exception(RestResponse.StatusCode.ToString());
        }

        public void RemoveTagFromTask(string taskId, string tagName)
        {
            InitilizeRequest("task/" + taskId + "/tag/" + tagName, Method.DELETE);
            RestResponse = (RestResponse)RestClient.Execute(RestRequest);

            if (RestResponse.StatusCode != HttpStatusCode.OK)
                throw new Exception(RestResponse.StatusCode.ToString());
        }
        public void PostAttachment(string taskId, string fileName, byte[] bytes)
        {
            InitilizeRequest("task/" + taskId + "/attachment", Method.POST);

            RestRequest.AddFile("attachment", bytes, fileName);

            RestResponse = (RestResponse)RestClient.Execute(RestRequest);


            if (RestResponse.StatusCode != HttpStatusCode.OK)
                throw new Exception(RestResponse.StatusCode.ToString());
        }

        public List<DTO.CustomField> GetAccessibleCustomFields(string listID)
        {
            List<DTO.CustomField> customFields = new List<DTO.CustomField>();
            RestClient.BaseUrl = new Uri(RestClient.BaseUrl.OriginalString + "list/" + listID + "/field");
            RestRequest = newRestRequest();
            RestRequest.Method = Method.GET;
            RestResponse = (RestResponse)RestClient.Execute(RestRequest);

            if (RestResponse.StatusCode != HttpStatusCode.OK)
                ErrorEmail.SendEmail("", "Phone Response System Error", "The recording system throw an error in  'GetTemplates'  " + RestResponse.Content);

            CustomFieldList customField = JsonConvert.DeserializeObject<CustomFieldList>(RestResponse.Content);



            customFields.AddRange(customField.fields);
            return customFields;


        }

        public List<Template> GetTemplates(string teamId)
        {

            int page = 0;
            var continu = true;

            List<Template> templatesList = new List<Template>();

            while (continu)
            {
                InitilizeRequest("team/" + teamId + "/taskTemplate", Method.GET);
               
                RestRequest.AddParameter("page", page);
                RestResponse = (RestResponse)RestClient.Execute(RestRequest);

                if (RestResponse.StatusCode != HttpStatusCode.OK)
                    throw new Exception(RestResponse.Content);

                Templates templats = JsonConvert.DeserializeObject<Templates>(RestResponse.Content);

                if (templats.templates.Length != 0)
                {
                    templatesList.AddRange(templats.templates);
                }

                else
                    continu = false;
                Console.WriteLine(templatesList.Count);
                page++;

            };
            return templatesList;
        }

        public string SetCustomFieldValue(string taskId, string fieldId, string CustomFeildvalue)
        {
            InitilizeRequest("task/" + taskId + "/field/" + fieldId, Method.POST);
            RestRequest.AddParameter("application/json", $"{{\"value\": {CustomFeildvalue}}}", ParameterType.RequestBody);
            RestClient.Timeout = 200000;
            RestResponse = (RestResponse)RestClient.Execute(RestRequest);

            if (RestResponse.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception(RestResponse.Content);
            }
            return RestResponse.Content;
        }

        public string LinkTask(string taskId, string fieldId, Array CustomFeildvalue)
        {
            //foreach item in CustomFeildvalue array create one string and add "" to each item
            string CustomFeildvalueString = "";
            foreach (var item in CustomFeildvalue)
            {
                CustomFeildvalueString += "\"" + item + "\",";
            }

            //remove last , from string
            CustomFeildvalueString = CustomFeildvalueString.Remove(CustomFeildvalueString.Length - 1);

            InitilizeRequest("task/" + taskId + "/field/" + fieldId, Method.POST);
            RestRequest.AddParameter("application/json", "{\"value\": {\"add\": [" + CustomFeildvalueString + "]}}", ParameterType.RequestBody);
            RestClient.Timeout = 200000;
            RestResponse = (RestResponse)RestClient.Execute(RestRequest);

            if (RestResponse.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception(RestResponse.Content);
            }
            return RestResponse.Content;
        }



        public void DeleteTask(string taskId)
        {
            InitilizeRequest("task/" + taskId, Method.DELETE);
            RestResponse = (RestResponse)RestClient.Execute(RestRequest);

            if (RestResponse.StatusCode != HttpStatusCode.OK && RestResponse.StatusCode != HttpStatusCode.NoContent)
                throw new Exception(RestResponse.StatusCode.ToString());

        }


        public void DeleteCustomFieldValue(string taskId, string fieldId)
        {
            InitilizeRequest("task/" + taskId + "/field/" + fieldId, Method.DELETE);
            RestResponse = (RestResponse)RestClient.Execute(RestRequest);

            if (RestResponse.StatusCode != HttpStatusCode.OK)
            {
                ErrorEmail.SendEmail("Joseph@uptodateteam.com", "Error In Clickup DeleteCustomFieldValue function HCS",
                RestResponse.Content.ToString()
                   + "\n\r" +  taskId, "joseph@beavercustomsoftware.com");
            }


        }

        public  DTO.User GetUser(List<DTO.CustomField> custom_fields, string FieldID)
        {
            DTO.User user = new DTO.User();
            var field = custom_fields.Where(i => i.id == FieldID).FirstOrDefault();
            if (field != null && field.value != null)
            {
                List<DTO.User> users = (List<DTO.User>)JsonConvert.DeserializeObject<List<DTO.User>>(field.value.ToString());
                user = users.FirstOrDefault();
            }
            return user;
        }



        public void AddUser(string taskId, string fieldID, DTO.User[] members, bool RemoveOld, DTO.User[] OldMembers = null)
        {
            InitilizeRequest("/task/" + taskId + "/field/" + fieldID, Method.POST);
            string value = "";
            if (RemoveOld == false)
            {
                 value = "{\"value\": {\"add\":[" + string.Join(',', members.Select(m => m.id)) + "] ,\"rem\":[]}}";
            }
            if (RemoveOld == true)
            {
                //DeleteCustomFieldValue(taskId, fieldID);
                value = "{\"value\": {\"add\":[" + string.Join(',', members.Select(m => m.id)) + "] ,\"rem\":[" + string.Join(',', OldMembers.Select(m => m.id)) + "]}}";
            }

            RestRequest.AddParameter("application/json", value, ParameterType.RequestBody);
        repeat:
            IRestResponse response = RestClient.Post(RestRequest);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                if (response.Content.Contains("Rate limit reached"))
                {
                    Thread.Sleep(60000);
                    goto repeat;
                }
                ErrorEmail.SendEmail("Joseph@uptodateteam.com", "Error In Clickup function AddUser HCS",
               response.Content.ToString()
                  + "\n\r" + taskId, "joseph@beavercustomsoftware.com");
            }
        }

        public void AddAssignee(string taskId, DTO.User[] members, bool RemoveOld, DTO.User[] old = null)
        {
            string value = "";
            InitilizeRequest("/task/" + taskId, Method.PUT);
            if (RemoveOld == false)
            {
                 value = "{\"assignees\": {\"add\":[" + string.Join(',', members.Select(m => m.id)) + "] ,\"rem\":[]}}";
            }
            else
            {
                 value = "{\"assignees\": {\"add\":[" + string.Join(',', members.Select(m => m.id)) + "] ,\"rem\":[" + string.Join(',', old.Select(m => m.id)) + "]}}";
            }

            RestRequest.AddParameter("application/json", value, ParameterType.RequestBody);
        repeat:
            IRestResponse response = RestClient.Put(RestRequest);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                if (response.Content.Contains("Rate limit reached"))
                {
                    Thread.Sleep(60000);
                    goto repeat;
                }
                ErrorEmail.SendEmail("Joseph@uptodateteam.com", "Error In Clickup function AddUser HCS",
               response.Content.ToString()
                  + "\n\r" + taskId, "joseph@beavercustomsoftware.com");
            }
        }



        public void AddDependency(string taskId, string dependsOn)
        {
            InitilizeRequest("task/" + taskId + "/dependency", Method.POST);
            RestRequest.AddParameter("application/json", $"{{\"depends_on\": \"{dependsOn}\"}}", ParameterType.RequestBody);

            RestResponse = (RestResponse)RestClient.Execute(RestRequest);

            if (RestResponse.StatusCode != HttpStatusCode.OK && RestResponse.StatusCode != HttpStatusCode.NoContent)
                throw new Exception(RestResponse.StatusCode.ToString());

        }
    }
}

