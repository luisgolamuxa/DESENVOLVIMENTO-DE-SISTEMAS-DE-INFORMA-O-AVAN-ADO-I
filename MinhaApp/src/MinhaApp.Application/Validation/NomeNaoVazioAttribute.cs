using System.ComponentModel.DataAnnotations;

namespace MinhaApp.Application.Validation
{
    public class NomeNaoVazioAttribute : ValidationAttribute
    {
        public NomeNaoVazioAttribute()
        {
            ErrorMessage = "O nome não pode ser vazio ou apenas espaços.";
        }

        public override bool IsValid(object? value)
        {
            if (value == null) return false;
            var s = value as string;
            if (s == null) return false;
            return !string.IsNullOrWhiteSpace(s);
        }
    }
}
