﻿using BeautyServiceDAL_P.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace BeutyView
{
    public partial class FormMain : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly IMainService service;
        public FormMain(IMainService service)
        {
            InitializeComponent();
            this.service = service;
        }

        private void ресурсыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormResourses>();
            form.ShowDialog();
        }

        private void магазиныToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormSklads>();
            form.ShowDialog();
        }

        private void пополнитьМагазинToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormPutOnSklad>();
            form.ShowDialog();
        }

        private void отчетыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void сформироватьДокументНаПередачуРусрсовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormTransferResourses>();
            form.ShowDialog();
        }

        private void движениеРесурсовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormMovementResourse>();
            form.ShowDialog();
        }
    }
}
