﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyServiceDAL.ViewModels
{
    public class SkladViewModel
    {
        public int SkladId { get; set; }
        [DisplayName("Название склада")]
        public string SkladName { get; set; }
        public List<SkladResourseViewModel> SkladResourses { get; set; }
    }
}
