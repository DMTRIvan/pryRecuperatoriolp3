using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TOOLS_CBA
{
    public partial class Form1 : Form
    {
        const int ALTO = 30;
        const int ANCHO = 30;
        clsEstanterias est;
        DataTable tablaEstanterias;
        Datos d;
        Graphics gra;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                d = new Datos();
                gra = pictureBox1.CreateGraphics();
                est = new clsEstanterias();
                tablaEstanterias = est.getEstanteria();
            }
            catch (Exception)
            {
                MessageBox.Show("error en la base de datos");
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gra.Clear(Color.White);
            DataTable tEstanterias = d.getData("SELECT * FROM ESTANTERIAS");
            DataTable tProductos = d.getData("SELECT * FROM Productos");
            Int32 acumulador = 0;

            //Int32 codigoProd = Convert.ToInt32(textBox1);

            foreach (DataRow filaProductos in tProductos.Rows)
            {
                if (filaProductos["producto"].ToString() == textBox1.Text)
                {
                    label3.Text = filaProductos["nombre"].ToString();
                    break;
                }
            }

            foreach (DataRow filaEstanterias in tEstanterias.Rows)
            {
                if (filaEstanterias["producto"].ToString() == textBox1.Text)
                {
                    acumulador = acumulador + Convert.ToInt32(filaEstanterias["stock"]);
                    
                }
            }
            label5.Text = acumulador.ToString();


            //Aca empiezo a graficar:
            
            Font f1 = new Font("Verdana", 8, FontStyle.Bold);

            int x = 0;
            int y = 0;
            int nc = 0;

            for (y = 0; y <= pictureBox1.Height - ALTO; y = y + ALTO)
            {
                for (x = 0; x <= pictureBox1.Width - ANCHO; x = x + ANCHO)
                {
                    nc++;

                    gra.DrawRectangle(Pens.Black, x, y, ANCHO, ALTO);
                    gra.DrawString(nc.ToString(), f1, Brushes.Black, x, y);

                    foreach (DataRow filaEstanterias in tEstanterias.Rows)
                    {

                        if ((filaEstanterias["producto"].ToString() == textBox1.Text) && filaEstanterias["estanteria"].ToString() == nc.ToString())
                        {

                            gra.FillRectangle(Brushes.Red, x, y, ANCHO, ALTO);
                            gra.DrawString(nc.ToString(), f1, Brushes.Black, x, y);
                        }
                        

                    }


                    //foreach (DataRow filaEstanterias in tEstanterias.Rows)
                    //{

                    //    if ((filaEstanterias["producto"].ToString() == textBox1.Text) && filaEstanterias["estanteria"].ToString() == nc.ToString())
                    //    {

                    //        gra.DrawRectangle(Pens.Red, x, y, ANCHO, ALTO);
                    //        gra.DrawString(nc.ToString(), f1, Brushes.Red, x, y);
                    //    }
                    //    else
                    //    {
                    //        gra.DrawRectangle(Pens.Black, x, y, ANCHO, ALTO);
                    //        gra.DrawString(nc.ToString(), f1, Brushes.Black, x, y);
                    //    }


                    //}

                    //DataRow fco = tablaEstanterias.Rows.Find(nc);

                    //if (fco == null)
                    //{
                    //    gra.DrawRectangle(Pens.Black, x, y, ANCHO, ALTO);
                    //}
                    //else
                    //{

                    //    gra.DrawRectangle(Pens.Red, x, y, ANCHO, ALTO);
                    //    DataRow fcl = tcl.Rows.Find(fco["cliente"]);

                    //    gra.DrawString(fcl["nombre"].ToString(), f1, Brushes.White, x + 5, y + 20);

                    //}

                    //gra.DrawString(nc.ToString(), f1, Brushes.White, x + 15, y + 4);


                    //foreach (DataRow filaEstanterias in tEstanterias.Rows)
                    //{
                    //    if (filaEstanterias["producto"].ToString() == textBox1.Text)
                    //    {
                    //        foreach (DataRow filaEstanterias2 in tEstanterias.Rows)
                    //        {
                    //            if (filaEstanterias2["estanteria"].ToString() == nc.ToString() && filaEstanterias["producto"].ToString() == textBox1.Text)
                    //            {
                    //                gra.DrawRectangle(Pens.Red, x, y, ANCHO, ALTO);
                    //                gra.DrawString(nc.ToString(), f1, Brushes.Red, x, y);
                    //            }
                    //            else
                    //            {
                    //                gra.DrawRectangle(Pens.Black, x, y, ANCHO, ALTO);
                    //                gra.DrawString(nc.ToString(), f1, Brushes.Black, x, y);
                    //            }
                    //        }


                    //    }
                    //}

                    //DataRow fco = tco.Rows.Find(nc);

                    //if (fco == null)
                    //{
                    //    gra.FillEllipse(Brushes.Green, x, y, ANCHO, ALTO);
                    //}
                    //else
                    //{

                    //    gra.FillEllipse(Brushes.Red, x, y, ANCHO, ALTO);
                    //    DataRow fcl = tcl.Rows.Find(fco["cliente"]);

                    //    gra.DrawString(fcl["nombre"].ToString(), f1, Brushes.White, x + 5, y + 20);

                    //}

                    //gra.DrawString(nc.ToString(), f1, Brushes.White, x + 15, y + 4);
                }
            }




        }

        
        

    }
}           
