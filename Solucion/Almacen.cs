using System;

namespace Solucion
{
    public class Almacen
    {
        // atributos de Almacen
        public List<Tabla> Tablas;

        public Almacen(int capacidadMaxima)
        {
            this.Tablas = new List<Tabla>(capacidadMaxima);
        }

        public Tabla BuscarTabla(double anchoSolicitado, double largoSolicitado, List<Tabla> tablas) 
        {
            // Buscar la tabla que mejor se ajuste a las dimensiones solicitadas
            // Si no hay ninguna tabla que se ajuste, se retorna null
            // Si se encuentra una tabla que se ajuste, se retorna la tabla
            Tabla tablaEncontrada = null;
            foreach (Tabla tabla in tablas)
            {
                if (tabla.Ancho >= anchoSolicitado && tabla.Largo >= largoSolicitado)
                {
                    tablaEncontrada = tabla;
                    break;
                }
            }

            return tablaEncontrada;
        }

        public List<Tabla> OrdenarTablas(List<Tabla> tablas)
        {
            // Ordenar las tablas de menor a mayor tamano. Primero ancho y luego largo
            tablas.Sort((tabla1, tabla2) => tabla1.Ancho.CompareTo(tabla2.Ancho));
            tablas.Sort((tabla1, tabla2) => tabla1.Largo.CompareTo(tabla2.Largo));
            return tablas;
        }

        public Tabla CortarTabla(double anchoSolicitado, double largoSolicitado, double precioBase)
        {
            return new Tabla(anchoSolicitado, largoSolicitado, precioBase);
        }

        public Tabla ObtenerTablaResidual(double anchoSolicitado, double largoSolicitado, double precioBase, Tabla nuevaTabla)
        {
            // Calcular las dimensiones de la tabla residual
            double anchoResidual = nuevaTabla.Ancho - anchoSolicitado;
            double largoResidual = nuevaTabla.Largo - largoSolicitado;

            return new Tabla(anchoResidual, largoResidual, precioBase);
        }
    }
}
