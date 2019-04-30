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



       


        private void button3_Click(object sender, EventArgs e)
        {
            BibliotecaWebAPI.WebAPI webapi = new BibliotecaWebAPI.WebAPI();
            dataGridView1.DataSource = webapi.DameRutas((int)this.comboBoxCiudades.SelectedValue, (int)this.comboBoxCiudadesDestino.SelectedValue);



        }



        private void Form1_Load(object sender, EventArgs e)
        {
            BibliotecaWebAPI.WebAPI webapi = new BibliotecaWebAPI.WebAPI();

            this.comboBoxCiudades.ValueMember = "id";
            this.comboBoxCiudades.DisplayMember = "NombreCiudad";
            this.comboBoxCiudades.DataSource = webapi.DameCiudades();

            this.comboBoxCiudadesDestino.ValueMember = "id";
            this.comboBoxCiudadesDestino.DisplayMember = "NombreCiudad";
            this.comboBoxCiudadesDestino.DataSource = webapi.DameCiudades();
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }





        //        private void button2_Click(object sender, EventArgs e)
        //        {
        //            //List<Ciudad> model = null;
        //            HttpClient client = new HttpClient();
        //            client.BaseAddress = new Uri("http://localhost:55002/");


        //            //if (textBox1.Text != "" || textBox2.Text != "")
        //            //{
        //            //MessageBox.Show("Tienes que rellenar el Origen y el Destino");

        //            //}

        //            //else
        //            //{
        //            //HttpResponseMessage response = client.GetAsync("api/Rutas?Origen=" + textBox1.Text /*+ textBox2*/).Result;
        //            //Ruta rut = response.Content.ReadAsAsync<Ruta>().Result;
        //            //List<Ruta> rutlist = new List<Ruta>();
        //            //rutlist.Add(rut);
        //            //dataGridView1.DataSource = rutlist;
        //            //?search ={ "id":[{"operator":"=","value":1}]
        //            HttpResponseMessage response = client.GetAsync("api/Ciudades/" + textBox1.Text /*+ textBox2*/).Result;
        //            Ciudad rut =  response.Content.ReadAsAsync<Ciudad>().Result;
        //            List<Ciudad> rutlist = new List<Ciudad>();
        //            rutlist.Add(rut);
        //            dataGridView1.DataSource = rutlist;
        //            //var jsonString = response.Content.ReadAsStringAsync();
        //            //jsonString.Wait();
        //            //model = JsonConvert.DeserializeObject<List<Ciudad>>(jsonString.Result);









        //            //}


        //        }

        ////        private void textBox3_TextChanged(object sender, EventArgs e)
        ////        {
        ////            //DataView DV = new DataView(dbdataset);
        ////            //DV.RowFilter = string.Format("Origen LIKE '%{0}%'", textBox3.Text);
        ////            //dataGridView1.DataSource = DV;
        ////        }

        ////        private void textBox4_TextChanged(object sender, EventArgs e)
        ////        {
        ////           DataView DV = new DataView(dbdataset);
        ////           DV.RowFilter = string.Format("Destino LIKE '%{0}%'", textBox4.Text);
        ////dataGridView1.DataSource = DV;
        ////            //string colname = listBox2.SelectedItem.Text;
        ////            //string value = textBox1.Text;
        ////            //if (colname != null && dt.Columns[colname] != null)
        ////            //{
        ////            //    if ("Byte,Decimal,Double,Int16,Int32,Int64,SByte,Single,UInt16,UInt32,UInt64,".Contains(dt.Columns[colname].DataType.Name + ","))
        ////            //    {
        ////            //        dv.RowFilter = colname + "=" + value;
        ////            //    }
        ////            //    else if (dt.Columns[colname].DataType == typeof(string))
        ////            //    {
        ////            //        dv.RowFilter = string.Format(colname + " LIKE '%{0}%'", value);
        ////            //    }
        ////            //    else if (dt.Columns[colname].DataType == typeof(DateTime))
        ////            //    {
        ////            //        dv.RowFilter = colname + " = #" + value + "#";
        ////            //    }
        ////            //}
        ////        }

        //        private void button4_Click(object sender, EventArgs e)
        //        {


        //        }







        //crear un boton y meter el texbox3 y 4 dentro y probar si tambien funciona 

    }
}
