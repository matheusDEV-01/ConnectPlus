using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ConnectPlus.WebAPI.Models;

[Table("Contato")]
[Index("Formadecontato", Name = "UQ__Contato__5F72B74C636245ED", IsUnique = true)]
[Index("Tipodecontato", Name = "UQ__Contato__E85DEE8CFAC7BE2C", IsUnique = true)]
public partial class Contato
{
    [Key]
    public Guid IdContato { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Nome { get; set; } = null!;

    [Column("formadecontato")]
    [StringLength(256)]
    [Unicode(false)]
    public string Formadecontato { get; set; } = null!;

    [Column("imagem")]
    [StringLength(100)]
    [Unicode(false)]
    public string Imagem { get; set; } = null!;

    [Column("tipodecontato")]
    [StringLength(256)]
    [Unicode(false)]
    public string Tipodecontato { get; set; } = null!;

    public Guid? IdTipoDeContato { get; set; }

    [ForeignKey("IdTipoDeContato")]
    [InverseProperty("Contatos")]
    public virtual TipoDeContato? IdTipoDeContatoNavigation { get; set; }
}
