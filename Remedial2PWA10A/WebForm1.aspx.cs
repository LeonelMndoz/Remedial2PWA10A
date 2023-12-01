using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ManejarSQL;
using static System.Net.Mime.MediaTypeNames;

namespace Remedial2PWA10A
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        ManejaSQL2023 sql;
        protected void Page_Load(object sender, EventArgs e)
        {
            sql = new ManejaSQL2023();
            sql.CadenaConex = @" Data Source= DESKTOP-FRD0LSO\SQLEXPRESS_2019;Initial Catalog=BDConstructora;Integrated Security=true";
            mostrarGridview();

        }

        public void mostrarGridviewControles()
        {
            string mensaje = "";
            SqlConnection conex = sql.ConectarBD(ref mensaje);
            string query = "SELECT * FROM Provee_De_Materi_Obra";
            GridView2.DataSource = sql.ConsultaDataSet(query, conex, ref mensaje);
            GridView2.DataBind();
            Label1.Text = mensaje;
        } 
        public void mostrarGridview()
        {
            string mensaje = "";
            SqlConnection conex = sql.ConectarBD(ref mensaje);
            string query = "SELECT pmo.Recibio, pmo.Entrega, pmo.Cantidad, pmo.Fecha_Entre, pmo.Precio, o.Nom_Obra, m.Descripcion_Mat, p.Razon FROM Provee_De_Materi_Obra as pmo INNER JOIN Obra as o ON o.ID_Obra = pmo.ID_Obra INNER JOIN Material as m ON m.ID_Material = pmo.ID_Material INNER JOIN Proveedor as p ON p.ID_Proveedor = pmo.ID_Proveedor;";
            GridView1.DataSource = sql.ConsultaDataSet(query, conex, ref mensaje);
            GridView1.DataBind();
            Label1.Text = mensaje;
        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    if (i == e.Row.Cells.Count - 1)
                    {
                        Button button = new Button();
                        button.ID = "agregar";
                        button.Text = "Agregar Registro";
                        button.Click += agregardatos;
                        e.Row.Cells[i].Controls.Add(button);
                    }
                    else
                    {
                        TextBox textBox = new TextBox();
                        textBox.ID = "tbd" + i;
                        e.Row.Cells[i].Controls.Add(textBox);
                    }
                }
            };

        }

        private void agregardatos(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow renglon = (GridViewRow)btn.NamingContainer;
            string Recibio = ((TextBox)renglon.FindControl("tbd0")).Text;
            string Entrega = ((TextBox)renglon.FindControl("tbd1")).Text;
            string Cantidad = ((TextBox)renglon.FindControl("tbd2")).Text;
            string Fecha_Entre = ((TextBox)renglon.FindControl("tbd3")).Text;
            string Precio = ((TextBox)renglon.FindControl("tbd4")).Text;
            string ID_Obra = ((TextBox)renglon.FindControl("tbd5")).Text;
            string ID_Material = ((TextBox)renglon.FindControl("tbd6")).Text;
            string ID_Proveedor = ((TextBox)renglon.FindControl("tbd7")).Text;
            string mensaje = "";
            SqlConnection conex = sql.ConectarBD(ref mensaje);
            string query = $"INSERT INTO " +
                $"Provee_De_Materi_Obra(Recibio, Entrega, Cantidad, Fecha_Entre, Precio, ID_Obra, ID_Material,ID_Proveedor) " +
                $"VALUES('{Recibio}', '{Entrega}', {Cantidad}, '{Fecha_Entre}', {Precio}, {ID_Obra}, {ID_Material}, {ID_Proveedor});";
            sql.ModificarBD(query, conex, ref mensaje);

            GridView1.Visible = true;
            GridView2.Visible = false;
            ButtonInsertar.Visible = true;
            ButtonDejarInsertar.Visible = false;
            mostrarGridview();
            Label1.Text = mensaje;

        }

        protected void ButtonDejarInsertar_Click(object sender, EventArgs e)
        {
            GridView1.Visible = true;
            GridView2.Visible = false;
            ButtonInsertar.Visible = true;
            ButtonDejarInsertar.Visible = false;
            mostrarGridview();
        }

        protected void ButtonInsertar_Click(object sender, EventArgs e)
        {
            GridView1.Visible = false;
            GridView2.Visible = true;
            ButtonDejarInsertar.Visible = true;
            ButtonInsertar.Visible = false;
            mostrarGridviewControles();
        }
    }
}