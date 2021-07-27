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
    public partial class Main : Form
    {

        #region DataBase

        string con = @"Data Source=(localDb)\localDBdd;Initial Catalog=CharityManeger;Integrated Security=True";
        SqlCommand cmd;
        SqlDataAdapter da;
        SqlDataReader dr;
        DataSet ds;

        #endregion

        #region ComboBox
        int gender, learn, worktype;
        private void ComboBoxGender_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            gender = ComboBoxGender.SelectedIndex;
        }
        private void ComboBoxLearn_SelectedIndexChanged(object sender, EventArgs e)
        {
            learn = ComboBoxLearn.SelectedIndex;
        }

        private void ComboBoxWT_SelectedIndexChanged(object sender, EventArgs e)
        {
            worktype = ComboBoxWT.SelectedIndex;
        }
        #endregion

        #region Main Form
        public Main()
        {

            InitializeComponent();
            SqlConnection cn = new SqlConnection(con);
            lblStatus.Text = "Today is :" + DateTime.Now;
        }
        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            { 
                this.WindowState = FormWindowState.Normal; 

            }
            else
                this.WindowState = FormWindowState.Maximized;
        }
        private void btnMinimize_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
      
        private void btnClose_Click(object sender, EventArgs e)
        {
           DialogResult result = MessageBox.Show("Are you want to close?","Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
           if (result == DialogResult.Yes)
           {
               Application.Exit();
           }
        }

        #endregion

        #region Tab Select
        private void tabControlMain_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (!e.TabPage.Enabled)
                e.Cancel = true;
        }

        #endregion

        #region Volunteer
        private void tabPageVol_Enter(object sender, EventArgs e)
        {
            panelSearchVol.Visible = false;
        }

        private void btnAddVol_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(con);
            try
            {
                try
                {
                    cmd = new SqlCommand("Insert into Volunteer(HR_ID,F_Name,L_Name,Phone,Degree) values(" + txtHR.Text + ",N'" + txtFiN.Text + "',N'" + txtLaN.Text + "',N'" + txtPh.Text + "',N'" + txtDeg.Text + "')", cn);
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Added Successfuly", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtHR.Clear();
                    txtFiN.Clear();
                    txtLaN.Clear();
                    txtPh.Clear();
                    txtDeg.Clear();
                    txtSearchVol.Clear();
                }
                catch (Exception)
                {
                    MessageBox.Show("Please, Add All Volunteer Data", "Some Error Happened ");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Some Error Happened ");
            }
            finally
            {
                cn.Close();
            }

        }
        private void btnSearchVol_Click(object sender, EventArgs e)
        {
            
            SqlConnection cn = new SqlConnection(con);
            try
            {
                
                try
                {
                    int id = int.Parse(txtSearchVol.Text);
                    cmd = new SqlCommand("Select F_Name,L_Name,Phone,Degree,HR_ID From Volunteer Where Vol_ID =" + id + "", cn);
                    cn.Open();
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    txtHR.Text = dr["HR_ID"].ToString();
                    txtFiN.Text = dr["F_Name"].ToString();
                    txtLaN.Text = dr["L_Name"].ToString();
                    txtPh.Text = dr["Phone"].ToString();
                    txtDeg.Text = dr["Degree"].ToString();
                    dr.Close();
                    cn.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Please, Enter Volunteer ID", "Some Error Happened ");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Some Error Happened ");
            }
            finally
            {
               // dr.Close();
                cn.Close();
            }
        }
        private void btnEditVol_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(con);
            if (panelSearchVol.Visible == true)
            {
                int id = int.Parse(txtSearchVol.Text);
                try
                {
                    cmd = new SqlCommand("Update Volunteer Set F_Name=N'" + txtFiN.Text + "',L_Name=N'" + txtLaN.Text + "',Phone=N'" + txtPh.Text + "',Degree=N'" + txtDeg.Text + "',HR_ID=" + int.Parse(txtHR.Text) + " Where Vol_ID =" + id + "", cn);
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Updated Successfuly ", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtHR.Clear();
                    txtFiN.Clear();
                    txtLaN.Clear();
                    txtPh.Clear();
                    txtDeg.Clear();
                    txtSearchVol.Clear();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message,"Some Error Happened ");
                }
                finally
                {
                    cn.Close();
                }
            }
            else
                panelSearchVol.Visible = true;
        }
        #endregion

        #region Donor
        private void tabPageDon_Enter(object sender, EventArgs e)
        {
            panelSearchDon.Visible = false;
        }
        private void btnAddDonor_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(con);
            try
            {
                try{
                cmd = new SqlCommand("Insert into Doner(Vol_ID,F_Name,L_Name,Phone,Donation) values(" + txtvolunteerID.Text + ",N'" + txtDFN.Text + "',N'" + txtDLN.Text + "',N'" + txtDPhone.Text + "'," + txtDon.Text +")", cn);
                cn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Added Successfuly", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtvolunteerID.Clear();
                txtDFN.Clear();
                txtDLN.Clear();
                txtDPhone.Clear();
                txtDon.Clear();
                txtSearchDon.Clear();
                }
                catch (Exception)
                {
                    MessageBox.Show("Please, Add All Doner Data", "Some Error Happened ");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Some Error Happened ");
            }
            finally
            {
                cn.Close();
            }
        }
        private void btnSearchDonor_Click(object sender, EventArgs e)
        {
            
            SqlConnection cn = new SqlConnection(con);
            try
            {
                try
                {
                    int id = int.Parse(txtSearchDon.Text);
                    cmd = new SqlCommand("Select F_Name,L_Name,Donation,Phone,Vol_ID From Doner Where Doner_ID =" + id + "", cn);
                    cn.Open();
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    txtvolunteerID.Text = dr["Vol_ID"].ToString();
                    txtDFN.Text = dr["F_Name"].ToString();
                    txtDLN.Text = dr["L_Name"].ToString();
                    txtDPhone.Text = dr["Phone"].ToString();
                    txtDon.Text = dr["Donation"].ToString();
                    dr.Close();
                    cn.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Please, Enter Doner ID", "Some Error Happened ");
                }
                
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Some Error Happened ");
            }
            finally
            {
                //dr.Close();
                cn.Close();
            }
        }
        private void btnEditDonor_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(con);
            if(panelSearchDon.Visible == true)
            {
                int id = int.Parse(txtSearchDon.Text);
                try
                {
                    cmd = new SqlCommand("Update Doner Set F_Name=N'" + txtDFN.Text + "',L_Name=N'" + txtDLN.Text + "',Phone=N'" + txtDPhone.Text + "',Donation=" + int.Parse(txtDon.Text) + ",Vol_ID=" + int.Parse(txtvolunteerID.Text) + " Where Doner_ID =" + id + "", cn);
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Updated Successfuly ", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtvolunteerID.Clear();
                    txtDFN.Clear();
                    txtDLN.Clear();
                    txtDPhone.Clear();
                    txtDon.Clear();
                    txtSearchDon.Clear();

                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message, "Some Error Happened ");
                }
                finally
                {
                    cn.Close();
                }
            }
            else
                panelSearchDon.Visible = true;
        }
        #endregion

        #region Case

        int idCase;
        private void visible()
        {
            if (panelSearchCase.Visible == true)
            {
                labelFN.Visible = false;
                labelLS.Visible = false;
                labelExp.Visible = false;
                labelGen.Visible = false;
                labelLearn.Visible = false;
                labelNID.Visible = false;
                labelPhone.Visible = false;
                labelWN.Visible = false;
                labeWT.Visible = false;
                labelAdress.Visible = false;
                labelAge.Visible = false;
                labelDebt.Visible = false;
                labeIncome.Visible = false;
                label22ChN.Visible = false;
                labelVolid.Visible = false;
                txtAdress.Visible = false;
                txtAge.Visible = false;
                txtChN.Visible = false;
                txtDebt.Visible = false;
                txtExp.Visible = false;
                txtFN.Visible = false;
                txtIncome.Visible = false;
                txtLN.Visible = false;
                txtNID.Visible = false;
                txtPhone.Visible = false;
                txtWN.Visible = false;
                txtVolid.Visible = false;
                ComboBoxWT.Visible = false;
                ComboBoxGender.Visible = false;
                ComboBoxLearn.Visible = false;
            }
            else
            {
                labelFN.Visible = true;
                labelLS.Visible = true;
                labelExp.Visible = true;
                labelGen.Visible = true;
                labelLearn.Visible = true;
                labelNID.Visible = true;
                labelPhone.Visible = true;
                labelWN.Visible = true;
                labeWT.Visible = true;
                labelAdress.Visible = true;
                labelAge.Visible = true;
                labelDebt.Visible = true;
                labeIncome.Visible = true;
                label22ChN.Visible = true;
                labelVolid.Visible = true;
                txtAdress.Visible = true;
                txtAge.Visible = true;
                txtChN.Visible = true;
                txtDebt.Visible = true;
                txtExp.Visible = true;
                txtFN.Visible = true;
                txtIncome.Visible = true;
                txtLN.Visible = true;
                txtNID.Visible = true;
                txtPhone.Visible = true;
                txtWN.Visible = true;
                ComboBoxWT.Visible = true;
                ComboBoxGender.Visible = true;
                ComboBoxLearn.Visible = true;
                txtVolid.Visible = true;
            }
        }
        private void tabPageCase_Enter(object sender, EventArgs e)
        {
            panelSearchCase.Visible = false;
        }

        private void btnAddCase_Click(object sender, EventArgs e)
        {
            
            SqlConnection cn = new SqlConnection(con);
            if (panelSearchCase.Visible == false)
            {
                try
                {
                    try
                    {
                        cmd = new SqlCommand("Insert into Case_data(Vol_ID,F_Name,L_Name,National_ID,Age,Phone,Adress,Gander,Learning,Child_Number,Work_Name,Work_Type,Income,Expness,Debts) values(" + int.Parse(txtVolid.Text) + ",N'" + txtFN.Text + "',N'" + txtLN.Text + "',N'" + txtNID.Text + "'," + int.Parse(txtAge.Text) + ",N'" + txtPhone.Text + "',N'" + txtAdress.Text + "',N'" + ComboBoxGender.Items[gender] + "',N'" + ComboBoxLearn.Items[learn] + "'," + int.Parse(txtChN.Text) + ",N'" + txtWN.Text + "',N'" + ComboBoxWT.Items[worktype] + "'," + int.Parse(txtIncome.Text) + "," + int.Parse(txtExp.Text) + "," + int.Parse(txtDebt.Text) + ")", cn);
                        cn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Data Added Successfuly", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtVolid.Clear();
                        txtFN.Clear();
                        txtLN.Clear();
                        txtNID.Clear();
                        txtAge.Clear();
                        txtPhone.Clear();
                        txtAdress.Clear();
                        ComboBoxGender.SelectedIndex = (-1);
                        ComboBoxLearn.SelectedIndex = (-1);
                        txtChN.Clear();
                        txtWN.Clear();
                        ComboBoxWT.SelectedIndex = (-1);
                        txtIncome.Clear();
                        txtExp.Clear();
                        txtDebt.Clear();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Please, Add All Case Data", "Some Error Happened ");
                    }


                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message, "Some Error Happened ");
                }
                finally
                {
                    cn.Close();
                }
            }
            else
            {
                panelSearchCase.Visible = false;
                visible();
            }

        }

        private void btnSearchCase_Click(object sender, EventArgs e)
        {
            panelSearchCase.Visible = false;
            visible();
            lblEdit.Visible = true;
            
            SqlConnection cn = new SqlConnection(con);
            try
            {
                try
                {
                    idCase = int.Parse(txtSearchCase.Text);
                    cmd = new SqlCommand("Select F_Name,L_Name,National_ID,Age,Phone,Adress,Gander,Learning,Child_Number,Work_Name,Work_Type,Income,Expness,Debts,Vol_ID From Case_data Where Case_ID =" + idCase + "", cn);
                    cn.Open();
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    txtVolid.Text = dr["Vol_ID"].ToString();
                    txtFN.Text = dr["F_Name"].ToString();
                    txtLN.Text = dr["L_Name"].ToString();
                    txtNID.Text = dr["National_ID"].ToString();
                    txtAge.Text = dr["Age"].ToString();
                    txtPhone.Text = dr["Phone"].ToString();
                    txtAdress.Text = dr["Adress"].ToString();
                    ComboBoxGender.Items.Add(dr["Gander"].ToString());
                    ComboBoxGender.SelectedIndex = 2;
                    ComboBoxLearn.Items.Add(dr["Learning"].ToString());
                    ComboBoxLearn.SelectedIndex = 7;
                    txtChN.Text = dr["Child_Number"].ToString();
                    txtWN.Text = dr["Work_Name"].ToString();
                    ComboBoxWT.Items.Add(dr["Work_Type"].ToString());
                    ComboBoxWT.SelectedIndex = 3;
                    txtIncome.Text = dr["Income"].ToString();
                    txtExp.Text = dr["Expness"].ToString();
                    txtDebt.Text = dr["Debts"].ToString();
                    dr.Close();
                    cn.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Please, Add case ID", "Some Error Happened ");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Some Error Happened ", ex.Message);
            }
            finally
            {
                //dr.Close();
                cn.Close();
            }
        }
        private void btnEditCase_Click(object sender, EventArgs e)
        {
            //panelSearchCase.Visible = true;
            //visible();
            SqlConnection cn = new SqlConnection(con);
  
            if(lblEdit.Visible == true)
            {

                    try
                    {
                        cmd = new SqlCommand("Update Case_data Set F_Name=N'" + txtFN.Text + "',L_Name=N'" + txtLN.Text + "',National_ID=N'" + txtNID.Text + "',Age=" + int.Parse(txtAge.Text) + ",Phone=N'" + txtPhone.Text + "',Adress=N'" + txtAdress.Text + "',Gander=N'" + ComboBoxGender.Items[gender] + "',Learning=N'" + ComboBoxLearn.Items[learn] + "',Child_Number=" + int.Parse(txtChN.Text) + ",Work_Name=N'" + txtWN.Text + "',Work_Type=N'" + ComboBoxWT.Items[worktype] + "',Income=" + int.Parse(txtIncome.Text) + ",Expness=" + int.Parse(txtExp.Text) + ",Debts=" + int.Parse(txtDebt.Text) + ",Vol_ID=" + int.Parse(txtVolid.Text) + " Where Case_ID =" + idCase + "", cn);
                        cn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Updated Successfuly ", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtVolid.Clear();
                        txtFN.Clear();
                        txtLN.Clear();
                        txtNID.Clear();
                        txtAge.Clear();
                        txtPhone.Clear();
                        txtAdress.Clear();
                        ComboBoxGender.SelectedIndex = -1;
                        ComboBoxLearn.SelectedIndex = -1;
                        txtChN.Clear();
                        txtWN.Clear();
                        ComboBoxWT.SelectedIndex = -1;
                        txtIncome.Clear();
                        txtExp.Clear();
                        txtDebt.Clear();
                        txtSearchCase.Clear();
                        lblEdit.Visible = false;
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message, "Some Error Happened ");
                    }
                    finally
                    {
                        cn.Close();
                    }

            }
            else
                panelSearchCase.Visible = true;
            visible();
        }

        #endregion

        #region CaseMang

        private void tabPageCaseMang_Enter(object sender, EventArgs e)
        {
            panelCaseMang.Visible = false;
        }

        private void btnFindCase_Click(object sender, EventArgs e)
        {
            panelCaseMang.Visible = true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            panelCaseMang.Visible = false;
            SqlConnection cn = new SqlConnection(con);
            cn.Open();
            try
            {
                try
                {
                    int id = int.Parse(txtShowCase.Text);
                    SqlDataAdapter da = new SqlDataAdapter("Select * From Case_data Where Case_ID =" + id + "", cn);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Case_Data");
                    DataGradeCase.DataSource = ds.Tables["Case_Data"];
                }
                catch (Exception)
                {
                    MessageBox.Show("Please, Add case ID", "Some Error Happened ");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Some Error Happened ", ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }
        
        private void btnCheckCase_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtShowCase.Text);
            int age, childNum, income, expeness, debts;
            SqlConnection cn = new SqlConnection(con);
            cn.Open();
            cmd = new SqlCommand("select *from Case_data where Case_ID="+id+"", cn);
            dr = cmd.ExecuteReader();
            dr.Read();
            age = (int)dr["Age"];
            childNum = (int)dr["Child_Number"];
            income = (int)dr["Income"];
            expeness = (int)dr["Expness"];
            debts = (int)dr["Debts"];

            if (age>18 && age<55 && childNum>1 && income>500 && income <=2500 && debts<25000 && (expeness-income) >= 500)
            {
                rdbAccept.Checked = true;
            }
            else
                rdbRefuse.Checked = true;
        }

        private void btnCheckDonation_Click(object sender, EventArgs e)
        {
            int total=0;
            SqlConnection cn = new SqlConnection(con);
            cn.Open();
            cmd = new SqlCommand("select SUM(Donation) as Total from Doner", cn);
            dr = cmd.ExecuteReader();
            dr.Read();
            total = (int)dr["Total"];
            if(total>30000)
            {
                rdbTrue.Checked = true;
            }
            else
            {
                rdbFalse.Checked = true;
            }
        }

        private void btnSendProject_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(con);

            if (rdbTrue.Checked == true && rdbAccept.Checked == true)
            {
                MessageBox.Show("The Case Accepted, and project will send ", "About Project", MessageBoxButtons.OK, MessageBoxIcon.Information);
                try
                {
                    
                    int id = int.Parse(txtShowCase.Text);
                    
                    cmd = new SqlCommand("Insert into Case_Situation(Case_ID,Accepted) values( " + id + ",'Accepted')", cn);
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Added Successfuly", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SqlCommand cmda = new SqlCommand("Insert into Doner(Donation) values (" + (-30000) + ") ", cn);
                    cmda.ExecuteNonQuery();

                    
                    MessageBox.Show("Deduction from Donation", "Deduction", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtShowCase.Clear();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message, "Some Error Happened ");
                }
                finally
                {
                    cn.Close();
                }
            }
            else if (rdbTrue.Checked == false && rdbAccept.Checked == true)
            {
                MessageBox.Show("There is a shortage in Donation", "About Project", MessageBoxButtons.OK, MessageBoxIcon.Information);
                try
                {
                    int id = int.Parse(txtShowCase.Text);
                    cmd = new SqlCommand("Insert into Case_Situation(Case_ID,Wating) values( " + id + ",'Wating')", cn);
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Added Successfuly", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtShowCase.Clear();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message, "Some Error Happened ");
                }
                finally
                {
                    cn.Close();
                }
            }
            else
            {
                MessageBox.Show("The Case Refused", "About Project", MessageBoxButtons.OK, MessageBoxIcon.Information);
                try
                {
                    int id = int.Parse(txtShowCase.Text);
                    cmd = new SqlCommand("Insert into Case_Situation(Case_ID,Refuse) values( " + id + ",'Refuse')", cn);
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Added Successfuly", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtShowCase.Clear();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message, "Some Error Happened ");
                }
                finally
                {
                    cn.Close();
                }
            }
        }
        #endregion


        #region Rebort

        private void btnWCase_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(con);
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Case_data INNER JOIN Case_Situation ON Case_Situation.Case_ID=Case_data.Case_ID And Wating = 'Wating' ", cn);
                DataSet ds = new DataSet();
                da.Fill(ds, "Case_Situation");
                DataGradeRebort.DataSource = ds.Tables["Case_Situation"];
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Some Error Happened ", ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }
        private void btnACase_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(con);
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT  * FROM Case_data INNER JOIN Case_Situation ON Case_Situation.Case_ID=Case_data.Case_ID And Accepted = 'Accepted' ", cn);
                DataSet ds = new DataSet();
                da.Fill(ds, "Case_Situation");
                DataGradeRebort.DataSource = ds.Tables["Case_Situation"];
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Some Error Happened ", ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }
        private void btnRCase_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(con);
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT  * FROM Case_data INNER JOIN Case_Situation ON Case_Situation.Case_ID=Case_data.Case_ID And Refuse = 'Refuse' ", cn);
                DataSet ds = new DataSet();
                da.Fill(ds, "Case_Situation");
                DataGradeRebort.DataSource = ds.Tables["Case_Situation"];
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Some Error Happened ", ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        #endregion



    }
 }
