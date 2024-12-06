// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using CajaRegistradora;
List<Fruta> frutas = new List<Fruta>();


int opcion;

do
{
    // Menú principal
    //Console.Clear();
    Console.WriteLine("----- CAJA REGISTRADORA -- FRUTERIA FRUVER EL PARAISO 1 -----");
    Console.WriteLine();
    Console.WriteLine("1. Agregar fruta a la lista de compras");
    Console.WriteLine("2. Eliminar fruta de la lista de compras");
    Console.WriteLine("3. Mostrar ticket");
    Console.WriteLine("4. Salir");
    Console.Write("Elige una opción: ");
    opcion = int.Parse(Console.ReadLine());



    switch (opcion)
    {
        case 1:
            agregarFruta(frutas);
            break;
        case 2:
            EliminarFruta(frutas);
            break;
        case 3:
            MostrarTicket(frutas);
            break;
        case 4:
            Console.WriteLine("Gracias por comprar en FRUVER PARAISO 1. ¡Hasta pronto!");
            break;
        default:
            Console.WriteLine("Opción no válida. Presione cualquier tecla para continuar.");
            Console.ReadKey();
            break;
    }
} while (opcion != 4);

static void agregarFruta(List<Fruta> frutas)
{
    Console.WriteLine("\nIngrese nombre de la fruta: ");
    string nombre = Console.ReadLine();

    Console.WriteLine("Ingrese precio de la fruta: ");
    double precio;
    while (!double.TryParse(Console.ReadLine(), out precio) || precio <= 0)
    {
        Console.WriteLine("Por favor ingrese un precio válido mayor a 0.");
    }

    Fruta nuevaFruta = new Fruta(nombre, precio);
    frutas.Add(nuevaFruta);
    Console.WriteLine("Fruta registada con exito\n");
}

static void MostrarTicket(List<Fruta> listaFrutas)
{
    //Console.Clear();
    if (listaFrutas.Count == 0)
    {
        Console.WriteLine("\nNo hay productos en su lista de compras.");
    }
    else
    {
        Console.WriteLine("--- Ticket de compra ---");
        double total = 0;
        int i = 1;
        foreach (var fruta in listaFrutas)
        {
            Console.WriteLine($"{i++}. {fruta.nombre} - ${fruta.precio:C}");
            Console.WriteLine("-----------------------------------------");
            total += fruta.precio;
        }
        Console.WriteLine($"Total a pagar: ${total:C}\n");
    }

}
static void EliminarFruta(List<Fruta> frutas)
{


    if (frutas.Count == 0)
    {
        Console.WriteLine("\n No hay frutas registradas para eliminar.");
        Console.WriteLine("Presione Enter para continuar.\n");
        Console.ReadLine();
        return;
    }

    // Mostrar frutas de la lista
    Console.WriteLine("Frutas disponibles para eliminar:");
    for (int j = 0; j < frutas.Count; j++)
    {
        Console.WriteLine($"{j + 1}. {frutas[j].nombre} - {frutas[j].precio:C}");
    }

    // Solicitar al usuario el número de la fruta a eliminar
    Console.Write("\n Seleccione el número de la fruta que desea eliminar: ");
    int i = 0;

    // se valida que el elemento [i] esté dentro del rango
    while (!int.TryParse(Console.ReadLine(), out i) || i < 1 || i > frutas.Count)
    {
        Console.Write("Selección inválida. Por favor ingrese un número válido: ");
    }

    // Eliminar la fruta seleccionada
    frutas.RemoveAt(i - 1);
    Console.WriteLine("Fruta eliminada con éxito.");
    Console.WriteLine("Presione Enter para continuar.\n");

}


