using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentResults;

namespace Alura.Adopet.Console.Comandos
{
    public interface IComando
    {
        Task<Result> ExecutarAsync(string[] args);
    }
}