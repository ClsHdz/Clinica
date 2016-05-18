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
        private DataTable usuarios = new DataTable();
        public Login()
        {
            log = false;
            logUsuario = false;
            logPass = false;
            InitializeComponent();
            this.TopMost = true;
            connStr = "Server=localhost; Database=clinica; Uid=root; Pwd=root; Port=3306";
            conn = new MySqlConnection(connStr);
            conn.Open();
            sentencia_SQL = "Select * from veterinarios;";
            comando = new MySqlCommand(sentencia_SQL, conn);
            resultado = comando.ExecuteReader();
            usuarios.Load(resultado);
            conn.Close();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
 //           connStr = "Server=localhost; Database=clinica; Uid=root; Pwd=root; Port=3306";
 //           conn = new MySqlConnection(connStr);
            conn.Open();

            usuario = textBox1.Text;
            usuario.ToUpper();
            contraseña = textBox2.Text;
            contraseña.ToUpper();
            sentencia_SQL = "Select nombre from veterinarios where nombre like '" + usuario + "' and contraseña like '" + contraseña + "';";
            comando = new MySqlCommand(sentencia_SQL, conn);
            resultado = comando.ExecuteReader();
            //            if (resultado != null)
            //            {
            //                logUsuario = true;
            //            }
            usuarios.Load(resultado);
            if (usuarios.Rows.Contains(usuario))
            {

                log = true;

            }
            conn.Close();
            comprobar();

            
        }

        private void comprobar()
        {
            if (log)
                {
                    label3.Text = "";
                    button1.DialogResult = DialogResult.OK;
                    
                }
            else
                {
                    label3.Text = "El usuario o contraseña no son correctos";
                    
                }
        }

        

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }

        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
