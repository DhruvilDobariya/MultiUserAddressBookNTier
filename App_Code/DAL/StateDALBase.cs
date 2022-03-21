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
/// Summary description for StateDALBase
/// </summary>

namespace AddressBook.DAL
{
    public abstract class StateDALBase
    {
        #region Local Variable
        private string _Message;
        public string Message
        {
            get { return _Message; }
            set { _Message = value; }
        }
        #endregion Local Variable

        #region Get State List
        public DataTable GetStateList(SqlInt32 UserId)
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
                objCmd.CommandText = "PR_State_SelectAllUserID";
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
        #endregion Get State List

        #region Get State By Id
        public StateENT GetStateById(SqlInt32 StateId, SqlInt32 UserId)
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
                objCmd.CommandText = "PR_State_SelectByPKUserID";
                objCmd.Parameters.AddWithValue("@StateID", StateId);
                objCmd.Parameters.AddWithValue("@UserID", UserId);

                SqlDataReader objSDR = objCmd.ExecuteReader();

                StateENT entState = new StateENT();

                if (objSDR.HasRows)
                {
                    while (objSDR.Read())
                    {
                        if (!objSDR["CountryID"].Equals(DBNull.Value))
                        {
                            string CountryID = objSDR["CountryID"].ToString();
                            entState.CountryID = Convert.ToInt32(CountryID);
                        }
                        if (!objSDR["StateID"].Equals(DBNull.Value))
                        {
                            string StateID = objSDR["StateID"].ToString();
                            entState.StateID = Convert.ToInt32(StateID);
                        }
                        if (!objSDR["StateName"].Equals(DBNull.Value))
                        {
                            entState.StateName = objSDR["StateName"].ToString();
                        }
                        if (!objSDR["StateCode"].Equals(DBNull.Value))
                        {
                            entState.StateCode = objSDR["StateCode"].ToString();
                        }
                        if (!objSDR["CreationDate"].Equals(DBNull.Value))
                        {
                            entState.CreationDate = Convert.ToDateTime(objSDR["CreationDate"].ToString());
                        }
                        break;
                    }
                }

                return entState;

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
        #endregion Get State By Id

        #region Insert State
        public bool InsertState(StateENT entState)
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
                objCmd.CommandText = "PR_State_InsertUserID";

                objCmd.Parameters.AddWithValue("@StateName", entState.StateName);
                objCmd.Parameters.AddWithValue("@StateCode", entState.StateCode);
                objCmd.Parameters.AddWithValue("@CountryID", entState.CountryID);
                objCmd.Parameters.AddWithValue("@UserID", entState.UserID);
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
                    _Message = "This State contain some records, So please delete these record, If you want to delete this State.";
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
        #endregion Insert State

        #region Update State By Id
        public bool UpdateState(StateENT entState)
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
                objCmd.CommandText = "PR_State_UpdateByPKUserID";

                objCmd.Parameters.AddWithValue("@StateName", entState.StateName);
                objCmd.Parameters.AddWithValue("@StateCode", entState.StateCode);
                objCmd.Parameters.AddWithValue("@CountryID", entState.CountryID);
                objCmd.Parameters.AddWithValue("@UserID", entState.UserID);
                objCmd.Parameters.AddWithValue("@StateID", entState.StateID);
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
                    _Message = "This State contain some records, So please delete these record, If you want to delete this State.";
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
        #endregion Update State By Id

        #region Delete State By Id
        public bool DeleteState(SqlInt32 StateID, SqlInt32 UserID)
        {
            #region Set Connection
            SqlConnection objConn = new SqlConnection(DatabaseConfig.ConnectionString);
            #endregion Set Connection
            try
            {
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();

                #region Create Command and Set Parameters
                SqlCommand objCmd = new SqlCommand("PR_State_DeleteByPKUserID", objConn);
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.AddWithValue("@StateID", StateID);
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
                    _Message = "This State contain some records, So please delete these record, If you want to delete this State.";
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
        #endregion Delete State By Id

        #region Get State For DropDown
        public DataTable GetStateDropDown(SqlInt32 UserId, SqlInt32 CountryID)
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

                if (!CountryID.IsNull)
                {

                    objCmd.CommandText = "PR_State_SelectByCountryIDUserID";
                    objCmd.Parameters.AddWithValue("@CountryID", CountryID);
                }
                else
                {
                    objCmd.CommandText = "PR_State_SelectForDropDownListUserID";
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
        #endregion Get State For DropDown
    }
}
