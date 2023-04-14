using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Vuelo
    {
      public static ML.Result Add (ML.Vuelo vuelo)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.VRodriguezAeromexicoEntities context = new DL.VRodriguezAeromexicoEntities())
                {
                    int query = context.VueloAdd(vuelo.NumVuelo, vuelo.Origen, vuelo.Destino, vuelo.FechaSalida.ToString());
                    if (query >= 1)
                    {
                        result.Correct = true;

                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "No se puede agregar el vuelo";
                    }
                }
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
            }
            return result;
      }
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.VRodriguezAeromexicoEntities context = new DL.VRodriguezAeromexicoEntities())
                {
                    var query = context.GetAllVuelo().ToList();
                    if(query != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var obj in query)
                        {
                            ML.Vuelo vuelo = new ML.Vuelo();
                            vuelo.IdVuelo = obj.IdVuelo;
                            vuelo.NumVuelo = obj.NumVuelo;
                            vuelo.Origen = obj.Origen;
                            vuelo.Destino = obj.Destino;
                            vuelo.FechaSalida = obj.FechaSalida.Value;

                            result.Objects.Add(vuelo);

                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "No se logran mostrar los registros";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
            }
            return result;
        }

       public static ML.Result VueloPasajeroAdd (ML.VueloPasajero vueloPasajero)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.VRodriguezAeromexicoEntities context = new DL.VRodriguezAeromexicoEntities())
                {

                    ML.Vuelo[] vuelos = new ML.Vuelo[vueloPasajero.Vuelo.Count];
                    ML.Pasajero[] pasajeros = new ML.Pasajero[vueloPasajero.Pasajero.Count];

                    for(int i = 0; i> vuelos.Length; i++)
                    {
                        foreach (ML.Vuelo vuelo in vueloPasajero.Vuelo)
                        {
                            vuelos[i] = vuelo;
                        }
                        foreach(ML.Pasajero pasajero in vueloPasajero.Pasajero)
                        {
                            pasajeros[i] = pasajero;
                        }
                        int query = context.VueloAsignado(vuelos[i].IdVuelo, pasajeros[i].IdPasajero);
                        if (query >= 1)
                        {
                            result.Message = "Vuelo reservado";
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.Message = "No se pudo reservar el vuelo";
                        }
                           
                    }
                   
                }
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
            }
            return result;
        }
        
    }
}
