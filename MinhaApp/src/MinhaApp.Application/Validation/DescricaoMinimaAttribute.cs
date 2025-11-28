using System.ComponentModel.DataAnnotations;

namespace MinhaApp.Application.Validation
{
    public class DescricaoMinimaAttribute : ValidationAttribute
    {
        private readonly int _minimo;

        public DescricaoMinimaAttribute(int minimo)
        {
            _minimo = minimo;
            ErrorMessage = $"A descrição deve ter ao menos {_minimo} caracteres.";
        }

        public override bool IsValid(object? value)
        {
            if (value == null) return false;
            var s = value as string;
            if (s == null) return false;
            return s.Trim().Length >= _minimo;
        }
    }
}
