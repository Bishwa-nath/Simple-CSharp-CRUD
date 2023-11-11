using System.Data;
using System.Data.SqlClient;

namespace CRUD_in_CSharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        SqlConnection conn = new SqlConnection("Data Source=BNC;Initial Catalog=CS_CRUD;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {

            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Products VALUES('" + int.Parse(textBox1.Text)
                + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + comboBox1.Text + "', getdate(), getdate())", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            comboBox1.Text = string.Empty;
            MessageBox.Show("Successfully Inserted");
            BindDate();
        }

        void BindDate()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Products", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            BindDate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BindDate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Products SET ProductName = '"
                + textBox2.Text + "', Design='" + textBox3.Text + "', Color = '"
                + comboBox1.Text + "', UpdatedDate = '" + DateTime.Parse(dateTimePicker1.Text) + "' WHERE ProductId = '"
                + int.Parse(textBox1.Text) + "'", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Successfully Updated");
            BindDate();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (MessageBox.Show("Are you sure want to delete?", "Delete Record", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("DELETE Products WHERE ProductId = '"
                        + int.Parse(textBox1.Text) + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Successfully Deleted");
                    BindDate();
                }

            }
            else
            {
                MessageBox.Show("Please, Select Product Id");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Products WHERE ProductId = '" 
                + int.Parse(textBox1.Text) + "'", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}