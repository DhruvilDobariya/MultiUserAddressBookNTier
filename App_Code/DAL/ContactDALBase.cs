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
/// Summary description for ContactDALBase
/// </summary>

namespace AddressBook.DAL
{
    public abstract class ContactDALBase
    {
        #region Local Variable
        private string _Message;
        public string Message
        {
            get { return _Message; }
            set { _Message = value; }
        }
        #endregion Local Variable

        #region Get Contact List
        public DataTable GetContactList(SqlInt32 UserId)
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
                objCmd.CommandText = "PR_Contact_SelectAllUserID";
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
        #endregion Get Contact List

        #region Get Contact By Id
        public ContactENT GetContactById(SqlInt32 ContactId, SqlInt32 UserId)
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
                objCmd.CommandText = "PR_Contact_SelectByPKUserID";
                objCmd.Parameters.AddWithValue("@ContactID", ContactId);
                objCmd.Parameters.AddWithValue("@UserID", UserId);

                SqlDataReader objSDR = objCmd.ExecuteReader();

                ContactENT entContact = new ContactENT();

                if (objSDR.HasRows)
                {
                    while (objSDR.Read())
                    {
                        if (!objSDR["ContactID"].Equals(DBNull.Value))
                        {
                            string ContactID = objSDR["ContactID"].ToString();
                            entContact.ContactID = Convert.ToInt32(ContactID);
                        }
                        if (!objSDR["ContactName"].Equals(DBNull.Value))
                        {
                            entContact.ContactName = objSDR["ContactName"].ToString();
                        }
                        if (!objSDR["CityID"].Equals(DBNull.Value))
                        {
                            string CityID = objSDR["CityID"].ToString();
                            entContact.CityID = Convert.ToInt32(CityID);
                        }
                        if (!objSDR["StateID"].Equals(DBNull.Value))
                        {
                            string StateID = objSDR["StateID"].ToString();
                            entContact.StateID = Convert.ToInt32(StateID);
                        }
                        if (!objSDR["CountryID"].Equals(DBNull.Value))
                        {
                            string CountryID = objSDR["CountryID"].ToString();
                            entContact.CountryID = Convert.ToInt32(CountryID);
                        }
                        if (!objSDR["ContactNo"].Equals(DBNull.Value))
                        {
                            entContact.ContactNo = objSDR["ContactNo"].ToString();
                        }
                        if (!objSDR["WhatsappNo"].Equals(DBNull.Value))
                        {
                            entContact.WhatsappNo = objSDR["WhatsappNo"].ToString();
                        }
                        if (!objSDR["BirthDate"].Equals(DBNull.Value))
                        {
                            entContact.CreationDate = Convert.ToDateTime(objSDR["CreationDate"].ToString());
                        }
                        if (!objSDR["Email"].Equals(DBNull.Value))
                        {
                            entContact.Email = objSDR["Email"].ToString();
                        }
                        if (!objSDR["Age"].Equals(DBNull.Value))
                        {
                            string Age = objSDR["Age"].ToString();
                            entContact.Age = Convert.ToInt32(Age);
                        }
                        if (!objSDR["BloodGroup"].Equals(DBNull.Value))
                        {
                            entContact.BloodGroup = objSDR["BloodGroup"].ToString();
                        }
                        if (!objSDR["FacebookID"].Equals(DBNull.Value))
                        {
                            entContact.FacebookID = objSDR["FacebookID"].ToString();
                        }
                        if (!objSDR["LinkedinID"].Equals(DBNull.Value))
                        {
                            entContact.LinkedinID = objSDR["LinkedinID"].ToString();
                        }
                        if (!objSDR["Address"].Equals(DBNull.Value))
                        {
                            entContact.Address = objSDR["Address"].ToString();
                        }
                        if (!objSDR["FilePath"].Equals(DBNull.Value))
                        {
                            entContact.FilePath = objSDR["FilePath"].ToString();
                        }
                        if (!objSDR["CreationDate"].Equals(DBNull.Value))
                        {
                            entContact.CreationDate = Convert.ToDateTime(objSDR["CreationDate"].ToString());
                        }
                        break;
                    }
                }

                return entContact;

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
        #endregion Get Contact By Id

        #region Insert Contact
        public SqlInt32 InsertContact(ContactENT entContact)
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
                objCmd.CommandText = "PR_Contact_InsertUserID";

