using System;

namespace Solucion
{
    public class Ferreteria
    {
        public double AnchoInicial;
        public double LargoInicial;
        public double PrecioBase;
        public Almacen AlmacenTablas;

        public Ferreteria(double anchoInicial, double largoInicial, double precioBase)
        {
            AnchoInicial = anchoInicial;
            LargoInicial = largoInicial;
            PrecioBase = precioBase;
            AlmacenTablas = new Almacen(500);
        }
         
        public double ProcesarSolicitud(double anchoSolicitado, double largoSolicitado)
        {
            // Buscar la tabla que mejor se ajuste a las dimensiones solicitadas
            // Si se encuentra una tabla que se ajuste, se retorna el precio de la tabla
            // Si no hay ninguna tabla que se ajuste, se crea una nueva tabla con las dimensiones estandar
            // Si no hay ninguna tabla que se ajuste y no se puede crear una nueva tabla, se retorna -1
            List<Tabla> tablas = AlmacenTablas.OrdenarTablas(AlmacenTablas.Tablas);
            Tabla tablaEncontrada = AlmacenTablas.BuscarTabla(anchoSolicitado, largoSolicitado, tablas);

            if (tablaEncontrada != null)
            {
                // Se encontro una tabla que se puede cortar para obtener la tabla solicitada
                tablaEncontrada = AlmacenTablas.CortarTabla(anchoSolicitado, largoSolicitado, this.PrecioBase);
                Tabla tablaResidual = AlmacenTablas.ObtenerTablaResidual(anchoSolicitado, largoSolicitado, this.PrecioBase, tablaEncontrada);
                AlmacenTablas.Tablas.Add(tablaResidual);
            }
            else
            {
                // No se encontro una tabla que se ajuste a las dimensiones solicitadas
                // Se crea una nueva tabla con las dimensiones estandar
                Tabla nuevaTabla = new Tabla(AnchoInicial, LargoInicial, PrecioBase);
                if (nuevaTabla.Ancho < anchoSolicitado || nuevaTabla.Largo < largoSolicitado)
                {
                    // No se puede crear una nueva tabla con las dimensiones solicitadas
                    return -1;
                }

                // Se corta una tabla estandar y se obtiene una tabla residual
                // Se devuelve la tabla solicitada
                tablaEncontrada = AlmacenTablas.CortarTabla(anchoSolicitado, largoSolicitado, this.PrecioBase);
                Tabla tablaResidual = AlmacenTablas.ObtenerTablaResidual(anchoSolicitado, largoSolicitado, this.PrecioBase, nuevaTabla);
                AlmacenTablas.Tablas.Add(tablaResidual);
            }
            
            return tablaEncontrada.Precio;
        }
    }
}