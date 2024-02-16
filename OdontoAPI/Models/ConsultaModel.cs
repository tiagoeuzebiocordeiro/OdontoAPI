using System.ComponentModel.DataAnnotations;

namespace OdontoAPI.Models
{
    public class ConsultaModel
    {
        [Key]
        public short Id { get; set; }
        [Required]
        public short DentistaAssociado { get; set; } // Meu EF entende que o DentistaAssociado (obj) é a coluna de id_dentista_associado no banco de dados
        [Required]
        public short PacienteAssociado { get; set; } // Meu EF entende que o PacienteAssociado (obj) é a coluna de id_paciente_associado no banco de dados
        [Required(ErrorMessage ="A data da consulta deve ser informada.")]
        public DateTime DataConsulta { get; set; }
        public DateTime DataCadastroConsulta { get; set; } // DATA DE CADASTRO NO BANCO. No meu banco de dados, existe uma trigger para isso, portanto, não irei coloca-los com valor inicial, como Date Now.
        public DateTime DataModificacaoConsulta { get; set; } // DATA DE MODIFICACAO NO BANCO. No meu banco de dados, existe uma trigger para isso, portanto, não irei coloca-los com valor inicial, como Date Now.
    }
}