                objCmd.Parameters.AddWithValue("@ContactName", entContact.ContactName);
                objCmd.Parameters.AddWithValue("@CityID", entContact.CityID);
                objCmd.Parameters.AddWithValue("@StateID", entContact.StateID);
                objCmd.Parameters.AddWithValue("@CountryID", entContact.CountryID);
                objCmd.Parameters.AddWithValue("@ContactNo", entContact.ContactNo);
                objCmd.Parameters.AddWithValue("@WhatsappNo", entContact.WhatsappNo);
                objCmd.Parameters.AddWithValue("@BirthDate", entContact.BirthDate);
                objCmd.Parameters.AddWithValue("@Email", entContact.Email);
                objCmd.Parameters.AddWithValue("@Age", entContact.Age);
                objCmd.Parameters.AddWithValue("@BloodGroup", entContact.BloodGroup);
                objCmd.Parameters.AddWithValue("@FacebookID", entContact.FacebookID);
                objCmd.Parameters.AddWithValue("@LinkedinID", entContact.LinkedinID);
                objCmd.Parameters.AddWithValue("@Address", entContact.Address);
                objCmd.Parameters.AddWithValue("@UserID", entContact.UserID);
                objCmd.Parameters.Add("@ContactID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                objCmd.ExecuteNonQuery();
                #endregion Create Command and Set Parameters

                SqlInt32 ContactID = Convert.ToInt32(objCmd.Parameters["@ContactID"].Value);
                return ContactID;

                if (objConn.State == ConnectionState.Open)
                    objConn.Close();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("The DELETE Contactment conflicted with the REFERENCE constraint"))
                {
                    _Message = "This Contact contain some records, So please delete these record, If you want to delete this Contact.";
                    return 0;
                }
                else
                {
                    _Message = ex.Message;
                    return 0;
                }
            }
            finally
            {
                if (objConn.State == ConnectionState.Open)
                    objConn.Close();
            }
        }
        #endregion Insert Contact

        #region Update Contact By Id
        public bool UpdateContact(ContactENT entContact)
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
                objCmd.CommandText = "PR_Contact_UpdateByPKUserID";

                objCmd.Parameters.AddWithValue("@ContactName", entContact.ContactName);
                objCmd.Parameters.AddWithValue("@CityID", entContact.CityID);
                objCmd.Parameters.AddWithValue("@StateID", entContact.StateID);
                objCmd.Parameters.AddWithValue("@CountryID", entContact.CountryID);
                objCmd.Parameters.AddWithValue("@ContactNo", entContact.ContactNo);
                objCmd.Parameters.AddWithValue("@WhatsappNo", entContact.WhatsappNo);
                objCmd.Parameters.AddWithValue("@BirthDate", entContact.BirthDate);
                objCmd.Parameters.AddWithValue("@Email", entContact.Email);
                objCmd.Parameters.AddWithValue("@Age", entContact.Age);
                objCmd.Parameters.AddWithValue("@BloodGroup", entContact.BloodGroup);
                objCmd.Parameters.AddWithValue("@FacebookID", entContact.FacebookID);
                objCmd.Parameters.AddWithValue("@LinkedinID", entContact.LinkedinID);
                objCmd.Parameters.AddWithValue("@Address", entContact.Address);
                objCmd.Parameters.AddWithValue("@UserID", entContact.UserID);
                objCmd.Parameters.AddWithValue("@ContactID", entContact.ContactID);
                objCmd.ExecuteNonQuery();
                #endregion Create Command and Set Parameters

                if (objConn.State == ConnectionState.Open)
                    objConn.Close();

                return true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("The DELETE Contactment conflicted with the REFERENCE constraint"))
                {
                    _Message = "This Contact contain some records, So please delete these record, If you want to delete this Contact.";
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
        #endregion Update Contact By Id

        #region Delete Contact By Id
        public bool DeleteContact(SqlInt32 ContactID, SqlInt32 UserID)
        {
            #region Set Connection
            SqlConnection objConn = new SqlConnection(DatabaseConfig.ConnectionString);
            #endregion Set Connection
            try
            {
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();

                #region Create Command and Set Parameters
                SqlCommand objCmd = new SqlCommand("PR_Contact_DeleteByPKUserID", objConn);
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.AddWithValue("@ContactID", ContactID);
                objCmd.Parameters.AddWithValue("@UserID", UserID);
                objCmd.ExecuteNonQuery();
                #endregion Create Command and Set Parameters

                if (objConn.State == ConnectionState.Open)
                    objConn.Close();

                return true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("The DELETE Contactment conflicted with the REFERENCE constraint"))
                {
                    _Message = "This Contact contain some records, So please delete these record, If you want to delete this Contact.";
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
        #endregion Delete Contact By Id

        #region Upload Image
        public bool UploadImage(SqlInt32 ContactID, SqlInt32 UserID, SqlString FilePath, SqlString FileType, SqlString FileSize)
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
                objCmd.CommandText = "PR_Contact_UpdateImagePathByPKUserID";

                objCmd.Parameters.AddWithValue("@FilePath", FilePath);
                objCmd.Parameters.AddWithValue("@FileType", FileType);
                objCmd.Parameters.AddWithValue("@FileSize", FileSize);
                objCmd.Parameters.AddWithValue("@UserID", UserID);
                objCmd.Parameters.AddWithValue("@ContactID", ContactID);
                objCmd.ExecuteNonQuery();
                #endregion Create Command and Set Parameters

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
        #endregion Upload Image

        #region Delete Image
        public bool UploadImage(SqlInt32 ContactID, SqlInt32 UserID)
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
                objCmd.CommandText = "PR_Contact_DeleteImageByPKUserID";

                objCmd.Parameters.AddWithValue("@UserID", UserID);
                objCmd.Parameters.AddWithValue("@ContactID", ContactID);
                objCmd.ExecuteNonQuery();
                #endregion Create Command and Set Parameters

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
        #endregion Delete Image

    }
}
