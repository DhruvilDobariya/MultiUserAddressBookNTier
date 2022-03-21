using AddressBook.ENT;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;


/// <summary>
/// Summary description for CityDALBase
/// </summary>

namespace AddressBook.DAL
{
    public abstract class CityDALBase
    {
        #region Local Variable
        private string _Message;
        public string Message
        {
            get { return _Message; }
            set { _Message = value; }
        }
        #endregion Local Variable

        #region Get City List
        public DataTable GetCityList(SqlInt32 UserId)
        {
            #region Set Connection
            SqlConnection objConn = new SqlConnection(DatabaseConfig.ConnectionString);
            #endregion Set Connection
            try
            {
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();
                DataTable dt = new DataTable();
                #region Create Command and Bind Data
                SqlCommand objCmd = new SqlCommand();
                objCmd.Connection = objConn;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "PR_City_SelectAllUserID";
                objCmd.Parameters.AddWithValue("@UserID", UserId);

                SqlDataReader objSDR = objCmd.ExecuteReader();

                dt.Load(objSDR);
                return dt;

                if (objConn.State == ConnectionState.Open)
                    objConn.Close();

                #endregion Create Command and Bind Data

            }
            catch (Exception ex)
            {
                _Message = ex.ToString();
                return null;
            }
            finally
            {
                if (objConn.State == ConnectionState.Open)
                    objConn.Close();
            }
        }
        #endregion Get City List

        #region Get City By Id
        public CityENT GetCityById(SqlInt32 CityId, SqlInt32 UserId)
        {
            #region Set Connection
            SqlConnection objConn = new SqlConnection(DatabaseConfig.ConnectionString);
            #endregion Set Connection
            try
            {
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();
                DataTable dt = new DataTable();
                #region Create Command and Bind Data
                SqlCommand objCmd = new SqlCommand();
                objCmd.Connection = objConn;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "PR_City_SelectByPKUserID";
                objCmd.Parameters.AddWithValue("@CityID", CityId);
                objCmd.Parameters.AddWithValue("@UserID", UserId);

                SqlDataReader objSDR = objCmd.ExecuteReader();

                CityENT entCity = new CityENT();

                if (objSDR.HasRows)
                {
                    while (objSDR.Read())
                    {
                        if (!objSDR["CityID"].Equals(DBNull.Value))
                        {
                            string CityID = objSDR["CityID"].ToString();
                            entCity.CityID = Convert.ToInt32(CityID);
                        }
                        if (!objSDR["StateID"].Equals(DBNull.Value))
                        {
                            string StateID = objSDR["StateID"].ToString();
                            entCity.StateID = Convert.ToInt32(StateID);
                        }
                        if (!objSDR["CityName"].Equals(DBNull.Value))
                        {
                            entCity.CityName = objSDR["CityName"].ToString();
                        }
                        if (!objSDR["PinCode"].Equals(DBNull.Value))
                        {
                            entCity.PinCode = objSDR["PinCode"].ToString();
                        }
                        if (!objSDR["STDCode"].Equals(DBNull.Value))
                        {
                            entCity.STDCode = objSDR["STDCode"].ToString();
                        }
                        if (!objSDR["CreationDate"].Equals(DBNull.Value))
                        {
                            entCity.CreationDate = Convert.ToDateTime(objSDR["CreationDate"].ToString());
                        }
                        break;
                    }
                }

                return entCity;

                if (objConn.State == ConnectionState.Open)
                    objConn.Close();

                #endregion Create Command and Bind Data

            }
            catch (Exception ex)
            {
                _Message = ex.ToString();
                return null;
            }
            finally
            {
                if (objConn.State == ConnectionState.Open)
                    objConn.Close();
            }
        }
        #endregion Get City By Id

        #region Insert City
        public bool InsertCity(CityENT entCity)
        {
            #region Set Connection
            SqlConnection objConn = new SqlConnection(DatabaseConfig.ConnectionString);
            #endregion Set Connection
            try
            {
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();

                #region Create Command and Set Parameters
                SqlCommand objCmd = new SqlCommand();
                objCmd.Connection = objConn;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "PR_City_InsertUserID";

                objCmd.Parameters.AddWithValue("@CityName", entCity.CityName);
                objCmd.Parameters.AddWithValue("@PinCode", entCity.PinCode);
                objCmd.Parameters.AddWithValue("@STDCode", entCity.STDCode);
                objCmd.Parameters.AddWithValue("@StateID", entCity.StateID);
                objCmd.Parameters.AddWithValue("@UserID", entCity.UserID);
                objCmd.ExecuteNonQuery();
                #endregion Create Command and Set Parameters

                if (objConn.State == ConnectionState.Open)
                    objConn.Close();

                return true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Violation of UNIQUE KEY constraint 'UK_City_CityName_UserID'."))
                {
                    _Message = "City already exist";
                    return false;
                }
                else
                {
                    _Message = ex.Message;
                    return false;
                }
            }
            finally
            {
                if (objConn.State == ConnectionState.Open)
                    objConn.Close();
            }
        }
        #endregion Insert City

