﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LIST.Data;
using Microsoft.EntityFrameworkCore;
using LIST.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LIST_Core.Controllers
{
    public class LoginController : Controller
    {
        private readonly LeerlingContext _context;

        public LoginController(LeerlingContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Signout()
        {
            HttpContext.Session.Remove("Token");
            HttpContext.Session.Remove("Type");
            return View("Index");
        }

        [HttpPost]
        public IActionResult Login(Login login)
        {
            if(!string.IsNullOrEmpty(login.Username) && !string.IsNullOrEmpty(login.Password))
            {
                var data = _context.Logindata.Where(s => s.Username == login.Username).FirstOrDefault();
                if (LIST.Classes.Encryption.HASH.checkPBKDF2(login.Password, data.Password))
                {
                    HttpContext.Session.SetString("Token", data.Token);
                    HttpContext.Session.SetInt32("Type", data.Type);
                    HttpContext.Session.SetString("Username", data.Username);
                    if (data.Type == 0)
                    {
                        return RedirectToAction("Index", "Leerling/Home");
                    }
                    else
                    {

                    }

                    ViewBag.Message = "Welkom " + data.Username + data.Type.ToString();
                    return View("Index");

                }
                else
                {
                    ViewBag.Message = "ErrGebruikersnaam of wachtwoord onjuist";
                    return View("Index");
                }
            }
            else
            {
                ViewBag.Message = "ErrVul alle velden in!";
                return View("Index");
            }


        }
    }
}