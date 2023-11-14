using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LojaVeiculos
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

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
            
        }

        private void lblInicio_Click(object sender, EventArgs e)
        {
            SwitchScreens(new frmInicio());
        }

        private void lblCliente_Click(object sender, EventArgs e)
        {
            SwitchScreens(new frmCliente());
        }

        private void lblVeiculos_Click(object sender, EventArgs e)
        {
            SwitchScreens(new frmVeiculos());
        }

        private void lblConsulta_Click(object sender, EventArgs e)
        {
            SwitchScreens(new frmConsulta());
        }
        
        private void btnSair_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente sair?", "Sair",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
