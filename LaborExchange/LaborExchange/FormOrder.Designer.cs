
namespace LaborExchange
{
    partial class FormOrder
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelApplicant = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.comboBoxUser = new System.Windows.Forms.ComboBox();
            this.labelVacancy = new System.Windows.Forms.Label();
            this.labelExchangeEmployee = new System.Windows.Forms.Label();
            this.comboBoxStatus = new System.Windows.Forms.ComboBox();
            this.textBoxDeliveryprice = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labelApplicant
            // 
            this.labelApplicant.AutoSize = true;
            this.labelApplicant.Location = new System.Drawing.Point(12, 50);
            this.labelApplicant.Name = "labelApplicant";
            this.labelApplicant.Size = new System.Drawing.Size(86, 13);
            this.labelApplicant.TabIndex = 44;
            this.labelApplicant.Text = "Цена доставки:";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(163, 134);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 43;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(67, 134);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 42;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // comboBoxUser
            // 
            this.comboBoxUser.FormattingEnabled = true;
            this.comboBoxUser.Location = new System.Drawing.Point(104, 20);
            this.comboBoxUser.Name = "comboBoxUser";
            this.comboBoxUser.Size = new System.Drawing.Size(158, 21);
            this.comboBoxUser.TabIndex = 41;
            // 
            // labelVacancy
            // 
            this.labelVacancy.AutoSize = true;
            this.labelVacancy.Location = new System.Drawing.Point(12, 23);
            this.labelVacancy.Name = "labelVacancy";
            this.labelVacancy.Size = new System.Drawing.Size(58, 13);
            this.labelVacancy.TabIndex = 40;
            this.labelVacancy.Text = "Заказчик:";
            // 
            // labelExchangeEmployee
            // 
            this.labelExchangeEmployee.AutoSize = true;
            this.labelExchangeEmployee.Location = new System.Drawing.Point(12, 82);
            this.labelExchangeEmployee.Name = "labelExchangeEmployee";
            this.labelExchangeEmployee.Size = new System.Drawing.Size(44, 13);
            this.labelExchangeEmployee.TabIndex = 38;
            this.labelExchangeEmployee.Text = "Статус:";
            // 
            // comboBoxStatus
            // 
            this.comboBoxStatus.FormattingEnabled = true;
            this.comboBoxStatus.Location = new System.Drawing.Point(104, 74);
            this.comboBoxStatus.Name = "comboBoxStatus";
            this.comboBoxStatus.Size = new System.Drawing.Size(158, 21);
            this.comboBoxStatus.TabIndex = 50;
            // 
            // textBoxDeliveryprice
            // 
            this.textBoxDeliveryprice.Location = new System.Drawing.Point(104, 48);
            this.textBoxDeliveryprice.Name = "textBoxDeliveryprice";
            this.textBoxDeliveryprice.Size = new System.Drawing.Size(158, 20);
            this.textBoxDeliveryprice.TabIndex = 51;
            // 
            // FormOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 170);
            this.Controls.Add(this.textBoxDeliveryprice);
            this.Controls.Add(this.comboBoxStatus);
            this.Controls.Add(this.labelApplicant);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.comboBoxUser);
            this.Controls.Add(this.labelVacancy);
            this.Controls.Add(this.labelExchangeEmployee);
            this.Name = "FormOrder";
            this.Text = "Заказ";
            this.Load += new System.EventHandler(this.FormOrder_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelApplicant;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.ComboBox comboBoxUser;
        private System.Windows.Forms.Label labelVacancy;
        private System.Windows.Forms.Label labelExchangeEmployee;
        private System.Windows.Forms.ComboBox comboBoxStatus;
        private System.Windows.Forms.TextBox textBoxDeliveryprice;
    }
}