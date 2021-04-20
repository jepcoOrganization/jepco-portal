using SiteWare.Entity.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiteWare.Entity.Entities;
using SiteWare.DataAccess.RepositorieConstants;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Common.Enums;
using SiteWare.Entity.Constants.Entity;

namespace SiteWare.DataAccess.Repositories
{
    public static class Lookup_SurveyAnswerRespository
    {

        public static ResultList<Lookup_SurveyAnswerEntity> SelectAllNotAsync()
        {
            ResultList<Lookup_SurveyAnswerEntity> result = new ResultList<Lookup_SurveyAnswerEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Lookup_SurveyAnswerRepositoryConstant.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Lookup_SurveyAnswerEntity> list = new List<Lookup_SurveyAnswerEntity>();
            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Lookup_SurveyAnswerEntity entity = EntityHelper(reader, false);
                    list.Add(entity);
                }

                if (list.Count > 0)
                {
                    reader.Close();

                    result.List = list;

                }
                else
                {
                    result.Status = ErrorEnums.Information;
                    result.Details = MessageConstants.CannotFindAllMessage;
                    result.Message = MessageConstants.CannotFindAllDetails;
                }
            }
            catch (Exception ex)
            {
                result.Status = ErrorEnums.Exception;
                result.Details = ex.Message + Environment.NewLine + ex.StackTrace;
                result.Message = ex.Message;
            }
            finally
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
                sqlCommand.Dispose();
            }

            return result;
        }

        public async static Task<ResultList<Lookup_SurveyAnswerEntity>> SelectByQuestionId(int ID)
        {

            ResultList<Lookup_SurveyAnswerEntity> result = new ResultList<Lookup_SurveyAnswerEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Lookup_SurveyAnswerRepositoryConstant.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Lookup_SurveyAnswerEntity> list = new List<Lookup_SurveyAnswerEntity>();
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Lookup_SurveyAnswerRepositoryConstant.QuestionID, ID));
                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                while (reader.Read())
                {
                    Lookup_SurveyAnswerEntity entity = EntityHelper(reader, false);
                    list.Add(entity);
                }
                if (list.Count > 0)
                {
                    reader.Close();

                    result.List = list;
                }
                else
                {
                    result.Status = ErrorEnums.Information;
                    result.Details = MessageConstants.CannotFindAllMessage;
                    result.Message = MessageConstants.CannotFindAllDetails;
                }
            }
            catch (Exception ex)
            {
                result.Status = ErrorEnums.Exception;
                result.Details = ex.Message + Environment.NewLine + ex.StackTrace;
                result.Message = ex.Message;
            }
            finally
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
                sqlCommand.Dispose();
            }

            return result;
        }
        public static ResultList<Lookup_SurveyAnswerEntity> SelectByQuestionIdNotAsync(int ID)
        {

            ResultList<Lookup_SurveyAnswerEntity> result = new ResultList<Lookup_SurveyAnswerEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Lookup_SurveyAnswerRepositoryConstant.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Lookup_SurveyAnswerEntity> list = new List<Lookup_SurveyAnswerEntity>();
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Lookup_SurveyAnswerRepositoryConstant.QuestionID, ID));
                SqlDataReader reader =  sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Lookup_SurveyAnswerEntity entity = EntityHelper(reader, false);
                    list.Add(entity);
                }
                if (list.Count > 0)
                {
                    reader.Close();

                    result.List = list;
                }
                else
                {
                    result.Status = ErrorEnums.Information;
                    result.Details = MessageConstants.CannotFindAllMessage;
                    result.Message = MessageConstants.CannotFindAllDetails;
                }
            }
            catch (Exception ex)
            {
                result.Status = ErrorEnums.Exception;
                result.Details = ex.Message + Environment.NewLine + ex.StackTrace;
                result.Message = ex.Message;
            }
            finally
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
                sqlCommand.Dispose();
            }

            return result;
        }
        public async static Task<ResultList<Lookup_SurveyAnswerEntity>> SelectAll()
        {
            ResultList<Lookup_SurveyAnswerEntity> result = new ResultList<Lookup_SurveyAnswerEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Lookup_SurveyAnswerRepositoryConstant.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Lookup_SurveyAnswerEntity> list = new List<Lookup_SurveyAnswerEntity>();
            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    Lookup_SurveyAnswerEntity entity = EntityHelper(reader, false);
                    list.Add(entity);
                }

                if (list.Count > 0)
                {
                    reader.Close();

                    result.List = list;

                }
                else
                {
                    result.Status = ErrorEnums.Information;
                    result.Details = MessageConstants.CannotFindAllMessage;
                    result.Message = MessageConstants.CannotFindAllDetails;
                }
            }
            catch (Exception ex)
            {
                result.Status = ErrorEnums.Exception;
                result.Details = ex.Message + Environment.NewLine + ex.StackTrace;
                result.Message = ex.Message;
            }
            finally
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
                sqlCommand.Dispose();
            }
            return result;
        }
        public async static Task<ResultEntity<Lookup_SurveyAnswerEntity>> Insert(Lookup_SurveyAnswerEntity entity)
        {

            ResultEntity<Lookup_SurveyAnswerEntity> result = new ResultEntity<Lookup_SurveyAnswerEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Lookup_SurveyAnswerRepositoryConstant.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Lookup_SurveyAnswerRepositoryConstant.QuestionID, entity.QuestionID);
                sqlCommand.Parameters.AddWithValue(Lookup_SurveyAnswerRepositoryConstant.OptionName, entity.OptionName);
                sqlCommand.Parameters.AddWithValue(Lookup_SurveyAnswerRepositoryConstant.NumberOfVotes, entity.NumberOfVotes);
                sqlCommand.Parameters.AddWithValue(Lookup_SurveyAnswerRepositoryConstant.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Lookup_SurveyAnswerRepositoryConstant.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(Lookup_SurveyAnswerRepositoryConstant.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(Lookup_SurveyAnswerRepositoryConstant.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Lookup_SurveyAnswerRepositoryConstant.EditUser, entity.EditUser);

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                result.Entity = entity;

                result.Status = ErrorEnums.Success;
                result.Message = MessageConstants.InsertSuccessMessage;
            }
            catch (Exception ex)
            {
                result.Status = ErrorEnums.Exception;
                result.Details = ex.Message + Environment.NewLine + ex.StackTrace;
            }
            finally
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
                sqlCommand.Dispose();
            }

            return result;
        }
        public async static Task<ResultEntity<Lookup_SurveyAnswerEntity>> Update(Lookup_SurveyAnswerEntity entity)
        {

            ResultEntity<Lookup_SurveyAnswerEntity> result = new ResultEntity<Lookup_SurveyAnswerEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Lookup_SurveyAnswerRepositoryConstant.SP_Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Lookup_SurveyAnswerRepositoryConstant.AnswerID, entity.AnswerID);
                sqlCommand.Parameters.AddWithValue(Lookup_SurveyAnswerRepositoryConstant.QuestionID, entity.QuestionID);
                sqlCommand.Parameters.AddWithValue(Lookup_SurveyAnswerRepositoryConstant.OptionName, entity.OptionName);
                //sqlCommand.Parameters.AddWithValue(Lookup_SurveyAnswerRepositoryConstant.NumberOfVotes, entity.NumberOfVotes);
                sqlCommand.Parameters.AddWithValue(Lookup_SurveyAnswerRepositoryConstant.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Lookup_SurveyAnswerRepositoryConstant.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Lookup_SurveyAnswerRepositoryConstant.EditUser, entity.EditUser);

                await sqlCommand.ExecuteNonQueryAsync();
                result.Entity = entity;

                result.Status = ErrorEnums.Success;
                result.Message = MessageConstants.UpdateSuccessMessage;
            }
            catch (Exception ex)
            {
                result.Status = ErrorEnums.Exception;
                result.Details = ex.Message + Environment.NewLine + ex.StackTrace;
            }
            finally
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
                sqlCommand.Dispose();
            }

            return result;
        }
        static Lookup_SurveyAnswerEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            Lookup_SurveyAnswerEntity entity = new Lookup_SurveyAnswerEntity();

            entity.AnswerID = Convert.ToInt32(reader[Lookup_SurveyAnswerConstants.AnswerID].ToString());
            entity.QuestionID = Convert.ToInt32(reader[Lookup_SurveyAnswerConstants.QuestionID].ToString());
            entity.OptionName = reader[Lookup_SurveyAnswerConstants.OptionName].ToString();
            entity.NumberOfVotes = Convert.ToInt64(reader[Lookup_SurveyAnswerConstants.NumberOfVotes].ToString());
            entity.LanguageID = Convert.ToByte(reader[Lookup_SurveyAnswerConstants.LanguageID].ToString());
            entity.AddDate = Convert.ToDateTime(reader[Lookup_SurveyAnswerConstants.AddDate].ToString());
            entity.EditDate = Convert.ToDateTime(reader[Lookup_SurveyAnswerConstants.EditDate].ToString());
            entity.AddUser = reader[Lookup_SurveyAnswerConstants.AddUser].ToString();
            entity.EditUser = reader[Lookup_SurveyAnswerConstants.EditUser].ToString();

            return entity;
        }

        public async static Task<ResultList<Lookup_SurveyAnswerEntity>> SelectByAnswerId(int ID)
        {

            ResultList<Lookup_SurveyAnswerEntity> result = new ResultList<Lookup_SurveyAnswerEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Lookup_SurveyAnswerRepositoryConstant.SP_SelecByAnswerID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Lookup_SurveyAnswerEntity> list = new List<Lookup_SurveyAnswerEntity>();
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Lookup_SurveyAnswerRepositoryConstant.AnswerID, ID));
                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                while (reader.Read())
                {
                    Lookup_SurveyAnswerEntity entity = EntityHelper(reader, false);
                    list.Add(entity);
                }
                if (list.Count > 0)
                {
                    reader.Close();

                    result.List = list;
                }
                else
                {
                    result.Status = ErrorEnums.Information;
                    result.Details = MessageConstants.CannotFindAllMessage;
                    result.Message = MessageConstants.CannotFindAllDetails;
                }
            }
            catch (Exception ex)
            {
                result.Status = ErrorEnums.Exception;
                result.Details = ex.Message + Environment.NewLine + ex.StackTrace;
                result.Message = ex.Message;
            }
            finally
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
                sqlCommand.Dispose();
            }

            return result;
        }

        public async static Task<ResultEntity<Lookup_SurveyAnswerEntity>> UpdateNumberofVotes(Lookup_SurveyAnswerEntity entity)
        {

            ResultEntity<Lookup_SurveyAnswerEntity> result = new ResultEntity<Lookup_SurveyAnswerEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Lookup_SurveyAnswerRepositoryConstant.SP_UpdateNumberofvotes, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Lookup_SurveyAnswerRepositoryConstant.AnswerID, entity.AnswerID);
                //sqlCommand.Parameters.AddWithValue(Lookup_SurveyAnswerRepositoryConstant.QuestionID, entity.QuestionID);
                //sqlCommand.Parameters.AddWithValue(Lookup_SurveyAnswerRepositoryConstant.OptionName, entity.OptionName);
                sqlCommand.Parameters.AddWithValue(Lookup_SurveyAnswerRepositoryConstant.NumberOfVotes, entity.NumberOfVotes);
                //sqlCommand.Parameters.AddWithValue(Lookup_SurveyAnswerRepositoryConstant.LanguageID, entity.LanguageID);
                //sqlCommand.Parameters.AddWithValue(Lookup_SurveyAnswerRepositoryConstant.EditDate, entity.EditDate);
                //sqlCommand.Parameters.AddWithValue(Lookup_SurveyAnswerRepositoryConstant.EditUser, entity.EditUser);

                await sqlCommand.ExecuteNonQueryAsync();
                result.Entity = entity;

                result.Status = ErrorEnums.Success;
                result.Message = MessageConstants.UpdateSuccessMessage;
            }
            catch (Exception ex)
            {
                result.Status = ErrorEnums.Exception;
                result.Details = ex.Message + Environment.NewLine + ex.StackTrace;
            }
            finally
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
                sqlCommand.Dispose();
            }

            return result;
        }
        public static DataTable GetAnswerDataByquestionId(long QuestID)
        {
            DataTable dt = new DataTable();
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Lookup_SurveyAnswerRepositoryConstant.SP_SelectByID, sqlConnection);
            SqlDataAdapter sda = new SqlDataAdapter();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Lookup_SurveyAnswerRepositoryConstant.QuestionID, QuestID);
                sqlCommand.Connection = sqlConnection;
                sda.SelectCommand = sqlCommand;
                sda.Fill(dt);
            }
            catch (Exception e)
            {
                return dt;
            }
            return dt;
        }
    }
}
