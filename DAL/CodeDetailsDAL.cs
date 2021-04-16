using DAL.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
    public class CodeDetailsDAL
    {
        private readonly IConfiguration _configuration;
        private readonly string _strConn;
        private const string __DEFAULT_CONN = "EzTrade_Demo";
        private readonly SqlConnection _sqlConnection;

        public CodeDetailsDAL(IConfiguration configuration)
        {
            this._configuration = configuration;
            _strConn = configuration.GetConnectionString(__DEFAULT_CONN);
            _sqlConnection = new SqlConnection(_strConn);
        }

        public DataTable GetCodeDetailsById(int? id)
        {
            DataTable dt = new DataTable();
            try
            {
                if (ConnectionState.Closed == _sqlConnection.State)
                {
                    _sqlConnection.Open();
                }
                SqlCommand cmd = new SqlCommand("SP_getCodeDetailsById", _sqlConnection);
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

        public void InsertCodeDetails(CodeDetails codeDetails)
        {
            
            try
            {
                if (ConnectionState.Closed == _sqlConnection.State)
                {
                    _sqlConnection.Open();
                }
                SqlCommand cmd = new SqlCommand("SP_InsertPriceList", _sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@PRICE_TC", codeDetails.Price_TC);
                cmd.Parameters.AddWithValue("@PRICE_TRAN", codeDetails.Price_Tran);
                cmd.Parameters.AddWithValue("@PRICE_SAN", codeDetails.Price_San);
                cmd.Parameters.AddWithValue("@G3_BUY", codeDetails.G3_Buy);
                cmd.Parameters.AddWithValue("@KL3_BUY", codeDetails.KL3_Buy);
                cmd.Parameters.AddWithValue("@G2_BUY", codeDetails.G2_Buy);
                cmd.Parameters.AddWithValue("@KL2_BUY", codeDetails.KL2_Buy);
                cmd.Parameters.AddWithValue("@G1_BUY", codeDetails.G1_Buy);
                cmd.Parameters.AddWithValue("@KL1_BUY", codeDetails.KL1_Buy);
                cmd.Parameters.AddWithValue("@PRICE_ORDEREXECUTION", codeDetails.Price_OrderExecution);
                cmd.Parameters.AddWithValue("@KL_ORDEREXECUTION", codeDetails.KL_OrderExecution);
                cmd.Parameters.AddWithValue("@G1_SELL", codeDetails.G1_Sell);
                cmd.Parameters.AddWithValue("@KL1_SELL", codeDetails.KL1_Sell);
                cmd.Parameters.AddWithValue("@G2_SELL", codeDetails.G2_Sell);
                cmd.Parameters.AddWithValue("@KL2_SELL", codeDetails.KL2_Sell);
                cmd.Parameters.AddWithValue("@G3_SELL", codeDetails.G3_Sell);
                cmd.Parameters.AddWithValue("@KL3_SELL", codeDetails.KL3_Sell);
                cmd.Parameters.AddWithValue("@TOTALKL", codeDetails.TotalKL);
                cmd.Parameters.AddWithValue("@OPENDOOR", codeDetails.OpenDoor);
                cmd.Parameters.AddWithValue("@TALLEST", codeDetails.Tallest);
                cmd.Parameters.AddWithValue("@LOWEST", codeDetails.Lowest);
                cmd.Parameters.AddWithValue("@NNBUY", codeDetails.NNBuy);
                cmd.Parameters.AddWithValue("@NNSELL", codeDetails.NNSell);
                cmd.Parameters.AddWithValue("@ROOM_LEFT", codeDetails.Room_Left);

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

        public void UpdateCodeDetails(CodeDetails codeDetails)
        {
            try
            {
                if (ConnectionState.Closed == _sqlConnection.State)
                {
                    _sqlConnection.Open();
                }
                SqlCommand cmd = new SqlCommand("Sp_UpdatePriceList", _sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ID", codeDetails.Id);
                cmd.Parameters.AddWithValue("@PRICE_TC", codeDetails.Price_TC);
                cmd.Parameters.AddWithValue("@PRICE_TRAN", codeDetails.Price_Tran);
                cmd.Parameters.AddWithValue("@PRICE_SAN", codeDetails.Price_San);
                cmd.Parameters.AddWithValue("@G3_BUY", codeDetails.G3_Buy);
                cmd.Parameters.AddWithValue("@KL3_BUY", codeDetails.KL3_Buy);
                cmd.Parameters.AddWithValue("@G2_BUY", codeDetails.G2_Buy);
                cmd.Parameters.AddWithValue("@KL2_BUY", codeDetails.KL2_Buy);
                cmd.Parameters.AddWithValue("@G1_BUY", codeDetails.G1_Buy);
                cmd.Parameters.AddWithValue("@KL1_BUY", codeDetails.KL1_Buy);
                cmd.Parameters.AddWithValue("@PRICE_ORDEREXECUTION", codeDetails.Price_OrderExecution);
                cmd.Parameters.AddWithValue("@KL_ORDEREXECUTION", codeDetails.KL_OrderExecution);
                cmd.Parameters.AddWithValue("@G1_SELL", codeDetails.G1_Sell);
                cmd.Parameters.AddWithValue("@KL1_SELL", codeDetails.KL1_Sell);
                cmd.Parameters.AddWithValue("@G2_SELL", codeDetails.G2_Sell);
                cmd.Parameters.AddWithValue("@KL2_SELL", codeDetails.KL2_Sell);
                cmd.Parameters.AddWithValue("@G3_SELL", codeDetails.G3_Sell);
                cmd.Parameters.AddWithValue("@KL3_SELL", codeDetails.KL3_Sell);
                cmd.Parameters.AddWithValue("@TOTALKL", codeDetails.TotalKL);
                cmd.Parameters.AddWithValue("@OPENDOOR", codeDetails.OpenDoor);
                cmd.Parameters.AddWithValue("@TALLEST", codeDetails.Tallest);
                cmd.Parameters.AddWithValue("@LOWEST", codeDetails.Lowest);
                cmd.Parameters.AddWithValue("@NNBUY", codeDetails.NNBuy);
                cmd.Parameters.AddWithValue("@NNSELL", codeDetails.NNSell);
                cmd.Parameters.AddWithValue("@ROOM_LEFT", codeDetails.Room_Left);

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

        public void DeleteCodeDetails(int? id)
        {
            SqlCommand cmd = new SqlCommand("SP_DeletePriceList", _sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", id);
            _sqlConnection.Open();
            cmd.ExecuteReader();
            _sqlConnection.Close();
        }
    }
}
