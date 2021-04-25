using System;
using System.Windows.Forms;
using LaborExchangeBusinessLogic.BusinessLogics;
using Unity;

namespace LaborExchange
{
    public partial class FormMain : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly OrdersLogic logic;

        public FormMain(OrdersLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        private void FormOrders_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var list = logic.Read(null);

                if (list != null)
                {
                    dataGridView.DataSource = list;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[2].Visible = false;
                    dataGridView.Columns[5].Visible = false;
                    dataGridView.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void авторыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.User != null)
            {
                    var form = Container.Resolve<FormAuthors>();
                    form.ShowDialog();
               
            }
            else
            {
                MessageBox.Show("Необходимо авторизоваться", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void издательстваToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.User != null)
            {

                    var form = Container.Resolve<FormPublishinghouses>();
                    form.ShowDialog();
              
            }
            else
            {
                MessageBox.Show("Необходимо авторизоваться", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void статусыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.User != null)
            {

                    var form = Container.Resolve<FormStatuses>();
                    form.ShowDialog();

            }
            else
            {
                MessageBox.Show("Необходимо авторизоваться", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void книгиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.User != null)
            {
              
                    var form = Container.Resolve<FormBooks>();
                    form.ShowDialog();
               
            }
            else
            {
                MessageBox.Show("Необходимо авторизоваться", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

  

        private void сделкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.User != null)
            {
                
                    var form = Container.Resolve<FormOrders>();
                    form.ShowDialog();
               
            }
            else
            {
                MessageBox.Show("Необходимо авторизоваться", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void входToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormAuthorize>();
            form.ShowDialog();
        }

        private void регистрацияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormRegister>();
            form.ShowDialog();
        }
    }
}
