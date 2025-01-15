// See https://aka.ms/new-console-template for more information







var names = new List<string>()
{
    "John","Omar","Alex","Ulises","Jhonatan","Jorge","Luis","Carlos","Eduardo","Javier"


};

var namesOrderedAscending = from n in names
                   orderby n
                   select n;
var namesOrderedDescending = from n in names
                            orderby n descending
                             select n;
//imprime la lista de nombres original
foreach (var name in names)
{
    Console.WriteLine(name);
}
Console.WriteLine("************");
//imprime la lista de nombres ordenada de forma ascendente
foreach (var name in namesOrderedAscending)
{
    Console.WriteLine(name);
}
Console.WriteLine("************");
//imprime la lista de nombres ordenada de forma descendente
foreach (var name in namesOrderedDescending)
{
    Console.WriteLine(name);
}
//creacion de funcion que unicamente seleccione los elementos que inicien con la letra J y los ordena de forma ascendente
var namesSelected = from n in names
                    where n.StartsWith("J")
                    orderby n
                    select n;

Console.WriteLine("************");
//imprime la lista de nombres que inician con la letra J
foreach (var name in namesSelected)
{
    Console.WriteLine(name);
}









