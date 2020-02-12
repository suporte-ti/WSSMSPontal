using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace WSSMSPontal.dao
{
    public class DaoSms
    {
        ConnectionStringSettings getString = WebConfigurationManager.ConnectionStrings["getcliente"] as ConnectionStringSettings;

        public string setRetornoSms(Models.Sms campos)
        {
            int intResposta = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("[CRM].[pro_setLogRetornoSms]", conn);

                    cmd.Parameters.AddWithValue("@type", campos.type);
                    cmd.Parameters.AddWithValue("@id", campos.id);
                    cmd.Parameters.AddWithValue("@to", campos.to);
                    cmd.Parameters.AddWithValue("@message", campos.message);
                    cmd.Parameters.AddWithValue("@schedule", campos.schedule);
                    cmd.Parameters.AddWithValue("@reference", campos.reference);
                    cmd.Parameters.AddWithValue("@status", campos.status);
                    cmd.Parameters.AddWithValue("@statusDescription", campos.statusDescription);

                    cmd.CommandTimeout = 160;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    intResposta = cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                return ex.Message.ToString();
//                throw new global::System.Data.StrongTypingException("'Procure o Administrador'", ex);
            }
            return "ok";
        }

        public string setRetornoAtualizaSms(Models.Sms campos)
        {
            int intResposta = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("[CRM].[pro_setLogRetornoAtualizaSms]", conn);

                    cmd.Parameters.AddWithValue("@messageid", campos.replies[0].messageId);
                    cmd.Parameters.AddWithValue("@reference", campos.replies[0].reference);
                    cmd.Parameters.AddWithValue("@message", campos.replies[0].message);
//                    cmd.Parameters.AddWithValue("@received", campos.replies[0].received);
                    cmd.Parameters.AddWithValue("@from", campos.replies[0].from);
                    cmd.Parameters.AddWithValue("@accountId", "2087");
                    cmd.Parameters.AddWithValue("@accountName", "Carsystem");

                    cmd.CommandTimeout = 160;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    intResposta = cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                return ex.Message.ToString();
                //throw new global::System.Data.StrongTypingException("'Procure o Administrador'", ex);
            }
            return "ok";
        }

        public string setLogErroSms(string strMensagem, string id_lead)
        {
            int intResposta = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("[CRM].[pro_LogErroSMS]", conn);

                    cmd.Parameters.AddWithValue("@ds_mensagem", strMensagem);
                    cmd.Parameters.AddWithValue("@id_lead", id_lead);

                    cmd.CommandTimeout = 160;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    intResposta = cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                return ex.Message.ToString();
                //throw new global::System.Data.StrongTypingException("'Procure o Administrador'", ex);
            }
            return "ok";
        }
    }
}