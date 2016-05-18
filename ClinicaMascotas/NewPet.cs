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
    public partial class NewPet : Form
    {
        int i = 0;
        bool comprobar = false;
        //Parametros de la conexion
        private string connStr;
        //Variable que maneja la conexion
        private MySqlConnection conn;
        //Consulta que quiero hacer a la base de datos
        private String sentencia_SQL;
        //Variable que sirve para crear la conexion
        private static MySqlCommand comando;
        private static MySqlCommand comando1;
        //Guarda el resultado de la consulta
        private MySqlDataReader resultado;
        private String propietario;
        private String nombre;
        private String pasaporte;
        private String telefono;
        private String fechaDia;
        private String fechaMes;
        private String fechaAño;
        private String fecha;
        private String especie;
        private String raza;
        private String chip;
        private char sexo;
        private DataTable propietarios = new DataTable();
        public NewPet()
        {
            InitializeComponent();
            connStr = "Server=localhost; Database=clinica; Uid=root; Pwd=root; Port=3306";
            conn = new MySqlConnection(connStr);
            conn.Open();
        }

        private void NewPet_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Close();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            comprobar = false;
            propietario = textBox2.Text;
            while(i < propietario.Length){
                if (propietario[i] == 1 || propietario[i] == 2 || propietario[i] == 3 || propietario[i] == 4 || propietario[i] == 5 || propietario[i] == 6 || propietario[i] == 7 || propietario[i] == 8 || propietario[i] == 9 || propietario[i] == 0)
                {
                    comprobar = true;
                }
                i++;
            }
            if (!comprobar)
            {
                sentencia_SQL = "Select dni from usuarios where dni like '" + propietario + "';";
                comando = new MySqlCommand(sentencia_SQL, conn);
                resultado = comando.ExecuteReader();
                propietarios.Load(resultado);
                if (propietarios.Rows.Count != 0)
                {
                    conn.Close();
                    conn = new MySqlConnection(connStr);
                    conn.Open();

                    nombre = textBox1.Text;
                    pasaporte = textBox3.Text;
                    fechaDia = textBox4.Text;
                    chip = textBox5.Text;
                    raza = textBox7.Text;
                    especie = textBox8.Text;
                    fechaAño = textBox9.Text;
                    fechaMes = textBox10.Text;
                    if (comboBox1.SelectedItem == "Macho")
                    {
                        sexo = 'M';
                    }
                    else if (comboBox1.SelectedItem == "Hembra")
                    {
                        sexo = 'F';
                    }
                    else
                    {
                        sexo = 'I';
                    }
                    propietario.ToUpper();
                    nombre = nombre.ToUpper();
                    raza = raza.ToUpper();
                    especie = especie.ToUpper();
                    fecha = fechaAño + "-" + fechaMes + "-" + fechaDia;

                    sentencia_SQL = "INSERT into mascotas values('" + pasaporte + "','" + nombre + "','" + sexo + "','" + especie + "','" + raza + "','" + chip + "','" + fecha + "','" + propietario + "');";
                    comando1 = new MySqlCommand(sentencia_SQL, conn);
                    comando1.ExecuteNonQuery();
                }
                else
                {
                    label11.Text = "El usuario debe ser el dni de uno ya existente";

                }
            }
            conn.Close();
            this.Close();
        }
    }
}
