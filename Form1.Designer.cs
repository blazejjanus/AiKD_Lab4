
namespace AiKD_Lab4 {
    partial class Form1 {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.source_file_input = new System.Windows.Forms.TextBox();
            this.source_file_label = new System.Windows.Forms.Label();
            this.file_type_input = new System.Windows.Forms.ComboBox();
            this.file_type_label = new System.Windows.Forms.Label();
            this.save_button = new System.Windows.Forms.Button();
            this.compression_ratio_label = new System.Windows.Forms.Label();
            this.jpg_quality_label = new System.Windows.Forms.Label();
            this.jpg_quality_input = new System.Windows.Forms.NumericUpDown();
            this.tif_compression_label = new System.Windows.Forms.Label();
            this.tif_compression_input = new System.Windows.Forms.ComboBox();
            this.bitmap_size_label = new System.Windows.Forms.Label();
            this.result_file_size_label = new System.Windows.Forms.Label();
            this.bitmap_size = new System.Windows.Forms.TextBox();
            this.result_file_size = new System.Windows.Forms.TextBox();
            this.compression_ratio = new System.Windows.Forms.TextBox();
            this.clear = new System.Windows.Forms.Button();
            this.load = new System.Windows.Forms.Button();
            this.pb_img = new System.Windows.Forms.PictureBox();
            this.target_file_input = new System.Windows.Forms.TextBox();
            this.target_file_label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.jpg_quality_input)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_img)).BeginInit();
            this.SuspendLayout();
            // 
            // source_file_input
            // 
            this.source_file_input.Location = new System.Drawing.Point(106, 5);
            this.source_file_input.Name = "source_file_input";
            this.source_file_input.Size = new System.Drawing.Size(197, 25);
            this.source_file_input.TabIndex = 0;
            // 
            // source_file_label
            // 
            this.source_file_label.AutoSize = true;
            this.source_file_label.Location = new System.Drawing.Point(13, 13);
            this.source_file_label.Name = "source_file_label";
            this.source_file_label.Size = new System.Drawing.Size(87, 17);
            this.source_file_label.TabIndex = 1;
            this.source_file_label.Text = "Plik źródłowy:";
            // 
            // file_type_input
            // 
            this.file_type_input.FormattingEnabled = true;
            this.file_type_input.Items.AddRange(new object[] {
            "jpg",
            "bmp",
            "png",
            "tif",
            "gif"});
            this.file_type_input.Location = new System.Drawing.Point(106, 34);
            this.file_type_input.Name = "file_type_input";
            this.file_type_input.Size = new System.Drawing.Size(197, 25);
            this.file_type_input.TabIndex = 2;
            this.file_type_input.Visible = false;
            this.file_type_input.SelectedIndexChanged += new System.EventHandler(this.file_type_input_SelectedIndexChanged);
            // 
            // file_type_label
            // 
            this.file_type_label.AutoSize = true;
            this.file_type_label.Location = new System.Drawing.Point(13, 41);
            this.file_type_label.Name = "file_type_label";
            this.file_type_label.Size = new System.Drawing.Size(83, 17);
            this.file_type_label.TabIndex = 3;
            this.file_type_label.Text = "Format pliku:";
            this.file_type_label.Visible = false;
            // 
            // save_button
            // 
            this.save_button.Location = new System.Drawing.Point(13, 94);
            this.save_button.Name = "save_button";
            this.save_button.Size = new System.Drawing.Size(87, 28);
            this.save_button.TabIndex = 4;
            this.save_button.Text = "Zapisz";
            this.save_button.UseVisualStyleBackColor = true;
            this.save_button.Visible = false;
            this.save_button.Click += new System.EventHandler(this.save_button_Click);
            // 
            // compression_ratio_label
            // 
            this.compression_ratio_label.AutoSize = true;
            this.compression_ratio_label.Location = new System.Drawing.Point(13, 201);
            this.compression_ratio_label.Name = "compression_ratio_label";
            this.compression_ratio_label.Size = new System.Drawing.Size(150, 17);
            this.compression_ratio_label.TabIndex = 5;
            this.compression_ratio_label.Text = "Współczynnik kompresji:";
            this.compression_ratio_label.Visible = false;
            // 
            // jpg_quality_label
            // 
            this.jpg_quality_label.AutoSize = true;
            this.jpg_quality_label.Location = new System.Drawing.Point(13, 74);
            this.jpg_quality_label.Name = "jpg_quality_label";
            this.jpg_quality_label.Size = new System.Drawing.Size(49, 17);
            this.jpg_quality_label.TabIndex = 6;
            this.jpg_quality_label.Text = "Jakość:";
            this.jpg_quality_label.Visible = false;
            // 
            // jpg_quality_input
            // 
            this.jpg_quality_input.Location = new System.Drawing.Point(106, 66);
            this.jpg_quality_input.Name = "jpg_quality_input";
            this.jpg_quality_input.Size = new System.Drawing.Size(197, 25);
            this.jpg_quality_input.TabIndex = 7;
            this.jpg_quality_input.Visible = false;
            this.jpg_quality_input.ValueChanged += new System.EventHandler(this.jpg_quality_input_ValueChanged);
            // 
            // tif_compression_label
            // 
            this.tif_compression_label.AutoSize = true;
            this.tif_compression_label.Location = new System.Drawing.Point(12, 74);
            this.tif_compression_label.Name = "tif_compression_label";
            this.tif_compression_label.Size = new System.Drawing.Size(92, 17);
            this.tif_compression_label.TabIndex = 8;
            this.tif_compression_label.Text = "Typ kompresji:";
            this.tif_compression_label.Visible = false;
            // 
            // tif_compression_input
            // 
            this.tif_compression_input.FormattingEnabled = true;
            this.tif_compression_input.Items.AddRange(new object[] {
            "brak",
            "Rle",
            "CCITT3",
            "CCITT4",
            "LZW"});
            this.tif_compression_input.Location = new System.Drawing.Point(106, 65);
            this.tif_compression_input.Name = "tif_compression_input";
            this.tif_compression_input.Size = new System.Drawing.Size(197, 25);
            this.tif_compression_input.TabIndex = 9;
            this.tif_compression_input.Visible = false;
            this.tif_compression_input.SelectedIndexChanged += new System.EventHandler(this.tif_compression_input_SelectedIndexChanged);
            // 
            // bitmap_size_label
            // 
            this.bitmap_size_label.AutoSize = true;
            this.bitmap_size_label.Location = new System.Drawing.Point(13, 137);
            this.bitmap_size_label.Name = "bitmap_size_label";
            this.bitmap_size_label.Size = new System.Drawing.Size(110, 17);
            this.bitmap_size_label.TabIndex = 10;
            this.bitmap_size_label.Text = "Rozmiar bitmapy:";
            this.bitmap_size_label.Visible = false;
            // 
            // result_file_size_label
            // 
            this.result_file_size_label.AutoSize = true;
            this.result_file_size_label.Location = new System.Drawing.Point(13, 169);
            this.result_file_size_label.Name = "result_file_size_label";
            this.result_file_size_label.Size = new System.Drawing.Size(165, 17);
            this.result_file_size_label.TabIndex = 11;
            this.result_file_size_label.Text = "Rozmiar pliku wynikowego:";
            this.result_file_size_label.Visible = false;
            // 
            // bitmap_size
            // 
            this.bitmap_size.Location = new System.Drawing.Point(200, 129);
            this.bitmap_size.Name = "bitmap_size";
            this.bitmap_size.ReadOnly = true;
            this.bitmap_size.Size = new System.Drawing.Size(103, 25);
            this.bitmap_size.TabIndex = 12;
            this.bitmap_size.Visible = false;
            // 
            // result_file_size
            // 
            this.result_file_size.Location = new System.Drawing.Point(200, 161);
            this.result_file_size.Name = "result_file_size";
            this.result_file_size.ReadOnly = true;
            this.result_file_size.Size = new System.Drawing.Size(103, 25);
            this.result_file_size.TabIndex = 13;
            this.result_file_size.Visible = false;
            // 
            // compression_ratio
            // 
            this.compression_ratio.Location = new System.Drawing.Point(200, 193);
            this.compression_ratio.Name = "compression_ratio";
            this.compression_ratio.ReadOnly = true;
            this.compression_ratio.Size = new System.Drawing.Size(103, 25);
            this.compression_ratio.TabIndex = 14;
            this.compression_ratio.Visible = false;
            // 
            // clear
            // 
            this.clear.Location = new System.Drawing.Point(13, 238);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(191, 23);
            this.clear.TabIndex = 15;
            this.clear.Text = "Wyczyść formularz";
            this.clear.UseVisualStyleBackColor = true;
            this.clear.Visible = false;
            this.clear.Click += new System.EventHandler(this.clear_Click);
            // 
            // load
            // 
            this.load.Location = new System.Drawing.Point(322, 5);
            this.load.Name = "load";
            this.load.Size = new System.Drawing.Size(93, 25);
            this.load.TabIndex = 16;
            this.load.Text = "Wczytaj";
            this.load.UseVisualStyleBackColor = true;
            this.load.Click += new System.EventHandler(this.load_Click);
            // 
            // pb_img
            // 
            this.pb_img.Location = new System.Drawing.Point(322, 5);
            this.pb_img.Name = "pb_img";
            this.pb_img.Size = new System.Drawing.Size(474, 440);
            this.pb_img.TabIndex = 17;
            this.pb_img.TabStop = false;
            this.pb_img.Visible = false;
            // 
            // target_file_input
            // 
            this.target_file_input.Location = new System.Drawing.Point(107, 5);
            this.target_file_input.Name = "target_file_input";
            this.target_file_input.Size = new System.Drawing.Size(196, 25);
            this.target_file_input.TabIndex = 18;
            this.target_file_input.Visible = false;
            // 
            // target_file_label
            // 
            this.target_file_label.AutoSize = true;
            this.target_file_label.Location = new System.Drawing.Point(12, 13);
            this.target_file_label.Name = "target_file_label";
            this.target_file_label.Size = new System.Drawing.Size(89, 17);
            this.target_file_label.TabIndex = 19;
            this.target_file_label.Text = "Plik docelowy:";
            this.target_file_label.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.target_file_label);
            this.Controls.Add(this.target_file_input);
            this.Controls.Add(this.pb_img);
            this.Controls.Add(this.load);
            this.Controls.Add(this.clear);
            this.Controls.Add(this.compression_ratio);
            this.Controls.Add(this.result_file_size);
            this.Controls.Add(this.bitmap_size);
            this.Controls.Add(this.result_file_size_label);
            this.Controls.Add(this.bitmap_size_label);
            this.Controls.Add(this.tif_compression_input);
            this.Controls.Add(this.tif_compression_label);
            this.Controls.Add(this.jpg_quality_input);
            this.Controls.Add(this.jpg_quality_label);
            this.Controls.Add(this.compression_ratio_label);
            this.Controls.Add(this.save_button);
            this.Controls.Add(this.file_type_label);
            this.Controls.Add(this.file_type_input);
            this.Controls.Add(this.source_file_label);
            this.Controls.Add(this.source_file_input);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.jpg_quality_input)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_img)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox source_file_input;
        private System.Windows.Forms.Label source_file_label;
        private System.Windows.Forms.ComboBox file_type_input;
        private System.Windows.Forms.Label file_type_label;
        private System.Windows.Forms.Button save_button;
        private System.Windows.Forms.Label compression_ratio_label;
        private System.Windows.Forms.Label jpg_quality_label;
        private System.Windows.Forms.NumericUpDown jpg_quality_input;
        private System.Windows.Forms.Label tif_compression_label;
        private System.Windows.Forms.ComboBox tif_compression_input;
        private System.Windows.Forms.Label bitmap_size_label;
        private System.Windows.Forms.Label result_file_size_label;
        private System.Windows.Forms.TextBox bitmap_size;
        private System.Windows.Forms.TextBox result_file_size;
        private System.Windows.Forms.TextBox compression_ratio;
        private System.Windows.Forms.Button clear;
        private System.Windows.Forms.Button load;
        private System.Windows.Forms.PictureBox pb_img;
        private System.Windows.Forms.TextBox target_file_input;
        private System.Windows.Forms.Label target_file_label;
    }
}

