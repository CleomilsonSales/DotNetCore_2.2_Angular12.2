using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProAgil.WebAPI.Dtos
{
    public class EventoDto
    {
        //DTO - Data Transfer Object
        public int Id { get; set; }
        
        [Required (ErrorMessage="O local deve ser preenchido")]
        [StringLength(100, MinimumLength=3, ErrorMessage="Local é entre 3 e 100 caracteres")]
        public string Local { get; set; }
        public string DataEvento { get; set; }

        [Required (ErrorMessage="O tema deve ser preenchido")]
        public string Tema { get; set; }
        
        [Range(2,120000, ErrorMessage="Quantidade deve estar entre 2 e 120000")]
        public int QtdPessoas { get; set; }
        public string ImagemURL {get; set;}
        
        [Phone]
        public string Telefone { get; set; }

        // [EmailAddress] é um decoration do dataNotantions que valida automaticamente o dado se é um e-mail válido antes da inserção 
        [EmailAddress]
        public string Email { get; set; }

        //abaixo relação das tabelas
        public List<LoteDto> Lotes { get; set; }
        public List<RedeSocialDto> RedesSociais { get; set; }
        public List<PalestranteDto> Palestrantes { get; set; }
    }
}