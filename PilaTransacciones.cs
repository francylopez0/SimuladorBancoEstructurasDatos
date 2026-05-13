public class PilaTransacciones
{
    private Nodo<Transaccion>? cima;

    public void Apilar(Transaccion transaccion)
    {
        Nodo<Transaccion> nuevo = new Nodo<Transaccion>(transaccion);
        nuevo.Siguiente = cima;
        cima = nuevo;
    }

    public Transaccion? Desapilar()
    {
        if (cima == null)
        {
            return null;
        }

        Transaccion transaccion = cima.Dato;
        cima = cima.Siguiente;
        return transaccion;
    }

    public Transaccion? VerUltima()
    {
        if (cima == null)
        {
            return null;
        }

        return cima.Dato;
    }

    public bool EstaVacia()
    {
        return cima == null;
    }

    public void Mostrar()
    {
        Nodo<Transaccion>? actual = cima;

        if (actual == null)
        {
            Console.WriteLine("No hay transacciones registradas.");
            return;
        }

        Console.WriteLine("=== HISTORIAL DE TRANSACCIONES ===");

        while (actual != null)
        {
            Console.WriteLine(actual.Dato);
            actual = actual.Siguiente;
        }
    }
}