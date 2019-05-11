using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using RIC.DB;

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




        private static string QueryTest()
        {

            StringBuilder strQuery = new StringBuilder();

            strQuery.AppendLine(" Select * from inicio;");

            return strQuery.ToString();

        }



    }
}