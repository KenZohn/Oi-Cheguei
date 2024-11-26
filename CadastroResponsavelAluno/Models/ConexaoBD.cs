using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroResponsavelAluno.Models
{
    public class ConexaoBD
    {
        private SQLiteConnection conn;
        private string stringConexao = "Data Source=" + System.IO.Path.Combine(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName) + "/ChegouBD.db";

        public ConexaoBD()
        {
            conn = new SQLiteConnection(stringConexao);
        }

        public SQLiteConnection AbrirConexao()
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            return conn;
        }

        public void FecharConexao()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }
    }
}
