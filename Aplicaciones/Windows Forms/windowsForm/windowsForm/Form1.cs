using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http.Formatting;
using System.Net.Http;
using Newtonsoft.Json;

namespace windowsForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }
       DataTable dbdataset;


        private void button1_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:55002/");
            HttpResponseMessage response = client.GetAsync("api/Ciudades").Result;
            var Rutas = response.Content.ReadAsAsync<List<Ciudad>>().Result;
            dataGridView1.DataSource = Rutas;
            //List<IEnumerable<Ciudad>> rutlist = new List<IEnumerable<Ciudad>>();
            //rutlist.Add(Rutas);
            //dataGridView1.DataSource = rutlist;

        }


        private void button3_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:55002/");
            HttpResponseMessage response = client.GetAsync("api/Rutas").Result;
            var Rutas = response.Content.ReadAsAsync<IEnumerable<Ruta>>().Result;
            //List<IEnumerable<Ciudad>> rutlist = new List<IEnumerable<Ciudad>>();
            //rutlist.Add(Rutas);
            //dataGridView1.DataSource = rutlist;
            dataGridView1.DataSource = Rutas;

        }


        private void button2_Click(object sender, EventArgs e)
        {
            //List<Ciudad> model = null;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:55002/");


            //if (textBox1.Text != "" || textBox2.Text != "")
            //{
            //MessageBox.Show("Tienes que rellenar el Origen y el Destino");

            //}

            //else
            //{
            //HttpResponseMessage response = client.GetAsync("api/Rutas?Origen=" + textBox1.Text /*+ textBox2*/).Result;
            //Ruta rut = response.Content.ReadAsAsync<Ruta>().Result;
            //List<Ruta> rutlist = new List<Ruta>();
            //rutlist.Add(rut);
            //dataGridView1.DataSource = rutlist;
            //?search ={ "id":[{"operator":"=","value":1}]
            HttpResponseMessage response = client.GetAsync("api/Ciudades/" + textBox1.Text /*+ textBox2*/).Result;
            Ciudad rut =  response.Content.ReadAsAsync<Ciudad>().Result;

            //var jsonString = response.Content.ReadAsStringAsync();
            //jsonString.Wait();
            //model = JsonConvert.DeserializeObject<List<Ciudad>>(jsonString.Result);
           
            List<Ciudad> rutlist = new List<Ciudad>();
           rutlist.Add(rut);
            dataGridView1.DataSource = rutlist;

          
            
            
            
            
           
            //}


        }

//        private void textBox3_TextChanged(object sender, EventArgs e)
//        {
//            //DataView DV = new DataView(dbdataset);
//            //DV.RowFilter = string.Format("Origen LIKE '%{0}%'", textBox3.Text);
//            //dataGridView1.DataSource = DV;
//        }

//        private void textBox4_TextChanged(object sender, EventArgs e)
//        {
//           DataView DV = new DataView(dbdataset);
//           DV.RowFilter = string.Format("Destino LIKE '%{0}%'", textBox4.Text);
//dataGridView1.DataSource = DV;
//            //string colname = listBox2.SelectedItem.Text;
//            //string value = textBox1.Text;
//            //if (colname != null && dt.Columns[colname] != null)
//            //{
//            //    if ("Byte,Decimal,Double,Int16,Int32,Int64,SByte,Single,UInt16,UInt32,UInt64,".Contains(dt.Columns[colname].DataType.Name + ","))
//            //    {
//            //        dv.RowFilter = colname + "=" + value;
//            //    }
//            //    else if (dt.Columns[colname].DataType == typeof(string))
//            //    {
//            //        dv.RowFilter = string.Format(colname + " LIKE '%{0}%'", value);
//            //    }
//            //    else if (dt.Columns[colname].DataType == typeof(DateTime))
//            //    {
//            //        dv.RowFilter = colname + " = #" + value + "#";
//            //    }
//            //}
//        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            dbdataset = new DataTable();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'autobusesSeseDataSet.Ciudades' Puede moverla o quitarla según sea necesario.
            this.ciudadesTableAdapter.Fill(this.autobusesSeseDataSet.Ciudades);
            // TODO: esta línea de código carga datos en la tabla 'autobusesSeseDataSet.Rutas' Puede moverla o quitarla según sea necesario.
            this.rutasTableAdapter.Fill(this.autobusesSeseDataSet.Rutas);

        }

      



        //crear un boton y meter el texbox3 y 4 dentro y probar si tambien funciona 

    }
}
