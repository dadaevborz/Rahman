namespace Rahman.ModelBD
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RARM")]
    public partial class RARM
    {
        public int id { get; set; }

        [StringLength(50)]
        public string Услуга { get; set; }

        [StringLength(50)]
        public string Цена { get; set; }

        [StringLength(50)]
        public string Время { get; set; }

        [StringLength(50)]
        public string Клиент { get; set; }
    }
}
