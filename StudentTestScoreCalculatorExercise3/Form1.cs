using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Threading;
using System.Security.Cryptography;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;
using System.Media;
using System.ComponentModel;

namespace StudenTestScoreCalculatorExercise3
{
    public partial class Form1 : Form
    {
        // This whole region is just for the top bar, on start up it adds the border shadow, adds events to make bar movable and imagebox hover events and etc
        #region TopBar
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        protected override CreateParams CreateParams
        {
            get
            {
                const int CS_DROPSHADOW = 0x20000;
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }

        private void Control_Bar_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void ExitBox_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ExitBox_MouseHover(object sender, EventArgs e)
        {
            ExitPictureBox.BackColor = Color.FromArgb(240, 71, 71);
        }

        private void ExitBox_MouseLeave(object sender, EventArgs e)
        {
            ExitPictureBox.BackColor = Color.FromArgb(45, 45, 48);
        }

        private void MinimisePictureBox_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void MinimisePictureBox_MouseHover(object sender, EventArgs e)
        {
            MinimisePictureBox.BackColor = Color.FromArgb(50, 53, 56);
        }

        private void MinimisePictureBox_MouseLeave(object sender, EventArgs e)
        {
            MinimisePictureBox.BackColor = Color.FromArgb(45, 45, 48);
        }

        private void TitleLabel_MouseMove(object sender, MouseEventArgs e)
        {
            Control_Bar_MouseMove(sender, e);
        }
        #endregion

        [DllImport("user32.dll")]
        static extern bool HideCaret(IntPtr hWnd);

        [DllImport("user32.dll")]
        static extern bool ShowCaret(IntPtr hWnd);


        public Form1()
        {
            InitializeComponent();

            //Formatting to make the grids fill given space on open
            StudentScoreDataGrid.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            StudentScoreDataGrid.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            //set Title
            TitleLabel.Text = "Student Test Score Calculator - " + StudentClass.CurrentGroup.Key;
        }

        private void StudentScoreDataGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            StudentScoreDataGrid.Rows[e.RowIndex].ErrorText = String.Empty;
        }


        /// <summary>
        /// Add event to current cell for `keypress` only if it is in column 1 (Student Score Column)
        /// </summary>
        private void StudentScoreDataGrid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= TextboxNumeric_KeyPress;
            if ((int)(((DataGridView)sender).CurrentCell.ColumnIndex) == 1)
            {
                e.Control.KeyPress += TextboxNumeric_KeyPress;
            }
        }

        /// <summary>
        /// Event on cell key press, checks if input key is a digit
        /// </summary>
        private void TextboxNumeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            InfoErrorLabel.Visible = false;
            int CellNumber;
            int.TryParse(((DataGridViewTextBoxEditingControl)sender).Text + e.KeyChar, out CellNumber);


            if ((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8)
            {
                //verify it is between 10 and 0
                if (CellNumber <= 10 && CellNumber >= 0)
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                    InfoErrorLabel.Text = "Number has to be less then 10 or more then 0";
                    InfoErrorLabel.Visible = true;
                }
            }
            else
            {
                // Stop the character from being entered into the control since it is non-numerical.
                e.Handled = true;
                SystemSounds.Beep.Play();
                InfoErrorLabel.Text = "Age must be numeric";
                InfoErrorLabel.Visible = true;
            }
            
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            InfoErrorLabel.Visible = false;

