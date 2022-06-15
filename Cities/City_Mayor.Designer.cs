
namespace Cities
{
    partial class City_Mayor
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.mayorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.kursovaDataSet = new Cities.KursovaDataSet();
            this.mayorTableAdapter = new Cities.KursovaDataSetTableAdapters.MayorTableAdapter();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.mayorIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mayorLastNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mayorFirstNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mayorPatronemicDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mayorGenderDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mayorDateOfBirthDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mayorPoliticalActivityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fKCityMayorMayorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.city_MayorTableAdapter = new Cities.KursovaDataSetTableAdapters.City_MayorTableAdapter();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.mayorBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kursovaDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fKCityMayorMayorBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(195, 198);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Назва міста";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(246, 275);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 32);
            this.label2.TabIndex = 1;
            this.label2.Text = "Id мера";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(72, 348);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(301, 32);
            this.label3.TabIndex = 2;
            this.label3.Text = "Чи є дійсним мером ?";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(426, 198);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(185, 39);
            this.textBox1.TabIndex = 3;
            // 
            // comboBox1
            // 
            this.comboBox1.DataSource = this.mayorBindingSource;
            this.comboBox1.DisplayMember = "Mayor_Id";
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(426, 272);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(185, 40);
            this.comboBox1.TabIndex = 5;
            this.comboBox1.ValueMember = "Mayor_Id";
            // 
            // mayorBindingSource
            // 
            this.mayorBindingSource.DataMember = "Mayor";
            this.mayorBindingSource.DataSource = this.kursovaDataSet;
            // 
            // kursovaDataSet
            // 
            this.kursovaDataSet.DataSetName = "KursovaDataSet";
            this.kursovaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // mayorTableAdapter
            // 
            this.mayorTableAdapter.ClearBeforeFill = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(225, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(297, 64);
            this.label4.TabIndex = 6;
            this.label4.Text = "Місто Мер";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(542, 715);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 46);
            this.button1.TabIndex = 7;
            this.button1.Text = "Изменить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(355, 714);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(129, 47);
            this.button2.TabIndex = 8;
            this.button2.Text = "Добавить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.mayorIdDataGridViewTextBoxColumn,
            this.mayorLastNameDataGridViewTextBoxColumn,
            this.mayorFirstNameDataGridViewTextBoxColumn,
            this.mayorPatronemicDataGridViewTextBoxColumn,
            this.mayorGenderDataGridViewTextBoxColumn,
            this.mayorDateOfBirthDataGridViewTextBoxColumn,
            this.mayorPoliticalActivityDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.mayorBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(59, 438);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(676, 212);
            this.dataGridView1.TabIndex = 9;
            // 
            // mayorIdDataGridViewTextBoxColumn
            // 
            this.mayorIdDataGridViewTextBoxColumn.DataPropertyName = "Mayor_Id";
            this.mayorIdDataGridViewTextBoxColumn.HeaderText = "Mayor_Id";
            this.mayorIdDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.mayorIdDataGridViewTextBoxColumn.Name = "mayorIdDataGridViewTextBoxColumn";
            this.mayorIdDataGridViewTextBoxColumn.Width = 150;
            // 
            // mayorLastNameDataGridViewTextBoxColumn
            // 
            this.mayorLastNameDataGridViewTextBoxColumn.DataPropertyName = "Mayor_Last_Name";
            this.mayorLastNameDataGridViewTextBoxColumn.HeaderText = "Mayor_Last_Name";
            this.mayorLastNameDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.mayorLastNameDataGridViewTextBoxColumn.Name = "mayorLastNameDataGridViewTextBoxColumn";
            this.mayorLastNameDataGridViewTextBoxColumn.Width = 150;
            // 
            // mayorFirstNameDataGridViewTextBoxColumn
            // 
            this.mayorFirstNameDataGridViewTextBoxColumn.DataPropertyName = "Mayor_First_Name";
            this.mayorFirstNameDataGridViewTextBoxColumn.HeaderText = "Mayor_First_Name";
            this.mayorFirstNameDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.mayorFirstNameDataGridViewTextBoxColumn.Name = "mayorFirstNameDataGridViewTextBoxColumn";
            this.mayorFirstNameDataGridViewTextBoxColumn.Width = 150;
            // 
            // mayorPatronemicDataGridViewTextBoxColumn
            // 
            this.mayorPatronemicDataGridViewTextBoxColumn.DataPropertyName = "Mayor_Patronemic";
            this.mayorPatronemicDataGridViewTextBoxColumn.HeaderText = "Mayor_Patronemic";
            this.mayorPatronemicDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.mayorPatronemicDataGridViewTextBoxColumn.Name = "mayorPatronemicDataGridViewTextBoxColumn";
            this.mayorPatronemicDataGridViewTextBoxColumn.Width = 150;
            // 
            // mayorGenderDataGridViewTextBoxColumn
            // 
            this.mayorGenderDataGridViewTextBoxColumn.DataPropertyName = "Mayor_Gender";
            this.mayorGenderDataGridViewTextBoxColumn.HeaderText = "Mayor_Gender";
            this.mayorGenderDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.mayorGenderDataGridViewTextBoxColumn.Name = "mayorGenderDataGridViewTextBoxColumn";
            this.mayorGenderDataGridViewTextBoxColumn.Width = 150;
            // 
            // mayorDateOfBirthDataGridViewTextBoxColumn
            // 
            this.mayorDateOfBirthDataGridViewTextBoxColumn.DataPropertyName = "Mayor_Date_Of_Birth";
            this.mayorDateOfBirthDataGridViewTextBoxColumn.HeaderText = "Mayor_Date_Of_Birth";
            this.mayorDateOfBirthDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.mayorDateOfBirthDataGridViewTextBoxColumn.Name = "mayorDateOfBirthDataGridViewTextBoxColumn";
            this.mayorDateOfBirthDataGridViewTextBoxColumn.Width = 150;
            // 
            // mayorPoliticalActivityDataGridViewTextBoxColumn
            // 
            this.mayorPoliticalActivityDataGridViewTextBoxColumn.DataPropertyName = "Mayor_Political_Activity";
            this.mayorPoliticalActivityDataGridViewTextBoxColumn.HeaderText = "Mayor_Political_Activity";
            this.mayorPoliticalActivityDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.mayorPoliticalActivityDataGridViewTextBoxColumn.Name = "mayorPoliticalActivityDataGridViewTextBoxColumn";
            this.mayorPoliticalActivityDataGridViewTextBoxColumn.Width = 150;
            // 
            // fKCityMayorMayorBindingSource
            // 
            this.fKCityMayorMayorBindingSource.DataMember = "FK_City_Mayor_Mayor";
            this.fKCityMayorMayorBindingSource.DataSource = this.mayorBindingSource;
            // 
            // city_MayorTableAdapter
            // 
            this.city_MayorTableAdapter.ClearBeforeFill = true;
            // 
            // comboBox2
            // 
            this.comboBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "true",
            "false"});
            this.comboBox2.Location = new System.Drawing.Point(426, 345);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(185, 40);
            this.comboBox2.TabIndex = 10;
            // 
            // City_Mayor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 891);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "City_Mayor";
            this.Text = "City_Mayor";
            this.Load += new System.EventHandler(this.City_Mayor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mayorBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kursovaDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fKCityMayorMayorBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private KursovaDataSet kursovaDataSet;
        private System.Windows.Forms.BindingSource mayorBindingSource;
        private KursovaDataSetTableAdapters.MayorTableAdapter mayorTableAdapter;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource fKCityMayorMayorBindingSource;
        private KursovaDataSetTableAdapters.City_MayorTableAdapter city_MayorTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn mayorIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mayorLastNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mayorFirstNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mayorPatronemicDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mayorGenderDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mayorDateOfBirthDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mayorPoliticalActivityDataGridViewTextBoxColumn;
        private System.Windows.Forms.ComboBox comboBox2;
    }
}