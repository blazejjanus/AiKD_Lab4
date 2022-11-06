using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace AiKD_Lab4 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void save_button_Click(object sender, EventArgs e) {
            if (program_info.TargetFileType == FileType.NONE) {
                DisplayError("Podano błędny typ pliku wynikowego!");
            } else {
                PassOptions();
                program_info.TargetFile = Functions.PrepearePath(target_file_input.Text);
                System.Int64 file_size = 0;
                System.Int64 bitmap_size = 0;
                try {
                    //bitmap_size = program_info.BitmapSize;
                    bitmap_size = program_info.SourceFileSize;
                    file_size = program_info.Save();
                }catch(Exception exc) {
                    DisplayError(exc.Message);
                }
                double compression_ratio = ((double)bitmap_size / file_size);
                this.bitmap_size.Text = bitmap_size + " B";
                this.result_file_size.Text = file_size + " B";
                this.compression_ratio.Text = Math.Round(compression_ratio, 2).ToString();
                ShowResults();
            }
        }

        private void load_Click(object sender, EventArgs e) {
            string source_path = source_file_input.Text;
            if (source_path == null) {
                DisplayError("Podaj ścieżkę pliku źródłowego.");
            } else {
                source_path = Functions.PrepearePath(source_path);
                source_file_input.Text = source_path;
                if (File.Exists(source_path)){
                    this.program_info = new ProgramInfo(source_path);
                    source_file_input.ReadOnly = true;
                    DisplayBitMap();
                    ShowSave();
                } else {
                    DisplayError("Podana ścieżka jest niepoprawna.");
                    source_file_input.Clear();
                }
            }
        }

        private void DisplayBitMap() {
            pb_img.Visible = true;
            Bitmap image = new Bitmap(program_info.Bitmap);
            pb_img.Image = image;
        }

        private void HideBitMap() {
            pb_img.Visible = false;
            pb_img.Image = null;
        }

        private void clear_Click(object sender, EventArgs e) {
            source_file_input.ReadOnly = false;
            if (keep_source_file_path == false) {
                source_file_input.Clear();
            }
            HideSave();
            HideResults();
            load.Visible = true;
            HideBitMap();
            file_type_input.Enabled = true;
            value_changed_by_user = false;
            file_type_input.SelectedIndex = -1;
        }

        private void file_type_input_SelectedIndexChanged(object sender, EventArgs e) {
            string fts = file_type_input.Text;
            FileType ft = Functions.String2FileType(fts);
            if (value_changed_by_user == true) {
                if (ft == FileType.NONE) {
                    DisplayError("Podaj poprawny typ pliku.");
                } else {
                    if (ft == FileType.JPG) {
                        file_type_input.Enabled = false;
                        jpg_quality_input.Visible = true;
                        jpg_quality_input.Value = 50;
                        jpg_quality_label.Visible = true;
                    }
                    if (ft == FileType.TIF) {
                        file_type_input.Enabled = false;
                        tif_compression_input.Visible = true;
                        tif_compression_input.Text = "brak";
                        tif_compression_label.Visible = true;
                    }
                    program_info.TargetFileType = ft;
                    PassOptions();
                    ShowTargetPath();
                }
            } else {
                value_changed_by_user = true;
            }
        }
        private void tif_compression_input_SelectedIndexChanged(object sender, EventArgs e) {
            PassOptions();
            TargetName();
        }
        private void jpg_quality_input_ValueChanged(object sender, EventArgs e) {
            PassOptions();
            TargetName();
        }
        private void PassOptions() {
            if (program_info.TargetFileType == FileType.JPG) {
                try {
                    int comp;
                    string str = jpg_quality_input.Value.ToString();
                    Int32.TryParse(str, out comp);
                    program_info.JPGCompression = comp;
                } catch (Exception exc) {
                    DisplayError(exc.Message);
                }
            }
            if (program_info.TargetFileType == FileType.TIF) {
                string str = tif_compression_input.Text;
                program_info.TIFCompression = Functions.String2TIFCompression(str);
            }
        }
        private void ShowSave() {
            load.Visible = false;
            file_type_input.Visible = true;
            file_type_label.Visible = true;
            //Widoczność przycisku zapisu
            save_button.Visible = true;
        }
        private void ShowTargetPath() {
            //Wyłączamy widoczność elementów do podawania ściezki do pliku źródłowego
            source_file_input.Visible = false;
            source_file_label.Visible = false;
            //Włączamy widoczność elementów do podawania ściezki do pliku docelowego
            target_file_input.Visible = true;
            target_file_label.Visible = true;
            TargetName();
        }
        private void TargetName() {
            //Domysłna wartość ścieżki docelowej
            string path = Functions.GetContainingFolder(program_info.SourceFilePath);
            path += "\\";
            path += program_info.GenFileName();
            target_file_input.Text = path;
        }
        private void HideSave() {
            //Wyłączamy widoczność kontrolek wybierania typu pliku
            file_type_input.Visible = false;
            file_type_label.Visible = false;
            //Włączamy widoczność elementów do podawania ściezki do pliku źródłowego
            source_file_input.Visible = true;
            source_file_label.Visible = true;
            //Wyłączamy widoczność elementów do podawania ściezki do pliku docelowego
            target_file_input.Visible = false;
            target_file_label.Visible = false;
            //Wyłączamy widoczność nasta jakości JPG
            jpg_quality_input.Visible = false;
            jpg_quality_label.Visible = false;
            //Wyłączamy widoczność kontrolek do wyboru typu kompresji TIF
            tif_compression_input.Visible = false;
            tif_compression_label.Visible = false;
            //Widoczność przycisku zapisu
            save_button.Visible = false;
        }

        private void ShowResults() {
            bitmap_size.Visible = true;
            bitmap_size_label.Visible = true;
            result_file_size.Visible = true;
            result_file_size_label.Visible = true;
            compression_ratio.Visible = true;
            compression_ratio_label.Visible = true;
            clear.Visible = true;
        }
        private void HideResults() {
            bitmap_size.Visible = false;
            bitmap_size_label.Visible = false;
            result_file_size.Visible = false;
            result_file_size_label.Visible = false;
            compression_ratio.Visible = false;
            compression_ratio_label.Visible = false;
            clear.Visible = false;
        }

        public void DisplayError(string message) {
            MessageBox.Show("Błąd!\n" + message);
        }
        //Pola
        ProgramInfo program_info;
        bool value_changed_by_user = true;
        bool keep_source_file_path = true;
    }
}
