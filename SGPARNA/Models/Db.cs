using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SGPARNA.Models
{

   public class Contacto
    {
        [Key]
        public int Id { get; set; }
        public string NumeroTelefone { get; set; }
        public string Email { get; set; }
        public ApplicationUser Usuario { get; set; }
    }
    public class Documento
    {
        [Key]
        public int Id { get; set; }
        public Categoria Categoria { get; set; }
        
    }
    public class Tipo_Documento
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Numero { get; set; }
        public string Imagem { get; set; }
        public Documento Documento { get; set; }
    }
    public class Processos
    {
        [Key]
        public int Id { get; set; }
        public Documento Documento { get; set; }

    }
    public class Documentos_Achados
    {
        [Key]
        public int Id { get; set; }
        public Documento Documento { get; set; }

    }
    public class Documentos_Perdidos
    {
        [Key]
        public int Id { get; set; }
        public Documento Documento { get; set; }

    }
    public class Estado_Documento
    {
        [Key]
        public int Id { get; set; }
        public Documento Documento { get; set; }

    }
    public class Servicos_de_utildidade
    {
        [Key]
        public int Id { get; set; }
        public Documento Documento { get; set; }

    }

    public class Categoria
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

    }

}