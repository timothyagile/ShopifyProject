﻿using System;
using System.Collections.Generic;

namespace Shopify.Models;

public partial class TQuocGia
{
    public string MaNuoc { get; set; } = null!;

    public string? TenNuoc { get; set; }

    public virtual ICollection<TDanhMucSp> TDanhMucSps { get; set; } = new List<TDanhMucSp>();
}
