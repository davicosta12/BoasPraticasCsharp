using Alura.Adopet.Console.Modelos;
using FluentResults;

namespace Alura.Adopet.Console.Utils
{
    public class SuccessWithPets : Success
    {
        public IEnumerable<Pet> Data { get; }

        public SuccessWithPets(IEnumerable<Pet> data)
        {
            Data = data;
        }
    }
}