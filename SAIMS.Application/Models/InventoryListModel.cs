using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAIMS.Application.Models
{
    public class InventoryListModel
    {
        public int Id { get; set; }
        public string Item { get; set; }
        public string Category { get; set; }
        public int AvailableQuantity { get; set; }
    }
}
