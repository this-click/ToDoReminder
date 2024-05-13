namespace ToDoReminder
{
    /// <summary>
    /// Class which holds the model for a task
    /// </summary>
    internal class Task
    {
        private DateTime _completionDate;
        private string _description;
        private PriorityType _priority;

        /// <summary>
        /// Default constructor
        /// </summary>
        public Task() : this(default, string.Empty, PriorityType.Normal)
        {
            // Set default priority
            _priority = PriorityType.Normal;
        }

        /// <summary>
        /// Constructor with 1 param
        /// </summary>
        /// <param name="completionDate"></param>
        public Task(DateTime completionDate) : this(completionDate, string.Empty, PriorityType.Normal)
        {
            _completionDate = completionDate;
        }

        /// <summary>
        /// Constructor with 2 parameters
        /// </summary>
        /// <param name="completionDate"></param>
        /// <param name="description"></param>
        public Task(DateTime completionDate, string description) : this(completionDate, description, PriorityType.Normal)
        {
            _description = description;
            _completionDate = completionDate;
        }

        /// <summary>
        /// Constructor with 3 parameters
        /// </summary>
        /// <param name="completionDate"></param>
        /// <param name="description"></param>
        /// <param name="priority"></param>
        public Task(DateTime completionDate, string description, PriorityType priority)
        {
            _completionDate = completionDate;
            _description = description;
            _priority = priority;
        }

        /// <summary>
        /// Property for task creation date
        /// </summary>
        public DateTime CompletionDate
        {
            get { return _completionDate; }
            set { _completionDate = value; }
        }

        /// <summary>
        /// Property for task description
        /// </summary>
        public string Description
        {
            get { return _description; }
            set
            {
                if (string.IsNullOrEmpty(_description))
                    _description = value;
            }
        }

        /// <summary>
        /// Property for task priority
        /// </summary>
        public PriorityType Priority
        {
            get { return _priority; }
            set { _priority = value; }
        }

        /// <summary>
        /// Returns a string composed of the name of the priority, replacing the _ character with a blank space
        /// </summary>
        /// <returns></returns>
        public string GetPriorityString()
        {
            string prio = _priority.ToString();
            return prio.Replace("_", " ");
        }

        /// <summary>
        /// Returns a string containing the time saved in date field, formatted as hh:mm
        /// </summary>
        /// <returns></returns>
        public string GetTimeString()
        {
            string hour = _completionDate.Hour.ToString();
            string minute = _completionDate.Minute.ToString();
            return hour + ":" + minute;
        }

        /// <summary>
        /// Pretty print a task object
        /// </summary>
        /// <returns>the text to be displayed in the list box</returns>
        public override string? ToString()
        {
            const int dateMaxLen = 28;
            const int prioMaxLen = 14;
            int dateFillerLen = dateMaxLen - _completionDate.ToLongDateString().Length;
            int prioFillerLen = prioMaxLen - GetPriorityString().Length;

            string textOut = $"{_completionDate.ToLongDateString()} {new string(' ', dateFillerLen)} {GetTimeString()} {new string(' ', 5)}" +
                $"{GetPriorityString()} {new string(' ', prioFillerLen + 5)} {Description}";
            return textOut;
        }
    }
}
