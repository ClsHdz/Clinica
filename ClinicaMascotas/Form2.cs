using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaMascotas
{
    public partial class Form2 : Form
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
        public Form2()
        {
            InitializeComponent();
            connStr = "Server=localhost; Database=clinica; Uid=root; Pwd=root; Port=3306";
            conn = new MySqlConnection(connStr);
            conn.Open();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            nombre = textBox1.Text;
            apellido = textBox2.Text;
            dni = textBox3.Text;
            telefono = textBox4.Text;
            nombre = nombre.ToUpper();
            apellido = apellido.ToUpper();
            sentencia_SQL = "INSERT into usuarios values(" + dni + ",'" + nombre + "','" + apellido + "',"+telefono+");";
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
