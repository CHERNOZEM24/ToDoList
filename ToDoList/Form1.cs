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
        public Form1()
        {
            InitializeComponent();
            SetupDataGridView();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void SetupDataGridView()
        {
            dataGridView1.Columns.Add("Priority", "Приоритет");
            dataGridView1.Columns.Add("Description", "Задача");
            dataGridView1.Columns.Add("Category", "Категория");
            dataGridView1.Columns.Add("DueDate", "Срок");
            dataGridView1.Columns.Add("Done", "✓");
            dataGridView1.Columns.Add("Delete", "Удалить");
        }

        public class Task
        {
            public string Description { get; set; }
            public bool IsDone { get; set; }
            public string Category { get; set; }
            public string Priority { get; set; }
            public DateTime? Date { get; set; }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Add_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add();
        }
    }
}
