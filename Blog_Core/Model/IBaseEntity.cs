﻿using Blog_Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog_Core.Model
{
    public interface IBaseEntity
    {
        DateTime CreateDate { get; set; }
        DateTime? UpdateDate { get; set; }
        DateTime? DeleteDate { get; set; }
        Status Status { get; set; }
    }
}
