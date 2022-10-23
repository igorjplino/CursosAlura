using ByteBank.Core.Model;
using ByteBank.Core.Repository;
using ByteBank.Core.Service;
using ByteBank.View.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ByteBank.View
{
    public partial class MainWindow : Window
    {
        private readonly ContaClienteRepository r_Repositorio;
        private readonly ContaClienteService r_Servico;
        private CancellationTokenSource _cts;

        public MainWindow()
        {
            InitializeComponent();

            r_Repositorio = new ContaClienteRepository();
            r_Servico = new ContaClienteService();
        }

        private void BtnProcessar_Click(object sender, RoutedEventArgs e)
        {
            BtnProcessar.IsEnabled = false;
            AtualizarView(new List<string>(), TimeSpan.Zero);

            var contas = r_Repositorio.GetContaClientes();

            var inicio = DateTime.Now;

            ///
            /// Diferentes formas de processar

            //ProcessarContas_Thread(contas, inicio);
            ProcessarContas_ContinueWith(contas, inicio);
            //ProcessarContas(contas, inicio);
        }

        /// <summary>
        /// Método utilizado na conclusão do curso
        /// </summary>
        /// <param name="contas"></param>
        private async void ProcessarContas(IEnumerable<ContaCliente> contas, DateTime inicio)
        {
            _cts = new CancellationTokenSource();

            PgsProgresso.Maximum = contas.Count();

            LimparView();

            var progress = new Progress<String>(str =>
                PgsProgresso.Value++);
            //var byteBankProgress = new ByteBankProgress<String>(str =>
            //  PgsProgresso.Value++);

            try
            {
                var resultado = await ConsolidarContas(contas, progress, _cts.Token);

                var fim = DateTime.Now;
                AtualizarView(resultado, fim - inicio);
            }
            catch (OperationCanceledException)
            {
                TxtTempo.Text = "Operação cancelada pelo usuário";
            }
            finally
            {
                BtnProcessar.IsEnabled = true;
                BtnCancelar.IsEnabled = false;
            }
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            BtnCancelar.IsEnabled = false;
            _cts.Cancel();
        }

        private async Task<string[]> ConsolidarContas(IEnumerable<ContaCliente> contas, IProgress<string> reportadorDeProgresso, CancellationToken ct)
        {
            var tasks = contas.Select(conta =>
                Task.Factory.StartNew(() =>
                {
                    ct.ThrowIfCancellationRequested();

                    var resultadoConsolidacao = r_Servico.ConsolidarMovimentacao(conta, ct);

                    reportadorDeProgresso.Report(resultadoConsolidacao);

                    ct.ThrowIfCancellationRequested();
                    return resultadoConsolidacao;
                }, ct)
            );

            return await Task.WhenAll(tasks);
        }

        private void LimparView()
        {
            LstResultados.ItemsSource = null;
            TxtTempo.Text = null;
            PgsProgresso.Value = 0;
        }

        private void AtualizarView(IEnumerable<String> result, TimeSpan elapsedTime)
        {
            var tempoDecorrido = $"{ elapsedTime.Seconds }.{ elapsedTime.Milliseconds} segundos!";
            var mensagem = $"Processamento de {result.Count()} clientes em {tempoDecorrido}";

            LstResultados.ItemsSource = result;
            TxtTempo.Text = mensagem;
        }

        #region Outras formas de trabalhar com thread e tasks

        /// <summary>
        /// Dividir a quantidade de contas para processa-las em Threads separadas
        /// </summary>
        /// <param name="contas"></param>
        private void ProcessarContas_Thread(IEnumerable<ContaCliente> contas, DateTime inicio)
        {
            var resultado = new List<string>();

            var contasQuantidadePorThread = contas.Count() / 4;

            var contas_parte1 = contas.Take(contasQuantidadePorThread);
            var contas_parte2 = contas.Skip(contasQuantidadePorThread).Take(contasQuantidadePorThread);
            var contas_parte3 = contas.Skip(contasQuantidadePorThread * 2).Take(contasQuantidadePorThread);
            var contas_parte4 = contas.Skip(contasQuantidadePorThread * 3);

            #region Criando as threads

            Thread thread_parte1 = new Thread(() =>
            {
                foreach (var conta in contas_parte3)
                {
                    var resultadoProcessamento = r_Servico.ConsolidarMovimentacao(conta);
                    resultado.Add(resultadoProcessamento);
                }
            });
            Thread thread_parte2 = new Thread(() =>
            {
                foreach (var conta in contas_parte3)
                {
                    var resultadoProcessamento = r_Servico.ConsolidarMovimentacao(conta);
                    resultado.Add(resultadoProcessamento);
                }
            });
            Thread thread_parte3 = new Thread(() =>
            {
                foreach (var conta in contas_parte3)
                {
                    var resultadoProcessamento = r_Servico.ConsolidarMovimentacao(conta);
                    resultado.Add(resultadoProcessamento);
                }
            });
            Thread thread_parte4 = new Thread(() =>
            {
                foreach (var conta in contas_parte4)
                {
                    var resultadoProcessamento = r_Servico.ConsolidarMovimentacao(conta);
                    resultado.Add(resultadoProcessamento);
                }
            });

            #endregion

            thread_parte1.Start();
            thread_parte2.Start();
            thread_parte3.Start();
            thread_parte4.Start();

            while (thread_parte1.IsAlive || thread_parte2.IsAlive || thread_parte3.IsAlive || thread_parte4.IsAlive)
            {
                Thread.Sleep(250);
            }

            var fim = DateTime.Now;
            AtualizarView(resultado, fim - inicio);
            BtnProcessar.IsEnabled = true;
        }

        /// <summary>
        /// Processar contas utilizando o Factory.
        /// O Factory é gerenciado pelo TaskScheduler, que determina onde cada Task será processada
        /// </summary>
        /// <param name="contas"></param>
        private void ProcessarContas_ContinueWith(IEnumerable<ContaCliente> contas, DateTime inicio)
        {
            var taskSchedulerUI = TaskScheduler.FromCurrentSynchronizationContext();

            var resultado = new List<string>();
            
            var contasTarefas = contas.Select(conta =>
            {
                return Task.Factory.StartNew(() =>
                {
                    var resultadoConta = r_Servico.ConsolidarMovimentacao(conta);
                    resultado.Add(resultadoConta);
                });
            }).ToArray();

            // Aguardar todas as tarefas serem concluídas antes de continuar a execução do código
            //Task.WaitAll(contasTarefas);

            Task.WhenAll(contasTarefas)
            .ContinueWith(t =>
            {
                var fim = DateTime.Now;
                AtualizarView(resultado, fim - inicio);
            }, taskSchedulerUI)
            .ContinueWith(t =>
            {
                BtnProcessar.IsEnabled = true;
            }, taskSchedulerUI);
        }

        #endregion
    }
}
