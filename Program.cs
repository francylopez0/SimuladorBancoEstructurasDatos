Banco banco = new Banco();

while (true)
{
    Console.WriteLine();
    Console.WriteLine("===== SIMULADOR DE BANCO =====");
    Console.WriteLine("1. Registrar cliente");
    Console.WriteLine("2. Listar clientes");
    Console.WriteLine("3. Buscar cliente");
    Console.WriteLine("4. Agregar cliente a cola");
    Console.WriteLine("5. Atender siguiente cliente");
    Console.WriteLine("6. Realizar deposito");
    Console.WriteLine("7. Realizar retiro");
    Console.WriteLine("8. Consultar saldo");
    Console.WriteLine("9. Deshacer ultima transaccion");
    Console.WriteLine("10. Mostrar cola");
    Console.WriteLine("11. Mostrar total clientes");
    Console.WriteLine("12. Mostrar total dinero banco");
    Console.WriteLine("13. Salir");

    Console.Write("Seleccione una opcion: ");
    string opcion = Console.ReadLine() ?? "";

    // REGISTRAR CLIENTE 

    if (opcion == "1")
    {
        Console.Write("Identificacion: ");
        string id = Console.ReadLine() ?? "";

        Console.Write("Nombre completo: ");
        string nombre = Console.ReadLine() ?? "";

        Console.Write("Numero cuenta: ");
        string cuenta = Console.ReadLine() ?? "";

        Console.Write("Saldo inicial: ");
        double saldo = LeerDouble();

        bool registrado = banco.RegistrarCliente(id, nombre, cuenta, saldo);

        if (registrado)
        {
            Console.WriteLine("Cliente registrado correctamente.");
        }
        else
        {
            Console.WriteLine("Cliente duplicado.");
        }
    }

    //  LISTAR 

    else if (opcion == "2")
    {
        banco.MostrarClientes();
    }

    //  BUSCAR 

    else if (opcion == "3")
    {
        Console.Write("Ingrese identificacion: ");
        string id = Console.ReadLine() ?? "";

        Cliente? cliente = banco.BuscarCliente(id);

        if (cliente == null)
        {
            Console.WriteLine("Cliente no encontrado.");
        }
        else
        {
            Console.WriteLine(cliente);
        }
    }

    //  COLA 

    else if (opcion == "4")
    {
        Console.Write("Ingrese identificacion cliente: ");
        string id = Console.ReadLine() ?? "";

        bool agregado = banco.AgregarClienteCola(id);

        if (agregado)
        {
            Console.WriteLine("Cliente agregado a cola.");
        }
        else
        {
            Console.WriteLine("Cliente no encontrado.");
        }
    }

    else if (opcion == "5")
    {
        Cliente? atendido = banco.AtenderSiguiente();

        if (atendido == null)
        {
            Console.WriteLine("No hay clientes en espera.");
        }
        else
        {
            Console.WriteLine("Atendiendo cliente:");
            Console.WriteLine(atendido);
        }
    }

    //DEPOSITO

    else if (opcion == "6")
    {
        Console.Write("Numero cuenta: ");
        string cuenta = Console.ReadLine() ?? "";

        Console.Write("Monto deposito: ");
        double monto = LeerDouble();

        bool realizado = banco.Depositar(cuenta, monto);

        if (realizado)
        {
            Console.WriteLine("Deposito realizado.");
        }
        else
        {
            Console.WriteLine("Cuenta no encontrada.");
        }
    }

    //RETIRO 

    else if (opcion == "7")
    {
        Console.Write("Numero cuenta: ");
        string cuenta = Console.ReadLine() ?? "";

        Console.Write("Monto retiro: ");
        double monto = LeerDouble();

        bool realizado = banco.Retirar(cuenta, monto);

        if (realizado)
        {
            Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("✔ Retiro realizado correctamente.");
Console.ResetColor();
        }
        else
        Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine("✘ No se pudo realizar el retiro. Fondos insuficientes o cuenta invalida.");
Console.ResetColor();
    }

    // CONSULTAR SALDO 

    else if (opcion == "8")
    {
        Console.Write("Numero cuenta: ");
        string cuenta = Console.ReadLine() ?? "";

        Cliente? cliente = banco.BuscarClientePorCuenta(cuenta);

        if (cliente == null)
        {
            Console.WriteLine("Cuenta no encontrada.");
        }
        else
        {
            Console.WriteLine($"Saldo actual: {cliente.Saldo:C0}");
        }
    }

    // DESHACER 

    else if (opcion == "9")
    {
        bool deshecho = banco.DeshacerUltimaTransaccion();

        if (deshecho)
        {
            Console.WriteLine("Ultima transaccion revertida.");
        }
        else
        {
            Console.WriteLine("No hay transacciones.");
        }
    }

    //  MOSTRAR COLA 

    else if (opcion == "10")
    {
        banco.MostrarCola();
    }

    // TOTAL CLIENTES

    else if (opcion == "11")
    {
        Console.WriteLine($"Total clientes: {banco.TotalClientes()}");
    }

    // TOTAL DINERO

    else if (opcion == "12")
    {
        Console.WriteLine($"Total dinero banco: {banco.TotalDineroBanco():C0}");
    }

    // SALIR 

    else if (opcion == "13")
    {
        Console.WriteLine("Saliendo...");
        break;
    }

    else
    {
        Console.WriteLine("Opcion invalida.");
    }
}


// = METODO AUXILIAR 

double LeerDouble()
{
    while (true)
    {
        string texto = Console.ReadLine() ?? "";

        if (double.TryParse(texto, out double numero))
        {
            return numero;
        }

        Console.Write("Ingrese un numero valido: ");
    }
}