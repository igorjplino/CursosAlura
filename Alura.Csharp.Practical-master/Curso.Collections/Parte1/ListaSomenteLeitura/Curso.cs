using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaSomenteLeitura
{
    class Curso
    {
        private IList<Aula> _aulas;

        private IDictionary<int, Aluno> _alunosDict;
        private IList<Aluno> _alunos;

        public Curso(string nome, string instrutor)
        {
            Nome = nome;
            Instrutor = instrutor;

            _aulas = new List<Aula>();
            _alunos = new List<Aluno>();
            _alunosDict = new Dictionary<int, Aluno>();
        }

        public string Nome { get; set; }
        public string Instrutor { get; set; }
        public int TempoTotal
        {
            get
            {
                return Aulas.Sum(o => o.Tempo);
            }
        }
        public IList<Aula> Aulas
        {
            get
            {
                return new ReadOnlyCollection<Aula>(_aulas);
            }
        }
        public IList<Aluno> Alunos
        {
            get
            {
                return new ReadOnlyCollection<Aluno>(_alunos.ToList());
            }
        }

        /// <summary>
        /// Matricular aluno no curso
        /// </summary>
        /// <param name="aluno">Aluno a ser matriculado</param>
        /// <exception cref="ArgumentNullException">Exceção lançada quando o argumento <paramref name="aluno"/> é nulo.</exception>
        internal void Matricular(Aluno aluno)
        {
            if (aluno == null)
            {
                throw new ArgumentNullException(nameof(aluno), "Não é permitido adicionar uma aula Nula");
            }

            if (EstaMatriculado(aluno))
            {
                throw new ArgumentException($"Aluno '{aluno.Nome}' já está matriculado");
            }

            ///
            ///Como Aluno é do tipo ISet, não preciso me preocupar em checar se ele já existe

            _alunos.Add(aluno);
            _alunosDict.Add(aluno.Matricula, aluno);
        }

        /// <summary>
        /// Adicionar aula no curso
        /// </summary>
        /// <param name="aula">Aula a ser adicionada</param>
        /// <exception cref="ArgumentNullException">Exceção lançada quando o argumento <paramref name="aula"/> é nulo.</exception>
        /// <exception cref="ArgumentException">Exceção lançada quando a Aula já existe no Curso.</exception>
        internal void AdicionarAula(Aula aula)
        {
            if (aula == null)
            {
                throw new ArgumentNullException(nameof(aula), "Não é permitido adicionar uma aula Nula");
            }

            if (_aulas.Any(o => o.Titulo.Equals(aula.Titulo, StringComparison.OrdinalIgnoreCase)))
            {
                throw new ArgumentException($"Aula '{aula.Titulo}' já existente no curso", nameof(aula));
            }

            _aulas.Add(aula);
        }

        internal bool EstaMatriculado(Aluno aluno)
        {
            return _alunos.Contains(aluno);
        }

        internal Aluno BuscarMatriculado(int matricula)
        {
            if (_alunosDict.TryGetValue(matricula, out Aluno aluno))
            {
                return aluno;
            }

            return null;
        }

        public override string ToString()
        {
            var aulas = string.Join(", ", Aulas);
            return $"Curso: {Nome} | Tempo: {TempoTotal} | Aulas: {aulas}";
        }
    }
}
