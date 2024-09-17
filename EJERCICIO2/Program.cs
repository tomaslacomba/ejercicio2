public class Flor
{
    public string Tipo { get; set; }
    public decimal Costo { get; set; }
}

public class ArregloFloral
{
    public List<Flor> Flores { get; set; } = new List<Flor>();

    public decimal CalcularCosto()
    {
        decimal total = 0;
        foreach (var flor in Flores)
        {
            total += flor.Costo;
        }
        return total;
    }
}

public class Pedido
{
    public string NombreCliente { get; set; }
    public List<ArregloFloral> ArreglosFlorales { get; set; } = new List<ArregloFloral>();

    public decimal CalcularTotal()
    {
        decimal total = 0;
        foreach (var arreglo in ArreglosFlorales)
        {
            total += arreglo.CalcularCosto();
        }
        return total;
    }

    public decimal CalcularDescuento()
    {
        if (ArreglosFlorales.Count > 5)
        {
            return CalcularTotal() * 0.10m;
        }
        return 0;
    }

    public decimal CalcularTotalConDescuento()
    {
        return CalcularTotal() - CalcularDescuento();
    }

    public void MostrarResumen()
    {
        Console.WriteLine($"Cliente: {NombreCliente}");
        Console.WriteLine($"Total sin descuento: {CalcularTotal():C}");
        Console.WriteLine($"Descuento: {CalcularDescuento():C}");
        Console.WriteLine($"Total con descuento: {CalcularTotalConDescuento():C}");
    }
}

public class Program
{
    public static void Main()
    {

        var rosa = new Flor { Tipo = "Rosa", Costo = 10.0m };
        var tulipan = new Flor { Tipo = "Tulipán", Costo = 8.0m };


        var arreglo1 = new ArregloFloral();
        arreglo1.Flores.Add(rosa);
        arreglo1.Flores.Add(tulipan);

        var arreglo2 = new ArregloFloral();
        arreglo2.Flores.Add(rosa);
        arreglo2.Flores.Add(rosa);


        var pedido = new Pedido { NombreCliente = "Tomas" };
        pedido.ArreglosFlorales.Add(arreglo1);
        pedido.ArreglosFlorales.Add(arreglo2);
        pedido.ArreglosFlorales.Add(arreglo1);
        pedido.ArreglosFlorales.Add(arreglo2);
        pedido.ArreglosFlorales.Add(arreglo1);
        pedido.ArreglosFlorales.Add(arreglo2);


        pedido.MostrarResumen();
    }
}
