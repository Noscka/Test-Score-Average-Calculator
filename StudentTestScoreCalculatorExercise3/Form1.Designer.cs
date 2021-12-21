namespace StudenTestScoreCalculatorExercise3
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Control_Bar = new System.Windows.Forms.Panel();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.MinimisePictureBox = new System.Windows.Forms.PictureBox();
            this.ExitPictureBox = new System.Windows.Forms.PictureBox();
            this.InfoPanel = new System.Windows.Forms.Panel();
            this.InfoErrorLabel = new System.Windows.Forms.Label();
            this.ControlPanel = new System.Windows.Forms.Panel();
            this.Exportbutton = new System.Windows.Forms.Button();
            this.ImportButton = new System.Windows.Forms.Button();
            this.StudentGroupsButton = new System.Windows.Forms.Button();
            this.CalculateButton = new System.Windows.Forms.Button();
            this.StudentScoreDataGrid = new System.Windows.Forms.DataGridView();
            this.StudentNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentScoreColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExportSaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.CreateGroupMainPanel = new System.Windows.Forms.Panel();
            this.AddNewGroupLabel = new System.Windows.Forms.Label();
            this.NewGroupTextBox = new System.Windows.Forms.TextBox();
            this.CreateGroupPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.ImportBackGroundWorker = new System.ComponentModel.BackgroundWorker();
            this.ImportFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.Control_Bar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MinimisePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExitPictureBox)).BeginInit();
            this.InfoPanel.SuspendLayout();
            this.ControlPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StudentScoreDataGrid)).BeginInit();
            this.CreateGroupMainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Control_Bar
            // 
            this.Control_Bar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Control_Bar.Controls.Add(this.TitleLabel);
            this.Control_Bar.Controls.Add(this.MinimisePictureBox);
            this.Control_Bar.Controls.Add(this.ExitPictureBox);
            this.Control_Bar.Dock = System.Windows.Forms.DockStyle.Top;
            this.Control_Bar.Location = new System.Drawing.Point(0, 0);
            this.Control_Bar.Name = "Control_Bar";
            this.Control_Bar.Size = new System.Drawing.Size(1019, 32);
            this.Control_Bar.TabIndex = 2;
            this.Control_Bar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Control_Bar_MouseMove);
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.TitleLabel.Location = new System.Drawing.Point(6, 6);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(38, 20);
            this.TitleLabel.TabIndex = 4;
            this.TitleLabel.Text = "Title";
            this.TitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TitleLabel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TitleLabel_MouseMove);
            // 
            // MinimisePictureBox
            // 
            this.MinimisePictureBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.MinimisePictureBox.Image = global::StudenTestScoreCalculatorExercise3.Properties.Resources._;
            this.MinimisePictureBox.Location = new System.Drawing.Point(955, 0);
            this.MinimisePictureBox.Name = "MinimisePictureBox";
            this.MinimisePictureBox.Size = new System.Drawing.Size(32, 32);
            this.MinimisePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.MinimisePictureBox.TabIndex = 3;
            this.MinimisePictureBox.TabStop = false;
            this.MinimisePictureBox.Click += new System.EventHandler(this.MinimisePictureBox_Click);
            this.MinimisePictureBox.MouseLeave += new System.EventHandler(this.MinimisePictureBox_MouseLeave);
            this.MinimisePictureBox.MouseHover += new System.EventHandler(this.MinimisePictureBox_MouseHover);
            // 
            // ExitPictureBox
            // 
            this.ExitPictureBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.ExitPictureBox.Image = global::StudenTestScoreCalculatorExercise3.Properties.Resources.x;
            this.ExitPictureBox.Location = new System.Drawing.Point(987, 0);
            this.ExitPictureBox.Name = "ExitPictureBox";
            this.ExitPictureBox.Size = new System.Drawing.Size(32, 32);
            this.ExitPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.ExitPictureBox.TabIndex = 3;
            this.ExitPictureBox.TabStop = false;
            this.ExitPictureBox.Click += new System.EventHandler(this.ExitBox_Click);
            this.ExitPictureBox.MouseLeave += new System.EventHandler(this.ExitBox_MouseLeave);
            this.ExitPictureBox.MouseHover += new System.EventHandler(this.ExitBox_MouseHover);
            // 
            // InfoPanel
            // 
            this.InfoPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.InfoPanel.Controls.Add(this.InfoErrorLabel);
            this.InfoPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.InfoPanel.Location = new System.Drawing.Point(200, 532);
            this.InfoPanel.Name = "InfoPanel";
            this.InfoPanel.Size = new System.Drawing.Size(819, 100);
            this.InfoPanel.TabIndex = 9;
            // 
            // InfoErrorLabel
            // 
            this.InfoErrorLabel.AutoSize = true;
            this.InfoErrorLabel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.InfoErrorLabel.Location = new System.Drawing.Point(10, 15);
            this.InfoErrorLabel.Name = "InfoErrorLabel";
            this.InfoErrorLabel.Size = new System.Drawing.Size(37, 20);
            this.InfoErrorLabel.TabIndex = 0;
            this.InfoErrorLabel.Text = "Info";
            this.InfoErrorLabel.Visible = false;
            // 
            // ControlPanel
            // 
            this.ControlPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.ControlPanel.Controls.Add(this.Exportbutton);
            this.ControlPanel.Controls.Add(this.ImportButton);
            this.ControlPanel.Controls.Add(this.StudentGroupsButton);
            this.ControlPanel.Controls.Add(this.CalculateButton);
            this.ControlPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.ControlPanel.Location = new System.Drawing.Point(0, 32);
            this.ControlPanel.Name = "ControlPanel";
            this.ControlPanel.Size = new System.Drawing.Size(200, 600);
            this.ControlPanel.TabIndex = 8;
            // 
            // Exportbutton
            // 
            this.Exportbutton.Location = new System.Drawing.Point(36, 172);
            this.Exportbutton.Name = "Exportbutton";
            this.Exportbutton.Size = new System.Drawing.Size(128, 30);
            this.Exportbutton.TabIndex = 3;
            this.Exportbutton.Text = "Export";
            this.Exportbutton.UseVisualStyleBackColor = true;
            this.Exportbutton.Click += new System.EventHandler(this.Exportbutton_Click);
            // 
            // ImportButton
            // 
            this.ImportButton.Location = new System.Drawing.Point(36, 122);
            this.ImportButton.Name = "ImportButton";
            this.ImportButton.Size = new System.Drawing.Size(128, 30);
            this.ImportButton.TabIndex = 2;
            this.ImportButton.Text = "Import";
            this.ImportButton.UseVisualStyleBackColor = true;
            this.ImportButton.Click += new System.EventHandler(this.ImportButton_Click);
            // 
            // StudentGroupsButton
            // 
            this.StudentGroupsButton.Location = new System.Drawing.Point(36, 72);
            this.StudentGroupsButton.Name = "StudentGroupsButton";
            this.StudentGroupsButton.Size = new System.Drawing.Size(128, 30);
            this.StudentGroupsButton.TabIndex = 1;
            this.StudentGroupsButton.Text = "Edit Groups";
            this.StudentGroupsButton.UseVisualStyleBackColor = true;
            this.StudentGroupsButton.Click += new System.EventHandler(this.StudentGroupsButton_Click);
            // 
            // CalculateButton
            // 
            this.CalculateButton.Location = new System.Drawing.Point(36, 22);
            this.CalculateButton.Name = "CalculateButton";
            this.CalculateButton.Size = new System.Drawing.Size(128, 30);
            this.CalculateButton.TabIndex = 1;
            this.CalculateButton.Text = "Calculate";
            this.CalculateButton.UseVisualStyleBackColor = true;
            this.CalculateButton.Click += new System.EventHandler(this.CalculateButton_Click);
            // 
            // StudentScoreDataGrid
            // 
            this.StudentScoreDataGrid.AllowUserToOrderColumns = true;
            this.StudentScoreDataGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.StudentScoreDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.StudentScoreDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.StudentScoreDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StudentNameColumn,
            this.StudentScoreColumn});
            this.StudentScoreDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StudentScoreDataGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.StudentScoreDataGrid.Location = new System.Drawing.Point(200, 32);
            this.StudentScoreDataGrid.Name = "StudentScoreDataGrid";
            this.StudentScoreDataGrid.Size = new System.Drawing.Size(819, 500);
            this.StudentScoreDataGrid.TabIndex = 10;
            this.StudentScoreDataGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.StudentScoreDataGrid_CellEndEdit);
            this.StudentScoreDataGrid.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.StudentScoreDataGrid_EditingControlShowing);
            // 
            // StudentNameColumn
            // 
            this.StudentNameColumn.HeaderText = "Student Name";
            this.StudentNameColumn.Name = "StudentNameColumn";
            // 
            // StudentScoreColumn
            // 
            this.StudentScoreColumn.HeaderText = "Student Score";
            this.StudentScoreColumn.MaxInputLength = 3;
            this.StudentScoreColumn.Name = "StudentScoreColumn";
            // 
            // CreateGroupMainPanel
            // 
            this.CreateGroupMainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.CreateGroupMainPanel.Controls.Add(this.AddNewGroupLabel);
            this.CreateGroupMainPanel.Controls.Add(this.NewGroupTextBox);
            this.CreateGroupMainPanel.Controls.Add(this.CreateGroupPanel);
            this.CreateGroupMainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CreateGroupMainPanel.Location = new System.Drawing.Point(200, 32);
            this.CreateGroupMainPanel.Name = "CreateGroupMainPanel";
            this.CreateGroupMainPanel.Size = new System.Drawing.Size(819, 500);
            this.CreateGroupMainPanel.TabIndex = 2;
            this.CreateGroupMainPanel.Visible = false;
            // 
            // AddNewGroupLabel
            // 
            this.AddNewGroupLabel.AutoSize = true;
            this.AddNewGroupLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddNewGroupLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.AddNewGroupLabel.Location = new System.Drawing.Point(665, 453);
            this.AddNewGroupLabel.Name = "AddNewGroupLabel";
            this.AddNewGroupLabel.Size = new System.Drawing.Size(122, 20);
            this.AddNewGroupLabel.TabIndex = 4;
            this.AddNewGroupLabel.Text = "Add New Group";
            this.AddNewGroupLabel.Click += new System.EventHandler(this.AddNewGroupLabel_Click);
            // 
            // NewGroupTextBox
            // 
            this.NewGroupTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.NewGroupTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NewGroupTextBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.NewGroupTextBox.ForeColor = System.Drawing.Color.White;
            this.NewGroupTextBox.Location = new System.Drawing.Point(150, 450);
            this.NewGroupTextBox.Name = "NewGroupTextBox";
            this.NewGroupTextBox.Size = new System.Drawing.Size(100, 26);
            this.NewGroupTextBox.TabIndex = 3;
            this.NewGroupTextBox.Text = "Double Click";
            // 
            // CreateGroupPanel
            // 
            this.CreateGroupPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.CreateGroupPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.CreateGroupPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.CreateGroupPanel.Location = new System.Drawing.Point(0, 0);
            this.CreateGroupPanel.Name = "CreateGroupPanel";
            this.CreateGroupPanel.Size = new System.Drawing.Size(819, 425);
            this.CreateGroupPanel.TabIndex = 3;
            // 
            // ImportBackGroundWorker
            // 
            this.ImportBackGroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.ImportBackGroundWorker_DoWork);
            this.ImportBackGroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.ImportBackGroundWorker_RunWorkerCompleted);
            // 
            // openFileDialog
            // 
            this.ImportFileDialog.FileName = "ImportFileDialog";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.ClientSize = new System.Drawing.Size(1019, 632);
            this.Controls.Add(this.CreateGroupMainPanel);
            this.Controls.Add(this.StudentScoreDataGrid);
            this.Controls.Add(this.InfoPanel);
            this.Controls.Add(this.ControlPanel);
            this.Controls.Add(this.Control_Bar);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Control_Bar.ResumeLayout(false);
            this.Control_Bar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MinimisePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExitPictureBox)).EndInit();
            this.InfoPanel.ResumeLayout(false);
            this.InfoPanel.PerformLayout();
            this.ControlPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.StudentScoreDataGrid)).EndInit();
            this.CreateGroupMainPanel.ResumeLayout(false);
            this.CreateGroupMainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Control_Bar;
        private System.Windows.Forms.PictureBox MinimisePictureBox;
        private System.Windows.Forms.PictureBox ExitPictureBox;
        private System.Windows.Forms.Panel InfoPanel;
        private System.Windows.Forms.Label InfoErrorLabel;
        private System.Windows.Forms.Panel ControlPanel;
        private System.Windows.Forms.Button ImportButton;
        private System.Windows.Forms.Button CalculateButton;
        private System.Windows.Forms.DataGridView StudentScoreDataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentScoreColumn;
        private System.Windows.Forms.Button Exportbutton;
        private System.Windows.Forms.SaveFileDialog ExportSaveFileDialog;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Button StudentGroupsButton;
        private System.Windows.Forms.Panel CreateGroupMainPanel;
        private System.Windows.Forms.FlowLayoutPanel CreateGroupPanel;
        private System.Windows.Forms.Label AddNewGroupLabel;
        private System.Windows.Forms.TextBox NewGroupTextBox;
        private System.ComponentModel.BackgroundWorker ImportBackGroundWorker;
        private System.Windows.Forms.OpenFileDialog ImportFileDialog;
    }
}

