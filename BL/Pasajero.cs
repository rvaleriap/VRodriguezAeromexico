using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Pasajero
    {
        public static ML.Result Add(ML.Pasajero pasajero)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.VRodriguezAeromexicoEntities context = new DL.VRodriguezAeromexicoEntities())
                {
                    int query = context.PasajeroAdd(pasajero.Nombre, pasajero.ApellidoPaterno, pasajero.ApellidoMaterno);
                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "No se puede ingresar";
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
        public static ML.Result Login(string UserName, string Password)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.VRodriguezAeromexicoEntities context = new DL.VRodriguezAeromexicoEntities())
                {
                    var query = context.UserGetById(UserName, Password).AsEnumerable().FirstOrDefault();
                    result.Objects = new List<object>();

                    if( query != null)
                    {
                        ML.Login login = new ML.Login();
                        login.UserName = query.UserName;
                        login.Password = query.Password;

                        result.Object = login;
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }

                    if (result.Correct)
                    {
                        ML.Login login = (ML.Login)result.Object;
                        if (Password == login.UserName)
                        {
                            result.Correct = true;
                            result.Message = "Autorice";
                        }
                       
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "Unhautorized";
                    }


                }
            }
            catch(Exception ex)
            {
                result.Correct= false;
                result.Message = ex.Message;
            }
            return result;
        }
    }
}
