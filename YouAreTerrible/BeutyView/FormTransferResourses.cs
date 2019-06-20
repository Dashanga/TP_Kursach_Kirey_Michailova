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
    public partial class FormTransferResourses : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly IReportService service;
        private readonly IApplicationService serviceA;
        public TransferResourseViewModel Model
        {
            set { model = value; }
            get
            {
                return model;
            }
        }
        private TransferResourseViewModel model;
        public FormTransferResourses(IReportService service, IApplicationService serviceA)
        {
            InitializeComponent();
            this.service = service;            this.serviceA = serviceA;
        }
        private void FormTransferResourses_Load(object sender, EventArgs e)
        {
            try
            {
                List<ApplicationViewModel> list = serviceA.GetList();
                if (list != null)
                {
                    if (list != null)
                    {
                        dataGridView1.DataSource = list;
                        dataGridView1.Columns[0].Visible = false;
                        dataGridView1.Columns[1].AutoSizeMode =
                        DataGridViewAutoSizeColumnMode.Fill;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }
            private void buttonSform_Click(object sender, EventArgs e)
        {

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                try
                {
                    serviceA.TakeApplicationInWork(new ApplicationBindingModel { ApplicationId = id });
                    SaveFileDialog sfd = new SaveFileDialog
                    {
                        Filter = "doc|*.doc|docx|*.docx"
                    };

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            service.TransferResourses(new ReportBindingModel
                            {
                                FileName = sfd.FileName
                            }, id);
                            MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                           MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Некорректные данные", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
            
        }
    }
}
