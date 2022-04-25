using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            Controle cad = new Controle();
            DateTime registro = DateTime.Now;
            cad.Cadastrar(txNome.Text, txCpf.Text, txTelefone.Text, txNascimento.Text, txCep.Text, txEndereco.Text, txComplemento.Text, txNumero.Text, txVacina.Text, txLote.Text, registro.ToString());

            MessageBox.Show(cad.mensagem);
        }

        private void btnConsultarTodos_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            Controle cons = new Controle();
            dt = cons.Consultar();
            dataGridView1.DataSource = dt;
        }

        private void btnConsultarNomeCpf_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            Controle cons = new Controle();
            dt = cons.ConsultarCpf(txCpf.Text, txNome.Text);
            dataGridView1.DataSource = dt;

        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            Controle del = new Controle();
            del.Deletar(txCpf.Text);
            MessageBox.Show(del.mensagem);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "RegistraVac";
        }
    }
}
