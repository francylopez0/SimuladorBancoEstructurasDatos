public class Cliente
{
    public string Identificacion { get; set; }
    public string NombreCompleto { get; set; }
    public string NumeroCuenta { get; set; }
    public double Saldo { get; set; }

    public Cliente(string identificacion, string nombreCompleto, string numeroCuenta, double saldo)
    {
        Identificacion = identificacion;
        NombreCompleto = nombreCompleto;
        NumeroCuenta = numeroCuenta;
        Saldo = saldo;
    }

    public override string ToString()
    {
        return $"ID: {Identificacion} | Nombre: {NombreCompleto} | Cuenta: {NumeroCuenta} | Saldo: {Saldo:C0}";
    }
}