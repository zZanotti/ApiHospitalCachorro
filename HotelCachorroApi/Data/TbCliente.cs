using System;
using System.Collections.Generic;

namespace HotelCachorroApi.Data
{
    public partial class TbCliente
    {
        public TbCliente()
        {
            TbCachorros = new HashSet<TbCachorro>();
            TbCheckins = new HashSet<TbCheckin>();
        }

        public int IdCliente { get; set; }
        public string? Nome { get; set; }
        public string? Sobrenome { get; set; }
        public string? Cpf { get; set; }

        public virtual ICollection<TbCachorro> TbCachorros { get; set; }
        public virtual ICollection<TbCheckin> TbCheckins { get; set; }
    }
}
