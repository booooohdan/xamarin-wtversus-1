using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace WarThunderComparer.comparerData.Collections
{
    class ShipTaskCollection
    {
        public static List<Task> GetTask()
        {
            Context context = Application.Context;

            List<Task> tasks = new List<Task>();
            Task task = null;

            task = new Task();
            task.Id = 1;
            task.Name = context.Resources.GetString(Resource.String.ShipTask1);
            tasks.Add(task);

            task = new Task();
            task.Id = 2;
            task.Name = context.Resources.GetString(Resource.String.ShipTask2);
            tasks.Add(task);

            task = new Task();
            task.Id = 3;
            task.Name = context.Resources.GetString(Resource.String.ShipTask3);
            tasks.Add(task);

            task = new Task();
            task.Id = 4;
            task.Name = context.Resources.GetString(Resource.String.ShipTask4);
            tasks.Add(task);

            task = new Task();
            task.Id = 5;
            task.Name = context.Resources.GetString(Resource.String.ShipTask5);
            tasks.Add(task);

            task = new Task();
            task.Id = 6;
            task.Name = context.Resources.GetString(Resource.String.ShipTask6);
            tasks.Add(task);

            task = new Task();
            task.Id = 7;
            task.Name = context.Resources.GetString(Resource.String.ShipTask7);
            tasks.Add(task);

            return tasks;
        }
    }
}