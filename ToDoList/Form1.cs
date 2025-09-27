using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDoList
{
    public partial class Form1 : Form
    {
        private List<Task> tasks = new List<Task>(); 

        public Form1()
        {
            InitializeComponent();
            SetupDataGridView();
            dataGridView1.CellClick += DataGridView1_CellClick; 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void SetupDataGridView()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.RowHeadersVisible = false;

            //Priority
            DataGridViewComboBoxColumn priorityCol = new DataGridViewComboBoxColumn();
            priorityCol.HeaderText = "Приоритет";
            priorityCol.Name = "Priority";
            priorityCol.Items.AddRange("Высокий", "Средний", "Низкий");
            dataGridView1.Columns.Add(priorityCol);

            //Name
            DataGridViewTextBoxColumn descCol = new DataGridViewTextBoxColumn();
            descCol.HeaderText = "Задача";
            descCol.Name = "Description";
            dataGridView1.Columns.Add(descCol);

            //Category
            DataGridViewComboBoxColumn categoryCol = new DataGridViewComboBoxColumn();
            categoryCol.HeaderText = "Категория";
            categoryCol.Name = "Category";
            categoryCol.Items.AddRange("Дом", "Учеба", "Спорт");
            dataGridView1.Columns.Add(categoryCol);

            //Date
            DataGridViewTextBoxColumn dateCol = new DataGridViewTextBoxColumn();
            dateCol.HeaderText = "Срок";
            dateCol.Name = "DueDate";
            dataGridView1.Columns.Add(dateCol);

            //IsDone
            DataGridViewCheckBoxColumn doneCol = new DataGridViewCheckBoxColumn();
            doneCol.HeaderText = "✓";
            doneCol.Name = "Done";
            dataGridView1.Columns.Add(doneCol);

            //Delete
            DataGridViewButtonColumn deleteCol = new DataGridViewButtonColumn();
            deleteCol.HeaderText = "Удалить";
            deleteCol.Name = "Delete";
            deleteCol.Text = "Тык";
            deleteCol.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(deleteCol);
        }

        public class Task
        {
            public string Description { get; set; }
            public bool IsDone { get; set; }
            public string Category { get; set; }
            public string Priority { get; set; }
            public DateTime? Date { get; set; }
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].Name == "Delete")
            {
                Task task = dataGridView1.Rows[e.RowIndex].Tag as Task;
                if (task != null) tasks.Remove(task);

                dataGridView1.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void Add_Click(object sender, EventArgs e)
        {
            Task newTask = new Task();
            tasks.Add(newTask);

            int rowIndex = dataGridView1.Rows.Add();
            dataGridView1.Rows[rowIndex].Tag = newTask; 
        }
    }
}