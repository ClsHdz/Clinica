using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaMascotas
{
    public partial class Form1 : Form
    {
        //Parametros de la conexion
        private string connStr;
        //Variable que maneja la conexion
        private MySqlConnection conn;
        //Consulta que quiero hacer a la base de datos
        private String sentencia_SQL;
        //Variable que sirve para crear la conexion
        private static MySqlCommand comando;
        //Guarda el resultado de la consulta
        private MySqlDataReader resultado;
        private String busqueda;
        private String nombre;
        private DataTable mascotas = new DataTable();
        private DataTable usuarios = new DataTable();
        

        public Form1()
        {
            InitializeComponent();
            connStr = "Server=localhost; Database=clinica; Uid=root; Pwd=root; Port=3306";
            conn = new MySqlConnection(connStr);
            
   //         m.Show();
            
   //         if (m.log == false)
  //          {
                
  //          }
  //          else
  //          {
               
  //          }
            
            
  //          sentencia_SQL = "Select * from usuarios";
  //          comando = new MySqlCommand(sentencia_SQL, conn);
  //          resultado = comando.ExecuteReader();
  //          usuarios.Load(resultado);
  //          dataGridView1.DataSource = usuarios;
  //          sentencia_SQL = "Select * from mascotas";
  //          comando = new MySqlCommand(sentencia_SQL, conn);
  //          resultado = comando.ExecuteReader();
  //          mascotas.Load(resultado);
  //          sentencia_SQL = "Select * from visitas";
  //          comando = new MySqlCommand(sentencia_SQL, conn);
  //          resultado = comando.ExecuteReader();
  //          visitas.Load(resultado);
            //dataGridView1.DataSource = usuarios;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            conn.Open();
                DataTable DT = (DataTable)dataGridView1.DataSource;
                if (DT != null)
                    DT.Clear();

                busqueda = textBox1.Text;
                busqueda.ToUpper();
                if (busqueda == "")
                {
                    sentencia_SQL = "Select * from usuarios";
                }
                else
                {
                    sentencia_SQL = "Select * from usuarios where nombre regexp '" + busqueda + "';";
                }
                comando = new MySqlCommand(sentencia_SQL, conn);
                resultado = comando.ExecuteReader();
                usuarios.Load(resultado);
                dataGridView1.DataSource = usuarios;
                
                //           dataGridView1.Rows.Clear();
                conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
                Form2 n = new Form2();
                n.Show();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
                Form3 n = new Form3();
                n.Show();
            
        }

        private void button6_Click(object sender, EventArgs e)
        {

            conn.Open();
                DataTable DT = (DataTable)dataGridView2.DataSource;
                if (DT != null)
                    DT.Clear();

                busqueda = textBox2.Text;
                busqueda.ToUpper();
                if (busqueda == "")
                {
                    sentencia_SQL = "Select * from mascotas";
                }
                else
                {
                    sentencia_SQL = "Select * from mascotas where nombre regexp '" + busqueda + "';";
                }
                comando = new MySqlCommand(sentencia_SQL, conn);
                resultado = comando.ExecuteReader();
                mascotas.Load(resultado);
                dataGridView2.DataSource = mascotas;
                conn.Close();
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
           
                NewPet n = new NewPet();
                n.Show();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
                Form4 n = new Form4();
                n.Show();
            
        }

        private void dataGridView2_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DatosMascota n = new DatosMascota();
            n.label9.Text = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
            n.label2.Text = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
            n.label7.Text = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
            n.label3.Text = dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
            n.label5.Text = dataGridView2.Rows[e.RowIndex].Cells[4].Value.ToString();
            n.label15.Text = dataGridView2.Rows[e.RowIndex].Cells[5].Value.ToString();
            n.label11.Text = dataGridView2.Rows[e.RowIndex].Cells[6].Value.ToString();
            n.label13.Text = dataGridView2.Rows[e.RowIndex].Cells[7].Value.ToString();

            n.cargaVisitas();
            n.Show();
        }
    }
}
