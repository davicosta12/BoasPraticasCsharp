using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alura.Adopet.Console.Comandos
{
    public interface IComando
    {
        Task ExecutarAsync(string[] args);
    }
}