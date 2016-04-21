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
    public partial class Login : Form
    {
        //Parametros de la conexion
        private string connStr;
        //Variable que maneja la conexion
        private MySqlConnection conn;
        //Consulta que quiero hacer a la base de datos
        private String sentencia_SQL;
        //Variable que sirve para crear la conexion
        private static MySqlCommand comando;
        private static MySqlCommand comandoB;
        //Guarda el resultado de la consulta
        private MySqlDataReader resultado;
        private String usuario;
        private String contraseña;
        private Boolean logUsuario;
        private Boolean logPass;
        public Boolean log;
        private String[][] datos; 
        public Login()
        {
            log = true;
            InitializeComponent();
            this.TopMost = true;
            connStr = "Server=localhost; Database=clinica; Uid=root; Pwd=root; Port=3306";
            conn = new MySqlConnection(connStr);
            conn.Open();
            sentencia_SQL = "Select * from veterinarios;";
            comando = new MySqlCommand(sentencia_SQL, conn);
            resultado = comando.ExecuteReader();
            
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            logUsuario = false;
            logPass = false;
            usuario = textBox1.Text;
            usuario.ToUpper();
            sentencia_SQL = "Select nombre from veterinarios where nombre like '" + usuario + "';";
            comando = new MySqlCommand(sentencia_SQL, conn);
            resultado = comando.ExecuteReader();
            if(resultado != null)
            {
                logUsuario = true;
            }
            conn.Close();
            connStr = "Server=localhost; Database=clinica; Uid=root; Pwd=root; Port=3306";
            conn = new MySqlConnection(connStr);
            conn.Open();
            contraseña = textBox2.Text;
            contraseña.ToUpper();
            sentencia_SQL = "Select nombre from veterinarios where nombre like '" + usuario + "';";
            comandoB = new MySqlCommand(sentencia_SQL, conn);
            resultado = comandoB.ExecuteReader();
            conn.Close();
            if (resultado != null)
            {
                logPass = true;
            }
            if (logUsuario && logPass)
            {
                log = true;
                conn.Close();
                this.Hide();
            }
            else
            {
                label3.Text = "El usuario o contraseña no son correctos";
            }
        }
    }
}
