using ClassLibary.ClickUp.Webhook;
using ClassLibrary.ClickUp.DTO;
using ClassLibrary.ClickUp.Functions;
using ClassLibrary.ErrorHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.HCSChampian
{
    public static class Monthly
    {
        static CU_Functions functions = new CU_Functions("pk_38316688_2CS2WFRS6JYO8E12AVRPTJMPT5CRHIUF");

        public static void CreateMonthlyHCBSTask(CU_Task task)
        {
            try
            {
                //get the assignee
                var assignee = functions.GetUser(task.custom_fields, "6cb1ed12-f3ee-46dc-90dd-ad871662efab");

                //get the current month in full name
                var currentMonth = DateTime.Now.ToString("MMMM");

                //get the current year
                var currentYear = DateTime.Now.Year;

                //get the task name
                var taskName = task.name;

                //get the lest date from current month
                var lastDay = DateTime.DaysInMonth(currentYear, DateTime.Now.Month);

                //first day of next month
                var firstDayNextMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(1);

                
                //convert to mili seconeds current time zone
                var lastDayInMili = new DateTimeOffset(firstDayNextMonth).ToUnixTimeMilliseconds();

                //create new tasks in monthly tasks
                //set task name
                CreateTask.Task Newtask = new CreateTask.Task();
                Newtask.name = taskName + " - " + currentMonth + " " + currentYear;

                //get cooridnator assignee
                var user = functions.GetUser(task.custom_fields, "6cb1ed12-f3ee-46dc-90dd-ad871662efab");


                //Set Newtask.assignees 
                if (user != null)
                    Newtask.assignees = new List<int> { user.id };

                //set due date
                Newtask.due_date = lastDayInMili;

                //Create Task
                var createtask = functions.CreateTaskFromTemplate("901301495756", "t-86a247ddc", $"{{\"name\": \"{Newtask.name}\"}}");
                var bodyStrings = new List<string>();

                
                    if (assignee != null)
                    {
                        //add the assignee to the task
                        bodyStrings.Add("\"assignees\":{" + @"""add"":[" + assignee.id + @"]," + @"""rem"":[]}");
                    }
                    //set the due date to the last day of the month id miliseconds

                    bodyStrings.Add("\"due_date\":" + Newtask.due_date);

                
                var body = @"{";
                body += string.Join(",", bodyStrings);

                body += @"}";
                //update the task
                functions.UpdateTask(createtask.id, body);

                //Create array from link task
                string[] array = new string[] { task.id };


                //relate the task to main 
                functions.LinkTask(createtask.id, "36e6c1f5-9a06-42d0-9e35-53dab308e83f", array);
            }
            catch (Exception ex)
            {
                ErrorEmail.SendEmail("joseph@uptodateteam.com", $"Error while creating monthly HCBS tasks", $"Hello, \r\n I encountered an error while creating the monthly HCBS tasks. \r\n The error message is {ex.Message} \r\n Task ID: {task.id}", "joseph@beavercustomsoftware.com");
            }
        }
    }
}
