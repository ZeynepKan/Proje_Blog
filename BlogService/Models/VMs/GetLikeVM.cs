using Blog_Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogService.Models.VMs
{
    public class GetLikeVM
    {
       public int ID { get; set; }
       public  DateTime CreateDate;
       public Status Status;
       public string UserName;
    
        
    }
}
