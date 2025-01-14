// See https://aka.ms/new-console-template for more information


var player = new Jugador("Omar", 100);
Console.WriteLine(player.Nombre);

class Jugador
{
    public string Nombre { get; set; }
    public int Puntos { get; set; }
    public Jugador(string nombre, int puntos)
    {
        Nombre = nombre;
        Puntos = puntos;
    }
}


