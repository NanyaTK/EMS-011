using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMS_011.Models
{
    public class PurchaseReports
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public string ProductName { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal Quantity { get; set; }

        public decimal Subtotal { get; set; }

        public decimal Total { get; set; }

        public string Payee { get; set; }

        //[RegularExpression(@"制御班|回路班|機械班|その他", ErrorMessage = "制御班,回路班,機械班,その他のいずれかで入力してください.")]
        //[Required]
        public string Division { get; set; }

        public string Remarks { get; set; }

        //[Column(TypeName = "mediumblob")]
        public byte[] ImageFile { get; set; }
    }
}
