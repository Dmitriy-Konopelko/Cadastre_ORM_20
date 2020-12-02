using System;
using System.IO;
using System.Text;

namespace AppLogging
{
    public class LogerService
    {
        private static string CurrentDay = DateTime.Now.ToShortDateString();
        // переменная содержащая информацию о текущей дате
        private static string CurrentCatalog = AppDomain.CurrentDomain.BaseDirectory.ToString();
        // переменная содержащая информацию о текущем каталоге
        private static string LoggCatalog = CurrentCatalog + "\\Журнал\\";
        // переменная содержащая информацию о каталоге в который будет вестись журнал

        /// <summary>
        /// Асинхронный метод записи информации в файл. В метод передается строка для записи
        /// Возвращаемого значения нет
        /// </summary>
        /// <param name="str"></param>
        public static async void ReadWriteAsync(string str)
        {
            // создаем каталог для журналирования
            DirectoryInfo dirInfo = new DirectoryInfo(LoggCatalog);
            // проверяем наличие каталога журналирования
            if (!dirInfo.Exists)
            {
                // если он не существует то создаем его
                dirInfo.Create();
            }
            // создаем строку содержащую путь и имя файла журналирования, для каждого нового дня это будет отдельный файл
            string FileName = LoggCatalog + "Журнал работы программы - " + CurrentDay + ".txt";
            // записываем информацию в файл
            using (StreamWriter writer = new StreamWriter(FileName, true, Encoding.Unicode))
            {
                await writer.WriteLineAsync(DateTime.Now.ToShortTimeString() + " : " + str);  // асинхронная запись в файл
            }
        }
    }
}
