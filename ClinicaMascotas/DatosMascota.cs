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
    public partial class DatosMascota : Form
    {
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
        private DataTable visitas = new DataTable();
        public String mascotaElegida;

        public void cargaVisitas()
        {
            mascotaElegida = this.label9.Text;

            connStr = "Server=localhost; Database=clinica; Uid=root; Pwd=root; Port=3306";
            conn = new MySqlConnection(connStr);
            conn.Open();
            DataTable DT = (DataTable)dataGridView1.DataSource;
            if (DT != null)
                DT.Clear();
            sentencia_SQL = "Select hora, descripcion from visitas where mascota like " + mascotaElegida + ";";
            comando = new MySqlCommand(sentencia_SQL, conn);
            resultado = comando.ExecuteReader();
            visitas.Load(resultado);
            dataGridView1.DataSource = visitas;



            conn.Close();
        }

        public DatosMascota()
        {
            InitializeComponent();

           
            
//            conn.Open();
//            sentencia_SQL = "Select * from mascotas where id = '" + mascotaElegida + "'";
//            comando = new MySqlCommand(sentencia_SQL, conn);
//            resultado = comando.ExecuteReader();
        }

        private void DatosMascota_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AñadirMascota n = new AñadirMascota();
            n.mascota = this.label9.Text;
            n.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            DataTable DT = (DataTable)dataGridView1.DataSource;
            if (DT != null)
                DT.Clear();
            sentencia_SQL = "Select hora, descripcion from visitas where mascota like " + mascotaElegida + ";";
            comando = new MySqlCommand(sentencia_SQL, conn);
            resultado = comando.ExecuteReader();
            visitas.Load(resultado);
            dataGridView1.DataSource = visitas;



            conn.Close();
        }
    }
}
