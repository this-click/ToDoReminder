namespace ToDoReminder
{
    /// <summary>
    /// Class that handles file IO operations
    /// </summary>
    internal class FileManager
    {
        //Write this token to ensure correct file opened and it's the one saved by the application
        private const string fileToken = "ToDoRe_21";
        private const double fileVersion = 1.0;

        /// <summary>
        /// Parse taskList and save the tasks into file
        /// </summary>
        /// <param name="taskList">holds the tasks</param>
        /// <param name="fileName">where to save</param>
        /// <returns>true if parse was successful, false otherwise</returns>
        public bool SaveTaskListToFile(List<Task> taskList, string fileName)
        {
            bool ok = true;
            StreamWriter writer = null;

            try
            {
                writer = new StreamWriter(fileName);
                writer.WriteLine(fileToken);
                writer.WriteLine(fileVersion);
                writer.WriteLine(taskList.Count);

                for (int i = 0; i < taskList.Count; i++)
                {
                    writer.WriteLine(taskList[i].Description);
                    writer.WriteLine(taskList[i].Priority.ToString());
                    writer.WriteLine(taskList[i].CompletionDate.Year);
                    writer.WriteLine(taskList[i].CompletionDate.Month);
                    writer.WriteLine(taskList[i].CompletionDate.Day);
                    writer.WriteLine(taskList[i].CompletionDate.Hour);
                    writer.WriteLine(taskList[i].CompletionDate.Minute);
                    writer.WriteLine(taskList[i].CompletionDate.Second);
                }
            }
            catch
            {
                ok = false;
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
            return ok;
        }

        /// <summary>
        /// Populate App GUI with task data from file
        /// </summary>
        /// <param name="taskList">the list of tasks to be read from file and displayed in the App</param>
        /// <param name="fileName">the file which holds the tasks</param>
        /// <returns>>true if read was successful, false otherwise</returns>
        public bool ReadTaskListFromFile(List<Task> taskList, string fileName)
        {
            bool ok = true;
            StreamReader reader = null;

            try
            {
                //Make sure task list is empty
                if (taskList != null)
                    taskList.Clear();
                else
                    taskList = new List<Task>();

                reader = new StreamReader(fileName);
                //Ensure that file token matches
                string tokenTest = reader.ReadLine();
                //Ensure that file version number matches
                double versionTest = double.Parse(reader.ReadLine());

                if ((tokenTest == fileToken) && (versionTest == fileVersion)) // correct file
                {
                    //Read num of tasks
                    int count = int.Parse(reader.ReadLine());

                    //for each task, create a task obj and save it in the taskList
                    for (int i = 0; i < count; i++)
                    {
                        Task task = new Task();
                        task.Description = reader.ReadLine();
                        task.Priority = (PriorityType)Enum.Parse(typeof(PriorityType), reader.ReadLine());

                        //date values are read only
                        int year = 0, month = 0, day = 0;
                        int hour = 0, minute = 0, second = 0;

                        year = int.Parse(reader.ReadLine());
                        month = int.Parse(reader.ReadLine());
                        day = int.Parse(reader.ReadLine());
                        hour = int.Parse(reader.ReadLine());
                        minute = int.Parse(reader.ReadLine());
                        second = int.Parse(reader.ReadLine());

                        task.CompletionDate = new DateTime(year, month, day, hour, minute, second);
                        taskList.Add(task);
                    }
                }
                else
                    ok = false;
            }
            catch
            {
                ok = false;
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
            return ok;
        }
    }
}
