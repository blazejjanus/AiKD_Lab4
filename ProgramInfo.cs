using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

//Brak wymagań co do wieloplatformowości
#pragma warning disable CA1416 // Validate platform compatibility

namespace AiKD_Lab4 {
    public class ProgramInfo {
        public ProgramInfo() {
            this.source_file = null;
            this.image = null;
            this.source_file_type = FileType.NONE;
            this.target_file_type = FileType.NONE;
            this.jpg_compression = 0;
            this.tif_compression = TIFCompression.NONE;
        }
        public ProgramInfo(string source_file) {
            if (File.Exists(source_file)) {
                this.source_file_type = Functions.GetFileType(source_file);
                if (this.source_file_type != FileType.NONE) {
                    this.source_file = source_file;
                    this.image = new Bitmap(source_file);
                    this.target_file_type = FileType.NONE;
                    this.jpg_compression = 0;
                    this.tif_compression = TIFCompression.NONE;
                } else {
                    throw new Exception("Typ podanego pliku jest nieprawidłowy!");
                }
            } else {
                throw new Exception("Podana ścieżka do pliku jest nieprawidłowa!");
            }
        }
        ~ProgramInfo() {
            image.Dispose(); //Zwalniamy bitmapę w destruktorze
        }
        //Metody
        public string GenFileName() {
            //Podstawowa nazwa
            string result = "result_";
            result += Functions.GetFileNameFromPath(this.source_file);
            //Opcje dla JPG
            if (target_file_type == FileType.JPG) {
                result += "_q-";
                result += this.jpg_compression;
            }
            //Opcje dla TIF
            if (target_file_type == FileType.TIF) {
                if (tif_compression != TIFCompression.NONE) {
                    result += "_";
                    result += Functions.TIFCompression2String(tif_compression);
                }
            }
            //Rozszerzenie
            result += ".";
            result += Functions.FileType2String(this.target_file_type);
            return result;
        }
        public System.Int64 Save() {
            System.Int64 size = 0;
            Bitmap img_copy = new Bitmap(image); //Kopia robocza
            if (target_file_type == FileType.JPG) {
                ImageCodecInfo JPG = GetEncoder(ImageFormat.Jpeg);
                System.Drawing.Imaging.Encoder JPG_en = System.Drawing.Imaging.Encoder.Quality;
                EncoderParameters JPG_Params = new EncoderParameters(1);
                JPG_Params.Param[0] = new EncoderParameter(JPG_en, this.jpg_compression);
                img_copy.Save(target_file, JPG, JPG_Params);
            } else {
                if (target_file_type == FileType.TIF) {
                    ImageCodecInfo TIF = GetEncoderInfo("image/tiff");
                    System.Drawing.Imaging.Encoder TIF_en = System.Drawing.Imaging.Encoder.Compression;
                    EncoderParameters TIF_Params = new EncoderParameters(1);
                    TIF_Params.Param[0] = new EncoderParameter(TIF_en, (long)GetEncoderValue());
                    img_copy.Save(target_file, TIF, TIF_Params);
                } else {
                    if (target_file_type == FileType.BMP) {
                        img_copy.Save(target_file, ImageFormat.Bmp);
                    } else {
                        if (target_file_type == FileType.PNG) {
                            img_copy.Save(target_file, ImageFormat.Png);
                        } else {
                            if (target_file_type == FileType.BMP) {
                                img_copy.Save(target_file, ImageFormat.Bmp);
                            } else {
                                if (target_file_type == FileType.GIF) {
                                    img_copy.Save(target_file, ImageFormat.Gif);
                                } else {
                                    if (target_file_type == FileType.NONE) {
                                        throw new Exception("Typ pliku docelowego jest niepoprawny.");
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (File.Exists(target_file)) {
                FileInfo file = new FileInfo(target_file);
                size = file.Length;
            } else {
                throw new Exception("Nie udało się wczytać rozmiaru pliku wynikowego.");
            }
            return size;
        }
        private EncoderValue GetEncoderValue() {
            EncoderValue result = EncoderValue.CompressionNone;
            switch (this.tif_compression) {
                case TIFCompression.NONE:
                    result = EncoderValue.CompressionNone;
                    break;
                case TIFCompression.CCITT3:
                    result = EncoderValue.CompressionCCITT3;
                    break;
                case TIFCompression.CCITT4:
                    result = EncoderValue.CompressionCCITT4;
                    break;
                case TIFCompression.LZW:
                    result = EncoderValue.CompressionLZW;
                    break;
                case TIFCompression.RLE:
                    result = EncoderValue.CompressionRle;
                    break;
            }
            return result;
        }
        private ImageCodecInfo GetEncoder(ImageFormat format) {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
            foreach (ImageCodecInfo codec in codecs) {
                if (codec.FormatID == format.Guid) {
                    return codec;
                }
            }
            return null;
        }
        private ImageCodecInfo GetEncoderInfo(String mimeType) {
            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j < encoders.Length; ++j) {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            return null;
        }
        //Właściwości
        public System.Int64 BitmapSize {
            get {
                System.Int64 size; //Long
                MemoryStream memory = new MemoryStream();
                Bitmap img_copy = new Bitmap(image); //Kopia robocza
                img_copy.Save(memory, ImageFormat.Bmp); //Zapis bitmapy do MemoryStream
                size = memory.Length; //Długość MemoryStream w bitach
                img_copy.Dispose(); //Zwalniamy kopię roboczą
                memory.Dispose(); //Zwalniamy MemoryStream
                return size/8;
            }
        }
        public System.Int64 SourceFileSize {
            get {
                System.Int64 size; //Long
                FileInfo file = new FileInfo(source_file);
                size = file.Length;
                return size;
            }
        }
        public int JPGCompression {
            get { return jpg_compression; }
            set {
                if (value > 100) {
                    throw new Exception("Maksymalna wartość kompresji JPG to 100!");
                }
                if (value < 0) {
                    throw new Exception("Minimalna wartość kompresji JPG to 0!");
                }
                jpg_compression = value;
            }
        }
        public TIFCompression TIFCompression {
            get { return tif_compression; }
            set { tif_compression = value; }
        }
        public FileType TargetFileType {
            get { return target_file_type; }
            set {
                if (value == FileType.NONE) {
                    throw new Exception("Ustaw poprawny typ pliku wynikowego!");
                }
                target_file_type = value;
            }
        }
        public FileType SourceFileType {
            get { return source_file_type; }
        }
        public Bitmap Bitmap {
            get { return image; }
        }
        public string SourceFilePath {
            get { return source_file; }
        }
        public string TargetFile {
            get { return target_file; }
            set { target_file = value; }
        }
        //Pola
        private string source_file;
        private string target_file;
        private Bitmap image;
        private FileType source_file_type;
        private FileType target_file_type;
        private int jpg_compression;
        private TIFCompression tif_compression;
    }
}
