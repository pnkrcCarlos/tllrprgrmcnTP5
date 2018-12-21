using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ2
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new EJ2Context("public"))
            {
                IDictionary<String, Cuenta> mCuentas = new Dictionary<String, Cuenta>();
                mCuentas.Add("CorrientePesos", new Cuenta
                {
                    CuentaId = 1,
                    Nombre = "CorrientePesos",
                    LimiteDescubierto = 5000,
                    Movimientos = new List<Movimiento>
                    {
                        new Movimiento
                        {
                            MovimientoId = 1,
                            FechaMovimiento = DateTime.Now,
                            Descripcion = "Ingreso",
                            Monto = 6000
                        },
                        new Movimiento
                        {
                            MovimientoId = 1,
                            FechaMovimiento = DateTime.Now,
                            Descripcion = "Extraccion",
                            Monto = -7000
                        }
                    }
                });

                mCuentas.Add("AhorroDolares", new Cuenta
                {
                    CuentaId = 1,
                    Nombre = "AhorroDolares",
                    LimiteDescubierto = 2000,
                    Movimientos = new List<Movimiento>
                    {
                        new Movimiento
                        {
                            MovimientoId = 1,
                            FechaMovimiento = DateTime.Now,
                            Descripcion = "Ingreso",
                            Monto = 6000
                        },
                        new Movimiento
                        {
                            MovimientoId = 1,
                            FechaMovimiento = DateTime.Now,
                            Descripcion = "Extraccion",
                            Monto = -1000
                        }
                    }
                });


                //Alta
                Cliente mCliente = new Cliente
                {
                    ClienteId = 1,
                    Nombre = "Lucas",
                    Apellido = "La Pietra",
                    Cuentas = mCuentas
                };

                db.Clientes.Add(mCliente);
                db.SaveChanges();

                //busqueda
                foreach (var cliente in db.Clientes)
                {
                    Console.WriteLine("Cliente encontrado Nombre: {0}, Apellido: {1}, IdCliente: {2}",
                        cliente.Nombre,
                        cliente.Apellido,
                        cliente.ClienteId);

                    foreach (var cuenta in db.Cuentas)
                    {
                        if (cliente.Cuentas.Keys.Contains(cuenta.Nombre) && cliente.Cuentas[cuenta.Nombre] == cuenta)
                        {
                            Console.WriteLine("\tCuenta encontrado Nombre: {0}, LimDescubierto: {1}, IdCuenta: {2}",
                            cuenta.Nombre,
                            cuenta.LimiteDescubierto,
                            cuenta.CuentaId);

                            foreach (var movimiento in db.Movimientos)
                            {
                                if (cuenta.Movimientos.Contains(movimiento))
                                {
                                    Console.WriteLine("\tMovimiento encontrado Descripcion: {0}, Monto: {1}, IdMovimiento: {2}",
                                    movimiento.Descripcion,
                                    movimiento.Monto,
                                    movimiento.MovimientoId);
                                }
                            }
                        }
                    }
                }

                Console.ReadKey();
            }
        }
    }
}
