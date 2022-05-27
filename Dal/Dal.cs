using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Models;

namespace Dal
{
    public class Dalcls
    {
        public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        public List<HomeModel> GetClientData(string strSearch)
        {
            List<HomeModel> lstHomeModel = new List<HomeModel>();
            try
            {
                DataTable dt = new DataTable();
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@FLAG", "GET"));
                param.Add(new SqlParameter("@Search", strSearch));
                SqlCommand cmd = new SqlCommand("sp_ClientDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(param.ToArray());
                con.Open();
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    HomeModel objHomeModel = new HomeModel();
                    objHomeModel.Id = Convert.ToInt32(dt.Rows[i]["Id"].ToString());
                    objHomeModel.Fname = dt.Rows[i]["FName"].ToString();
                    objHomeModel.LName = dt.Rows[i]["LName"].ToString();
                    objHomeModel.Address = dt.Rows[i]["Address"].ToString();
                    objHomeModel.EmailId = dt.Rows[i]["EmailID"].ToString();
                    objHomeModel.DOB = Convert.ToDateTime(dt.Rows[i]["DOB"].ToString());
                    lstHomeModel.Add(objHomeModel);
                }
            }
            catch(Exception ex)
            {

            }
            finally
            {
                con.Close();
            }
            return lstHomeModel;
        }

        public List<HomeModel> GetClientDataAPI(string strSearch)
        {
            List<HomeModel> lstHomeModel = new List<HomeModel>();
            try
            {
                DataTable dt = new DataTable();
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@FLAG", "APIData"));
                param.Add(new SqlParameter("@Search", strSearch));
                SqlCommand cmd = new SqlCommand("sp_ClientDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(param.ToArray());
                con.Open();
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    HomeModel objHomeModel = new HomeModel();
                    objHomeModel.Id = Convert.ToInt32(dt.Rows[i]["Id"].ToString());
                    objHomeModel.Fname = dt.Rows[i]["FName"].ToString();
                    objHomeModel.LName = dt.Rows[i]["LName"].ToString();
                    objHomeModel.Address = dt.Rows[i]["Address"].ToString();
                    objHomeModel.EmailId = dt.Rows[i]["EmailID"].ToString();
                    objHomeModel.DOB = Convert.ToDateTime(dt.Rows[i]["DOB"].ToString());
                    lstHomeModel.Add(objHomeModel);
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }
            return lstHomeModel;
        }



        public int InsertClientData(HomeModel objHomeModel)
        {
            int iRetvalue = 0;
            try
            {
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@FLAG", "INS"));                
                param.Add(new SqlParameter("@Fname", objHomeModel.Fname));
                param.Add(new SqlParameter("@LName", objHomeModel.LName));
                param.Add(new SqlParameter("@Address", objHomeModel.Address));
                param.Add(new SqlParameter("@EmailId", objHomeModel.EmailId));
                param.Add(new SqlParameter("@DOB", objHomeModel.DOB));
                SqlCommand cmd = new SqlCommand("sp_ClientDetails", con);               
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(param.ToArray());
                con.Open();
                iRetvalue = cmd.ExecuteNonQuery();                               
            }
            catch (Exception ex)
            {
                iRetvalue = 0;
            }
            finally
            {
                con.Close();
            }
            return iRetvalue;
        }

    }
}