using Alura.Adopet.Console.Modelos;

namespace Alura.Adopet.Console.Utils
{
    public class LeitorDeArquivo
    {
        private string caminhoArquivo;

        public LeitorDeArquivo(string caminhoDoArquivo)
        {
            this.caminhoArquivo = caminhoDoArquivo;
        }

        public virtual IEnumerable<Pet>? RealizaLeitura()
        {
            if (string.IsNullOrEmpty(this.caminhoArquivo)) return null;

            List<Pet> listaDePet = new();
            using (StreamReader sr = new(this.caminhoArquivo))
            {
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