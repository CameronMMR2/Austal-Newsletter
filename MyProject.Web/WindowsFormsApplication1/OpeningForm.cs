using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyProject.Business;
using MyProject.Data;


namespace MyProject.WinForm
{
    public partial class OpeningForm : Form
    {

        //Instantiate the business engine
        BusinessEngine businessEngine = new BusinessEngine();

        //Create Location for Group Boxes
        Point groupBoxLocation = new Point(12, 40);
            

        #region Constructor
        public OpeningForm()
        {
            InitializeComponent();
            AccountInformationGroupBox.Visible = false;
            LoadAccountEmails();
            LoadAccountPasswords();
            textBox4.PasswordChar = '*';
            textBox5.PasswordChar = '*';
        }
        #endregion

        #region Public Methods
                
      

        #endregion

        #region Private Methods

        #region LoadAccountEmails
        private void LoadAccountEmails() 
        {
            List<string> AccountEmails = businessEngine.GetAccountEmails();

            comboBox1.Items.Clear();

            foreach(var Email in AccountEmails)
            {
                comboBox1.Items.Add(Email);
            }

        }
        #endregion

        #region LoadAccountPasswords
        private void LoadAccountPasswords()
        {
            List<string> AccountPasswords = businessEngine.GetAccountPasswords();

            comboBox2.Items.Clear();

            foreach (var Password in AccountPasswords)
            {
                comboBox2.Items.Add(Password);
            }

        }
        #endregion 

        #region Get Account Information Navigation Button Press
        private void getAccountInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button2.Visible = false;
            CreateAccountGroupBox.Visible = false;
            AccountInformationGroupBox.Location = groupBoxLocation;
            AccountInformationGroupBox.Visible = true;
        }
        #endregion

        #region Create Account Wizard Button Press
        private void createAccountWizardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AccountInformationGroupBox.Visible = false;
            button2.Visible = true;
            CreateAccountGroupBox.Location = groupBoxLocation;
            CreateAccountGroupBox.Visible = true;
        }
        #endregion
        
        #region Exit Application Button
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region TextBox Key Up Events
        private void textBox4_KeyUp(object sender, KeyEventArgs e)
        {
            if (textBox4.Text != textBox5.Text)
            {
                label8.Visible = true;
                label8.Text = "Passwords Do Not Match!";
                label8.ForeColor = Color.Red;
            }
            else
            {
                label8.Visible = true;
                label8.Text = "Passwords Match!";
                label8.ForeColor = Color.Green;
            }
        }

        

        private void textBox5_KeyUp(object sender, KeyEventArgs e)
        {
            if (textBox4.Text != textBox5.Text)
            {
                label8.Visible = true;
                label8.Text = "Passwords Do Not Match!";
                label8.ForeColor = Color.Red;
            }
            else
            {
                label8.Visible = true;
                label8.Text = "Passwords Match!";
                label8.ForeColor = Color.Green;
            }
        }
        #endregion

        #region Create Account Button
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != null && textBox4.Text != null && textBox2.Text != null && textBox1.Text != null && textBox3.Text != "" && textBox4.Text != "" && textBox2.Text != "" && textBox1.Text != "")
            {

                bool state = businessEngine.AddAccount(textBox3.Text, textBox4.Text, textBox2.Text, textBox1.Text);

                if (state)
                {
                    LoadAccountEmails();
                    LoadAccountPasswords();
                    MessageBox.Show("Account and User Created!");
                }
            }
        }
        #endregion

        #endregion

    }
}
