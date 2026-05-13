public class Transaccion
{
    public string Tipo { get; set; }
    public string NumeroCuenta { get; set; }
    public double Monto { get; set; }

    public Transaccion(string tipo, string numeroCuenta, double monto)
    {
        Tipo = tipo;
        NumeroCuenta = numeroCuenta;
        Monto = monto;
    }

    public override string ToString()
    {
        return $"Tipo: {Tipo} | Cuenta: {NumeroCuenta} | Monto: {Monto:C0}";
    }
}