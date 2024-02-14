using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace OdontoAPI.Models
{
    public class DentistaModel
    {
        [Key]
        public short Id { get; set; }

        [Required(ErrorMessage ="O nome do dentista deve ser informado.",AllowEmptyStrings =false)]
        [StringLength(60, MinimumLength =3)]
        public string Nome { get; set; }

        [Required(ErrorMessage ="O código do CRO deve ser informado.", AllowEmptyStrings =false)]
        [StringLength (10, MinimumLength =6)]
        public string CodigoCro { get; set; }

        [Required(ErrorMessage ="A especialidade do dentista deve ser informada.",AllowEmptyStrings =false)]
        [StringLength(30, MinimumLength =5)]
        public string Especialidade { get; set; }

        [Required(ErrorMessage ="O endereço do dentista deve ser informado.", AllowEmptyStrings =false)]
        [StringLength(80, MinimumLength =10)]
        public string Endereco { get; set; }

        [Required(ErrorMessage ="O telefone do dentista deve ser informado.", AllowEmptyStrings =false)]
        [StringLength(11)]
        public string Telefone { get; set; }

        [Required(ErrorMessage ="O CPF do dentista deve ser informado.", AllowEmptyStrings =false)]
        [StringLength(11)]
        public string Cpf { get; set; }

        [Required(ErrorMessage ="O e-mail do dentista deve ser informado.", AllowEmptyStrings =false)]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Informe um e-mail válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage ="A data de nascimento do dentista deve ser informada.")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage ="O sexo do(a) dentista deve ser informado.", AllowEmptyStrings =false)]
        [StringLength(1)] // Verificar se funciona para char
        public char Sexo { get; set; }

        [Required(ErrorMessage ="O turno do(a) dentista deve ser informado.",AllowEmptyStrings =false)]
        [StringLength(8, MinimumLength = 5)]
        public string Turno { get; set; }

        [Required]
        public bool Status { get; set; } // Ativo ou Inativo

        public DateTime DataCadastro { get; set; } // No meu banco de dados, existe uma trigger para isso, portanto, não irei coloca-los com valor inicial, como Date Now.
        public DateTime DataModificacao { get; set; } // No meu banco de dados, existe uma trigger para isso, portanto, não irei coloca-los com valor inicial, como Date Now.

    }
}
