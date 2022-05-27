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
    public partial class GameForm : Form
    {
        private DBManager<Game, int> dBManager;
        private Game selectedGame;

        public GameForm()
        {
            InitializeComponent();

            dBManager = new DBManager<Game, int>(DBContextManager.CreateGameContext
                                                (DBContextManager.CreateContext()));

            LoadGames();
        }

        private void createBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedGame != null)
                {
                    MessageBox.Show("You can't create duplicated Game!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (ValidateData())
                {
                    string name = nameTxtBox.Text;

                    Game game = new Game(name);

                    dBManager.Create(game);
                    MessageBox.Show("Game created successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadGames();

                    ClearData();
                }
                else
                {
                    MessageBox.Show("Name is required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            if (ValidateData())
            {
                Game game = new Game(selectedGame.ID, nameTxtBox.Text);

                dBManager.Update(game);

                MessageBox.Show("Game updated successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadGames();

                ClearData();
            }
            else
            {
                MessageBox.Show("Name is required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = gameDataGridView.Rows[e.RowIndex];

            selectedGame = row.DataBoundItem as Game;

            nameTxtBox.Text = selectedGame.Name;
        }

        private void LoadGames() 
        {
            gameDataGridView.DataSource = dBManager.ReadAll();
        }

        private bool ValidateData() 
        {
            if (nameTxtBox.Text != string.Empty) 
            {
                return true;
            }
            return false;
        }

        private void ClearData() 
        {
            nameTxtBox.Text=string.Empty;

            selectedGame = null;
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (selectedGame != null)
            {
                dBManager.Delete(selectedGame.ID);

                LoadGames();

                ClearData();
            }
            else
            {
                MessageBox.Show("You must select game!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        //useless stuff i missclicked and added here and i cant remove them without it breaking, pls sent help

    }
}
