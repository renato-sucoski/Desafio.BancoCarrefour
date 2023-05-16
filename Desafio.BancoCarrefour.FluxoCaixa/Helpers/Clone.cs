using System.Reflection;
using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Desafio.BancoCarrefour.FluxoCaixa.Helpers
{
    public static class Clone
    {
        public  static void CopiarPropriedades(object origem, object destino)
        {
            Type tipoOrigem = origem.GetType();
            Type tipoDestino = destino.GetType();

            PropertyInfo[] propriedadesOrigem = tipoOrigem.GetProperties();
            PropertyInfo[] propriedadesDestino = tipoDestino.GetProperties();

            foreach (PropertyInfo propriedadeOrigem in propriedadesOrigem)
            {
                foreach (PropertyInfo propriedadeDestino in propriedadesDestino)
                {
                    if (propriedadeOrigem.Name == propriedadeDestino.Name &&
                        propriedadeOrigem.PropertyType == propriedadeDestino.PropertyType &&
                        propriedadeDestino.CanWrite)
                    {
                        propriedadeDestino.SetValue(destino, propriedadeOrigem.GetValue(origem));
                        break;
                    }
                }
            }
        }

    }
}
