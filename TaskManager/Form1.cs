using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Activation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaskManager.Properties;


namespace TaskManager
{
    public partial class Form1 : Form
    {
        private List<string> tasks = new List<string>();
        private string filePath;
        public Form1()
        {
            InitializeComponent();
            filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "tasks.txt"); // Ruta a Documentos
            LoadTasks();
        }


        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr one, int two, int three, int four);

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            string task = txtTask.Text;
            if (!string.IsNullOrWhiteSpace(task))
            {
                tasks.Add(task);
                UpdateTaskList();
                SaveTasks();
                txtTask.Clear();
            }
        }

        

        private void UpdateTaskList()
        {
            flowLayoutPanelTasks.Controls.Clear();
            foreach (var task in tasks)
            {
                var item = new ListViewItem();
                AddTaskToPanel(task);
            }
        }

        private void LoadTasks()
        {
            if (File.Exists(filePath))
            {
                tasks = File.ReadAllLines(filePath).ToList();
                UpdateTaskList();
            }
        }

        private void SaveTasks()
        {
            File.WriteAllLines(filePath, tasks);

        }

        private void AddTaskToPanel(string task)
        {
            Panel taskPanel = new Panel
            {
                 Width = flowLayoutPanelTasks.Width - 25,
                 Height = 30,
                 BorderStyle = BorderStyle.None
            };

            CheckBox checkBox = new CheckBox 
            { 
                Location = new Point(5,5),
                Width = 20, 
                Height = 20
            };

            checkBox.CheckedChanged += (s, e) => 
            {
                taskPanel.BackColor = checkBox.Checked ? Color.LightGreen : Color.White;
            };

            Label label = new Label
            { 
                Text = task,
                Location = new Point(30, 5),
                Width = 400, Height = 20 
            };

            Button deleteButton = new Button 
            { 
                Text = "Borrar",
                Location = new Point(taskPanel.Width - 75, 2),
                Width = 60,
                Height = 25 
            };

            deleteButton.Click += (s, e) => 
            {
                tasks.Remove(task);
                flowLayoutPanelTasks.Controls.Remove(taskPanel);
                SaveTasks();
            };

            taskPanel.Controls.Add(checkBox);
            taskPanel.Controls.Add(label);
            taskPanel.Controls.Add(deleteButton);

            flowLayoutPanelTasks.Controls.Add(taskPanel);

        }
        


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void maximizeButton_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
                maximizeButton.Image = Resources.NormalScreen;
            }
            else
            {
                WindowState = FormWindowState.Normal;
                maximizeButton.Image = Resources.NormalScreen;
            }
        }

        private void minimizeButton_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        

        
    }
}
