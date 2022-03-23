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
/// Summary description for UserDALBase
/// </summary>

namespace AddressBook.DAL
{
    public abstract class UserDALBase
    {
        protected string _Message;
        public string Message
        {
            get { return _Message; }
            set { _Message = value; }
        }

        #region Validate User
        public UserENT ValidateUser(SqlString UserName, SqlString Password)
        {
            #region Set Connection
            SqlConnection objConn = new SqlConnection(DatabaseConfig.ConnectionString);
            #endregion Set Connection

            try
            {
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();

                #region Create Command and Set Parameters
                SqlCommand objCmd = new SqlCommand("PR_User_SelectByUsernamePassword", objConn);
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.AddWithValue("@UserName", UserName);
                objCmd.Parameters.AddWithValue("@Password", Password);
                SqlDataReader objSDR = objCmd.ExecuteReader();
                #endregion Create Command and Set Parameters

                #region Get data and validate user
                UserENT entUser = new UserENT();
                if (objSDR.HasRows)
                {
                    while (objSDR.Read())
                    {
                        if (!objSDR["UserID"].Equals(DBNull.Value))
                        {
                            entUser.UserID = Convert.ToInt32(objSDR["UserID"].ToString().Trim());
                        }
                        if (!objSDR["UserName"].Equals(DBNull.Value))
                        {
                            entUser.UserName = objSDR["UserName"].ToString().Trim();
                        }
                        if (!objSDR["Password"].Equals(DBNull.Value))
                        {
                            entUser.Password = objSDR["Password"].ToString().Trim();
                        }
                        if (!objSDR["DisplayName"].Equals(DBNull.Value))
                        {
                            entUser.DisplayName = objSDR["DisplayName"].ToString().Trim();
                        }
                        if (!objSDR["Email"].Equals(DBNull.Value))
                        {
                            entUser.Email = objSDR["Email"].ToString().Trim();
                        }
                        if (!objSDR["MobileNo"].Equals(DBNull.Value))
                        {
                            entUser.MobileNo = objSDR["MobileNo"].ToString().Trim();
                        }
                        if (!objSDR["Address"].Equals(DBNull.Value))
                        {
                            entUser.Address = objSDR["Address"].ToString().Trim();
                        }
                        break;
                    }
                    return entUser;
                }
                else
                {
                    _Message = "Username or Password Invalid!";
                    return null;
                }
                #endregion Get data and validate user

                if (objConn.State == ConnectionState.Open)
                    objConn.Close();
            }
            catch (Exception ex)
            {
                _Message = ex.Message;
                return null;
            }
            finally
            {
                if (objConn.State == ConnectionState.Open)
                    objConn.Close();
            }
        }
        #endregion Validate User

        #region Select By PK
        public UserENT SelectByPK(SqlInt32 UserID)
        {
            #region Set Connection
            SqlConnection objConn = new SqlConnection(DatabaseConfig.ConnectionString);
            #endregion Set Connection

            try
            {
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();

                #region Create Command and Set Parameters
                SqlCommand objCmd = new SqlCommand("PR_User_SelectByPK", objConn);
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.AddWithValue("@UserID", UserID);
                SqlDataReader objSDR = objCmd.ExecuteReader();
                #endregion Create Command and Set Parameters

                #region Get data and validate user
                UserENT entUser = new UserENT();
                if (objSDR.HasRows)
                {
                    while (objSDR.Read())
                    {
                        if (!objSDR["UserName"].Equals(DBNull.Value))
                        {
                            entUser.UserName = objSDR["UserName"].ToString().Trim();
                        }
                        if (!objSDR["Password"].Equals(DBNull.Value))
                        {
                            entUser.Password = objSDR["Password"].ToString().Trim();
                        }
                        if (!objSDR["DisplayName"].Equals(DBNull.Value))
                        {
                            entUser.DisplayName = objSDR["DisplayName"].ToString().Trim();
                        }
                        if (!objSDR["Email"].Equals(DBNull.Value))
                        {
                            entUser.Email = objSDR["Email"].ToString().Trim();
                        }
                        if (!objSDR["MobileNo"].Equals(DBNull.Value))
                        {
                            entUser.MobileNo = objSDR["MobileNo"].ToString().Trim();
                        }
                        if (!objSDR["Address"].Equals(DBNull.Value))
                        {
                            entUser.Address = objSDR["Address"].ToString().Trim();
                        }
                        break;
                    }
                }
                #endregion Get data and validate user

                return entUser;

                if (objConn.State == ConnectionState.Open)
                    objConn.Close();
            }
            catch (Exception ex)
            {
                _Message = ex.Message;
                return null;
            }
            finally
            {
                if (objConn.State == ConnectionState.Open)
                    objConn.Close();
            }
        }
        #endregion Select By PK

