using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace UtilitiesApp {
    public partial class MainFrm : DevComponents.DotNetBar.Metro.MetroForm {
        public MainFrm() {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e) {
            string iSalt = phDESalt.Text,
                  iPass = phDEPass.Text;

            bool oState = BCrypt.CheckPassword(iPass, iSalt);

            phDEState.Text = "oState: " + oState;
            phDEState.ForeColor = oState ? Color.Green : Color.Red;
        }

        private void button1_Click(object sender, EventArgs e) {
            string iSalt = phTBSalt.Text,
                   iPass = phTBPass.Text,
                   gPassword = BCrypt.HashPassword(iPass, iSalt);

            phTBOut.Text = gPassword;
        }

        private void button2_Click(object sender, EventArgs e) {
            phTBSalt.Text = BCrypt.GenerateSalt();
        }

        private void buttonX1_Click(object sender, EventArgs e) {
            phTBSalt.Text = BCrypt.GenerateSalt();
        }

        private void buttonX2_Click(object sender, EventArgs e) {
            string iSalt = phTBSalt.Text,
                   iPass = phTBPass.Text,
                   gPassword = BCrypt.HashPassword(iPass, iSalt);

            phTBOut.Text = gPassword;
        }

        private void buttonX3_Click(object sender, EventArgs e) {
            string iSalt = phDESalt.Text,
                  iPass = phDEPass.Text;

            bool oState = BCrypt.CheckPassword(iPass, iSalt);

            phDEState.Text = "oState: " + oState;


            phDEState.ForeColor = oState ? Color.Green : Color.Red;
        }

        private void phDEPass_TextChanged(object sender, EventArgs e) {

        }
    }
}