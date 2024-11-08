using System;

namespace Solucion
{
    public class Tabla
    {
        public double Ancho;
        public double Largo;
        public double Precio;

        public Tabla(double ancho, double largo, double precioBase)
        {
            Ancho = ancho;
            Largo = largo;
            Precio = (int)(ancho * largo * precioBase);
        }
    }
}
