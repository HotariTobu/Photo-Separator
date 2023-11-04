using MetadataExtractor;
using MetadataExtractor.Formats.Exif;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Photo_Separator
{
    // NuGet で MetadataExtractor を追加してください 
    public class PhotoData
    {
        /// <summary>
        /// 撮影日時
        /// </summary>
        public DateTime Date { get; set; } = new DateTime(0);
        private string[] dateTimeFormats = { "yyyy:MM:dd HH:mm:ss.fff", "yyyy:MM:dd HH:mm:ss" };

        /// <summary>
        /// 値が設定されているか
        /// </summary>
        /// <param name="obj">PhotoDataクラスのプロパティ</param>
        /// <returns>値が設定されていれば true</returns>
        public static bool HasValue(Object obj)
        {
            Type type = obj.GetType();
            if (type == typeof(DateTime))
            {
                return ((DateTime)obj) != new DateTime(0);
            } else if (type == typeof(string))
            {
                return !string.IsNullOrEmpty((string)obj);
            } else if(type == typeof(double))
            {
                return ((double)obj) != double.MinValue;
            }
            return false;
        }

        public PhotoData() { }
        public PhotoData(string filename)
        {
            try
            {
                IEnumerable<Directory> directories = ImageMetadataReader.ReadMetadata(filename);
                Parse(directories);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void Parse(IEnumerable<Directory> directories)
        {
            try
            {
                // 日付・時刻
                var subIfdDirectory = directories.OfType<ExifSubIfdDirectory>().FirstOrDefault();
                var ifdo = directories.OfType<ExifIfd0Directory>().FirstOrDefault();
                var dateTime = subIfdDirectory?.GetDescription(ExifDirectoryBase.TagDateTimeOriginal);

                if (dateTime == null)
                {
                    dateTime = ifdo?.GetDescription(ExifDirectoryBase.TagDateTimeOriginal);
                }
                // .mov / .mp4 の場合
                if (dateTime == null)
                {
                    var str = GetString(directories, "QuickTime Movie Header", "Created");
                    if (str != null)
                    {
                        var utc = DateTime.ParseExact(str.Substring(str.IndexOf(" ") + 1),
                            "M d HH:mm:ss yyyy",
                            System.Globalization.DateTimeFormatInfo.InvariantInfo,
                            System.Globalization.DateTimeStyles.None);
                        var local = TimeZoneInfo.ConvertTimeFromUtc(utc, TimeZoneInfo.Local);

                        dateTime = local.ToString("yyyy:MM:dd HH:mm:ss");
                    }
                }
                if (dateTime != null)
                {
                    Date = DateTime.ParseExact(dateTime,
                        dateTimeFormats,
                        System.Globalization.DateTimeFormatInfo.InvariantInfo,
                        System.Globalization.DateTimeStyles.None);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private string GetString(IEnumerable<Directory> directories, string directoryName, string tag)
        {
            var dir = directories.Where(x => x.Name == directoryName).FirstOrDefault();
            var str= dir?.Tags.Where(x => x.Name == tag).FirstOrDefault()?.Description;
            return str;
        }
    }
}
