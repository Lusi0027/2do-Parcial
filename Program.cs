namespace SistemaDeGestiónDeInventario
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sistema de Gestion de inventario");

            List<Producto> inventario = new List<Producto>();

            bool continuar = true;

            while (continuar)
            {
                Console.WriteLine("\n1. Electrónico  2. Alimento  3. Ver todo  4. Salir");
                Console.Write("Opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.Write("Nombre: ");
                        string nombre = Console.ReadLine();
                        Console.Write("Código: ");
                        string codigo = Console.ReadLine();
                        Console.Write("Precio: ");
                        double precio = double.Parse(Console.ReadLine());
                        Console.Write("Cantidad: ");
                        int cantidad = int.Parse(Console.ReadLine());
                        Console.Write("Garantía (meses): ");
                        int garantia = int.Parse(Console.ReadLine());

                        inventario.Add(new ProductoElectronico(nombre, codigo, precio, cantidad, garantia));
                        Console.WriteLine("Agregado");
                        break;

                    case "2":
                        Console.Write("Nombre: ");
                        nombre = Console.ReadLine();
                        Console.Write("Código: ");
                        codigo = Console.ReadLine();
                        Console.Write("Precio: ");
                        precio = double.Parse(Console.ReadLine());
                        Console.Write("Cantidad: ");
                        cantidad = int.Parse(Console.ReadLine());
                        Console.Write("Vencimiento (D/M/Y): ");
                        string vencimiento = Console.ReadLine();

                        inventario.Add(new ProductoAlimento(nombre, codigo, precio, cantidad, vencimiento));
                        Console.WriteLine("Agregado");
                        break;

                    case "3":
                        Console.WriteLine("\n---INVENTARIO---");
                        foreach (Producto p in inventario)
                            p.MostrarProducto();
                        break;

                    case "4":
                        continuar = false;
                        break;
                }
            }
        }
    }

    public class Producto
    {
        private string nombre;
        private string codigo;
        private double precio;
        private int cantidad;

        public Producto(string nombre, string codigo, double precio, int cantidad)
        {
            this.nombre = nombre;
            this.codigo = codigo;
            this.precio = precio;
            this.cantidad = cantidad;
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        public double Precio
        {
            get { return precio; }
            set { precio = value; }
        }

        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        public virtual void MostrarProducto()
        {
            Console.WriteLine($"Nombre: {nombre}");
            Console.WriteLine($"Codigo: {codigo}");
            Console.WriteLine($"Precio: {precio}");
            Console.WriteLine($"Cantidad: {cantidad}");
        }

        public virtual double CalcularImpuesto()
        {
            return 0;
        }
    }

    public class ProductoElectronico : Producto
    {
        private int garantiaMeses;

        public ProductoElectronico(string nombre, string codigo, double precio, int cantidad, int garantiaMeses) : base(nombre, codigo, precio, cantidad)
        {
            this.garantiaMeses = garantiaMeses;
        }

        public int GarantiaMeses
        {
            get { return garantiaMeses; }
            set { garantiaMeses = value; }
        }

        public override double CalcularImpuesto()
        {
            return Precio * 0.18;
        }

        public override void MostrarProducto()
        {
            Console.WriteLine("\n---PRODUCTO ELECTRONICO---");
            base.MostrarProducto();
            Console.WriteLine($"Garantía: {GarantiaMeses} meses");
            Console.WriteLine($"Impuesto (18% ITBIS): ${CalcularImpuesto()}");
            Console.WriteLine($"Precio Unitario con Impuesto: ${Precio + CalcularImpuesto()}");
        }
    }

    public class ProductoAlimento : Producto
    {
        private string fechaVencimiento;

        public ProductoAlimento(string nombre, string codigo, double precio, int cantidad, string fechaVencimiento) : base(nombre, codigo, precio, cantidad)
        {
            this.fechaVencimiento = fechaVencimiento;
        }

        public string FechaVencimiento
        {
            get { return fechaVencimiento; }
            set { fechaVencimiento = value; }
        }

        public override double CalcularImpuesto()
        {
            return Precio * 0.08;
        }

        public override void MostrarProducto()
        {
            Console.WriteLine("\n---PRODUCTO ALIMENTICIO---");
            base.MostrarProducto();
            Console.WriteLine($"Fecha de vencimiento: {fechaVencimiento}");
            Console.WriteLine($"Impuesto (8%): ${CalcularImpuesto()}");
            Console.WriteLine($"Precio Unitario con Impuesto: ${Precio + CalcularImpuesto()}");
        }
    }
}