using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace AiKD_Lab4 {
    public static partial class Functions {
        public static string GetText(string filename) {
            string result = null;
            if (filename == null) {
                result = Input.StringValue("teks źródłowy:");
            } else {
                if (File.Exists(filename) == false) {
                    throw new Exception("Podaj poprawną ścieżkę pliku źródłowego!");
                } else {
                    if (is_file_binary(filename) == true) {
                        byte[] bytes = File.ReadAllBytes(filename);
                        StringBuilder sb = new StringBuilder();
                        foreach(byte b in bytes) {
                            sb.Append(b);
                        }
                        result = sb.ToString();
                    } else {
                        result = File.ReadAllText(filename);
                    }
                }
            }
            return result;
        }
        private static bool is_file_binary(string filename) {
            string ext = GetExtension(filename);
            if(ext == "bin") {
                return true;
            }
            if (ext == "exe") {
                return true;
            }
            if (ext == "msi") {
                return true;
            }
            if (ext == "dat") {
                return true;
            }
            if (ext == "iso") {
                return true;
            }
            return false;
        }
        private static string GetExtension(string filename) {
            string ext = null;
            for(int i=filename.Length-1; i>0; i--) {
                if (filename.ElementAt(i) == '.') {
                    break;
                } else {
                    ext += filename.ElementAt(i);
                }
            }
            ext = RotateString(ext);
            return ext;
        }
        public static string ShortNumbers(string source) {
            string regex = "^0+(?!$)";
            return Regex.Replace(source, regex, "");
        }
        public static string RotateString(string source) {
            string result = null;
            for(int i = source.Length-1; i >= 0; i--) {
                result += source[i];
            }
            return result;
        }
        public static FileType GetFileType(string file_path) {
            string ext = GetExtension(file_path);
            return String2FileType(ext);
        }
        public static FileType String2FileType(string file_extension) {
            FileType file_type = FileType.NONE;
            file_extension = file_extension.Trim(); //Usuwamy białe znaki
            file_extension = file_extension.Trim('.'); //Usuwamy kropkę
            file_extension = file_extension.ToLower(); //Małe litery
            switch (file_extension) {
                case "jpg":
                    file_type = FileType.JPG;
                    break;
                case "jpeg":
                    file_type = FileType.JPG;
                    break;
                case "png":
                    file_type = FileType.PNG;
                    break;
                case "tif":
                    file_type = FileType.TIF;
                    break;
                case "tiff":
                    file_type = FileType.TIF;
                    break;
                case "bmp":
                    file_type = FileType.BMP;
                    break;
                case "gif":
                    file_type = FileType.GIF;
                    break;
                default:
                    file_type = FileType.NONE;
                    break;
            }
            return file_type;
        }
        public static string FileType2String(FileType file_type) {
            string ext = null;
            switch(file_type) {
                case FileType.JPG:
                    ext = "jpg";
                    break;
                case FileType.PNG:
                    ext = "png";
                    break;
                case FileType.TIF:
                    ext = "tif";
                    break;
                case FileType.GIF:
                    ext = "gif";
                    break;
                case FileType.BMP:
                    ext = "bmp";
                    break;
                default:
                    ext = null;
                    break;
            }
            return ext;
        }

        public static TIFCompression String2TIFCompression(string val) {
            TIFCompression result = TIFCompression.NONE;
            val = val.Trim();
            val = val.ToLower();
            switch (val) {
                case "brak":
                    result = TIFCompression.NONE;
                    break;
                case "none":
                    result = TIFCompression.NONE;
                    break;
                case "no":
                    result = TIFCompression.NONE;
                    break;
                case "rle":
                    result = TIFCompression.RLE;
                    break;
                case "ccitt3":
                    result = TIFCompression.CCITT3;
                    break;
                case "c3":
                    result = TIFCompression.CCITT3;
                    break;
                case "ccitt4":
                    result = TIFCompression.CCITT4;
                    break;
                case "c4":
                    result = TIFCompression.CCITT4;
                    break;
                case "lzw":
                    result = TIFCompression.LZW;
                    break;
                default:
                    result = TIFCompression.NONE;
                    break;
            }
            return result;
        }

        public static string TIFCompression2String(TIFCompression val) {
            string result = null;
            switch (val) {
                case TIFCompression.NONE:
                    result = "brak";
                    break;
                case TIFCompression.RLE:
                    result = "Rle";
                    break;
                case TIFCompression.CCITT3:
                    result = "CCITT3";
                    break;
                case TIFCompression.CCITT4:
                    result = "CCITT4";
                    break;
                case TIFCompression.LZW:
                    result = "LZW";
                    break;
            }
            return result;
        }

        public static string PrepearePath(string path) {
            string result = null;
            result = path.Trim();
            result = result.Trim('\"');
            result = result.Trim('\'');
            return result;
        }
        public static string GetContainingFolder(string path) {
            string result = null;
            path = PrepearePath(path);
            int char_to_remove = 0;
            for(int i = path.Length-1; i >= 0; i--) {
                if (path.ElementAt(i) == '\\') {
                    break;
                } else {
                    char_to_remove++;
                }
            }
            for(int i = 0; i<(path.Length-char_to_remove-1); i++) {
                result += path.ElementAt(i);
            }
            return result;
        }
        public static string GetFileNameFromPath(string path) {
            string result = null;
            path = PrepearePath(path);
            for (int i = path.Length-1; i >= 0; i--) {
                if (path.ElementAt(i) == '\\') {
                    break;
                } else {
                    result += path.ElementAt(i);
                }
            }
            result = RotateString(result);
            result = CutFileExtension(result);
            return result;
        }
        public static string CutFileExtension(string file_name) {
            string result = null;
            for(int i=0; i<file_name.Length; i++) {
                if (file_name.ElementAt(i) == '.') {
                    break;
                } else {
                    result += file_name.ElementAt(i);
                }
            }
            return result;
        }
    }
}
