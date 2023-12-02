using Microsoft.AspNetCore.DataProtection.KeyManagement;

namespace GWI.Models.Pessoas
{
    public class PessoasCurriculos
    {

        public int cr_id { get; set; }
        public string cr_nome { get; set; }
        public string cr_endereco { get; set; }
        public string cr_data_nasc { get; set; }
        public string cr_estado_civil { get; set; }
        public string cr_objetivos { get; set; }
        public string cr_telefone_opc { get; set; }
        public string cr_email_opc { get; set; }

        public PessoasCurriculos()
        {
            cr_id = 0;
            cr_nome = string.Empty;
            cr_endereco = string.Empty;
            cr_data_nasc = string.Empty;
            cr_estado_civil = string.Empty;
            cr_objetivos = string.Empty;
            cr_telefone_opc = string.Empty;
            cr_email_opc = string.Empty;
        }
    }
}
