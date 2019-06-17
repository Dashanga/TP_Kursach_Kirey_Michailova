using BeautyServiceDAL_P.BindingModels;
using BeautyServiceDAL_P.Interfaces;
using BeautyServiceDAL_P.ViewModel;
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
    public partial class FormResourse : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int Id { set { id = value; } }
        private readonly IResourseService service;
        private int? id;


        public FormResourse(IResourseService service)
        {
            InitializeComponent();
            this.service = service;
        }
        private void FormResourse_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    ResourseViewModel view = service.GetElement(id.Value);
                    if (view != null)
                    {
                        textBoxName.Text = view.ResourseName;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните ФИО", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxPrice.Text))
            {
                MessageBox.Show("Заполните цену", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (id.HasValue)
                {
                    service.UpdElement(new ResourseBindingModel
                    {
                        Id = id.Value,
                        ResourseName = textBoxName.Text,
                        ResoursePrice = Convert.ToInt32(textBoxPrice.Text),
                    });
                }
                else
            {
                    service.AddElement(new ResourseBindingModel
                    {
                        ResourseName = textBoxName.Text,
                        ResoursePrice = Convert.ToInt32(textBoxPrice.Text),
                    });
                }
                MessageBox.Show("Сохранение прошло успешно", "Сообщение",
               MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }

        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