        #region Update City By Id
        public bool UpdateCity(CityENT entCity)
        {
            #region Set Connection
            SqlConnection objConn = new SqlConnection(DatabaseConfig.ConnectionString);
            #endregion Set Connection
            try
            {
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();

                #region Create Command and Set Parameters
                SqlCommand objCmd = new SqlCommand();
                objCmd.Connection = objConn;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "PR_City_UpdateByPKUserID";

                objCmd.Parameters.AddWithValue("@CityName", entCity.CityName);
                objCmd.Parameters.AddWithValue("@PinCode", entCity.PinCode);
                objCmd.Parameters.AddWithValue("@STDCode", entCity.STDCode);
                objCmd.Parameters.AddWithValue("@StateID", entCity.StateID);
                objCmd.Parameters.AddWithValue("@UserID", entCity.UserID);
                objCmd.Parameters.AddWithValue("@CityID", entCity.CityID);
                objCmd.ExecuteNonQuery();
                #endregion Create Command and Set Parameters

                if (objConn.State == ConnectionState.Open)
                    objConn.Close();

                return true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Violation of UNIQUE KEY constraint 'UK_City_CityName_UserID'."))
                {
                    _Message = "City already exist";
                    return false;
                }
                else
                {
                    _Message = ex.Message;
                    return false;
                }
            }
            finally
            {
                if (objConn.State == ConnectionState.Open)
                    objConn.Close();
            }
        }
        #endregion Update City By Id

        #region Delete City By Id
        public bool DeleteCity(SqlInt32 CityID, SqlInt32 UserID)
        {
            #region Set Connection
            SqlConnection objConn = new SqlConnection(DatabaseConfig.ConnectionString);
            #endregion Set Connection
            try
            {
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();

                #region Create Command and Set Parameters
                SqlCommand objCmd = new SqlCommand("PR_City_DeleteByPKUserID", objConn);
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.AddWithValue("@CityID", CityID);
                objCmd.Parameters.AddWithValue("@UserID", UserID);
                objCmd.ExecuteNonQuery();
                #endregion Create Command and Set Parameters

                if (objConn.State == ConnectionState.Open)
                    objConn.Close();

                return true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("The DELETE statement conflicted with the REFERENCE constraint"))
                {
                    _Message = "This City contain some records, So please delete these record, If you want to delete this City.";
                    return false;
                }
                else
                {
                    _Message = ex.Message;
                    return false;
                }
            }
            finally
            {
                if (objConn.State == ConnectionState.Open)
                    objConn.Close();
            }
        }
        #endregion Delete City By Id

        #region Get City For DropDown
        public DataTable GetCityDropDown(SqlInt32 UserId, SqlInt32 StateID)
        {
            #region Set Connection
            SqlConnection objConn = new SqlConnection(DatabaseConfig.ConnectionString);
            #endregion Set Connection
            try
            {
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();
                DataTable dt = new DataTable();
                #region Create Command and Bind Data
                SqlCommand objCmd = new SqlCommand();
                objCmd.Connection = objConn;
                objCmd.CommandType = CommandType.StoredProcedure;

                if (!StateID.IsNull)
                {

                    objCmd.CommandText = "PR_City_SelectByStateIDUserID";
                    objCmd.Parameters.AddWithValue("@StateID", StateID);
                }
                else
                {
                    objCmd.CommandText = "PR_City_SelectForDropDownListUserID";
                }

                objCmd.Parameters.AddWithValue("@UserID", UserId);

                SqlDataReader objSDR = objCmd.ExecuteReader();

                dt.Load(objSDR);
                return dt;

                if (objConn.State == ConnectionState.Open)
                    objConn.Close();

                #endregion Create Command and Bind Data

            }
            catch (Exception ex)
            {
                _Message = ex.ToString();
                return null;
            }
            finally
            {
                if (objConn.State == ConnectionState.Open)
                    objConn.Close();
            }
        }
        #endregion Get City For DropDown
    }
}
