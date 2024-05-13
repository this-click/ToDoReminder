namespace ToDoReminder
{
    /// <summary>
    /// Conatiner class which is responsible for CRUD operations on tasks
    /// </summary>
    public class TaskManager
    {
        private readonly List<Task>? tasks;

        public TaskManager()
        {
            tasks = new List<Task>();
        }

        /// <summary>
        /// Add a new object at the end of the task list
        /// </summary>
        /// <param name="newTask">the task obj to be added</param>
        /// <returns>true if task added successfully, false otherwise</returns>
        internal bool AddNewTask(Task? newTask)
        {
            bool okTask = true;

            if (newTask != null && tasks != null)
                tasks.Add(newTask);
            else
                okTask = false;
            return okTask;
        }

        /// <summary>
        /// Edit a task object in the task list
        /// </summary>
        /// <param name="newTask">the obj with the new values from user</param>
        /// <param name="index">object's position in the list</param>
        /// <returns>true if edit was successful, false otherwise</returns>
        internal bool EditTask(Task? newTask, int index)
        {
            bool okTask = true;

            if (newTask != null && tasks != null && CheckIndex(index))
                tasks[index] = newTask;
            else
                okTask = false;
            return okTask;
        }

        /// <summary>
        /// Delete a task object from the task list
        /// </summary>
        /// <param name="index">object's position in the list</param>
        /// <returns>true if delete was successful, false otherwise</returns>
        internal bool DeleteTask(int index)
        {
            bool okTask = true;

            if (tasks != null && CheckIndex(index))
                tasks.RemoveAt(index);
            else
                okTask = false;
            return okTask;
        }

        /// <summary>
        /// Gets all the tasks in an array of strings format, to be displayed in the listbox
        /// </summary>
        /// <returns></returns>
        internal string[] GetTasksToStringList()
        {
            string[] infoStrings;

            if (tasks != null)
            {
                infoStrings = new string[tasks.Count];
                for (int i = 0; i < infoStrings.Length; i++)
                {
                    if (tasks[i] != null)
                        infoStrings[i] = tasks[i].ToString() ?? string.Empty;
                }
            }
            else
                infoStrings = [];

            return infoStrings;
        }

        /// <summary>
        /// Saves the tasks to file
        /// </summary>
        /// <param name="fileName">which file to save in</param>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        internal bool WriteDataToFile(string fileName, out string errorMessage)
        {
            errorMessage = string.Empty;
            FileManager fileManager = new FileManager();
            if (tasks != null)
            {
                if (tasks.Count > 0)
                {
                    return fileManager.SaveTaskListToFile(tasks, fileName);
                }
                else
                {
                    errorMessage = "Please enter data before saving";
                    return false;
                }
            }
            else
                return false;
        }

        /// <summary>
        /// Read the tasks from file
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        internal bool ReadDataFromFile(string fileName)
        {
            if (tasks != null)
            {
                FileManager fileManager = new FileManager();
                return fileManager.ReadTaskListFromFile(tasks, fileName);
            }
            else return false;
        }

        /// <summary>
        /// Get a task at index
        /// </summary>
        /// <param name="index">position in list</param>
        /// <returns></returns>
        internal Task? GetTaskAt(int index)
        {
            if (tasks != null)
                return tasks[index];
            else return null;
        }

        /// <summary>
        /// Chack index is valid
        /// </summary>
        /// <param name="index"></param>
        /// <returns>true if index valid</returns>
        public bool CheckIndex(int index)
        {
            if (tasks != null)
                return (index >= 0) && (index < tasks.Count);
            else return false;
        }
    }
}