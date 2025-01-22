using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alura.Adopet.Console.Modelos;

namespace Alura.Adopet.Console.Utils
{
    public static class PetAPartirDoCsv
    {
        public static Pet ConverteDoTexto(this string? linha)
        {
            if (linha is null) throw new ArgumentNullException("Texto não pode ser nulo!");
            if (string.IsNullOrEmpty(linha)) throw new ArgumentException("Texto não pode ser vazio!");

            string[] propriedades = linha.Split(';');
            if (propriedades.Length != 3) throw new ArgumentException("Texto inválido!");

            string guid = propriedades[0];
            if (!Guid.TryParse(guid, out Guid petId)) throw new ArgumentException("Guid inválido!");

            if (!int.TryParse(propriedades[2], out int tipoPet) || tipoPet < 0 || tipoPet > 2) throw new ArgumentException("Tipo de Pet inválido!");

            return new Pet(petId, propriedades[1], int.Parse(propriedades[2]) == 1 ? TipoPet.Gato : TipoPet.Cachorro);
        }
    }
}