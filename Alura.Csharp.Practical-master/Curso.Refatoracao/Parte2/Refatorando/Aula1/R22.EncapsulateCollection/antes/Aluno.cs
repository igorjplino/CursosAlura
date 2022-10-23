using System;
using System.Collections.Generic;
using System.Text;

namespace refatoracao.R22.EncapsulateCollection.antes
{
    class Programa
    {
        void Testar()
        {
            Aluno aluno = new Aluno();
            aluno.Cursos.Add(new Curso("JavaScript Básico"));
            aluno.Cursos.Add(new Curso("C# Intermediário"));
            aluno.Cursos.Add(new Curso("Java Avançado"));
        }
    }

    class Aluno
    {
        private readonly List<Curso> cursos;
        internal List<Curso> Cursos { get => cursos; }

        public Aluno()
        {
            cursos = new List<Curso>();
        }
    }

    class Curso
    {
        readonly string nome;
        public string Nome
        {
            get
            {
                return nome;
            }
        }

        public Curso(string nome)
        {
            this.nome = nome;
        }
    }
}
