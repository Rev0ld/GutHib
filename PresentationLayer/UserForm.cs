using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ServiceLayer;
using BusinessLayer;

namespace PresentationLayer
{
    public partial class UserForm : Form
    {

        private DBManager<User, int> dBManager;
        private User selectedUser;

        public UserForm()
        {
            InitializeComponent();
            dBManager = new DBManager<User, int>(DBContextManager.CreateUserContext
                                                (DBContextManager.CreateContext()));

            LoadUsers();
        }

        private void createBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedUser != null)
                {
                    MessageBox.Show("You can't create duplicated users!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (ValidateData())
                {
                    
                    string firstName = fNameTxtBox.Text;
                    string lastName = lNameTxtBox.Text;
                    byte age = Convert.ToByte(ageBox.Value);
                    string userName = userTxtBox.Text;
                    string password = passwordTxtBox.Text;
                    string eMail = emailTxtBox.Text;

                    User user = new User(firstName, lastName, age, userName, password, eMail);

                    dBManager.Create(user);
                    MessageBox.Show("User created successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadUsers();

                    ClearData();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        } //done

        private void updateBtn_Click(object sender, EventArgs e)
        {
            if (ValidateData())
            {
                User user = new User(selectedUser.ID, fNameTxtBox.Text, lNameTxtBox.Text, Convert.ToByte(ageBox.Value), userTxtBox.Text, passwordTxtBox.Text, emailTxtBox.Text);
                dBManager.Update(user);

                MessageBox.Show("User updated successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadUsers();

                ClearData();

            }
            else 
            {
                MessageBox.Show("First name, Last name, age, Username, Password and Email required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        } //done

        private void exitBtn_Click(object sender, EventArgs e) 
        {
            this.Close();
        }  //done

        private void userDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = userDataGridView.Rows[e.RowIndex];

            selectedUser = row.DataBoundItem as User;

            fNameTxtBox.Text = selectedUser.FirstName;
            lNameTxtBox.Text = selectedUser.LastName;
            ageBox.Value = selectedUser.Age;
            userTxtBox.Text = selectedUser.UserName;
            passwordTxtBox.Text = selectedUser.Password;
            emailTxtBox.Text = selectedUser.EMail;

        } //done

        private void LoadUsers()
        {
            userDataGridView.DataSource = dBManager.ReadAll();
        } //done

        private bool ValidateData() 
        {
            if (fNameTxtBox.Text != string.Empty && lNameTxtBox.Text != string.Empty && userTxtBox.Text != string.Empty && passwordTxtBox.Text != string.Empty && emailTxtBox.Text != string.Empty)
            {
                return true;
            }
            return false;


        } //done

        private void ClearData() 
        {
            fNameTxtBox.Text = string.Empty;
            lNameTxtBox.Text = string.Empty;
            ageBox.Value = ageBox.Minimum;
            userTxtBox.Text = string.Empty;
            passwordTxtBox.Text = string.Empty;
            emailTxtBox.Text = string.Empty;

            selectedUser = null;

        } //done

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (selectedUser != null)
            {
                dBManager.Delete(selectedUser.ID);

                LoadUsers();

                ClearData();
            }
            else 
            {
                MessageBox.Show("You must select user!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        //useless stuff i missclicked and added here and i cant remove them without it breaking, pls sent help

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        
    }
}
