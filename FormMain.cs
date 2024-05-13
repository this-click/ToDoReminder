namespace ToDoReminder
{
    public partial class FormMain : Form
    {
        private TaskManager? _taskManager;
        private string _fileName = Application.StartupPath + "\\Tasks.txt";

        public FormMain()
        {
            InitializeComponent();
            InitializeGUI();
        }

        /// <summary>
        /// Reset the UI when adding a new task
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuFileNew_Click(object sender, EventArgs e)
        {
            InitializeGUI();
        }

        /// <summary>
        /// Read tasks from file when user clicks on File > Open
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuFileOpen_Click(object sender, EventArgs e)
        {
            string errorMessage = "Something went wrong while reading data from file";

            bool okReadFile = false;
            if (_taskManager != null)
                okReadFile = _taskManager.ReadDataFromFile(_fileName);
            if (!okReadFile)
                MessageBox.Show(errorMessage);
            else
                UpdateListBoxGUI();
        }

        /// <summary>
        /// Write tasks to file when user clicks on File > Save
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuFileSave_Click(object sender, EventArgs e)
        {
            string errorMessage = "Something went wrong while saving data to file";

            bool okWriteToFile = false;
            if (_taskManager != null)
                okWriteToFile = _taskManager.WriteDataToFile(_fileName, out errorMessage);
            if (!okWriteToFile)
                MessageBox.Show(errorMessage);
            else
                MessageBox.Show("Data saved to file: " + Environment.NewLine + _fileName);
        }

        /// <summary>
        /// Handle exit menu item: close the app on confirmation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuFileExit_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("Are you sure you want to exit?", "Think twice", MessageBoxButtons.OKCancel);
            if (DialogResult == DialogResult.OK)
                Application.Exit();
        }

        /// <summary>
        /// Display app description when user clicks on Help > About
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuHelpAbout_Click(object sender, EventArgs e)
        {
            AboutBox aboutBox = new AboutBox();
            aboutBox.ShowDialog();
        }

        /// <summary>
        /// Display clock in bottom right corner
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clockTimer_Tick(object sender, EventArgs e)
        {
            lblClock.Text = DateTime.Now.ToLongTimeString();
        }

        /// <summary>
        /// Add new task when user clicks on Add button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Task? task = ReadInput();

            bool okTask = false;
            if (_taskManager != null)
                okTask = _taskManager.AddNewTask(task);

            if (okTask)
                UpdateListBoxGUI();
        }

        /// <summary>
        /// Edit an existing task when user clicks on Change button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lstTasks.SelectedItem != null)
            {
                // Make Save and Cancel buttons visible. Disable Add button
                btnCancel.Visible = true;
                btnSave.Visible = true;
                btnAdd.Enabled = false;
                // Change FormMain title to emphasize edit mode
                Text += " -- edit";

                int index = lstTasks.SelectedIndex;
                if (_taskManager != null && index >= 0)
                {
                    Task? task = _taskManager.GetTaskAt(index);
                    if (task != null)
                        RepopulateMainFormInputs(task);
                }
            }
        }

        /// <summary>
        /// Update the UI when user edits a task and saves the changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (lstTasks.SelectedItem != null)
            {
                int index = lstTasks.SelectedIndex;
                Task? newTask = ReadInput();

                bool okNewTask = false;
                if (_taskManager != null)
                    okNewTask = _taskManager.EditTask(newTask, index);

                if (okNewTask)
                {
                    PartialInitializeGUI();
                    //Deselects listbox item selection
                    lstTasks.ClearSelected();
                    UpdateListBoxGUI();
                }
            }
        }

        /// <summary>
        /// Revert changes to a task
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            PartialInitializeGUI();
            //Deselects listbox item selection
            lstTasks.ClearSelected();
        }

        /// <summary>
        /// Delete a task when user clicks on Delete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDel_Click(object sender, EventArgs e)
        {
            if (lstTasks.SelectedItem != null)
            {
                int index = lstTasks.SelectedIndex;
                //Ask for confirmation
                DialogResult = MessageBox.Show("Are you sure you want to delete this item?", "Think twice", MessageBoxButtons.OKCancel);
                if (DialogResult == DialogResult.OK)
                {
                    if (_taskManager != null)
                    {
                        bool okDelete = _taskManager.DeleteTask(index);
                        if (okDelete)
                        {
                            {
                                UpdateListBoxGUI();
                                PartialInitializeGUI();
                                //Deselects listbox item selection
                                lstTasks.ClearSelected();
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Enable buttons Change and Delete when user selects an item in the list box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstTasks_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnEdit.Enabled = true;
            btnDel.Enabled = true;
        }

        /// <summary>
        /// Reset UI to default values
        /// </summary>
        private void InitializeGUI()
        {
            _taskManager = new TaskManager();
            lstTasks.Items.Clear();

            // Initialize combobox
            cbPriority.Items.Clear();
            cbPriority.Items.AddRange(Enum.GetNames(typeof(PriorityType)));

            lblClock.Text = string.Empty;
            clockTimer.Start();

            dateTimePicker.Format = DateTimePickerFormat.Custom;
            dateTimePicker.CustomFormat = "yyyy-MM-dd  HH:mm";

            // Setup the tooltips
            toolTip1.ShowAlways = true;
            toolTip1.SetToolTip(dateTimePicker, "Click to open calendar for date, write time here.");
            toolTip1.SetToolTip(cbPriority, "Select the priority");

            string tips = "To change, select an item first" + Environment.NewLine;
            tips += "Make your changes in the input controls, " + Environment.NewLine;
            tips += "Click the Change button." + Environment.NewLine;

            toolTip1.SetToolTip(lstTasks, tips);
            toolTip1.SetToolTip(btnEdit, tips);

            string deleteTips = "Select an item first and then click this button!";
            toolTip1.SetToolTip(btnDel, deleteTips);

            string descriptionTips = "Write your secrets here";
            toolTip1.SetToolTip(txtTask, descriptionTips);

            menuFileOpen.Enabled = true;
            menuFileSave.Enabled = true;
            menuHelpAbout.Enabled = true;

            PartialInitializeGUI();

        }

        /// <summary>
        /// Reset UI to default values, except the list box
        /// </summary>
        private void PartialInitializeGUI()
        {
            btnDel.Enabled = false;
            btnEdit.Enabled = false;
            btnSave.Visible = false;
            btnCancel.Visible = false;
            btnAdd.Enabled = true;

            // Change FormMain title to the original text
            Text = "ToDo Reminder by Ramona";

            //Reinitialize task data
            cbPriority.SelectedIndex = (int)PriorityType.Normal;
            txtTask.Text = string.Empty;
            dateTimePicker.Value = DateTime.Now;
        }

        /// <summary>
        /// Read data from user
        /// </summary>
        /// <returns>task or null</returns>
        private Task? ReadInput()
        {
            string description;

            DateTime date = ReadDate();
            PriorityType priority = ReadPriority();
            bool okDescription = ReadDescription(out description);

            //If description valid (priority and date have default values in case of error), then create a new task object
            if (okDescription)
                return new Task(date, description, priority);
            else
                return null;
        }

        /// <summary>
        /// Read description
        /// </summary>
        /// <param name="description"></param>
        /// <returns></returns>
        private bool ReadDescription(out string description)
        {
            description = txtTask.Text;
            if (!string.IsNullOrEmpty(description))
                return true;
            else
            {
                MessageBox.Show("Please enter a description for the task");
                return false;
            }
        }

        /// <summary>
        /// Read date
        /// </summary>
        /// <returns>set date if valid, current date otherwise</returns>
        private DateTime ReadDate()
        {
            DateTime date = dateTimePicker.Value;
            if (date < DateTime.MinValue || date > DateTime.MaxValue)
                date = DateTime.Now;
            return date;
        }

        /// <summary>
        /// Read priority
        /// </summary>
        /// <returns>selected priority if valid, Normal otherwise</returns>
        private PriorityType ReadPriority()
        {
            PriorityType priority;
            int selectedIndex = cbPriority.SelectedIndex;
            if (selectedIndex >= 0)
                priority = (PriorityType)cbPriority.SelectedIndex;
            else
                priority = PriorityType.Normal;
            return priority;
        }

        /// <summary>
        /// Display tasks in GUI
        /// </summary>
        private void UpdateListBoxGUI()
        {
            lstTasks.Items.Clear();
            if (_taskManager != null)
            {
                string[] infoStrings = _taskManager.GetTasksToStringList();
                if (infoStrings != null)
                    lstTasks.Items.AddRange(infoStrings);
            }
        }

        private void RepopulateMainFormInputs(Task task)
        {
            // Get previous task data
            DateTime date = task.CompletionDate;
            PriorityType priority = task.Priority;
            string description = task.Description;

            // Set the previous task data in input fields for editing
            txtTask.Text = description;
            cbPriority.Text = priority.ToString();
            dateTimePicker.Value = date;
        }
    }
}
