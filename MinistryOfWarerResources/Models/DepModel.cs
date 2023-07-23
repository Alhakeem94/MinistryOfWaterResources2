
using System.ComponentModel.DataAnnotations.Schema;

namespace MinistryOfWarerResources.Models
{
    public class DepModel
    {
        public int Id { get; set; }
        public string DepName { get; set; }



        [ForeignKey("OfficeTable")]
        public int OfficeTableId { get; set; }
        public OfficeModel OfficeTable { get; set; }


    }
}
