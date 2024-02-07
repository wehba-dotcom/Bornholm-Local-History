using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;


namespace WebApi.SharedModels

{

    public class Feallesbase
    {
        [Key]
        public int ID { get; set; }
        public string? AvisTypeID { get; set; }

        public DateTime? Avisdato { get; set; }
        public string? Efternavn { get; set; }
        [Required]
        public string? Fornavne { get; set; }

        public DateTime? Foedt { get; set; }
        public string? Alder { get; set; }
        public string? Doebenavn { get; set; }
        public string? Erhverv { get; set; }
        public string? Adresser { get; set; }
        public string? SognID { get; set; }
        public string? TidlBopael { get; set; }

        public DateTime? Doedsdato { get; set; }

        public DateTime? Begravelsesdato { get; set; }
        public string? Begravelsessted { get; set; }
        public string? Efterladte { get; set; }
        public string? FlereDoedsannoncer { get; set; }
        public string? AndreDataFraAnnoncen { get; set; }
        public string? Oegenavne { get; set; }

        public DateTime? Nekrolog { get; set; }

        public DateTime? Mindeord { get; set; }

        public DateTime? Statstidende { get; set; }
        [DisplayName("Partner Link")]
        public string? Partnerlink { get; set; }
        public Feallesbase()
        {

        }


    }
}

