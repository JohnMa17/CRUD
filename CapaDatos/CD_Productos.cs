using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class CD_Productos
    {
        private CD_Conexion conexion = new CD_Conexion();

        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        public DataTable Mostrar()
        {
            //TRANSACT SQL
            comando.Connection = conexion.Abrirconexion();
            comando.CommandText = "MostrarProductos";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;

        }

        public void Insertar(string nombre, string desc, string marca, double precio, int stock)
        {
            //PROCEDIMIENTO
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.Abrirconexion();
            comando.CommandText = "InsertarProductos";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Nombre", nombre);
            comando.Parameters.AddWithValue("@Desc", desc);
            comando.Parameters.AddWithValue("@Marca", marca);
            comando.Parameters.AddWithValue("@Precio", precio);
            comando.Parameters.AddWithValue("@Stock", stock);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

        public void Editar (string nombre, string desc, string marca, double precio, int stock, int Id)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.Abrirconexion();
            comando.CommandText = "EditarProductos";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Nombre", nombre);
            comando.Parameters.AddWithValue("@Desc", desc);
            comando.Parameters.AddWithValue("@Marca", marca);
            comando.Parameters.AddWithValue("@Precio", precio);
            comando.Parameters.AddWithValue("@Stock", stock);
            comando.Parameters.AddWithValue("@Id", Id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

        public void Eliminar(int Id)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.Abrirconexion();
            comando.CommandText = "EliminarProductos";
            comando.CommandType= CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdPro", Id);
            comando.ExecuteNonQuery();
        }
    }
}
