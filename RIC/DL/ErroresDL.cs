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
	public class ErroresDL

	{

        public static List<Error> GetErrores()
        {

            List<Error> lstError = new List<Error>();
            Connection objConn = new Connection();

            DataTable dtError = null;

            try
            {

                dtError = objConn.LoadDatos(QueryGetErrores());
                if (dtError.Rows.Count > 0)
                {
                    foreach (DataRow row in dtError.Rows)
                    {
                        Error objError = new Error();

                        objError.iId = Convert.ToInt32( row["iderror"].ToString());
                        objError.strDesc = row["descerror"].ToString();
                        objError.strEstatus = row["descestatus"].ToString();


                        lstError.Add(objError);
                    }
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return lstError;

        }


        public static List<Error> FindErrores()
        {

            List<Error> lstError = new List<Error>();
            Connection objConn = new Connection();

            DataTable dtError = null;

            try
            {

                dtError = objConn.LoadDatos(QueryGetErrores());
                if (dtError.Rows.Count > 0)
                {
                    foreach (DataRow row in dtError.Rows)
                    {
                        Error objError = new Error();

                        objError.iId = Convert.ToInt32(row["iderror"].ToString());
                        objError.strDesc = row["descerror"].ToString();
                        objError.strEstatus = row["descestatus"].ToString();


                        lstError.Add(objError);
                    }
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return lstError;

        }

        private static string QueryGetErrores()
        {

            StringBuilder strQuery = new StringBuilder();

            strQuery.AppendLine(" SELECT iderror, descerror, descestatus");
            strQuery.AppendLine(" FROM");
            strQuery.AppendLine(" error");
            strQuery.AppendLine(" INNER JOIN estatus ON error.idestatus = estatus.idestatus;");

            return strQuery.ToString();

        }


        private static string QueryFindErrores()
        {

            StringBuilder strQuery = new StringBuilder();

            strQuery.AppendLine(" SELECT iderror, descerror, descestatus");
            strQuery.AppendLine(" FROM");
            strQuery.AppendLine(" error");
            strQuery.AppendLine(" INNER JOIN estatus ON error.idestatus = estatus.idestatus;");

            return strQuery.ToString();

        }

    }
}