        #region Insert
        public bool Insert(UserENT entUser)
        {
            #region Set Connection
            SqlConnection objConn = new SqlConnection(DatabaseConfig.ConnectionString);
            #endregion Set Connection

            try
            {
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();

                #region Create Command and Set Parameters
                SqlCommand objCmd = objConn.CreateCommand();
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.AddWithValue("@UserName", entUser.UserName);
                objCmd.Parameters.AddWithValue("@Password", entUser.Password);
                objCmd.Parameters.AddWithValue("@DisplayName", entUser.DisplayName);
                objCmd.Parameters.AddWithValue("@Address", entUser.Address);
                objCmd.Parameters.AddWithValue("@Email", entUser.Email);
                objCmd.Parameters.AddWithValue("@MobileNo", entUser.MobileNo);
                #endregion Create Command and Set Parameters

                objCmd.CommandText = "PR_User_Insert";
                objCmd.ExecuteNonQuery();

                if (objConn.State == ConnectionState.Open)
                    objConn.Close();

                return true;

            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Cannot insert duplicate key row in object 'dbo.User' with unique index 'IX_User'"))
                {
                    _Message = "This Username already exist";
                }
                else
                {
                    _Message = ex.Message;
                }
                return false;
            }
            finally
            {
                if (objConn.State == ConnectionState.Open)
                    objConn.Close();
            }
        }
        #endregion Insert

        #region Update
        public bool Update(UserENT entUser)
        {
            #region Set Connection
            SqlConnection objConn = new SqlConnection(DatabaseConfig.ConnectionString);
            #endregion Set Connection

            try
            {
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();

                #region Create Command and Set Parameters
                SqlCommand objCmd = objConn.CreateCommand();
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.AddWithValue("@UserID", entUser.UserID);
                objCmd.Parameters.AddWithValue("@UserName", entUser.UserName);
                objCmd.Parameters.AddWithValue("@Password", entUser.Password);
                objCmd.Parameters.AddWithValue("@DisplayName", entUser.DisplayName);
                objCmd.Parameters.AddWithValue("@Address", entUser.Address);
                objCmd.Parameters.AddWithValue("@Email", entUser.Email);
                objCmd.Parameters.AddWithValue("@MobileNo", entUser.MobileNo);
                #endregion Create Command and Set Parameters

                objCmd.CommandText = "PR_User_UpdateByPK";
                objCmd.ExecuteNonQuery();

                if (objConn.State == ConnectionState.Open)
                    objConn.Close();

                return true;

            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Cannot insert duplicate key row in object 'dbo.User' with unique index 'IX_User'"))
                {
                    _Message = "This Username already exist";
                }
                else
                {
                    _Message = ex.Message;
                }
                return false;
            }
            finally
            {
                if (objConn.State == ConnectionState.Open)
                    objConn.Close();
            }
        }
        #endregion Update

        #region Delete
        public bool Delete(SqlInt32 UserID)
        {
            #region Set Connection
            SqlConnection objConn = new SqlConnection(DatabaseConfig.ConnectionString);
            #endregion Set Connection

            try
            {
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();

                #region Create Command and Set Parameters
                SqlCommand objCmd = objConn.CreateCommand();
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.AddWithValue("@UserID", UserID);
                #endregion Create Command and Set Parameters

                objCmd.CommandText = "PR_User_Delete";
                objCmd.ExecuteNonQuery();

                if (objConn.State == ConnectionState.Open)
                    objConn.Close();

                return true;

            }
            catch (Exception ex)
            {
                _Message = ex.Message;
                return false;
            }
            finally
            {
                if (objConn.State == ConnectionState.Open)
                    objConn.Close();
            }
        }
        #endregion Delete
    }
}
