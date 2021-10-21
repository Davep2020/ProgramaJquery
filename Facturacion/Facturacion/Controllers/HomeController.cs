using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Facturacion.Models;

namespace Facturacion.Controllers
{
    public class HomeController : Controller
    {

        FacturaEntities modelo = new FacturaEntities(); 

        public ActionResult Index()
        {
            List<MuestraLosCientes_Result> lista = new List<MuestraLosCientes_Result>();
            lista = modelo.MuestraLosCientes().ToList();
            return View(lista);
        }


        #region Json
        public ActionResult RetornaClientes()
        {
            List<MuestraLosCientes_Result> Cliente = this.modelo.MuestraLosCientes().ToList();
            return Json(Cliente);
        }
        public ActionResult RetornaFactura(int CodigoCliente)
        {
            List<MuestralasFacturasCLIENTE_Result> Factura = this.modelo.MuestralasFacturasCLIENTE(CodigoCliente).ToList();
            return Json(Factura);
        }


        [HttpPost]
        public ActionResult Recibos(RecibosSelect_Result modelos,int? MontoAbono1 , int? NumeroFacturaAbonada1, int? MontoAbono2, int? NumeroFacturaAbonada2)
        {
            int registros = 0;
           string mensaje = "";
     for(var i = 0; i < 3; i++)
            {
                if (i == 0) {
                if (modelos.MontoAbono != 0)
                {
                    try
                    {
                        registros = modelo.AgregaRecibo(
                            modelos.CodigoCliente,
                            modelos.MontoAbono,
                            modelos.NumeroFacturaAbonada

                       );



                    }

                    catch (Exception e)
                    {
                        mensaje = "Ocurrió un error: " + e.Message;
                    }

                }
                }
                if (i == 1)
                {

                if (MontoAbono1 != 0)
                {
                    try
                    {
                        registros = modelo.AgregaRecibo(
                            modelos.CodigoCliente,
                            modelos.MontoAbono = (int)MontoAbono1,
                            modelos.NumeroFacturaAbonada = (int)NumeroFacturaAbonada1

                       );



                    }

                    catch (Exception e)
                    {
                        mensaje = "Ocurrió un error: " + e.Message;
                    }

                }
                }
                if (i == 2)
                {
                if (MontoAbono2 != 0)
                {
                    try
                    {
                        registros = modelo.AgregaRecibo(
                            modelos.CodigoCliente,
                            modelos.MontoAbono = (int)MontoAbono2,
                            modelos.NumeroFacturaAbonada = (int)NumeroFacturaAbonada2

                       );



                    }

                    catch (Exception e)
                    {
                        mensaje = "Ocurrió un error: " + e.Message;
                    }

                }
                }
            }
              

            return RedirectToAction("Pagos", "Home");
        }





        #endregion


        public ActionResult Pagos()
        {
            return View();
        }

        public ActionResult Contact(int CodigoCliente)
        {
            ClienteID_Result modelovista = new ClienteID_Result();
            modelovista = this.modelo.ClienteID(CodigoCliente).FirstOrDefault();
            return View(modelovista);
        }
        [HttpPost]
        public ActionResult Contact(ClienteID_Result modelos)
        {
            int registros = 0;

            string mensaje = "";

            try
            {
                registros = modelo.ModificarCliente(
                    modelos.CodigoCliente,
                    modelos.NombreCliente,
                    modelos.SaldoMes,
                    modelos.AbonoMes

               );



            }

            catch (Exception e)
            {
                mensaje = "Ocurrió un error: " + e.Message;
            }

            return RedirectToAction("Index", "Home");
        }
        #region ingresaCliente
        public ActionResult IngresarCliente()
        {
            return View();
        }
        [HttpPost]
        public ActionResult IngresarCliente(MuestraCliente_Result modelos)
        {
            int registros = 0;

            string mensaje = "";

            try
            {
                registros = modelo.InsertCliente(
                    modelos.NombreCliente,
                    modelos.SaldoMes,
                    modelos.AbonoMes

               );



            }

            catch (Exception e)
            {
                mensaje = "Ocurrió un error: " + e.Message;
            }

            return View();
        }
        #endregion

    }
}