using System.ComponentModel.DataAnnotations;

namespace KoiCareSystem.CSDL
{
    public class CaKoi
    {
        [Key]  
        public int MaCa { get; set; }  

        [Required]  
        [StringLength(100)] 
        public string TenCa { get; set; }  


        [StringLength(10)]  
        public string GioiTinh { get; set; } 


        [StringLength(100)] 
        public string GiongCa { get; set; } 


        [Range(0, double.MaxValue)]  
        public decimal CanNang { get; set; } 

        [Range(0, double.MaxValue)]  
        public decimal KichThuoc { get; set; } 

        [StringLength(100)] 
        public string XuatXu { get; set; }  
    }
}
