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
    class TankTaskCollection
    {
        public static List<Task> GetTankTask()
        {
            Context context = Application.Context;

            List<Task> tankTasks = new List<Task>();
            Task task = null;

            task = new Task();
            task.Id = 1;
            task.Name = context.Resources.GetString(Resource.String.TankTask1);
            tankTasks.Add(task);

            task = new Task();
            task.Id = 2;
            task.Name = context.Resources.GetString(Resource.String.TankTask2);
            tankTasks.Add(task);

            task = new Task();
            task.Id = 3;
            task.Name = context.Resources.GetString(Resource.String.TankTask3);
            tankTasks.Add(task);

            task = new Task();
            task.Id = 4;
            task.Name = context.Resources.GetString(Resource.String.TankTask4);
            tankTasks.Add(task);


            task = new Task();
            task.Id = 5;
            task.Name = context.Resources.GetString(Resource.String.TankTask5);
            tankTasks.Add(task);

            task = new Task();
            task.Id = 6;
            task.Name = context.Resources.GetString(Resource.String.TankTask6);
            tankTasks.Add(task);

            task = new Task();
            task.Id = 7;
            task.Name = context.Resources.GetString(Resource.String.TankTask7);
            tankTasks.Add(task);


            return tankTasks;

        }
    }
}
