using System;

namespace HotelCachorroApi.Models{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Cpf { get; set;}
        public ICollection<Cachorro> Cachorros { get; set; }
    }
}