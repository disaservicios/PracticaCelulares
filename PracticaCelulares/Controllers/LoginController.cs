using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Web;
using System.Web.Mvc;
using PracticaCelulares.Models;

namespace PracticaCelulares.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Enter(string Usuario, string pass)
        {
            try
            {
                using (MSSQL_Practica_LlamadasEntities conexion = new MSSQL_Practica_LlamadasEntities())
                {
                    var data = from tbl_users in conexion.Users
                              where tbl_users.UserName == Usuario && tbl_users.Passwordkey == pass && tbl_users.Activo == 1
                              select tbl_users;

                    if (data.Count() > 0)
                    {
                        Users usersSesion = new Users();
                        Session["User"] = usersSesion;
                        return Content("1");
                    }
                    else
                    {
                        return Content("Usuario y/o contraseña incorrectos, favor de validar");
                    }
                }
               
                

            }catch(Exception ex)
            {
                return Content(ex.Message);
            }
        }
    }
}