using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CharityManeger
{
    public partial class Login : Form
    {
        Main obj = new Main();

        #region DB

        string conString = @"Data Source=(localDb)\localDBdd;Initial Catalog=CharityManeger;Integrated Security=True";
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        SqlConnection connection = new SqlConnection();

        #endregion

        #region Prop

        string[] username=new string[3];
        string[] password=new string[3];

         #endregion

        #region Form
        public Login()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you want to close?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void Login_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(conString);
            connection.Open();
            cmd = new SqlCommand("select * from userLogin where user_ID=1 ", connection);
            cmd.ExecuteNonQuery();
            dt = new DataTable();
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                username[0] = dr["username"].ToString();
                password[0] = dr["password"].ToString();
            }

            cmd = new SqlCommand("select * from userLogin where user_ID=2 ", connection);
            cmd.ExecuteNonQuery();
            dt = new DataTable();
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                username[1] = dr["username"].ToString();
                password[1] = dr["password"].ToString();
            }

            cmd = new SqlCommand("select * from userLogin where user_ID=3 ", connection);
            cmd.ExecuteNonQuery();
            dt = new DataTable();
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                username[2] = dr["username"].ToString();
                password[2] = dr["password"].ToString();
            }
            connection.Close();
        }

        #endregion

        #region Login Button
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == username[0] && txtPassword.Text == password[0])
            {
                obj.tabControlMain.SelectTab("tabPageVol");
                obj.tabPageDon.Enabled = false;
                obj.tabPageCase.Enabled = false;
                obj.tabPageCaseMang.Enabled = false;
                obj.tabPageRebort.Enabled = false;
                obj.Show();
                this.Hide();
            }
            else if (txtUsername.Text == username[1] && txtPassword.Text == password[1])
            {
                obj.tabControlMain.SelectTab("tabPageDon");
                obj.tabPageVol.Enabled = false;
                obj.tabPageCaseMang.Enabled = false;
                obj.tabPageRebort.Enabled = false;
                obj.Show();
                this.Hide();
            }
            else if (txtUsername.Text == username[2] && txtPassword.Text == password[2])
            {
                obj.tabControlMain.SelectTab("tabPageCaseMang");
                obj.tabPageVol.Enabled = false;
                obj.tabPageDon.Enabled = false;
                obj.tabPageCase.Enabled = false;
                
                obj.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("The UserName or Password is worng","Worng",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
           
        }

        #endregion

        

    }
}
