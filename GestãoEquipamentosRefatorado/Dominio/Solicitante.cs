using System;
using System.Collections.Generic;
using System.Text;
using GestaoEquipamentos.ConsoleApp;

namespace GestaoEquipamentos.ConsoleApp.Dominio
{
    public class Solicitante
    {
        public int id;
        public string nome;
        public string email;
        public int NumeroTelefone;

      public Solicitante()
       {
            id = GeradorId.GerarIdSolicitante();
       }
        public Solicitante(int idSelecionado)
        {
            id = idSelecionado;
        }

        public string Validar()
        {
            string resultadoValidacao = "";

            if (string.IsNullOrEmpty(nome))
                resultadoValidacao += "O campo Nome é obrigatório \n";

            if (nome.Length < 6)
                resultadoValidacao += "O campo Nome não pode ter menos de 6 letras \n";

            if (string.IsNullOrEmpty(resultadoValidacao))
                resultadoValidacao = "EQUIPAMENTO_VALIDO";

            return resultadoValidacao;
        }
        public override bool Equals(object obj)
        {
            Solicitante solictante = (Solicitante)obj;

            if (id == solictante.id)
                return true;
            else
                return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(id, nome, email, NumeroTelefone);
        }
    }

}
