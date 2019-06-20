using BeautyServiceDAL_P.Interfaces;
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
    public partial class FormLogin : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly IProviderService service;
        public FormLogin(IProviderService service)
        {
            InitializeComponent();
            this.service = service;
        }

        private void buttonIn_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (service.ProviderExist(textBoxMail.Text, textBoxPassword.Text))
                {
                    var form = Container.Resolve<FormMain>();
                    form.ShowDialog();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
MessageBoxIcon.Error);
            }
        }
    }
}
