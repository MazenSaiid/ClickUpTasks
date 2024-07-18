using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.ClickUp.DTO
{
#pragma warning disable

    public class CreateTask
    {
        public class CustomField
        {
            public string id { get; set; }
            public object value { get; set; }

            public CustomField() { }
            public CustomField(string id, object value)
            {
                this.id = id;
                this.value = value;
            }
        }

        public class Task
        {
            public string name { get; set; }
            public string description { get; set; }
            public List<int> assignees { get; set; }
            public List<string> tags { get; set; }
            public string status { get; set; }
            public int? priority { get; set; }
            public long? due_date { get; set; }
            public bool due_date_time { get; set; }
            public int? time_estimate { get; set; }
            public long? start_date { get; set; }
            public bool start_date_time { get; set; }
            public bool notify_all { get; set; }
            public object parent { get; set; }
            public object links_to { get; set; }
            public bool check_required_custom_fields { get; set; }
            public List<CustomField> custom_fields { get; set; }
            public Task()
            {
                custom_fields = new List<CustomField>();
            }
            public Task(string name)
            {
                this.name = name;
                custom_fields = new List<CustomField>();
            }
            public void AddCustomFields(params CustomField[] customFields)
            {
                custom_fields.AddRange(customFields.ToList());
            }
        }
    }
}
