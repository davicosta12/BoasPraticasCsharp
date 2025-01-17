using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alura.Adopet.Console.Modelos;

namespace Alura.Adopet.Console.Utils
{
    public class LeitorDeArquivo
    {
        private readonly string caminhoArquivo;

        public LeitorDeArquivo(string caminhoDoArquivo)
        {
            this.caminhoArquivo = caminhoDoArquivo;
        }

        public IEnumerable<Pet>? RealizaLeitura()
        {
            List<Pet> listaDePet = new();
            if (string.IsNullOrEmpty(this.caminhoArquivo)) return null;
            using (StreamReader sr = new StreamReader(this.caminhoArquivo))
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