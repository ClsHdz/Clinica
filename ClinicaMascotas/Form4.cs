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
    public partial class Form4 : Form
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
        private String apellido;
        private String nombre;
        private String dni;
        private String telefono;
        public Form4()
        {
            InitializeComponent();
            connStr = "Server=localhost; Database=clinica; Uid=root; Pwd=root; Port=3306";
            conn = new MySqlConnection(connStr);
            conn.Open();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dni = textBox1.Text;
            sentencia_SQL = "DELETE from mascotas WHERE pasaporte = " + dni + ";";
            comando = new MySqlCommand(sentencia_SQL, conn);
            comando.ExecuteNonQuery();
            conn.Close();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Close();
            this.Close();
        }
    }
}
