using System;

namespace AkkaDddSandbox.Core.Models
{
    public class TaskModel
    {
        public TaskModel(string status, DateTime dateTimeStatusSet)
        {
            Status = status;
            DateTimeStatusSet = dateTimeStatusSet;
        }

        public string Status { get; }
        public DateTime DateTimeStatusSet { get; }

        public TaskModel With(string status = null, DateTime? dateTimeStatusSet = null)
        {
            return new TaskModel(status ?? Status, dateTimeStatusSet ?? DateTimeStatusSet);
        }
    }
}