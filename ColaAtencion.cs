public class ColaAtencion
{
    private Nodo<Cliente>? frente;
    private Nodo<Cliente>? final;

    public void Encolar(Cliente cliente)
    {
        Nodo<Cliente> nuevo = new Nodo<Cliente>(cliente);

        if (frente == null)
        {
            frente = nuevo;
            final = nuevo;
        }
        else
        {
            final!.Siguiente = nuevo;
            final = nuevo;
        }
    }

    public Cliente? Desencolar()
    {
        if (frente == null)
        {
            return null;
        }

        Cliente cliente = frente.Dato;
        frente = frente.Siguiente;

        if (frente == null)
        {
            final = null;
        }

        return cliente;
    }

    public Cliente? VerSiguiente()
    {
        if (frente == null)
        {
            return null;
        }

        return frente.Dato;
    }

    public bool EstaVacia()
    {
        return frente == null;
    }

    public void MostrarCola()
    {
        Nodo<Cliente>? actual = frente;

        if (actual == null)
        {
           Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("⚠ No hay clientes en cola.");
Console.ResetColor();
            return;
        }

        Console.WriteLine("=== COLA DE ATENCIÓN ===");

        while (actual != null)
        {
            Console.WriteLine(actual.Dato);
            actual = actual.Siguiente;
        }
    }
}