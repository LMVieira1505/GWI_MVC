namespace GWI.Models
{
    public class FormsCurrs
    {
       
            public int cr_id { get; set; }
            public string cr_Nome_Usuario { get; set; }
            public string cr_Endereco { get; set; }
            public string cr_Data_Nascimento { get; set; }
            public string cr_Estado_Civil { get; set; }
            public string cr_Objetivos { get; set; }
            public int cr_p_id { get; set; }
            public int cr_exp_id { get; set; }
            public int cr_em_id { get; set; }
            public int cr_tl_id { get; set; }
            public int cr_hbt_id { get; set; }
            public int cr_hb_id { get; set; }
            public int cr_fcd_id { get; set; }

        public FormsCurrs()
        {
            cr_id = 0;
            cr_Nome_Usuario = string.Empty;
            cr_Endereco = string.Empty;
            cr_Data_Nascimento = string.Empty;
            cr_Estado_Civil = string.Empty;
            cr_Objetivos = string.Empty;
            cr_p_id = 0;
            cr_exp_id = 0;
            cr_em_id = 0;
            cr_tl_id = 0;
            cr_hbt_id = 0;
            cr_hb_id = 0;
            cr_fcd_id = 0;

        }
    }
}
