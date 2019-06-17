using BeautyServiceDAL_P.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using BeautyServiceDAL_P.ViewModel;
using BeautyServiceDAL_P.BindingModels;

namespace BeutyView
{
    public partial class FormPutOnSklad : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly ISkladService serviceS;
        private readonly IResourseService serviceR;
        private readonly IMainService serviceM;
        public FormPutOnSklad(ISkladService serviceS, IResourseService serviceR,
IMainService serviceM)
        {
            InitializeComponent();
            this.serviceS = serviceS;
            this.serviceR = serviceR;
            this.serviceM = serviceM;
        }
        private void FormPutOnSklad_Load(object sender, EventArgs e)
        {
            try
            {
                List<ResourseViewModel> listC = serviceR.GetList();
                if (listC != null)
                {
                    comboBoxResourse.DisplayMember = "ResourseName";
                    comboBoxResourse.ValueMember = "Id";
                    comboBoxResourse.DataSource = listC;
                    comboBoxResourse.SelectedItem = null;
                }
                List<SkladViewModel> listS = serviceS.GetList();
                if (listS != null)
                {
                    comboBoxSklad.DisplayMember = "SkladName";
                    comboBoxSklad.ValueMember = "Id";
                    comboBoxSklad.DataSource = listS;
                    comboBoxSklad.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxResourse.SelectedValue == null)
            {
                MessageBox.Show("Выберите ресурс", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            if (comboBoxSklad.SelectedValue == null)
            {
                MessageBox.Show("Выберите магазин", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            try
            {
                serviceM.PutResourseOnSklad(new SkladResourseBindingModel
                {
                    ResourseId = Convert.ToInt32(comboBoxResourse.SelectedValue),
                    SkladId = Convert.ToInt32(comboBoxSklad.SelectedValue),
                    Count = Convert.ToInt32(textBoxCount.Text)
                });
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
