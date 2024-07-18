using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#pragma warning disable
namespace ClassLibrary.ClickUp.DTO
{
    // WebhookApiResponse myDeserializedClass = JsonConvert.DeserializeObject<WebhookApiResponse>(myJsonResponse);
    // WebhookApiResponse myDeserializedClass = JsonConvert.DeserializeObject<WebhookApiResponse>(myJsonResponse);
    // WebhookApiResponse myDeserializedClass = JsonConvert.DeserializeObject<List<WebhookApiResponse>>(myJsonResponse);
    public class Creator
    {
        public int id { get; set; }
        public string username { get; set; }
        public string color { get; set; }
        public string email { get; set; }
        public object profilePicture { get; set; }
    }

    public class CustomField
    {
        public string id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public TypeConfig type_config { get; set; }
        public string date_created { get; set; }
        public bool hide_from_guests { get; set; }
        public string required { get; set; }
        public object value { get; set; }
    }

    public class Folder
    {
        public string id { get; set; }
        public string name { get; set; }
        public bool hidden { get; set; }
        public bool access { get; set; }
    }

    public class List
    {
        public string id { get; set; }
        public string name { get; set; }
        public bool access { get; set; }
    }

    public class Option
    {
        public string id { get; set; }
        public string name { get; set; }
        public object color { get; set; }
        public int orderindex { get; set; }
        public string label { get; set; }
    }

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
        public bool archived { get; set; }
        public Creator creator { get; set; }
        public List<object> assignees { get; set; }
        public List<Watcher> watchers { get; set; }
        public List<object> checklists { get; set; }
        public List<object> tags { get; set; }
        public object parent { get; set; }
        public object priority { get; set; }
        public object due_date { get; set; }
        public object start_date { get; set; }
        public object points { get; set; }
        public object time_estimate { get; set; }
        public List<CustomField> custom_fields { get; set; }
        public List<object> dependencies { get; set; }
        public List<object> linked_tasks { get; set; }
        public string team_id { get; set; }
        public string url { get; set; }
        public List list { get; set; }
        public Project project { get; set; }
        public Folder folder { get; set; }
        public Space space { get; set; }
    }

    public class Project
    {
        public string id { get; set; }
        public string name { get; set; }
        public bool hidden { get; set; }
        public bool access { get; set; }
    }

    public class WebhookApiResponse
    {
        public string id { get; set; }
        public string trigger_id { get; set; }
        public DateTime date { get; set; }
        public Payload payload { get; set; }
    }

    public class Space
    {
        public string id { get; set; }
    }

    public class Status
    {
        public string id { get; set; }
        public string status { get; set; }
        public string color { get; set; }
        public int orderindex { get; set; }
        public string type { get; set; }
    }
    public class Tag
    {
        public string name { get; set; }
        public string tag_fg { get; set; }
        public string tag_bg { get; set; }
        public int? creator { get; set; }

    }
    public class TypeConfig
    {
        public bool? new_drop_down { get; set; }
        public List<Option> options { get; set; }
        public int? @default { get; set; }
        public object placeholder { get; set; }
    }

    public class Watcher
    {
        public int id { get; set; }
        public string username { get; set; }
        public string color { get; set; }
        public string initials { get; set; }
        public string email { get; set; }
        public string profilePicture { get; set; }
    }
    public class User
    {
        public int id { get; set; }
        public string username { get; set; }
        public string color { get; set; }
        public string initials { get; set; }
        public string email { get; set; }
        public string profilePicture { get; set; }
    }

    public class CustomFieldRelation
    {
        public string id { get; set; }
        public string name { get; set; }
        public string status { get; set; }
        public string color { get; set; }
        public object custom_type { get; set; }
        public string team_id { get; set; }
        public bool deleted { get; set; }
        public string url { get; set; }
        public bool access { get; set; }
    }

    public class Templates
    {
        public Template[] templates { get; set; }

    }
    public class Template
    {
        public string name { get; set; }

        public string id { get; set; }

    }

    public class CustomFieldList
    {
        public CustomField[] fields { get; set; }
    }

    public class AttchmentField
    {
        public string id { get; set; }
        public string date { get; set; }
        public string title { get; set; }
        public int type { get; set; }
        public int source { get; set; }
        public int version { get; set; }
        public string extension { get; set; }
        public object thumbnail_small { get; set; }
        public object thumbnail_medium { get; set; }
        public object thumbnail_large { get; set; }
        public object is_folder { get; set; }
        public string mimetype { get; set; }
        public bool hidden { get; set; }
        public string parent_id { get; set; }
        public int size { get; set; }
        public int total_comments { get; set; }
        public int resolved_comments { get; set; }
        public User user { get; set; }
        public bool deleted { get; set; }
        public object orientation { get; set; }
        public string url { get; set; }
        public object parent_comment_type { get; set; }
        public object parent_comment_parent { get; set; }
        public object email_data { get; set; }
        public string url_w_query { get; set; }
        public string url_w_host { get; set; }
    }

    public class Item
    {
        public string id { get; set; }
        public string name { get; set; }
        public double orderindex { get; set; }
        public object assignee { get; set; }
        public object group_assignee { get; set; }
        public bool resolved { get; set; }
        public object parent { get; set; }
        public string date_created { get; set; }
        public List<object> children { get; set; }
    }

    public class Checklist
    {
        public string id { get; set; }
        public string task_id { get; set; }
        public string name { get; set; }
        public string date_created { get; set; }
        public int orderindex { get; set; }
        public int creator { get; set; }
        public int resolved { get; set; }
        public int unresolved { get; set; }
        public List<Item> items { get; set; }
    }



}
