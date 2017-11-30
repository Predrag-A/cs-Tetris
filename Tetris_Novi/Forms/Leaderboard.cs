﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tetris_Novi.Classes;

namespace Tetris_Novi.Forms
{
    public partial class LeaderboardForm : Form
    {

        #region Attributes

        PlayerList list;

        #endregion

        #region Constructors

        public LeaderboardForm(PlayerList l)
        {
            list = l;
            list.List.Sort();            
            InitializeComponent();
        }

        #endregion

        #region Methods

        void LoadData()
        {
            data.DataSource = list.List.ToList();
            data.Columns[2].HeaderText = "Date";
            data.Columns[2].DefaultCellStyle.Format = "dd/MM/yyyy";
        }

        #endregion

        #region Events

        private void LeaderboardForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to clear the leaderboard?", "Confirm", 
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                list.List.Clear();
                list.Serialize("Leaderboard.xml");
                this.Close();
            }
        }        

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
    }
}
