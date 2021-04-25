using LaborExchangeBusinessLogic.BindingModels;
using LaborExchangeBusinessLogic.BusinessLogics;
using System;
using System.Windows.Forms;

namespace LaborExchange
{
    public partial class FormOrder : Form
    {
        public int Id { set { id = value; } }
        private readonly OrdersLogic logic;
        private readonly UsersLogic logicU;
        private readonly StatusLogic logicS;
        private int? id;

        public FormOrder(OrdersLogic logic, UsersLogic logicU, StatusLogic logicS)
        {
            InitializeComponent();
            this.logic = logic;
            this.logicU = logicU;
            this.logicS = logicS;

        }

        private void FormOrder_Load(object sender, EventArgs e)
        {
            try
            {
                var listApplicant = logicU.Read(null);

                foreach (var item in listApplicant)
                {
                    comboBoxUser.DisplayMember = "Login";
                    comboBoxUser.ValueMember = "Userid";
                    comboBoxUser.DataSource = listApplicant;
                    comboBoxUser.SelectedItem = null;
                }

                var listVacancy = logicS.Read(null);

                foreach (var item in listVacancy)
                {
                    comboBoxStatus.DisplayMember = "State";
                    comboBoxStatus.ValueMember = "Statusid";
                    comboBoxStatus.DataSource = listVacancy;
                    comboBoxStatus.SelectedItem = null;
                }
          
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (id.HasValue)
            {
                try
                {
                    var view = logic.Read(new OrdersBindingModel { Orderid = id })?[0];

                    if (view != null)
                    {
                        comboBoxUser.SelectedValue = view.Userid;
                        comboBoxStatus.SelectedValue = view.Statusid;
                        textBoxDeliveryprice.Text = view.Deliveryprice.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
           
            if (comboBoxUser.SelectedValue == null)
            {
                MessageBox.Show("Выберите заказчика", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxStatus.SelectedValue == null)
            {
                MessageBox.Show("Выберите статус заказа", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {

                logic.CreateOrUpdate(new OrdersBindingModel
                {
                    Orderid = id,
                    Orderdate = DateTime.Now,
                    Deliveryprice = Convert.ToDecimal(textBoxDeliveryprice.Text),
                    Userid = Convert.ToInt32(comboBoxUser.SelectedValue),
                    Statusid = Convert.ToInt32(comboBoxStatus.SelectedValue)
                    //Userid = (int)comboBoxUser.SelectedValue,
                    //Statusid = (int)comboBoxStatus.SelectedValue

                });


                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
