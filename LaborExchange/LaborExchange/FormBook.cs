using LaborExchangeBusinessLogic.BindingModels;
using LaborExchangeBusinessLogic.BusinessLogics;
using LaborExchangeBusinessLogic.ViewModels;
using System;
using System.Windows.Forms;
using Unity;
using Microsoft.EntityFrameworkCore;

namespace LaborExchange
{
    public partial class FormBook : Form
    {
        public int Id { set { id = value; } }
        private readonly BooksLogic logic;
        private int? id;

        public FormBook(BooksLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        BooksViewModel view;

        private void FormEducation_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    view = logic.Read(new BooksBindingModel { Bookid = id })?[0];

                    if (view != null)
                    {
                        textBoxGenre.Text = view.Genre;
                        textBoxName.Text = view.Name;
                        textBoxPrice.Text = view.Price.ToString();
                        textBoxAmount.Text = view.Amount.ToString();
                        textBoxRating.Text = view.Rating.ToString();
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
            if (string.IsNullOrEmpty(textBoxGenre.Text))
            {
                MessageBox.Show("Заполните тип", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {

                logic.CreateOrUpdate(new BooksBindingModel
                {
                    Bookid = id,
                    Genre = textBoxGenre.Text,
                    Name = textBoxName.Text,
                    Price = Convert.ToDecimal(textBoxPrice.Text),
                    Amount = Convert.ToInt32(textBoxAmount.Text),
                    Rating = Convert.ToInt64(textBoxRating.Text)
                });


                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (DbUpdateException exe)
            {
                MessageBox.Show(exe?.InnerException?.Message, "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
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
