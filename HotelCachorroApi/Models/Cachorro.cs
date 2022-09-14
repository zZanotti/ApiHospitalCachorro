using System;

namespace HotelCachorroApi.Models{
    public class Cachorro
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Raca { get; set;}
        public Cliente Cliente { get; set;}
        public string Porte { get; set; }
        public double Peso { get; set; }
    }
}