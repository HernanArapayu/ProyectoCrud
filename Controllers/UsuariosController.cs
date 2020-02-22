using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Empresa.Models;


namespace Empresa.Controllers
{
    public class UsuariosController:Controller
    {
          CRUDContext context;

         public UsuariosController(CRUDContext CTX){
             context = CTX;
         }  

         public IActionResult index(){
             Usuarios usuario = new Usuarios();

             ViewBag.Usuarios = context.Usuarios.ToList();
             return View(usuario);
         }

         [BindProperty]
         public Usuarios usuario {get;set;}


         public IActionResult guardar(){
                
                if(!ModelState.IsValid){
                    return RedirectToAction("Crear");
                }
                var _usuario = context.Usuarios.Where(x=>x.IdUsuario==usuario.IdUsuario).SingleOrDefault();
                if(_usuario==null){
                    context.Usuarios.Add(usuario);
                }else{

                    _usuario.Nombre=usuario.Nombre;
                    _usuario.Apellido=usuario.Apellido;
                    _usuario.Edad=usuario.Edad;
                    _usuario.Email=usuario.Email;
                }

                
                context.SaveChanges();


                return RedirectToAction("index");
         }

         public IActionResult Crear(){
             return View();
         }

        public IActionResult Modificar(int id){

            var usuario = context.Usuarios.Find(id);
            if(usuario==null){
                return Redirect("Home/Index");

            }

            return View(usuario);
        }

        public IActionResult Eliminar(int id){
            var usuario = context.Usuarios.Find(id);
            if(usuario==null){
                return StatusCode(404);
            }

            context.Usuarios.Remove(usuario);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}