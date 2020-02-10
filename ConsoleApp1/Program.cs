
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //InsertPedido();
            ListaCliente();
            //ListaProduto();
            //ListaPedidios();
        }

        public static void InsertPedido()
        {
            var uri = "http://192.168.15.36:9000/pedidos";
            
            string dadosPOST = "id=7";
            dadosPOST = dadosPOST + "&clientes.id=1";
            dadosPOST = dadosPOST + "&clientes.nome=Antonio";
            dadosPOST = dadosPOST + "&produtos.id=1";
            dadosPOST = dadosPOST + "&produtos.descricao=TECLADO";
            dadosPOST = dadosPOST + "&produtos.valor=8190";
            dadosPOST = dadosPOST + "&totalPedido=14380";

            var dados = Encoding.UTF8.GetBytes(dadosPOST);
            var requisicaoWeb = WebRequest.CreateHttp(uri);
            
            requisicaoWeb.Method = "POST";
            requisicaoWeb.ContentType = "application/x-www-form-urlencoded";
            requisicaoWeb.ContentLength = dados.Length;
            requisicaoWeb.UserAgent = "RequisicaoWebDemo";

            using (var stream = requisicaoWeb.GetRequestStream())
            {
                stream.Write(dados, 0, dados.Length);
                stream.Close();
            }

            using (var resposta = requisicaoWeb.GetResponse())
            {
                var streamDados = resposta.GetResponseStream();
                StreamReader reader = new StreamReader(streamDados);
                object objResponse = reader.ReadToEnd();
                
            }
        }

        public static void ListaCliente()
        {
            var uri = "http://192.168.15.36:9000/clientes";
            WebRequest request = (HttpWebRequest)WebRequest.Create(uri);

            var requisicaoWeb = WebRequest.CreateHttp(uri);
            requisicaoWeb.Method = "GET";
            requisicaoWeb.UserAgent = "RequisicaoWebDemo";

            using (var resposta = requisicaoWeb.GetResponse())
            {
                var streamDados = resposta.GetResponseStream();
                StreamReader reader = new StreamReader(streamDados);
                object objResponse = reader.ReadToEnd();
                Console.WriteLine(objResponse.ToString());
                Console.ReadLine();
                streamDados.Close();
                resposta.Close();
            }
        }

        public static void ListaProduto()
        {
            var uri = "http://192.168.15.36:9000/produtos";
            WebRequest request = (HttpWebRequest)WebRequest.Create(uri);

            var requisicaoWeb = WebRequest.CreateHttp(uri);
            requisicaoWeb.Method = "GET";
            requisicaoWeb.UserAgent = "RequisicaoWebDemo";

            using (var resposta = requisicaoWeb.GetResponse())
            {
                var streamDados = resposta.GetResponseStream();
                StreamReader reader = new StreamReader(streamDados);
                object objResponse = reader.ReadToEnd();
                Console.WriteLine(objResponse.ToString());
                Console.ReadLine();
                streamDados.Close();
                resposta.Close();
            }
        }

        public static void ListaPedidios()
        {
            var uri = "http://192.168.15.36:9000/pedidos";
            WebRequest request = (HttpWebRequest)WebRequest.Create(uri);

            var requisicaoWeb = WebRequest.CreateHttp(uri);
            requisicaoWeb.Method = "GET";
            requisicaoWeb.UserAgent = "RequisicaoWebDemo";

            using (var resposta = requisicaoWeb.GetResponse())
            {
                var streamDados = resposta.GetResponseStream();
                StreamReader reader = new StreamReader(streamDados);
                object objResponse = reader.ReadToEnd();
                Console.WriteLine(objResponse.ToString());
                Console.ReadLine();
                streamDados.Close();
                resposta.Close();
            }
        }
    }
}
