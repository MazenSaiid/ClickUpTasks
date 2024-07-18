using ClassLibrary.ClickUp.DTO;
using System;
using System.Collections.Generic;

namespace ClassLibary.ClickUp.Webhook
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
 
    public class Payload
    {
        public string id { get; set; }
        public object custom_id { get; set; }
        public string name { get; set; }
        public string text_content { get; set; }
        public string description { get; set; }
        public Status status { get; set; }
        public string orderindex { get; set; }
        public string date_created { get; set; }
        public string date_updated { get; set; }
        public object date_closed { get; set; }
        public object date_done { get; set; }
        public bool archived { get; set; }
        public Creator creator { get; set; } = new Creator();
        public List<User> assignees { get; set; } = new List<User>();
        public List<Watcher> watchers { get; set; } = new List<Watcher>();
        public List<object> checklists { get; set; } = new List<object>();
        public List<Tag> tags { get; set; } = new List<Tag>();
        public string parent { get; set; } 
        public object priority { get; set; }
        public object due_date { get; set; }
        public object start_date { get; set; }
        public object points { get; set; }
        public object time_estimate { get; set; }
        public List<CustomField> custom_fields { get; set; } = new List<CustomField>();
        public List<object> dependencies { get; set; }
        public List<object> linked_tasks { get; set; }
        public string team_id { get; set; }
        public string url { get; set; }
        public Sharing sharing { get; set; }
        public List list { get; set; } = new List();
        public Project project { get; set; } = new Project();
        public Folder folder { get; set; } = new Folder();
        public Space space { get; set; } = new Space();
    }

    public class Project
    {
        public string id { get; set; }
        public string name { get; set; }
        public bool hidden { get; set; }
        public bool access { get; set; }
    }

    public class ClickUpPayload
    {
        public string id { get; set; }
        public string trigger_id { get; set; }
        public DateTime date { get; set; }
        public Payload payload { get; set; }
    }

    public class Sharing
    {
        public bool @public { get; set; }
        public object public_share_expires_on { get; set; }
        public List<string> public_fields { get; set; } = new List<string>();
        public object token { get; set; }
        public bool seo_optimized { get; set; }
    }

}
