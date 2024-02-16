using System.ComponentModel.DataAnnotations;

namespace OdontoAPI.Models
{
    public class PacienteModel
    {
        [Key]
        public short Id { get; set; }

        [Required(ErrorMessage = "O nome do paciente deve ser informado.", AllowEmptyStrings =false)]
        [StringLength(60, MinimumLength = 3)]
        public string Nome { get; set; }

        [Required(ErrorMessage ="A data de nascimento do paciente deve ser informado.")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage ="O CPF do paciente deve ser informado.", AllowEmptyStrings =false)]
        [StringLength(11)]
        public string Cpf { get; set; }

        [Required(ErrorMessage ="O endereço do paciente deve ser informado.", AllowEmptyStrings =false)]
        [StringLength(80,MinimumLength =30)]
        public string Endereco { get; set; }

        [Required(ErrorMessage ="O telefone do paciente deve ser informado.", AllowEmptyStrings =false)]
        [StringLength(11)]
        public string Telefone { get; set; }

        [Required(ErrorMessage ="O e-mail do paciente deve ser informado.",AllowEmptyStrings =false)]
        public string Email { get; set; }

        [Required(ErrorMessage = "O sexo do(a) paciente deve ser informado.", AllowEmptyStrings = false)]
        public char Sexo { get; set; }
        
        [Required]
        public bool Status { get; set; } // Ativo ou Inativo


        public DateTime DataCadastro { get; set; }
        public DateTime DataModificacao { get; set; }

    }
}
