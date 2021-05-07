using GestaoEquipamentos.ConsoleApp.Controladores;
using GestaoEquipamentos.ConsoleApp.Dominio;
using System;

namespace GestaoEquipamentos.ConsoleApp.Telas
{
    public class TelaSolicitante : TelaBase
    {
        private ControladorSolicitante controladorSolicitante;
        public TelaSolicitante(ControladorSolicitante controlador)
            : base("Cadastro de Solicitantes")
        {
            controladorSolicitante = controlador;
        }

        public override void InserirNovoRegistro()
        {
            ConfigurarTela("Inserindo um novo Solicitante...");

            bool conseguiuGravar = GravarEquipamento(0);

            if (conseguiuGravar)
                ApresentarMensagem("Solicitante inserido com sucesso", TipoMensagem.Sucesso);
            else
            {
                ApresentarMensagem("Falha ao tentar inserir o Solicitante", TipoMensagem.Erro);
                InserirNovoRegistro();
            }
        }

        public override void EditarRegistro()
        {
            ConfigurarTela("Editando um Solicitante...");

            VisualizarRegistros();

            Console.WriteLine();

            Console.Write("Digite o número do Solicitante que deseja editar: ");
            int id = Convert.ToInt32(Console.ReadLine());

            bool conseguiuGravar = GravarEquipamento(id);

            if (conseguiuGravar)
                ApresentarMensagem("Solicitante editado com sucesso", TipoMensagem.Sucesso);
            else
            {
                ApresentarMensagem("Falha ao tentar editar o Solicitante", TipoMensagem.Erro);
                EditarRegistro();
            }
        }

        public override void ExcluirRegistro()
        {
            ConfigurarTela("Excluindo um Solicitante...");

            VisualizarRegistros();

            Console.WriteLine();

            Console.Write("Digite o número do Solicitante que deseja excluir: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            bool conseguiuExcluir = controladorSolicitante.ExcluirSolicitante(idSelecionado);

            if (conseguiuExcluir)
                ApresentarMensagem("Solicitante excluído com sucesso", TipoMensagem.Sucesso);
            else
            {
                ApresentarMensagem("Falha ao tentar excluir o Solicitante", TipoMensagem.Erro);
                ExcluirRegistro();
            }
        }

        public override void VisualizarRegistros()
        {
            ConfigurarTela("Visualizando equipamentos...");

            string configuracaColunasTabela = "{0,-10} | {1,-55} | {2,-35}";

            MontarCabecalhoTabela(configuracaColunasTabela);

            Solicitante[] solicitantes = controladorSolicitante.SelecionarTodosSolicitantes();

            if (solicitantes.Length == 0)
            {
                ApresentarMensagem("Nenhum Solicitante cadastrado!", TipoMensagem.Atencao);
                return;
            }

            for (int i = 0; i < solicitantes.Length; i++)
            {
                Console.WriteLine(configuracaColunasTabela,
                   solicitantes[i].id, solicitantes[i].nome, solicitantes[i].email, solicitantes[i].NumeroTelefone);
            }
        }

        #region métodos privados
        private static void MontarCabecalhoTabela(string configuracaoColunasTabela)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(configuracaoColunasTabela, "Id", "Nome", "Fabricante");

            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");

            Console.ResetColor();
        }

        private bool GravarEquipamento(int id)
        {
            string resultadoValidacao;
            bool conseguiuGravar = true;

            Console.Write("Digite o nome do Solicitante: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o email do Solicitante: ");
            string email = Console.ReadLine();

            Console.Write("Digite o número de telefone do Solicitante: ");
            int numero = Convert.ToInt32(Console.ReadLine());

            resultadoValidacao = controladorSolicitante.RegistrarSolicitante(
                id, nome, email, numero);

            if (resultadoValidacao != "SOLICITANTE_VALIDO")
            {
                ApresentarMensagem(resultadoValidacao, TipoMensagem.Erro);
                conseguiuGravar = false;
            }

            return conseguiuGravar;
        }



        #endregion
    }

}
