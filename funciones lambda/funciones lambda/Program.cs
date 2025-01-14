// See https://aka.ms/new-console-template for more information
Func<int, int> cuadrado = x => x * x;
Console.WriteLine(cuadrado(5)); // 25
Console.WriteLine(Func<int, int, int> elevar=(int basee, int potencia)=>basee*potencia);
