using GestaoEquipamentos.ConsoleApp.Dominio;
using System;

namespace GestaoEquipamentos.ConsoleApp.Controladores
{
     public  class ControladorSolicitante : ControladorBase
    {
        public string RegistrarSolicitante(int id, string nome, string email, int numeroTelefone)
        {
            Solicitante solicitante = null;

            int posicao;

            if (id == 0)
            {
                solicitante = new Solicitante();
                posicao = ObterPosicaoVaga();
            }
            else
            {
                posicao = ObterPosicaoOcupada(new Solicitante(id));
                solicitante = (Solicitante)registros[posicao];
            }

            solicitante.nome = nome;
            solicitante.email = email;
            solicitante.NumeroTelefone = numeroTelefone;

            string resultadoValidacao = solicitante.Validar();

            if (resultadoValidacao == "Solicitante_VALIDO")
                registros[posicao] = solicitante;

            return resultadoValidacao;
        }

        public Solicitante SelecionarSolicitantePorId(int id)
        {
            return (Solicitante)SelecionarRegistroPorId(new Solicitante(id));
        }

        public bool ExcluirSolicitante(int idSelecionado)
        {
            return ExcluirRegistro(new Solicitante(idSelecionado));
        }

        public Solicitante[] SelecionarTodosSolicitantes()
        {
            Solicitante[] solicitantesAux = new Solicitante[QtdRegistrosCadastrados()];

            Array.Copy(SelecionarTodosRegistros(), solicitantesAux, solicitantesAux.Length);

            return solicitantesAux;
        }

    }
}