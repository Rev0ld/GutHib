using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;
using ServiceLayer;

namespace PresentationLayer
{
    public partial class GenreForm : Form
    {

        private DBManager<Genre, int> dBManager;
        private Genre selectedGenre;

        public GenreForm()
        {
            InitializeComponent();

            dBManager = new DBManager<Genre, int>(DBContextManager.CreateGenreContext
                                                 (DBContextManager.CreateContext()));

            LoadGenre();
        }

        private void createBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedGenre != null) 
                {
                    MessageBox.Show("You can't create duplicated genre!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (ValidateData())
                {
                    s]
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {

        }

        private void exitBtn_Click(object sender, EventArgs e)
        {

        }

        private void genreDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void LoadGenre() 
        {
            genreDataGridView.DataSource = dBManager.ReadAll();
        }

        public bool ValidateData() 
        {
            if (nameTxtBox.Text != string.Empty) 
            {
                return true;
            }
            return false;
        }

        public void ClearData() 
        {
            nameTxtBox.Text = string.Empty;

            selectedGenre = null;
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (selectedGenre != null)
            {
                dBManager.Delete(selectedGenre.ID);

                LoadGenre();

                ClearData();
            }
            else 
            {
                MessageBox.Show("You must select a genre!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
