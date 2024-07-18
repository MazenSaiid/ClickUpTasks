using ClassLibary.ClickUp.Webhook;
using RestSharp;
using System.Collections.Generic;

#pragma warning disable
namespace ClassLibrary.ClickUp.DTO
{

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);


    public class Field
    {
        public string field { get; set; }
        public int width { get; set; }
        public bool hidden { get; set; }
    }

    public class CU_Tasks
    {
        public CU_Task[] Tasks { get; set; }
    }

    public class CU_Task
    {
        public string id { get; set; }
        public object custom_id { get; set; }
        public string name { get; set; }
        public object text_content { get; set; }
        public object description { get; set; }
        public Status status { get; set; }
        public string orderindex { get; set; }
        public string date_created { get; set; }
        public string date_updated { get; set; }
        public object date_closed { get; set; }
        public bool archived { get; set; }
        public Creator creator { get; set; }
        public List<User> assignees { get; set; } = new List<User>();
        public List<Watcher> watchers { get; set; }
        public List<object> checklists { get; set; }
        public List<Tag> tags { get; set; }
        public object parent { get; set; }
        public object priority { get; set; }
        public object due_date { get; set; }
        public object start_date { get; set; }
        public object points { get; set; }
        public object time_estimate { get; set; }
        public int time_spent { get; set; }
        public List<CustomField> custom_fields { get; set; }
        public List<object> dependencies { get; set; }
        public List<object> linked_tasks { get; set; }
        public string team_id { get; set; }
        public string url { get; set; }
        public string permission_level { get; set; }
        public List list { get; set; }
        public Project project { get; set; }
        public Folder folder { get; set; }
        public Space space { get; set; }
        public List<object> attachments { get; set; }

        public CU_Task() { }

        public CU_Task(ClickUpPayload payload)
        {
            id = payload.payload.id;
            name = payload.payload?.name;
            text_content = payload.payload?.text_content;
            description = payload.payload?.description;
            status = payload.payload?.status;
            orderindex = payload.payload?.orderindex;
            date_created = payload.payload?.date_created;
            date_updated = payload.payload?.date_updated;
            date_closed = payload.payload?.date_closed;
            creator = payload.payload?.creator;
            parent = payload.payload?.parent;
            dependencies = payload.payload?.dependencies;

            assignees = payload.payload?.assignees;
            due_date = payload.payload?.due_date;
            start_date = payload.payload?.start_date;
            points = payload.payload?.points;
            time_estimate = payload.payload?.time_estimate;
            priority = payload.payload?.priority;
            custom_id = payload.payload?.custom_id;
            linked_tasks = payload.payload?.linked_tasks;
            list = payload.payload?.list;
            folder = payload.payload?.folder;
            space = payload.payload?.space;
            custom_fields = payload.payload?.custom_fields;
            checklists = payload.payload?.checklists;
            tags = payload.payload?.tags;
            
        }

    }
}

