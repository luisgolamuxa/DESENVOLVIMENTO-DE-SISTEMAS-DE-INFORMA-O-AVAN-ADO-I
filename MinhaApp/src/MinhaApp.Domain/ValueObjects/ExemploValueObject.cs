using System;

namespace MinhaApp.Domain.ValueObjects
{
    public class ExemploValueObject
    {
        public string Atributo1 { get; private set; }
        public int Atributo2 { get; private set; }

        public ExemploValueObject(string atributo1, int atributo2)
        {
            if (string.IsNullOrWhiteSpace(atributo1))
                throw new ArgumentException("Atributo1 não pode ser vazio.", nameof(atributo1));

            if (atributo2 < 0)
                throw new ArgumentOutOfRangeException(nameof(atributo2), "Atributo2 deve ser maior ou igual a zero.");

            Atributo1 = atributo1;
            Atributo2 = atributo2;
        }

        // Implementar métodos de igualdade e hashcode se necessário
        public override bool Equals(object obj)
        {
            if (obj is ExemploValueObject other)
            {
                return Atributo1 == other.Atributo1 && Atributo2 == other.Atributo2;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Atributo1, Atributo2);
        }
    }
}