using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alura.Adopet.Console.Modelos;

namespace Alura.Adopet.Console.Utils
{
    public class LeitorDeArquivo
    {
        public IEnumerable<Pet> RealizaLeitura(string caminhoDoArquivoASerLido)
        {
            List<Pet> listaDePet = new();
            using (StreamReader sr = new StreamReader(caminhoDoArquivoASerLido))
            {
                System.Console.WriteLine("----- Serão importados os dados abaixo -----");
                while (!sr.EndOfStream)
                {
                    string linha = sr.ReadLine();
                    Pet pet = linha.ConverteDoTexto();
                    listaDePet.Add(pet);
                }
            }

            return listaDePet;
        }
    }
}