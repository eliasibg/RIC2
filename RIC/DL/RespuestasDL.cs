﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Npgsql;
using RIC.DB;
using RIC.Models;

namespace RIC.DL
{
	public class RespuestasDL 
	{



        public static bool Test()
        {


            DataTable dtTest = null;
            Connection objConn = new Connection();
            bool blTest = false;

            try
            {
                dtTest = objConn.LoadDatos(QueryTest());

                foreach (DataRow row in dtTest.Rows)
                {
                    blTest = true; // Asgina el valor del estatus 

                }

                
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return blTest;

        }


        public static List<Respuesta> GetRespuestas()
        {

            List<Respuesta> lstInventario = new List<Respuesta>();
            Connection objConn = new Connection();

            DataTable dtResp = null;

            try
            {

                dtResp = objConn.LoadDatos(QueryGetRespuestas());
                if (dtResp.Rows.Count > 0)
                {
                    foreach (DataRow row in dtResp.Rows)
                    {
                        Respuesta objResp = new Respuesta();

                        objResp.strIdResp = row["idrespuesta"].ToString();
                        objResp.strRespuesta = row["descresp"].ToString();
                        objResp.strMotivo = row["descmotivo"].ToString();
                        objResp.strEstatus = row["descestatus"].ToString();


                        lstInventario.Add(objResp);
                    }
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return lstInventario;

        }


        public static List<Respuesta> FindRespuestas(String strIdMotivo)
        {

            List<Respuesta> lstInventario = new List<Respuesta>();
            Connection objConn = new Connection();

            DataTable dtResp = null;

            try
            {
                NpgsqlParameter[] param = new NpgsqlParameter[1];

                param[0] = new NpgsqlParameter("IdMotivo", strIdMotivo);

                dtResp = objConn.LoadDatos(QueryFindRespuestas(), param);
                if (dtResp.Rows.Count > 0)
                {
                    foreach (DataRow row in dtResp.Rows)
                    {
                        Respuesta objResp = new Respuesta();

                        objResp.strRespuesta = row["descresp"].ToString();
                        objResp.strMotivo = row["descmotivo"].ToString();
                        objResp.strEstatus = row["descestatus"].ToString();


                        lstInventario.Add(objResp);
                    }
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return lstInventario;

        }


        public static Dictionary<string, string> GetComboMotivo()
        {

            Dictionary<string, string> dicMotivo = new Dictionary<string, string>();
            List<Motivo> lstInventario = new List<Motivo>();
            Connection objConn = new Connection();

            DataTable dtResp = null;

            try
            {

                dtResp = objConn.LoadDatos(QueryGetMotivos());
                if (dtResp.Rows.Count > 0)
                {
                    foreach (DataRow row in dtResp.Rows)
                    {
                        Motivo objResp = new Motivo();

                        objResp.strIdMotivo = row["idmotivo"].ToString();
                        objResp.strDescMotivo = row["descmotivo"].ToString();
                        
                        lstInventario.Add(objResp);
                    }

                    var lstMotivo = lstInventario;

                    foreach (var item in lstMotivo)
                    {
                        //dicEmpresas.Add(Convert.ToString(item.IdEmpresa + "_" + item.CveEmpresa), Convert.ToString(item.NombreEmpresa));
                        dicMotivo.Add(Convert.ToString(item.strIdMotivo), Convert.ToString(item.strDescMotivo ));
                    }

                }
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return dicMotivo;

        }


        public static bool InsertarInventario(string strIdMotivo, string strRespuesta)
        {
            bool blIsOk = true;

            Connection objConn = new Connection();

            using (NpgsqlConnection conn = new NpgsqlConnection(objConn.connectionString))
            {
                conn.Open();

                using (NpgsqlTransaction tr = conn.BeginTransaction())
                {
                    try
                    {

                        NpgsqlParameter[] param = new NpgsqlParameter[2];

                        param[0] =    new NpgsqlParameter("IdMotivo", strIdMotivo);
                        param[1] = new NpgsqlParameter("Respuesta", strRespuesta);


                        int iFirma = objConn.InsertQuery(QueryInsertResp(), param);

                       
                            tr.Commit();


                        blIsOk = true;
                        
                    }
                    catch (Exception ex)
                    {
                        tr.Rollback();
                        conn.Close();
                        return false;
                    }
                }
                conn.Close();
            }
            return blIsOk;
        }



        public static List<Respuesta> LoadRespuesta(String strIdResp)
        {

            List<Respuesta> lstInventario = new List<Respuesta>();
            Connection objConn = new Connection();

            DataTable dtResp = null;

           
            try
            {
                NpgsqlParameter[] param = new NpgsqlParameter[1];

                param[0] = new NpgsqlParameter("IdResp", Convert.ToInt32(strIdResp));

                dtResp = objConn.LoadDatos(QueryFindRespuesta(), param);
                if (dtResp.Rows.Count > 0)
                {
                    foreach (DataRow row in dtResp.Rows)
                    {
                        Respuesta objResp = new Respuesta();

                        objResp.strRespuesta = row["descresp"].ToString();
                        objResp.strMotivo = row["idmotivo"].ToString();
                        objResp.strEstatus = row["descestatus"].ToString();


                        lstInventario.Add(objResp);
                    }
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return lstInventario;

        }






        public static bool ModificarInventario(string strIdMotivo, string strRespuesta, string strIdResp)
        {
            bool blIsOk = true;

            Connection objConn = new Connection();

            using (NpgsqlConnection conn = new NpgsqlConnection(objConn.connectionString))
            {
                conn.Open();

                using (NpgsqlTransaction tr = conn.BeginTransaction())
                {
                    try
                    {

                        NpgsqlParameter[] param = new NpgsqlParameter[3];

                        param[0] = new NpgsqlParameter("IdMotivo", strIdMotivo);
                        param[1] = new NpgsqlParameter("Respuesta", strRespuesta);
                        param[2] = new NpgsqlParameter("IdResp", Convert.ToInt32(strIdResp));


                        int iFirma = objConn.InsertQuery(QueryUpdateResp(), param);


                        tr.Commit();


                        blIsOk = true;

                    }
                    catch (Exception ex)
                    {
                        tr.Rollback();
                        conn.Close();
                        return false;
                    }
                }
                conn.Close();
            }
            return blIsOk;
        }





        private static string QueryTest()
        {

            StringBuilder strQuery = new StringBuilder();

            strQuery.AppendLine(" Select * from inicio;");

            return strQuery.ToString();

        }

        private static string QueryGetMotivos()
        {

            StringBuilder strQuery = new StringBuilder();

            strQuery.AppendLine(" Select * from motivo;");

            return strQuery.ToString();

        }


        private static string QueryGetRespuestas()
        {

            StringBuilder strQuery = new StringBuilder();

            strQuery.AppendLine(" SELECT idrespuesta, descresp, descmotivo, descestatus");
            strQuery.AppendLine(" FROM");
            strQuery.AppendLine(" respuestas");
            strQuery.AppendLine(" INNER JOIN motivo ON respuestas.idmotivo = motivo.idmotivo");
            strQuery.AppendLine(" INNER JOIN estatus ON respuestas.idestatus = estatus.idestatus;");

            return strQuery.ToString();

        }


        private static string QueryFindRespuestas()
        {

            StringBuilder strQuery = new StringBuilder();

            strQuery.AppendLine(" SELECT descresp, descmotivo, descestatus");
            strQuery.AppendLine(" FROM");
            strQuery.AppendLine(" respuestas");
            strQuery.AppendLine(" INNER JOIN motivo ON respuestas.idmotivo = motivo.idmotivo");
            strQuery.AppendLine(" INNER JOIN estatus ON respuestas.idestatus = estatus.idestatus");
            strQuery.AppendLine(" where");
            strQuery.AppendLine(" respuestas.idmotivo = @IdMotivo");

            return strQuery.ToString();

        }


        private static string QueryFindRespuesta()
        {

            StringBuilder strQuery = new StringBuilder();

            strQuery.AppendLine(" SELECT descresp, respuestas.idmotivo, descestatus");
            strQuery.AppendLine(" FROM");
            strQuery.AppendLine(" respuestas");
            strQuery.AppendLine(" INNER JOIN motivo ON respuestas.idmotivo = motivo.idmotivo");
            strQuery.AppendLine(" INNER JOIN estatus ON respuestas.idestatus = estatus.idestatus");
            strQuery.AppendLine(" where");
            strQuery.AppendLine(" respuestas.idrespuesta = @IdResp");

            return strQuery.ToString();

        }


        private static string QueryInsertResp()
        {

            StringBuilder strQuery = new StringBuilder();

            strQuery.AppendLine(" insert into respuestas (idmotivo, descresp, idestatus)");
            strQuery.AppendLine(" values (@IdMotivo, @Respuesta, 1);");

            return strQuery.ToString();

        }


        private static string QueryUpdateResp()
        {

            StringBuilder strQuery = new StringBuilder();

            strQuery.AppendLine(" update respuestas");
            strQuery.AppendLine(" set idmotivo = @IdMotivo, descresp = @Respuesta ");
            strQuery.AppendLine(" where idrespuesta = @IdResp");

            return strQuery.ToString();

        }


    }
}