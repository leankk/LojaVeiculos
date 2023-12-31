﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace LojaVeiculos
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
            
        }

        //método para mostrar as telas no panel
        public void SwitchScreens(object menu)
        {
            if (this.pnConteudo.Controls.Count > 0)
                this.pnConteudo.Controls.RemoveAt(0);
            Form newForm = menu as Form;
            newForm.TopLevel = false;
            newForm.Dock = DockStyle.Fill;
            this.pnConteudo.Controls.Add(newForm);
            this.pnConteudo.Tag = newForm;
            newForm.Show();
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Bem vindo(a) ao Sistema de Controle da AlphaSpeed!", "Bem vindo(a)",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            lblUser.Text = frmLogin.UserConnected;
        }

        private void btnTroca_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja trocar de usuário?", "Trocar Usuário",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                frmLogin objlog = new frmLogin();
                objlog.Show();
                this.Close();
            }
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            SwitchScreens(new frmCliente());
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            SwitchScreens(new frmUsuarios());
        }

        private void btnVeiculos_Click(object sender, EventArgs e)
        {
            SwitchScreens(new frmVeiculos());
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente sair?", "Sair",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnInicio_MouseEnter(object sender, EventArgs e)
        {
            btnInicio.BackColor = Color.FromArgb(25, 25, 25);
        }

        private void btnCliente_MouseEnter(object sender, EventArgs e)
        {
            btnCliente.BackColor = Color.FromArgb(25, 25, 25);
        }

        private void btnTroca_MouseEnter(object sender, EventArgs e)
        {
            btnTroca.BackColor = Color.FromArgb(25, 25, 25);
        }

        private void btnVeiculos_MouseEnter(object sender, EventArgs e)
        {
            btnVeiculos.BackColor = Color.FromArgb(25, 25, 25);
        }

        private void btnInicio_MouseLeave(object sender, EventArgs e)
        {
            btnInicio.BackColor = Color.Transparent;
        }

        private void btnCliente_MouseLeave(object sender, EventArgs e)
        {
            btnCliente.BackColor = Color.Transparent;
        }

        private void btnTroca_MouseLeave(object sender, EventArgs e)
        {
            btnTroca.BackColor = Color.Transparent;
        }

        private void btnVeiculos_MouseLeave(object sender, EventArgs e)
        {
            btnVeiculos.BackColor = Color.Transparent;
        }
    }
}
