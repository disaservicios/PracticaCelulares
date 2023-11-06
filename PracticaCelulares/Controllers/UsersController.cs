using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
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
                List<Tipo_UsuarioDTO> lstTipo = (from tu in conexion.Tipo_Usuario
                                                 select new Tipo_UsuarioDTO
                                                 {
                                                    Id_Tipo_Usuario = tu.Id_Tipo_Usuario,
                                                    Tipo_Descripcion = tu.Tipo_Descripcion,
                                                 }).ToList();


                lst = (from dto in conexion.Vw_Users                                           
                      orderby dto.UserName
                      select new UsersDTO
                      {
                          Id_User = dto.Id_User,
                          UserName = dto.UserName,
                          UserLogin= dto.UserLogin,
                          Passwordkey = dto.Passwordkey,
                          Tipo_Descripcion = dto.Tipo_Descripcion,
                          Rol_Descripcion = dto.Rol_Descripcion,
                          Phone = dto.Phone,
                          
                      }).ToList();
                
            }           
            
            return View(lst);
        }
        [HttpGet]
        public ActionResult Add() 
        {
            List<Tipo_UsuarioDTO> lstTipo = null;
            List<RolesDTO> lstRoles = null;

            using (MSSQL_Practica_LlamadasEntities conexion = new MSSQL_Practica_LlamadasEntities())
            {
                                 lstTipo = (from tu in conexion.Tipo_Usuario
                                                 select new Tipo_UsuarioDTO
                                                 {
                                                     Id_Tipo_Usuario = tu.Id_Tipo_Usuario,
                                                     Tipo_Descripcion = tu.Tipo_Descripcion,
                                                     Activo = tu.Activo,
                                                 }).ToList();

                                 lstRoles = (from ro in conexion.Roles
                                 select new RolesDTO
                                {
                                 Id_Rol = ro.Id_Rol,
                                 Rol_Descripcion = ro.Rol_Descripcion,
                                 Activo = ro.Activo,
                                }).ToList();
            }

            List<SelectListItem> tipoList = lstTipo.ConvertAll(x =>
            {
                return new SelectListItem()
                {
                    Text = x.Tipo_Descripcion.ToString(),
                    Value = x.Id_Tipo_Usuario.ToString(),
                    Selected = false
                };
            });

            List<SelectListItem> tipoRol = lstRoles.ConvertAll(x =>
            {
                return new SelectListItem()
                {
                    Text = x.Rol_Descripcion.ToString(),
                    Value = x.Id_Rol.ToString(),
                    Selected = false
                };
            });

            ViewBag.tipoRol = tipoRol;

            ViewBag.tipoList = tipoList;
                
             return View();
            

          
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

            using (var con = new MSSQL_Practica_LlamadasEntities())
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

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            EditcUsers editcUsers = new EditcUsers();

            using(var con = new MSSQL_Practica_LlamadasEntities())
            {
                var oUsers = con.Users.Find(Id);
                editcUsers.Id_User = oUsers.Id_User;
                editcUsers.UserName = oUsers.UserName;
                editcUsers.UserLogin = oUsers.UserLogin;
                
                editcUsers.Phone = oUsers.Phone;
                editcUsers.Rol_Descripcion = "1";
                editcUsers.Tipo_Descripcion = "1";

            }

            return View(editcUsers);
        }

        [HttpPost]
        public ActionResult Edit(EditcUsers editcUsers) 
        {
            //if (!ModelState.IsValid)
            //{
            //    return View(usersEdit);
            //}

            using (var con = new MSSQL_Practica_LlamadasEntities())
            {
                var oUsers = con.Users.Find(editcUsers.Id_User);
                oUsers.UserName = editcUsers.UserName;
                oUsers.UserLogin = editcUsers.UserLogin;
                oUsers.Phone = editcUsers.Phone;
                oUsers.Id_Rol = 1;
                oUsers.Id_Tipo_Usuario = 1;
                oUsers.Passwordkey = "2";
                

                //if (oUsers.Passwordkey!=null && oUsers.Passwordkey.Length>0 && oUsers.Passwordkey.Trim() != "")
                //{
                //    oUsers.Passwordkey= editcUsers.Passwordkey;
                //}
                
                con.Entry(oUsers).State = System.Data.Entity.EntityState.Modified;
                con.SaveChanges();

            }

            return Redirect(Url.Content("~/Users/"));
        }

        [HttpPost]
        public ActionResult Delete(int Id)
        {
            

            using (var con = new MSSQL_Practica_LlamadasEntities())
            {
                var oUsers = con.Users.Find(Id);
                oUsers.Activo = 2;
                

                con.Entry(oUsers).State = System.Data.Entity.EntityState.Modified;
                con.SaveChanges();

            }

            return Content("1");
        }

        public ActionResult ListCell()
        {
            List<Models.DTO.Mobile_Line> lst = null;
            using (MSSQL_Practica_LlamadasEntities conexion = new MSSQL_Practica_LlamadasEntities())
            {
                
                lst = (from dto in conexion.Mobile_Line
                       orderby dto.Descr
                       select new Models.DTO.Mobile_Line
                       {
                           Id_Mobile_Line = dto.Id_Mobile_Line,
                           MobileLineId = dto.MobileLineId,
                           MobileLine = dto.MobileLine,
                           Descr = dto.Descr,
                           

                       }).ToList();

            }

            return View(lst);
        }

    }
}