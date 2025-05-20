using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Projeto_Pet_shop
{
    internal class ClassMYSQL
    {
        public static string servidor = "Server=localhost;Database=loja_pet_shop;Uid=root;Pwd=";
        public static MySqlConnection conexao = new MySqlConnection(servidor);
        public static MySqlCommand comando = conexao.CreateCommand();
    }
}
