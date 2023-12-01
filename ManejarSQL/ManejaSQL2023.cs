using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManejarSQL
{
    public class ManejaSQL2023
    {
        public string CadenaConex { get; set; }

        public SqlConnection ConectarBD(ref string mensajesal)
        {
            SqlConnection Variable1 = new SqlConnection();
            Variable1.ConnectionString
                = CadenaConex;
            try
            {
                Variable1.Open();
                mensajesal = "Conexion Exitosa";
            }
            catch (Exception ex)
            {
                Variable1 = null;
                mensajesal = "Error: " + ex.Message;
            }
            return Variable1;
        }

        public Boolean ModificarBD(string sentenciaSQL,
            SqlConnection cnab, ref string msjsal)
        {
            Boolean salida = false;
            if (cnab != null)
            {
                SqlCommand vw = new SqlCommand();
                vw.Connection = cnab;
                vw.CommandText = sentenciaSQL;
                try
                {
                    vw.ExecuteNonQuery();
                    msjsal = "Modificación CORRECTA!!";
                    salida = true;
                }
                catch (Exception ex)
                {
                    msjsal = "Error: " + ex.Message;
                    salida = false;
                }
                cnab.Close();
                cnab.Dispose();
            }
            else
            {
                msjsal = "NO hay Conexión con la BD";
                salida = false;
            }
            return salida;
        }

        public SqlDataReader ConsultaDataReader(string query1,
            SqlConnection cnab2, ref string msjsal2)
        {
            SqlDataReader contenedor_sal = null;
            if (cnab2 != null)
            {
                SqlCommand mini = new SqlCommand();
                mini.Connection = cnab2;
                mini.CommandText = query1;
                try
                {
                    contenedor_sal = mini.ExecuteReader();
                    msjsal2 = "Consulta en Reader CORRECTA!!!";
                }
                catch (Exception ex)
                {
                    contenedor_sal = null;
                    msjsal2 = "ERROR: " + ex.Message;
                }
            }
            else
            {
                contenedor_sal = null;
                msjsal2 = "No hay Conexión con la BD";
            }
            return contenedor_sal;
        }

        public DataTable ConsultaDataSet(string query2, SqlConnection cnab3,
            ref string msj3)
        {
            DataSet bdvirtual = null;
            SqlCommand twizy = null;
            DataTable tablasalida = null;
            if (cnab3 != null)
            {
                twizy = new SqlCommand();
                twizy.Connection = cnab3;
                twizy.CommandText = query2;
                SqlDataAdapter kenworth = new SqlDataAdapter();
                bdvirtual = new DataSet();
                kenworth.SelectCommand = twizy;
                try
                {
                    kenworth.Fill(bdvirtual);
                    tablasalida = bdvirtual.Tables[0];
                    msj3 = "Consulta con DS Correcta!! ";

                }
                catch (Exception r)
                {
                    bdvirtual = null;
                    msj3 = "Error: " + r.Message;
                }
                cnab3.Close();
                cnab3.Dispose();
            }
            else
            {
                msj3 = "Sin Conexión a la BD no se puede ejecutar CONSULTA";
                bdvirtual = null;
            }
            return tablasalida;
        }
    }

}
