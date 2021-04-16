using DAL;
using DAL.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BLL
{
    public class CodeDetailsBLL
    {
        private readonly CodeDetailsDAL _codeDAL;
        private readonly ILogger<CodeDetailsBLL> _logger;

        public CodeDetailsBLL(CodeDetailsDAL codeDAL, ILogger<CodeDetailsBLL> logger)
        {
            _logger = logger;
            _codeDAL = codeDAL;
        }

        public CodeDetails GetCodeDetailsById(int? id)
        {
            CodeDetails code = new CodeDetails();
            DataTable dt = _codeDAL.GetCodeDetailsById(id);
            
            foreach(DataRow dr in dt.Rows)
            {
                code.Price_TC = string.IsNullOrEmpty(dr["Price_TC"].ToString()) ? 0 : float.Parse(dr["Price_TC"].ToString());
                code.Price_Tran = string.IsNullOrEmpty(dr["Price_Tran"].ToString()) ? 0 : float.Parse(dr["Price_Tran"].ToString());
                code.Price_San = string.IsNullOrEmpty(dr["Price_San"].ToString()) ? 0 : float.Parse(dr["Price_San"].ToString());
                code.G3_Buy = string.IsNullOrEmpty(dr["G3_Buy"].ToString()) ? 0 : float.Parse(dr["G3_Buy"].ToString());
                code.KL3_Buy = string.IsNullOrEmpty(dr["KL3_Buy"].ToString()) ? 0 : decimal.Parse(dr["KL3_Buy"].ToString());
                code.G2_Buy = string.IsNullOrEmpty(dr["G2_Buy"].ToString()) ? 0 : float.Parse(dr["G2_Buy"].ToString());
                code.KL2_Buy = string.IsNullOrEmpty(dr["KL2_Buy"].ToString()) ? 0 : decimal.Parse(dr["KL2_Buy"].ToString());
                code.G1_Buy = string.IsNullOrEmpty(dr["G1_Buy"].ToString()) ? 0 : float.Parse(dr["G1_Buy"].ToString());
                code.KL1_Buy = string.IsNullOrEmpty(dr["KL1_Buy"].ToString()) ? 0 : decimal.Parse(dr["KL1_Buy"].ToString());
                code.Price_OrderExecution = string.IsNullOrEmpty(dr["Price_OrderExecution"].ToString()) ? 0 : float.Parse(dr["Price_OrderExecution"].ToString());
                code.KL_OrderExecution = string.IsNullOrEmpty(dr["KL_OrderExecution"].ToString()) ? 0 : decimal.Parse(dr["KL_OrderExecution"].ToString());
                code.G1_Sell = string.IsNullOrEmpty(dr["G1_Sell"].ToString()) ? 0 : float.Parse(dr["G1_Sell"].ToString());
                code.KL1_Sell = string.IsNullOrEmpty(dr["KL1_Sell"].ToString()) ? 0 : decimal.Parse(dr["KL1_Sell"].ToString());
                code.G2_Sell = string.IsNullOrEmpty(dr["G2_Sell"].ToString()) ? 0 : float.Parse(dr["G2_Sell"].ToString());
                code.KL2_Sell = string.IsNullOrEmpty(dr["KL2_Sell"].ToString()) ? 0 : decimal.Parse(dr["KL2_Sell"].ToString());
                code.G3_Sell = string.IsNullOrEmpty(dr["G3_Sell"].ToString()) ? 0 : float.Parse(dr["G3_Sell"].ToString());
                code.KL3_Sell = string.IsNullOrEmpty(dr["KL3_Sell"].ToString()) ? 0 : decimal.Parse(dr["KL3_Sell"].ToString());
                code.TotalKL = string.IsNullOrEmpty(dr["TotalKL"].ToString()) ? 0 : decimal.Parse(dr["TotalKL"].ToString());
                code.OpenDoor = string.IsNullOrEmpty(dr["OpenDoor"].ToString()) ? 0 : float.Parse(dr["OpenDoor"].ToString());
                code.Tallest = string.IsNullOrEmpty(dr["Tallest"].ToString()) ? 0 : float.Parse(dr["Tallest"].ToString());
                code.Lowest = string.IsNullOrEmpty(dr["Lowest"].ToString()) ? 0 : float.Parse(dr["Lowest"].ToString());
                code.NNBuy = string.IsNullOrEmpty(dr["NNBuy"].ToString()) ? 0 : float.Parse(dr["NNBuy"].ToString());
                code.NNSell = string.IsNullOrEmpty(dr["NNSell"].ToString()) ? 0 : float.Parse(dr["NNSell"].ToString());
                code.Room_Left = string.IsNullOrEmpty(dr["Room_Left"].ToString()) ? 0 : decimal.Parse(dr["Room_Left"].ToString());
            }
            return code;
        }

        public void AddCodeDetails(CodeDetails codeDetails)
        {
            _codeDAL.InsertCodeDetails(codeDetails);
        }

        public void UpdateCodeDetails(CodeDetails codeDetails)
        {
            _codeDAL.UpdateCodeDetails(codeDetails);
        }
        
        public void DeleteCodeDetails(int? id)
        {
            _codeDAL.DeleteCodeDetails(id);
        }
    }
}
