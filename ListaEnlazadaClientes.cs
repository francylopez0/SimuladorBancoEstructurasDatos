public class ListaEnlazadaClientes
{
    private Nodo<Cliente>? cabeza;

    public Nodo<Cliente>? Cabeza
    {
        get { return cabeza; }
    }

    public void Insertar(Cliente cliente)
    {
        Nodo<Cliente> nuevo = new Nodo<Cliente>(cliente);

        if (cabeza == null)
        {
            cabeza = nuevo;
        }
        else
        {
            Nodo<Cliente>? actual = cabeza;

            while (actual.Siguiente != null)
            {
                actual = actual.Siguiente;
            }

            actual.Siguiente = nuevo;
        }
    }

    public Cliente? BuscarPorIdentificacion(string identificacion)
    {
        Nodo<Cliente>? actual = cabeza;

        while (actual != null)
        {
            if (actual.Dato.Identificacion == identificacion)
            {
                return actual.Dato;
            }

            actual = actual.Siguiente;
        }

        return null;
    }

    public Cliente? BuscarPorCuenta(string numeroCuenta)
    {
        Nodo<Cliente>? actual = cabeza;

        while (actual != null)
        {
            if (actual.Dato.NumeroCuenta == numeroCuenta)
            {
                return actual.Dato;
            }

            actual = actual.Siguiente;
        }

        return null;
    }

    public void Mostrar()
    {
        Nodo<Cliente>? actual = cabeza;

        if (actual == null)
        {
            Console.WriteLine("No hay clientes registrados.");
            return;
        }

        while (actual != null)
        {
            Console.WriteLine(actual.Dato);
            actual = actual.Siguiente;
        }
    }

    public int Contar()
    {
        int contador = 0;
        Nodo<Cliente>? actual = cabeza;

        while (actual != null)
        {
            contador++;
            actual = actual.Siguiente;
        }

        return contador;
    }

    public double CalcularTotalDinero()
    {
        double total = 0;
        Nodo<Cliente>? actual = cabeza;

        while (actual != null)
        {
            total += actual.Dato.Saldo;
            actual = actual.Siguiente;
        }

        return total;
    }
}