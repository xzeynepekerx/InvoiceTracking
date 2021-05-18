using Dapper;
using InvoiceTracking.UI.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Claims;

namespace InvoiceTracking.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly LoginForm _loginInfo;
        private readonly string _connectionString;
        public HomeController(IOptions<LoginForm> loginInfo, IOptions<DbConnection> dbConnection)
        {
            _loginInfo = loginInfo.Value;
            _connectionString = dbConnection.Value.ConnectionString;
        }
        [Authorize]

        public IActionResult Index()
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var result = sqlConnection.Query<Invoice>("select * from Invoices").ToList();

                ViewBag.invoices = result;
            }

            return View();
        }

        [Authorize]
        public IActionResult AddInvoice()
        {
            return View();
        }

        [Authorize]
        public IActionResult UpdateInvoice(string InvoiceNo)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@InvoiceNo", InvoiceNo);
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var result = sqlConnection.Query<Invoice>("select * from Invoices where InvoiceNo=@InvoiceNo", parameters).ToList();

                ViewBag.invoices = result;
            }
            return View();
        }



        [Authorize]
        public IActionResult DeleteInvoice(string InvoiceNo)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@InvoiceNo", InvoiceNo);
                using (var sqlConnection = new SqlConnection(_connectionString))
                {
                    var result = sqlConnection.Query<Invoice>("delete from Invoices where InvoiceNo=@InvoiceNo", parameters);

                }
                return Redirect("/");
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
            }
            return Redirect("/");
        }
        [Authorize]
        [HttpPost]
        public IActionResult AddInvoice(Invoice invoice)
        {
            try
            {
                if (IsInvoiceThere(invoice.InvoiceNo))
                {
                    TempData["error"] = "İlgili Fatura numarsına ait kayıt bulunmaktadır. Lütfen kontrol ediniz.";
                }
                else
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@InvoiceNo", invoice.InvoiceNo);
                    parameters.Add("@NameSurname", invoice.NameSurname);
                    parameters.Add("@Tc", invoice.Tc);
                    parameters.Add("@SubscriberNo", invoice.SubscriberNo);
                    parameters.Add("@Address", invoice.Address);
                    parameters.Add("@InvoiceType", invoice.InvoiceType);
                    parameters.Add("@Price", invoice.Price);
                    parameters.Add("@InvoiceDate", invoice.InvoiceDate);
                    parameters.Add("@InvoiceStatus", invoice.InvoiceStatus);
                    parameters.Add("@InvoiceStatusText", invoice.InvoiceStatusText);
                    using (var sqlConnection = new SqlConnection(_connectionString))
                    {
                        var result = sqlConnection.Query<Invoice>(@"
                    insert into Invoices 
                    (InvoiceNo,NameSurname,Tc,SubscriberNo,Address,InvoiceType,Price,InvoiceDate,InvoiceStatus,InvoiceStatusText) values 
                    (@InvoiceNo,@NameSurname,@Tc,@SubscriberNo,@Address,@InvoiceType,@Price,@InvoiceDate,@InvoiceStatus,@InvoiceStatusText)", parameters);

                    }
                    return Redirect("/");
                }

            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
            }
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult UpdateInvoice(Invoice invoice)
        {
            try
            {
               
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@InvoiceNo", invoice.InvoiceNo);
                    parameters.Add("@NameSurname", invoice.NameSurname);
                    parameters.Add("@Tc", invoice.Tc);
                    parameters.Add("@SubscriberNo", invoice.SubscriberNo);
                    parameters.Add("@Address", invoice.Address);
                    parameters.Add("@InvoiceType", invoice.InvoiceType);
                    parameters.Add("@Price", invoice.Price);
                    parameters.Add("@InvoiceDate", invoice.InvoiceDate);
                    parameters.Add("@InvoiceStatus", invoice.InvoiceStatus);
                    parameters.Add("@InvoiceStatusText", invoice.InvoiceStatusText);
                    using (var sqlConnection = new SqlConnection(_connectionString))
                    {
                        var result = sqlConnection.Query<Invoice>(@"
                    update Invoices set NameSurname=@NameSurname,Tc=@Tc,SubscriberNo=@SubscriberNo,Address=@Address,InvoiceType=@InvoiceType,Price=@Price,
                                        InvoiceDate=@InvoiceDate,InvoiceStatus=@InvoiceStatus,InvoiceStatusText=@InvoiceStatusText
                            where InvoiceNo=@InvoiceNo", parameters);

                    }
                    return Redirect("/");
                

            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
            }
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        [Authorize]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return Redirect("/Login");
        }
        [HttpPost]
        public IActionResult Login(LoginForm loginForm)
        {
            if (loginForm.Username == _loginInfo.Username && loginForm.Password == _loginInfo.Password)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier,loginForm.Username)
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties();
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

                return Redirect(string.IsNullOrEmpty(HttpContext.Request.Query["ReturnUrl"]) ? "/" : HttpContext.Request.Query["ReturnUrl"].ToString());
            }

            TempData["error"] = $"Kullanıcı adı veya parola yanlış.";
            return View();
        }

        public bool IsInvoiceThere(string InvoiceNo)
        {
            bool durum = false;
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@InvoiceNo", InvoiceNo);
                using (var sqlConnection = new SqlConnection(_connectionString))
                {
                    var result = sqlConnection.Query<Invoice>("select InvoiceNo from Invoices where InvoiceNo=@InvoiceNo", parameters);
                    if (result.ToList().Count>0)
                    {
                        durum = true;
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
            }

            return durum;
        }
    }
}