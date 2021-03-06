﻿using BeautyServiceDAL.BindingModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyServiceDAL.ViewModels
{
    public class ServiceViewModel
    {
        public int ServiceId { get; set; }
        [DisplayName("Название услуги")]
        public string ServiceName { get; set; }
        public List<ServiceResourseViewModel> ServiceResourses { get; set; }
    }
}
