using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mvc_CRUD.Models
{
  public class Personel
  {

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }


    [DisplayName("Personel Adı")]
    [Required(ErrorMessage = "{0} boş geçilemez.")]
    [MaxLength(40, ErrorMessage = "{0} {1} karakterden uzun olamaz.")]
    [MinLength(3, ErrorMessage = "{0} {1} karakterden kısa olamaz.")]
    public string Ad { get; set; }


    [Display(Name = "Personel Soyadı")]
    [MaxLength(35, ErrorMessage = "{0} {1} karakterden uzun olamaz.")]
    public string Soyad { get; set; }


    [Display(Name = "Doğum yılı")]
    //1970 ile 2020 arasında olmalı
    [Range(1970, 2020, ErrorMessage = "{0} {1} ile {2} arasında olmalıdır.")]
    public int DogumYili { get; set; }


    [Display(Name = "İşe Giriş Tarihi")]
    public DateTime IseBaslamaTarihi { get; set; }

    [ScaffoldColumn(false)]
    [DisplayName("Aktiflik Durumu")]
    public bool Aktif { get; set; } = true;


    [ScaffoldColumn(false)]
    [DisplayName("Personel Adı Soyadı")]
    [NotMapped]
    [Browsable(false)]
    public string AdSoyad => Ad + " " + Soyad;

    [ScaffoldColumn(false)]
    [DisplayName("Aktiflik Durumu")]
    public string AktifString => Aktif ? "Aktif" : "Pasif";

  }
}
