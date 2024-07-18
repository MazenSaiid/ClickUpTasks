using ClassLibrary.ClickUp.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibary
{
    public class ClickUpConvert
    {
        public static CustomField GetCustomField(CU_Task task, string fieldId)
        {
            return task.custom_fields.Single(c => c.id == fieldId);
        }
        public static string GetCFValue(CustomField customField)
        {
            var value = customField.value != null ? customField.value.ToString() : null;
            return value;
        }

        public static string GetDDItemId(CustomField dropDown)
        {
            if (dropDown.value != null)             
            return dropDown.type_config.options.SingleOrDefault(o => o.orderindex == int.Parse(dropDown.value.ToString())).id;

            else return null;
        }

        public static DateTime? MilisecondsToDate(string miliseconds)
        {
            DateTime? date = miliseconds != null ? (DateTime?)DateTimeOffset.FromUnixTimeMilliseconds(long.Parse(miliseconds)).LocalDateTime : null;
            return date;
        }

        public static List<CustomFieldRelation> ConvertToRelation(CustomField customField)
        {
            if (customField.value == null)
                return null;
            return JsonConvert.DeserializeObject<CustomFieldRelation[]>(customField.value.ToString()).ToList();
        }
        public static Option GetDDItemByMame(CustomField customField, string name)
        {
            var option = customField.type_config.options.Where(o => o.name.Trim().ToLower() == name.Trim().ToLower()).FirstOrDefault();
            if (option != null)
                return option;
            else
                return null;
        }
        public static Option GetDDItemByIndex(CustomField customField)
        {
            if (customField.value != null)
            {
                var option = customField.type_config.options.Where(o => o.orderindex == int.Parse(customField.value.ToString())).FirstOrDefault();
                if (option != null)
                    return option;
                else return null;
            }
            else
                return null;
        }
        public static string CustomFieldFilter(string fieldId, string op, object value)
        {
            var t = value.GetType();
            var val = value.ToString();

            if (value.GetType().Name == "String")
                val = "\"" + value.ToString() + "\"";
            else if (value.GetType() == typeof(long[]))
                val = "[" + String.Join(",", new List<long>((long[])value).ConvertAll(i => i.ToString()).ToArray()) + "]";
            ;

            var filter = "{\"field_id\":\"" + fieldId +  "\",\"operator\":\""+ op +"\",\"value\":"+ val +"}";
            return filter;
        }

        public static List<Option> GetLabelsByIds(CustomField customField)
        {
            var options = new List<Option>();
            if (customField.value != null)
            {
                var values = JsonConvert.DeserializeObject<string[]>(customField.value.ToString()).ToList();
                foreach (var v in values)
                {
                    options.Add(customField.type_config.options.SingleOrDefault(o => o.id == v));
                }
                if (options != null)
                    return options;
                else return null;
            }
            else
                return null;
        }
    }
}
