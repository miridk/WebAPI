﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Todo
    {
        [Key]
        public int TodoId
        {
            get;
            set;
        }
        public string TodoTask
        {
            get;
            set;
        }

        public int Amount
        {
            get;
            set;
        }
    }
}
