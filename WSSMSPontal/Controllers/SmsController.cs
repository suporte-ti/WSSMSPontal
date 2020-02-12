using System;
using System.Web.Http;
using WSSMSPontal.Models;

namespace WSSMSPontal.Controllers
{
    public class SmsController : ApiController
    {
        [AcceptVerbs("POST")]
        [Route("Status")]
        public string Status(Sms camposSms)
        {
            try
            {
                string strResposta;

                if (camposSms.type == "api_message")
                {
                    dao.DaoSms sms = new dao.DaoSms();
                    strResposta = sms.setRetornoSms(camposSms);
                }
                else
                {
                    strResposta = RespostaFinalSms(camposSms);
                }
            }
            catch (Exception ex)
            {
                dao.DaoSms log = new dao.DaoSms();
                log.setLogErroSms(ex.Message.ToString(), camposSms.reference);

                return ex.Message.ToString();
                //throw;
            }
            return ("OK");
        }

        //[AcceptVerbs("POST")]
        //[Route("RespostaFinalSms")]
        public string RespostaFinalSms(Sms camposSms)
        {
            try
            {
                string strResposta;
                dao.DaoSms atualizaSms = new dao.DaoSms();
                strResposta = atualizaSms.setRetornoAtualizaSms(camposSms);
            }
            catch (Exception ex)
            {
                dao.DaoSms log = new dao.DaoSms();
                log.setLogErroSms(ex.Message.ToString(), camposSms.reference);

                return ex.Message.ToString();
                //throw;
            }
            return "Ok";
        }
    }
}
