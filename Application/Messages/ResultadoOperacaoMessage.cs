using System;
using System.Collections.Generic;
using System.Text;

namespace Hotelaria.Application.Messages
{
    public static class ResultadoOperacaoMessage
    {
        public static readonly string Sucesso = "Operação concluida com sucesso.";

        public static readonly string NaoEncontrado = "Entidade não encontrada.";

        public static readonly string RequisicaoInvalida = "Requisição inválida.";
    }
}