            //Make sure at least 1 row has values
            if (StudentScoreDataGrid.RowCount == 1)
            {
                InfoErrorLabel.Text = "You must enter Values in at least 1 row";
                InfoErrorLabel.Visible = true;
                return;
            }
            else
            {
                RecountStudentList();

                StudentClass HighestStudent = StudentClass.CurrentGroup.Value.OrderByDescending(x => x.StudentScore).First();
                StudentClass LowestStudent = StudentClass.CurrentGroup.Value.OrderByDescending(x => x.StudentScore).Last();

                //Display Calculated Results
                InfoErrorLabel.Text = "Highest Student: \"" + HighestStudent.StudentName + "\" | Score: " + HighestStudent.StudentScore + "\n";
                InfoErrorLabel.Text += "Average Student Score " + StudentClass.TotalScore/StudentClass.CurrentGroup.Value.Count + "\n";
                InfoErrorLabel.Text += "Lowest Student: \"" + LowestStudent.StudentName + "\" | Score: " + LowestStudent.StudentScore + "\n";
                InfoErrorLabel.Visible = true;
            }
        }

        private void ImportButton_Click(object sender, EventArgs e)
        {
            ImportFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
            ImportFileDialog.Filter = "Json Files (*.json)|*.json|All files (*.*)|*.*";

            ImportFileDialog.CheckFileExists = true;
            ImportFileDialog.CheckPathExists = true;

            ImportFileDialog.Multiselect = true;

            DialogResult IFD = this.ImportFileDialog.ShowDialog();
            if (IFD == DialogResult.OK)
            {
                if (!ImportBackGroundWorker.IsBusy)
                {
                    ImportBackGroundWorker.RunWorkerAsync();
                }
            }
        }

        private void ImportBackGroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            //temp import Dictionary plus group Already exist counter
            Dictionary<String, List<StudentClass>> ImportDictionary = new Dictionary<String, List<StudentClass>>();
            int FailedGroupAdd = 0;

            //if picked multi files, go through all files
            foreach (String FilePath in ImportFileDialog.FileNames)
            {
                ImportDictionary = JsonConvert.DeserializeObject<Dictionary<String, List<StudentClass>>>(File.ReadAllText(FilePath));

                //go through temp dictionary, try add to main dictionary and if failed then increment FailedGroupAdd counter
                foreach(KeyValuePair<String, List<StudentClass>> ValuePair in ImportDictionary)
                {
                    try
                    {
                        StudentClass.StudentListDictionary.Add(ValuePair.Key, ValuePair.Value);
                    }
                    catch
                    {
                        FailedGroupAdd++;
                    }
                }
            }

            if (FailedGroupAdd > 0)
            {
                e.Result = $"{FailedGroupAdd} groups failed to add, Others Added";
            }
            else
            {
                e.Result = $"Added Groups";
            }
        }

        private void ImportBackGroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                InfoErrorLabel.Text = "There was an error while importing";
            }
            else if (e.Cancelled)
            {
                InfoErrorLabel.Text = "Operation was cancelled";
            }
            else
            {
                InfoErrorLabel.Text = (String)e.Result;
            }
            InfoErrorLabel.Visible = true;
        }

        private void Exportbutton_Click(object sender, EventArgs e)
        {
            RecountStudentList();

            //show folder select save location and save type
            ExportSaveFileDialog.InitialDirectory = Directory.GetCurrentDirectory();

            //Filters/Save as types
            ExportSaveFileDialog.Filter = "Export For Import (*.json)|*.json|Export For Show (*.txt)|*.txt";


            if (ExportSaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                switch (ExportSaveFileDialog.FilterIndex)
                {
                    // Json Export
                    case 1:
                        File.WriteAllText(ExportSaveFileDialog.FileName, JsonConvert.SerializeObject(StudentClass.StudentListDictionary));
                        break;

                    // Text Export
                    case 2:
                        using (StreamWriter writer = File.CreateText(Path.GetFullPath(ExportSaveFileDialog.FileName)))
                        {
                            foreach (KeyValuePair<String, List<StudentClass>> GroupforExport in StudentClass.StudentListDictionary)
                            {

                                writer.WriteLine("▐░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▌");
                                writer.WriteLine("◤━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━◥");
                                writer.WriteLine(" ◤━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━◥");
                                writer.WriteLine((" ┃ Group: " + GroupforExport.Key).PadRight(36) + "┃");
                                writer.WriteLine(" ◣━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━◢");

                                try
                                {
                                    //Calculate total mark for each group
                                    int totalGroupMark = 0;
                                    foreach (StudentClass StudentInClass in GroupforExport.Value)
                                    {
                                        totalGroupMark += StudentInClass.StudentScore;
                                    }

                                    // format and make the output be nice
                                    

                                    StudentClass HighestStudent = GroupforExport.Value.OrderByDescending(x => x.StudentScore).First();
                                    StudentClass LowestStudent = GroupforExport.Value.OrderByDescending(x => x.StudentScore).Last();



                                    writer.WriteLine(" Average Student Score " + totalGroupMark / GroupforExport.Value.Count);
                                    writer.WriteLine((" Highest Student: \"" + HighestStudent.StudentName + "\"").PadRight(50) + "| Score: " + HighestStudent.StudentScore);
                                    writer.WriteLine((" Lowest Student: \"" + LowestStudent.StudentName + "\"").PadRight(50) + "| Score: " + LowestStudent.StudentScore);
                                    writer.WriteLine(" =================================================================================================");

                                    foreach (StudentClass StudentInClass in GroupforExport.Value)
                                    {
                                        writer.WriteLine((" Name: " + StudentInClass.StudentName).PadRight(50) + "| Score: " + StudentInClass.StudentScore);
                                    }
                                }
                                catch
                                {
                                    writer.WriteLine(" Group Empty");
                                }

                                writer.WriteLine("◣━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━◢");

                            }
                        }
                        break;
                }
            }
        }

        #region Functions

        public void RecountStudentList()
        {
            //Reset values
            StudentClass.CurrentGroup.Value.Clear();
            StudentClass.TotalScore = 0;

            foreach (DataGridViewRow row in StudentScoreDataGrid.Rows)
            {
                //Add each row to List as a `StudentClass` Object, try catch incase the values are invalid
                try { StudentClass.CurrentGroup.Value.Add(new StudentClass(row.Cells["StudentNameColumn"].Value.ToString(), Int32.Parse(row.Cells["StudentScoreColumn"].Value.ToString()))); } catch { }
            }

            StudentClass.StudentListDictionary[StudentClass.CurrentGroup.Key] = StudentClass.CurrentGroup.Value;

            //Add up all scores from all Students for average calculations
            foreach (StudentClass student in StudentClass.CurrentGroup.Value)
            {
                StudentClass.TotalScore += student.StudentScore;
            }
        }

        public void RelistEditGroupPanel()
        {
            RecountStudentList();

            CreateGroupPanel.Controls.Clear();

            foreach (KeyValuePair<String, List<StudentClass>> DictionaryEntry in StudentClass.StudentListDictionary)
            {
                // Create panel to hold all the "information"
                Panel EntryPanel = new Panel();
                EntryPanel.Name = DictionaryEntry.Key;
                EntryPanel.Size = new Size(813, 76);
                EntryPanel.BackColor = Color.FromArgb(28, 28, 28);
                EntryPanel.DoubleClick += (sender2, e2) => EntryPanel_DoubleClick(sender2, e2, DictionaryEntry);

                //Text box diguisted as label
                TextBox LabelTextBoxName = new TextBox();
                LabelTextBoxName.Text = DictionaryEntry.Key;
                LabelTextBoxName.BackColor = EntryPanel.BackColor;
                LabelTextBoxName.BorderStyle = BorderStyle.FixedSingle;
                LabelTextBoxName.Size = new Size(150, 20);
                LabelTextBoxName.Location = new Point(50, (EntryPanel.Size.Height / 2) - (LabelTextBoxName.Size.Height / 2));
                LabelTextBoxName.ForeColor = Color.White;
                LabelTextBoxName.ReadOnly = true;
                LabelTextBoxName.GotFocus += DynamicTextBox_GotFocus;
                LabelTextBoxName.DoubleClick += DynamicTextBox_DoubleClick;
                LabelTextBoxName.KeyDown += (sender2, e2) => LabelTextBoxName_KeyDown(sender2, e2, DictionaryEntry.Key);

                //Label with array count
                Label ArrayCount = new Label();
                ArrayCount.Text = DictionaryEntry.Value.Count.ToString();
                ArrayCount.AutoSize = true;
                ArrayCount.ForeColor = Color.White;
                ArrayCount.Location = new Point(300, (EntryPanel.Size.Height / 2) - (ArrayCount.Size.Height / 2));

                Label RemoveSelf = new Label();
                RemoveSelf.Text = "Remove";
                RemoveSelf.Cursor = Cursors.Hand;
                RemoveSelf.AutoSize = true;
                RemoveSelf.ForeColor = Color.FromArgb(0, 192, 192);
                RemoveSelf.Location = new Point(500, (EntryPanel.Size.Height / 2) - (RemoveSelf.Size.Height / 2));
                RemoveSelf.Click += (sender2, e2) => RemoveSelf_Click(sender2, e2, DictionaryEntry.Key);

                //add all things to dynamic panel
                EntryPanel.Controls.Add(LabelTextBoxName);
                EntryPanel.Controls.Add(ArrayCount);
                EntryPanel.Controls.Add(RemoveSelf);

                // Add panel to the main panel to show and allow for edits and etc
                CreateGroupPanel.Controls.Add(EntryPanel);
            }
        }

        #endregion

        private void StudentGroupsButton_Click(object sender, EventArgs e)
        {
            RelistEditGroupPanel();

            CreateGroupMainPanel.Visible = !CreateGroupMainPanel.Visible;
        }

        #region DynamicEvents
        /// <summary>
        /// Double press use group
        /// </summary>
        private void EntryPanel_DoubleClick(object sender, EventArgs e, KeyValuePair<String, List<StudentClass>> GroupContained)
        {
            // save current group
            RecountStudentList();

            StudentClass.CurrentGroup = GroupContained;


            //clear the data grid view
            StudentScoreDataGrid.Rows.Clear();
            StudentScoreDataGrid.Refresh();

            foreach (StudentClass student in StudentClass.CurrentGroup.Value)
            {
                DataGridViewRow row = (DataGridViewRow)StudentScoreDataGrid.Rows[0].Clone();
                row.Cells[0].Value = student.StudentName;
                row.Cells[1].Value = student.StudentScore;
                StudentScoreDataGrid.Rows.Add(row);
            }

            TitleLabel.Text = "Student Test Score Calculator - " + GroupContained.Key;
        }

        /// <summary>
        /// Allow Editing
        /// </summary>
        private void DynamicTextBox_DoubleClick(object sender, EventArgs e)
        {
            ((TextBox)sender).ReadOnly = false;
            ShowCaret(((TextBox)sender).Handle);
        }

        /// <summary>
        /// On enter continue
        /// </summary>
        private void LabelTextBoxName_KeyDown(object sender, KeyEventArgs e,String OldKey)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InfoErrorLabel.Visible = false;


                ((TextBox)sender).ReadOnly = true;

                if (StudentClass.StudentListDictionary.ContainsKey(((TextBox)sender).Text))
                {
                    InfoErrorLabel.Text = "Name Already Exists, rename to something else";
                    InfoErrorLabel.Visible = true;
                }
                else
                {
                    List<StudentClass> ChangingList;

                    StudentClass.StudentListDictionary.TryGetValue(OldKey, out ChangingList);

                    StudentClass.StudentListDictionary.Add(((TextBox)sender).Text, ChangingList);
                    StudentClass.StudentListDictionary.Remove(OldKey);
                }

                RelistEditGroupPanel();
            }
        }

        private void DynamicTextBox_GotFocus(object sender, EventArgs e)
        {
            //hide the I beam inside the textbox to make it seem as label
            HideCaret(((TextBox)sender).Handle);
        }

        /// <summary>
        /// Remove Self click, just remove entry and dictionary entry
        /// </summary>
        private void RemoveSelf_Click(object sender, EventArgs e, String SelfKey)
        {
            StudentClass.StudentListDictionary.Remove(SelfKey);

            RelistEditGroupPanel();
        }
        #endregion

        private void AddNewGroupLabel_Click(object sender, EventArgs e)
        {
            //reset Info Error Label
            InfoErrorLabel.Visible = false;

            //Check if new group name(Key) already exists in the dictionary
            foreach (String ExistingKeys in StudentClass.StudentListDictionary.Keys)
            {
                if(NewGroupTextBox.Text == ExistingKeys)
                {
                    InfoErrorLabel.Text = "\"" + ExistingKeys + "\" Already exists";
                    InfoErrorLabel.Visible = true;
                    return;
                }
            }

            //add the new group and relist the panel
            StudentClass.StudentListDictionary.Add(NewGroupTextBox.Text, new List<StudentClass>());
            RelistEditGroupPanel();
        }
    }

    /// <summary>
    /// An object Class for easier Serializetion
    /// </summary>
    public class StudentClass
    {
        /// <summary>
        /// Current Group Key name
        /// </summary>
        public static KeyValuePair<String, List<StudentClass>> CurrentGroup = new KeyValuePair<string, List<StudentClass>>("Unnamed Group", new List<StudentClass>() { });

        /// <summary>
        /// Global Dictionary of Student List
        /// </summary>
        public static Dictionary<String, List<StudentClass>> StudentListDictionary = new Dictionary<String, List<StudentClass>>();

        /// <summary>
        /// Global TotalScore float, keeps in object to be able to access anywhere
        /// </summary>
        public static float TotalScore { get; set; } = 0;
        
        /// <summary>
        /// Student Name
        /// </summary>
        public String StudentName { get; set; }
        
        /// <summary>
        /// Student Score
        /// </summary>
        public int StudentScore { get; set; }

        /// <summary>
        /// Create Object
        /// </summary>
        /// <param name="studentName">Student Name</param>
        /// <param name="studentScore">Student Score</param>
        public StudentClass(String studentName, int studentScore)
        {
            StudentName = studentName;
            StudentScore = studentScore;
        }
    }
}
