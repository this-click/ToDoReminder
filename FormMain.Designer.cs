namespace ToDoReminder
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            mnsFile = new MenuStrip();
            menuFile = new ToolStripMenuItem();
            menuFileNew = new ToolStripMenuItem();
            menuFileOpen = new ToolStripMenuItem();
            menuFileSave = new ToolStripMenuItem();
            menuFileExit = new ToolStripMenuItem();
            menuHelp = new ToolStripMenuItem();
            menuHelpAbout = new ToolStripMenuItem();
            lblDateTime = new Label();
            dateTimePicker = new DateTimePicker();
            lblPriority = new Label();
            cbPriority = new ComboBox();
            txtTask = new TextBox();
            lblTodo = new Label();
            btnAdd = new Button();
            grpList = new GroupBox();
            lblDescp = new Label();
            lblPrio = new Label();
            lblHour = new Label();
            lblDate = new Label();
            lstTasks = new ListBox();
            btnEdit = new Button();
            btnDel = new Button();
            toolTip1 = new ToolTip(components);
            clockTimer = new System.Windows.Forms.Timer(components);
            lblClock = new Label();
            btnCancel = new Button();
            btnSave = new Button();
            mnsFile.SuspendLayout();
            grpList.SuspendLayout();
            SuspendLayout();
            // 
            // mnsFile
            // 
            mnsFile.Items.AddRange(new ToolStripItem[] { menuFile, menuHelp });
            mnsFile.Location = new Point(0, 0);
            mnsFile.Name = "mnsFile";
            mnsFile.Size = new Size(944, 24);
            mnsFile.TabIndex = 0;
            mnsFile.Text = "menuStrip1";
            // 
            // menuFile
            // 
            menuFile.DropDownItems.AddRange(new ToolStripItem[] { menuFileNew, menuFileOpen, menuFileSave, menuFileExit });
            menuFile.Name = "menuFile";
            menuFile.Size = new Size(37, 20);
            menuFile.Text = "File";
            // 
            // menuFileNew
            // 
            menuFileNew.Name = "menuFileNew";
            menuFileNew.Size = new Size(148, 22);
            menuFileNew.Text = "New    Ctrl+N";
            menuFileNew.Click += menuFileNew_Click;
            // 
            // menuFileOpen
            // 
            menuFileOpen.Name = "menuFileOpen";
            menuFileOpen.Size = new Size(148, 22);
            menuFileOpen.Text = "Open data file";
            menuFileOpen.Click += menuFileOpen_Click;
            // 
            // menuFileSave
            // 
            menuFileSave.Name = "menuFileSave";
            menuFileSave.Size = new Size(148, 22);
            menuFileSave.Text = "Save data file";
            menuFileSave.Click += menuFileSave_Click;
            // 
            // menuFileExit
            // 
            menuFileExit.Name = "menuFileExit";
            menuFileExit.Size = new Size(148, 22);
            menuFileExit.Text = "Exit   Alt+F4";
            menuFileExit.Click += menuFileExit_Click;
            // 
            // menuHelp
            // 
            menuHelp.DropDownItems.AddRange(new ToolStripItem[] { menuHelpAbout });
            menuHelp.Name = "menuHelp";
            menuHelp.Size = new Size(44, 20);
            menuHelp.Text = "Help";
            // 
            // menuHelpAbout
            // 
            menuHelpAbout.Name = "menuHelpAbout";
            menuHelpAbout.Size = new Size(116, 22);
            menuHelpAbout.Text = "About...";
            menuHelpAbout.Click += menuHelpAbout_Click;
            // 
            // lblDateTime
            // 
            lblDateTime.AutoSize = true;
            lblDateTime.Location = new Point(12, 47);
            lblDateTime.Name = "lblDateTime";
            lblDateTime.Size = new Size(81, 15);
            lblDateTime.TabIndex = 1;
            lblDateTime.Text = "Date and time";
            // 
            // dateTimePicker
            // 
            dateTimePicker.Font = new Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateTimePicker.Location = new Point(117, 41);
            dateTimePicker.Name = "dateTimePicker";
            dateTimePicker.Size = new Size(156, 21);
            dateTimePicker.TabIndex = 2;
            dateTimePicker.Value = new DateTime(2024, 4, 26, 15, 26, 36, 0);
            // 
            // lblPriority
            // 
            lblPriority.AutoSize = true;
            lblPriority.Location = new Point(428, 42);
            lblPriority.Name = "lblPriority";
            lblPriority.Size = new Size(45, 15);
            lblPriority.TabIndex = 3;
            lblPriority.Text = "Priority";
            // 
            // cbPriority
            // 
            cbPriority.DropDownStyle = ComboBoxStyle.DropDownList;
            cbPriority.Font = new Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbPriority.FormattingEnabled = true;
            cbPriority.Location = new Point(503, 39);
            cbPriority.Name = "cbPriority";
            cbPriority.Size = new Size(130, 23);
            cbPriority.TabIndex = 4;
            // 
            // txtTask
            // 
            txtTask.Font = new Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTask.Location = new Point(117, 93);
            txtTask.Name = "txtTask";
            txtTask.Size = new Size(516, 21);
            txtTask.TabIndex = 5;
            // 
            // lblTodo
            // 
            lblTodo.AutoSize = true;
            lblTodo.Location = new Point(12, 96);
            lblTodo.Name = "lblTodo";
            lblTodo.Size = new Size(36, 15);
            lblTodo.TabIndex = 6;
            lblTodo.Text = "To do";
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(332, 133);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 7;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // grpList
            // 
            grpList.Controls.Add(lblDescp);
            grpList.Controls.Add(lblPrio);
            grpList.Controls.Add(lblHour);
            grpList.Controls.Add(lblDate);
            grpList.Controls.Add(lstTasks);
            grpList.ForeColor = Color.Green;
            grpList.Location = new Point(12, 162);
            grpList.Name = "grpList";
            grpList.Size = new Size(920, 392);
            grpList.TabIndex = 8;
            grpList.TabStop = false;
            grpList.Text = "To Do";
            // 
            // lblDescp
            // 
            lblDescp.AutoSize = true;
            lblDescp.ForeColor = Color.Black;
            lblDescp.Location = new Point(444, 19);
            lblDescp.Name = "lblDescp";
            lblDescp.Size = new Size(67, 15);
            lblDescp.TabIndex = 4;
            lblDescp.Text = "Description";
            // 
            // lblPrio
            // 
            lblPrio.AutoSize = true;
            lblPrio.ForeColor = Color.Black;
            lblPrio.Location = new Point(314, 19);
            lblPrio.Name = "lblPrio";
            lblPrio.Size = new Size(45, 15);
            lblPrio.TabIndex = 3;
            lblPrio.Text = "Priority";
            // 
            // lblHour
            // 
            lblHour.AutoSize = true;
            lblHour.ForeColor = Color.Black;
            lblHour.Location = new Point(221, 19);
            lblHour.Name = "lblHour";
            lblHour.Size = new Size(34, 15);
            lblHour.TabIndex = 2;
            lblHour.Text = "Hour";
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.ForeColor = Color.Black;
            lblDate.Location = new Point(6, 19);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(31, 15);
            lblDate.TabIndex = 1;
            lblDate.Text = "Date";
            // 
            // lstTasks
            // 
            lstTasks.Font = new Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lstTasks.FormattingEnabled = true;
            lstTasks.ItemHeight = 15;
            lstTasks.Location = new Point(6, 41);
            lstTasks.Name = "lstTasks";
            lstTasks.Size = new Size(906, 319);
            lstTasks.TabIndex = 0;
            lstTasks.SelectedIndexChanged += lstTasks_SelectedIndexChanged;
            // 
            // btnEdit
            // 
            btnEdit.Enabled = false;
            btnEdit.Location = new Point(299, 570);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(75, 23);
            btnEdit.TabIndex = 9;
            btnEdit.Text = "Change";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDel
            // 
            btnDel.Enabled = false;
            btnDel.Location = new Point(406, 570);
            btnDel.Name = "btnDel";
            btnDel.Size = new Size(75, 23);
            btnDel.TabIndex = 10;
            btnDel.Text = "Delete";
            btnDel.UseVisualStyleBackColor = true;
            btnDel.Click += btnDel_Click;
            // 
            // clockTimer
            // 
            clockTimer.Enabled = true;
            clockTimer.Interval = 1000;
            clockTimer.Tick += clockTimer_Tick;
            // 
            // lblClock
            // 
            lblClock.AutoSize = true;
            lblClock.Location = new Point(856, 574);
            lblClock.Name = "lblClock";
            lblClock.Size = new Size(59, 15);
            lblClock.TabIndex = 11;
            lblClock.Text = "hh:mm:ss";
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(428, 133);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 12;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Visible = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(236, 133);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 13;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(944, 605);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            Controls.Add(lblClock);
            Controls.Add(btnDel);
            Controls.Add(btnEdit);
            Controls.Add(grpList);
            Controls.Add(btnAdd);
            Controls.Add(lblTodo);
            Controls.Add(txtTask);
            Controls.Add(cbPriority);
            Controls.Add(lblPriority);
            Controls.Add(dateTimePicker);
            Controls.Add(lblDateTime);
            Controls.Add(mnsFile);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MainMenuStrip = mnsFile;
            MaximizeBox = false;
            Name = "FormMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ToDo Reminder by Ramona";
            toolTip1.SetToolTip(this, "Click to open calendar");
            mnsFile.ResumeLayout(false);
            mnsFile.PerformLayout();
            grpList.ResumeLayout(false);
            grpList.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip mnsFile;
        private ToolStripMenuItem menuFile;
        private ToolStripMenuItem menuFileNew;
        private ToolStripMenuItem menuFileOpen;
        private ToolStripMenuItem menuFileSave;
        private ToolStripMenuItem menuFileExit;
        private ToolStripMenuItem menuHelp;
        private Label lblDateTime;
        private DateTimePicker dateTimePicker;
        private Label lblPriority;
        private ComboBox cbPriority;
        private TextBox txtTask;
        private Label lblTodo;
        private Button btnAdd;
        private GroupBox grpList;
        private Label lblDate;
        private ListBox lstTasks;
        private Label lblDescp;
        private Label lblPrio;
        private Label lblHour;
        private Button btnEdit;
        private Button btnDel;
        private ToolTip toolTip1;
        private System.Windows.Forms.Timer clockTimer;
        private ToolStripMenuItem menuHelpAbout;
        private Label lblClock;
        private Button btnCancel;
        private Button btnSave;
    }
}
