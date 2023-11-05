using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PracticaCelulares.Models;
using PracticaCelulares.Models.DTO;
using PracticaCelulares.Models.DTOCrud;

namespace PracticaCelulares.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            List<UsersDTO> lst = null;
            using (MSSQL_Practica_LlamadasEntities conexion = new MSSQL_Practica_LlamadasEntities())
            {
                lst = (from dto in conexion.Vw_Users                                           
                      orderby dto.UserName
                      select new UsersDTO
                      {
                          
                          UserName = dto.UserName,
                          UserLogin= dto.UserLogin,
                          Passwordkey = dto.Passwordkey,
                          Tipo_Descripcion = dto.Tipo_Descripcion,
                          Rol_Descripcion= dto.Rol_Descripcion,
                          Phone = dto.Phone,
                          
                      }).ToList();
                
            }           
            
            return View(lst);
        }
        [HttpGet]
        public ActionResult Add() 
        {
            
            {
                return View();
            }

          
        }
      
        [HttpPost]
        public ActionResult Add(cUsers usersEdit)
        {
            usersEdit.Rol_Descripcion = "1";
            usersEdit.Tipo_Descripcion = "1";

            //if (!ModelState.IsValid)
            //{
            //    return View(usersEdit);
            //}

            using(var con = new MSSQL_Practica_LlamadasEntities())
            {
                Users bdUser = new Users();
                bdUser.Activo = 1;
                bdUser.UserName = usersEdit.UserName;
                bdUser.UserLogin = usersEdit.UserLogin;
                bdUser.Passwordkey = usersEdit.Passwordkey;
                bdUser.Phone = usersEdit.Phone;

                bdUser.Id_Rol = 1;
                bdUser.Id_Tipo_Usuario = 1;

                con.Users.Add(bdUser);
                con.SaveChanges();
                
            }

            return Redirect(Url.Content("~/Users/"));
        }        

    }
}