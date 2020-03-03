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

namespace pjConexion1
{
    public partial class frmClientes : Form
    {
        public frmClientes()
        {
            InitializeComponent();
        }
        SqlConnection cn = new SqlConnection("Data Source=(local);Initial Catalog=Neptuno;Integrated Security=True");

        public void ListaClientes()
        {
            using (SqlDataAdapter DF = new SqlDataAdapter("Select * from Clientes", cn))
            {
                using (DataSet Da = new DataSet())
                {
                    //llenar el DataSet mediante el metodo Fill de AqlDataAparter
                    DF.Fill(Da, "Clientes");
                    //Mostrar los datos en el control DataGridView
                    dgClientes.DataSource = Da.Tables["Clientes"];

                    lblTotal.Text = Da.Tables["Clientes"].Rows.Count.ToString();
                }
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'neptunoDataSet.clientes' Puede moverla o quitarla según sea necesario.
            //this.clientesTableAdapter.Fill(this.neptunoDataSet.clientes);
            ListaClientes();
        }
    }
}
