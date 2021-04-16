using DAL;
using DAL.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Text;

namespace BLL
{
    public class CodeBLL
    {
        private readonly CodeDAL _codeDAL;
        private readonly ILogger<CodeBLL> _logger;

        public CodeBLL(CodeDAL codeDAL, ILogger<CodeBLL> logger)
        {
            _logger = logger;
            _codeDAL = codeDAL;
        }

        public List<Code> GetAllCode()
        {
            try
            {
                Code code = new Code();
                DataTable dt = _codeDAL.GetCode();
                List<Code> codes = new List<Code>();
                foreach (DataRow dr in dt.Rows)
                {
                    codes.Add(new Code
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        NameCode = string.IsNullOrEmpty(dr["name_code"].ToString()) ? "" : dr["name_code"].ToString(),
                        Id_details = Convert.ToInt32(dr["id_details"]),
                        Price_TC = string.IsNullOrEmpty(dr["Price_TC"].ToString()) ? 0 : float.Parse(dr["Price_TC"].ToString()),
                        Price_Tran = string.IsNullOrEmpty(dr["Price_Tran"].ToString()) ? 0 : float.Parse(dr["Price_Tran"].ToString()),
                        Price_San = string.IsNullOrEmpty(dr["Price_San"].ToString()) ? 0 : float.Parse(dr["Price_San"].ToString()),
                        G3_Buy = string.IsNullOrEmpty(dr["G3_Buy"].ToString()) ? 0 : float.Parse(dr["G3_Buy"].ToString()),
                        KL3_Buy = string.IsNullOrEmpty(dr["KL3_Buy"].ToString()) ? 0 : decimal.Parse(dr["KL3_Buy"].ToString()),
                        G2_Buy = string.IsNullOrEmpty(dr["G2_Buy"].ToString()) ? 0 : float.Parse(dr["G2_Buy"].ToString()),
                        KL2_Buy = string.IsNullOrEmpty(dr["KL2_Buy"].ToString()) ? 0 : decimal.Parse(dr["KL2_Buy"].ToString()),
                        G1_Buy = string.IsNullOrEmpty(dr["G1_Buy"].ToString()) ? 0 : float.Parse(dr["G1_Buy"].ToString()),
                        KL1_Buy = string.IsNullOrEmpty(dr["KL1_Buy"].ToString()) ? 0 : decimal.Parse(dr["KL1_Buy"].ToString()),
                        Price_OrderExecution = string.IsNullOrEmpty(dr["Price_OrderExecution"].ToString()) ? 0 : float.Parse(dr["Price_OrderExecution"].ToString()),
                        KL_OrderExecution = string.IsNullOrEmpty(dr["KL_OrderExecution"].ToString()) ? 0 : decimal.Parse(dr["KL_OrderExecution"].ToString()),
                        G1_Sell = string.IsNullOrEmpty(dr["G1_Sell"].ToString()) ? 0 : float.Parse(dr["G1_Sell"].ToString()),
                        KL1_Sell = string.IsNullOrEmpty(dr["KL1_Sell"].ToString()) ? 0 : decimal.Parse(dr["KL1_Sell"].ToString()),
                        G2_Sell = string.IsNullOrEmpty(dr["G2_Sell"].ToString()) ? 0 : float.Parse(dr["G2_Sell"].ToString()),
                        KL2_Sell = string.IsNullOrEmpty(dr["KL2_Sell"].ToString()) ? 0 : decimal.Parse(dr["KL2_Sell"].ToString()),
                        G3_Sell = string.IsNullOrEmpty(dr["G3_Sell"].ToString()) ? 0 : float.Parse(dr["G3_Sell"].ToString()),
                        KL3_Sell = string.IsNullOrEmpty(dr["KL3_Sell"].ToString()) ? 0 : decimal.Parse(dr["KL3_Sell"].ToString()),
                        TotalKL = string.IsNullOrEmpty(dr["TotalKL"].ToString()) ? 0 : decimal.Parse(dr["TotalKL"].ToString()),
                        OpenDoor = string.IsNullOrEmpty(dr["OpenDoor"].ToString()) ? 0 : float.Parse(dr["OpenDoor"].ToString()),
                        Tallest = string.IsNullOrEmpty(dr["Tallest"].ToString()) ? 0 : float.Parse(dr["Tallest"].ToString()),
                        Lowest = string.IsNullOrEmpty(dr["Lowest"].ToString()) ? 0 : float.Parse(dr["Lowest"].ToString()),
                        NNBuy = string.IsNullOrEmpty(dr["NNBuy"].ToString()) ? 0 : float.Parse(dr["NNBuy"].ToString()),
                        NNSell = string.IsNullOrEmpty(dr["NNSell"].ToString()) ? 0 : float.Parse(dr["NNSell"].ToString()),
                        Room_Left = string.IsNullOrEmpty(dr["Room_Left"].ToString()) ? 0 : decimal.Parse(dr["Room_Left"].ToString())
                    });
                }
                return codes;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Code> GetCodes()
        {
            try
            {
                Code code = new Code();
                DataTable dt = _codeDAL.GetAllCode();
                List<Code> codes = new List<Code>();
                foreach (DataRow dr in dt.Rows)
                {
                    codes.Add(new Code
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        NameCode = string.IsNullOrEmpty(dr["name_code"].ToString()) ? "" : dr["name_code"].ToString(),
                        Id_details = Convert.ToInt32(dr["id_details"])
                    });
                }
                return codes;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public List<CodeDetails> AllCodeDetails()
        {
            List<CodeDetails> list_codeDetails = new List<CodeDetails>();
            var listCodeDetails = _codeDAL.AllCodeDetails();
            foreach (DataRow dr in listCodeDetails.Tables[0].Rows)
            {
                CodeDetails code = new CodeDetails();
                code.Id = Convert.ToInt32(dr["id"]);
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
                list_codeDetails.Add(code);
            }
            return list_codeDetails;
        }

        public Code GetCodeById(int? id)
        {
            Code code = new Code();
            code.Id = (int)id;
            DataTable dt = _codeDAL.GetCodeById(id);

            foreach (DataRow dr in dt.Rows)
            {
                code.Id = Convert.ToInt32(dr["Id"]);
                code.NameCode = string.IsNullOrEmpty(dr["name_code"].ToString()) ? "" : dr["name_code"].ToString();
                code.Id_details = Convert.ToInt32(dr["id_details"]);
                //code.Price_TC = string.IsNullOrEmpty(dr["Price_TC"].ToString()) ? 0 : float.Parse(dr["Price_TC"].ToString());
                //code.Price_Tran = string.IsNullOrEmpty(dr["Price_Tran"].ToString()) ? 0 : float.Parse(dr["Price_Tran"].ToString());
                //code.Price_San = string.IsNullOrEmpty(dr["Price_San"].ToString()) ? 0 : float.Parse(dr["Price_San"].ToString());
                //code.G3_Buy = string.IsNullOrEmpty(dr["G3_Buy"].ToString()) ? 0 : float.Parse(dr["G3_Buy"].ToString());
                //code.KL3_Buy = string.IsNullOrEmpty(dr["KL3_Buy"].ToString()) ? 0 : decimal.Parse(dr["KL3_Buy"].ToString());
                //code.G2_Buy = string.IsNullOrEmpty(dr["G2_Buy"].ToString()) ? 0 : float.Parse(dr["G2_Buy"].ToString());
                //code.KL2_Buy = string.IsNullOrEmpty(dr["KL2_Buy"].ToString()) ? 0 : decimal.Parse(dr["KL2_Buy"].ToString());
                //code.G1_Buy = string.IsNullOrEmpty(dr["G1_Buy"].ToString()) ? 0 : float.Parse(dr["G1_Buy"].ToString());
                //code.KL1_Buy = string.IsNullOrEmpty(dr["KL1_Buy"].ToString()) ? 0 : decimal.Parse(dr["KL1_Buy"].ToString());
                //code.Price_OrderExecution = string.IsNullOrEmpty(dr["Price_OrderExecution"].ToString()) ? 0 : float.Parse(dr["Price_OrderExecution"].ToString());
                //code.KL_OrderExecution = string.IsNullOrEmpty(dr["KL_OrderExecution"].ToString()) ? 0 : decimal.Parse(dr["KL_OrderExecution"].ToString());
                //code.G1_Sell = string.IsNullOrEmpty(dr["G1_Sell"].ToString()) ? 0 : float.Parse(dr["G1_Sell"].ToString());
                //code.KL1_Sell = string.IsNullOrEmpty(dr["KL1_Sell"].ToString()) ? 0 : decimal.Parse(dr["KL1_Sell"].ToString());
                //code.G2_Sell = string.IsNullOrEmpty(dr["G2_Sell"].ToString()) ? 0 : float.Parse(dr["G2_Sell"].ToString());
                //code.KL2_Sell = string.IsNullOrEmpty(dr["KL2_Sell"].ToString()) ? 0 : decimal.Parse(dr["KL2_Sell"].ToString());
                //code.G3_Sell = string.IsNullOrEmpty(dr["G3_Sell"].ToString()) ? 0 : float.Parse(dr["G3_Sell"].ToString());
                //code.KL3_Sell = string.IsNullOrEmpty(dr["KL3_Sell"].ToString()) ? 0 : decimal.Parse(dr["KL3_Sell"].ToString());
                //code.TotalKL = string.IsNullOrEmpty(dr["TotalKL"].ToString()) ? 0 : decimal.Parse(dr["TotalKL"].ToString());
                //code.OpenDoor = string.IsNullOrEmpty(dr["OpenDoor"].ToString()) ? 0 : float.Parse(dr["OpenDoor"].ToString());
                //code.Tallest = string.IsNullOrEmpty(dr["Tallest"].ToString()) ? 0 : float.Parse(dr["Tallest"].ToString());
                //code.Lowest = string.IsNullOrEmpty(dr["Lowest"].ToString()) ? 0 : float.Parse(dr["Lowest"].ToString());
                //code.NNBuy = string.IsNullOrEmpty(dr["NNBuy"].ToString()) ? 0 : float.Parse(dr["NNBuy"].ToString());
                //code.NNSell = string.IsNullOrEmpty(dr["NNSell"].ToString()) ? 0 : float.Parse(dr["NNSell"].ToString());
                //code.Room_Left = string.IsNullOrEmpty(dr["Room_Left"].ToString()) ? 0 : decimal.Parse(dr["Room_Left"].ToString());
            }
            return code;
        }

        public void AddCode(Code code)
        {
            _codeDAL.InsertCode(code);
        }

        public void UpdateCode(Code code)
        {
            _codeDAL.UpdateCode(code);
        }

        public void DeleteCode(int? id)
        {
            _codeDAL.Delete(id);
        }
    }
}
