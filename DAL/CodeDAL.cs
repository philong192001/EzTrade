using DAL.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
    public class CodeDAL
    {
        private readonly IConfiguration _configuration;
        private readonly string _strConn;
        private const string __DEFAULT_CONN = "EzTrade_Demo";
        private readonly SqlConnection _sqlConnection;

        public CodeDAL(IConfiguration config)
        {
            this._configuration = config;
            _strConn = _configuration.GetConnectionString(__DEFAULT_CONN);
            _sqlConnection = new SqlConnection(_strConn);
        }
        public DataTable GetCode()
        {
            DataTable dt = new DataTable();
            try
            {
                if (ConnectionState.Closed == _sqlConnection.State)
                {
                    _sqlConnection.Open();
                }
                SqlCommand cmd = new SqlCommand("SP_GetPiceList", _sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader rd = cmd.ExecuteReader();
                dt.Load(rd);
            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                _sqlConnection.Close();
            }
            return dt;
        }
        
        public DataTable GetCodeById(int? id)
        {
            DataTable dt = new DataTable();
            try
            {
                if(ConnectionState.Closed == _sqlConnection.State)
                {
                    _sqlConnection.Open();
                }
                SqlCommand cmd = new SqlCommand("SP_getCodeById", _sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", id);
                SqlDataReader rd = cmd.ExecuteReader();
                dt.Load(rd);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                _sqlConnection.Close();
            }
            return dt;
        }

        public DataSet AllCodeDetails()
        {
            DataSet ds = new DataSet();
            try
            {
                if (ConnectionState.Closed == _sqlConnection.State)
                {
                    _sqlConnection.Open();
                }
                SqlCommand cmd = new SqlCommand("SP_GetAllCodeDetails", _sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
            }
            catch
            {
                throw;
            }
            finally
            {
                _sqlConnection.Close();
            }
            return ds;
        }

        public DataTable GetAllCode()
        {
            DataTable dt = new DataTable();
            try
            {
                if (ConnectionState.Closed == _sqlConnection.State)
                {
                    _sqlConnection.Open();
                }
                SqlCommand cmd = new SqlCommand("SP_GetAllCode", _sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch
            {
                throw;
            }
            finally
            {
                _sqlConnection.Close();
            }
            return dt;
        }

        public void InsertCode(Code code)
        {
            try
            {
                if (ConnectionState.Closed == _sqlConnection.State)
                {
                    _sqlConnection.Open();
                }
                SqlCommand cmd = new SqlCommand("SP_InsertCode",_sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NAME_CODE", code.NameCode);
                cmd.Parameters.AddWithValue("@ID_DETAILS", code.Id_details);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                _sqlConnection.Close();
            }
        }

        public void UpdateCode(Code code)
        {
            try
            {
                if (ConnectionState.Closed == _sqlConnection.State)
                {
                    _sqlConnection.Open();
                }
                SqlCommand cmd = new SqlCommand("Sp_UpdateCode", _sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", code.Id);
                cmd.Parameters.AddWithValue("@NAME_CODE", code.NameCode);
                cmd.Parameters.AddWithValue("@ID_DETAILS", code.Id_details);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                _sqlConnection.Close();
            }
        }
        
        public void Delete(int? id)
        {
            SqlCommand cmd = new SqlCommand("Sp_DeleteCode", _sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", id);
            _sqlConnection.Open();
            cmd.ExecuteReader();
            _sqlConnection.Close();
        }
    }
}
