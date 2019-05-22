using System;
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

            strQuery.AppendLine(" SELECT descresp, descmotivo, descestatus");
            strQuery.AppendLine(" FROM");
            strQuery.AppendLine(" respuestas");
            strQuery.AppendLine(" INNER JOIN motivo ON respuestas.idmotivo = motivo.idmotivo");
            strQuery.AppendLine(" INNER JOIN estatus ON respuestas.idestatus = estatus.idestatus;");

            return strQuery.ToString();

        }


        private static string QueryInsertResp()
        {

            StringBuilder strQuery = new StringBuilder();

            strQuery.AppendLine(" insert into respuestas (idmotivo, descresp, idestatus)");
            strQuery.AppendLine(" values (@IdMotivo, @Respuesta, 1);");

            return strQuery.ToString();

        }

    }
}