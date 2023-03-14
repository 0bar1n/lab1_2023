using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace organizer
{
    public partial class OrganizerForm : Form
    {


        public Organizer organizer = new Organizer();

        public OrganizerForm()
        {
            InitializeComponent();
        }



        private void button3_Click(object sender, EventArgs e)
        {
            AddEventForm eventForm = new AddEventForm();
            eventForm.Show();

            eventForm.setOrganize(ref organizer);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            refreshDataGridView();
        }

        public void refreshDataGridView()
        {
            dataGridView1.Rows.Clear();
            organizer.list.ForEach(item =>
            {
                DataGridViewRow row = new DataGridViewRow();

                row.Cells.Add(new DataGridViewTextBoxCell 
                { 
                    Value = $"{item.Date.Year}-{item.Date.Month}-{item.Date.Day}"
                });
                row.Cells.Add(new DataGridViewTextBoxCell 
                { 
                    Value = $"{item.Time.Hours}:{item.Time.Minutes}:{item.Time.Seconds}"
                });
                row.Cells.Add(new DataGridViewTextBoxCell 
                { 
                    Value = item.Event 
                });

                row.Cells.Add(new DataGridViewTextBoxCell
                {
                    Value = item.eventType.ToString(),
                    Style = new DataGridViewCellStyle
                    {
                        BackColor = item.eventType == EventType.TASK ? System.Drawing.Color.HotPink : System.Drawing.Color.DeepPink
                    }
                }) ;
                dataGridView1.Rows.Add(row);
            });
        }

        private void OrganizerForm_Activated(object sender, EventArgs e)
        {
            refreshDataGridView();
        }

        private void OrganizerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            groupBox3.Visible = !groupBox3.Visible;
            button2.Text = groupBox3.Visible ? "Скрыть поиск" : "Найти";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            List<Data> tmp = organizer.findByTime(dateTimePicker1.Text);

            dataGridView1.Rows.Clear();

            tmp.ForEach(item =>
            {
                DataGridViewRow row = new DataGridViewRow();

                row.Cells.Add(new DataGridViewTextBoxCell
                {
                    Value = $"{item.Date.Year}-{item.Date.Month}-{item.Date.Day}"
                });
                row.Cells.Add(new DataGridViewTextBoxCell
                {
                    Value = $"{item.Time.Hours}:{item.Time.Minutes}:{item.Time.Seconds}"
                });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = item.Event });

                dataGridView1.Rows.Add(row);
            });
        }


        private void button4_Click(object sender, EventArgs e)
        {
            organizer.sortByData(0);
            refreshDataGridView();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            organizer.sortByData(1);
            refreshDataGridView();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            List<Data> tmp = organizer.findByTime(dateTimePicker1.Text);

            dataGridView1.Rows.Clear();

            tmp.ForEach(item =>
            {
                DataGridViewRow row = new DataGridViewRow();

                row.Cells.Add(new DataGridViewTextBoxCell
                {
                    Value = $"{item.Date.Year}-{item.Date.Month}-{item.Date.Day}"
                });
                row.Cells.Add(new DataGridViewTextBoxCell
                {
                    Value = $"{item.Time.Hours}:{item.Time.Minutes}:{item.Time.Seconds}"
                });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = item.Event });

                dataGridView1.Rows.Add(row);
            });
        }

        private void OrganizerForm_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Add(EventType.MEETING.ToString());
            comboBox1.Items.Add(EventType.TASK.ToString());
            comboBox1.Select(0, 1);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            List<Data> tmp = organizer.findByCategory((EventType)Enum.Parse(typeof(EventType),
                comboBox1.Text, true));


            dataGridView1.Rows.Clear();

            tmp.ForEach(item =>
            {
                DataGridViewRow row = new DataGridViewRow();

                row.Cells.Add(new DataGridViewTextBoxCell
                {
                    Value = $"{item.Date.Year}-{item.Date.Month}-{item.Date.Day}"
                });
                row.Cells.Add(new DataGridViewTextBoxCell
                {
                    Value = $"{item.Time.Hours}:{item.Time.Minutes}:{item.Time.Seconds}"
                });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = item.Event });

                dataGridView1.Rows.Add(row);
            });
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            refreshDataGridView();
        }
    }
}
