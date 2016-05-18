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
    public partial class AñadirMascota : Form
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
        public String mascota;
        private String hora;
        private String descripcion;
        public AñadirMascota()
        {
            InitializeComponent();
            connStr = "Server=localhost; Database=clinica; Uid=root; Pwd=root; Port=3306";
            conn = new MySqlConnection(connStr);
            conn.Open();
        }

        private void AñadirMascota_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            hora = textBox5.Text+"-"+textBox6.Text+"-"+textBox7.Text+" "+textBox1.Text+":"+textBox3.Text+":"+textBox4.Text;
            descripcion = textBox2.Text;
            sentencia_SQL = "INSERT into visitas(mascota, hora, descripcion) values('"+mascota+"','"+hora+"','"+descripcion+"')";
            comando = new MySqlCommand(sentencia_SQL, conn);
            comando.ExecuteNonQuery();
            conn.Close();
            this.Close();
        }
    }
}
