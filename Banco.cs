public class Banco
{
    private ListaEnlazadaClientes clientes;
    private ColaAtencion colaAtencion;
    private PilaTransacciones historial;

    public Banco()
    {
        clientes = new ListaEnlazadaClientes();
        colaAtencion = new ColaAtencion();
        historial = new PilaTransacciones();
    }

    // CLIENTES 

    public bool RegistrarCliente(string identificacion, string nombre, string cuenta, double saldo)
    {
        Cliente? existeId = clientes.BuscarPorIdentificacion(identificacion);
        Cliente? existeCuenta = clientes.BuscarPorCuenta(cuenta);

        if (existeId != null || existeCuenta != null)
        {
            return false;
        }

        Cliente nuevo = new Cliente(identificacion, nombre, cuenta, saldo);
        clientes.Insertar(nuevo);

        return true;
    }

    public void MostrarClientes()
    {
        clientes.Mostrar();
    }

    public Cliente? BuscarCliente(string identificacion)
    {
        return clientes.BuscarPorIdentificacion(identificacion);
    }

public Cliente? BuscarClientePorCuenta(string cuenta)
{
    return clientes.BuscarPorCuenta(cuenta);
}
    public int TotalClientes()
    {
        return clientes.Contar();
    }

    public double TotalDineroBanco()
    {
        return clientes.CalcularTotalDinero();
    }

    // COLA 

    public bool AgregarClienteCola(string identificacion)
    {
        Cliente? cliente = clientes.BuscarPorIdentificacion(identificacion);

        if (cliente == null)
        {
            return false;
        }

        colaAtencion.Encolar(cliente);
        return true;
    }

    public Cliente? AtenderSiguiente()
    {
        return colaAtencion.Desencolar();
    }

    public void MostrarCola()
    {
        colaAtencion.MostrarCola();
    }

    // TRANSACCIONES 

    public bool Depositar(string cuenta, double monto)
    {
        Cliente? cliente = clientes.BuscarPorCuenta(cuenta);

        if (cliente == null)
        {
            return false;
        }

        cliente.Saldo += monto;

        Transaccion transaccion = new Transaccion("Deposito", cuenta, monto);
        historial.Apilar(transaccion);

        return true;
    }

    public bool Retirar(string cuenta, double monto)
    {
        Cliente? cliente = clientes.BuscarPorCuenta(cuenta);

        if (cliente == null)
        {
            return false;
        }

        if (cliente.Saldo < monto)
        {
            return false;
        }

        cliente.Saldo -= monto;

        Transaccion transaccion = new Transaccion("Retiro", cuenta, monto);
        historial.Apilar(transaccion);

        return true;
    }

    public bool DeshacerUltimaTransaccion()
    {
        Transaccion? ultima = historial.Desapilar();

        if (ultima == null)
        {
            return false;
        }

        Cliente? cliente = clientes.BuscarPorCuenta(ultima.NumeroCuenta);

        if (cliente == null)
        {
            return false;
        }

        if (ultima.Tipo == "Deposito")
        {
            cliente.Saldo -= ultima.Monto;
        }
        else if (ultima.Tipo == "Retiro")
        {
            cliente.Saldo += ultima.Monto;
        }

        return true;
    }
}