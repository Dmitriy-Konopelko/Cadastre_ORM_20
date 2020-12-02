using System;
using System.IO;
using System.Text;

namespace AppLogging
{
    public class LogerService
    {
        private static readonly string CurrentDay = DateTime.Now.ToShortDateString();
        // переменная содержащая информацию о текущей дате
        private static readonly string CurrentCatalog = AppDomain.CurrentDomain.BaseDirectory.ToString();
        // переменная содержащая информацию о текущем каталоге
        private static readonly string LoggCatalog = CurrentCatalog + "\\Журнал\\";
        // переменная содержащая информацию о каталоге в который будет вестись журнал

        /// <summary>
        /// <para>Асинхронный метод записи информации в файл журнала.</para>
        /// <para>Путь и имя журнала формируется автоматически в зависимости от места запуска приложения</para>
        /// <para>В метод передается строка для записи</para> 
        /// </summary>
        /// <param name="str"></param>
        /// /// <remarks>str - переменная типа String содержащая информацию для записи в журнал</remarks>
        /// <returns>Возвращаемого значения нет</returns>

        public static async void WriteLogAsync(string str)
        {
            // создаем каталог для журналирования
            var dirInfo = new DirectoryInfo(LoggCatalog);
            // проверяем наличие каталога журналирования
            if (!dirInfo.Exists)
            {
                // если он не существует то создаем его
                dirInfo.Create();
            }
            // создаем строку содержащую путь и имя файла журналирования, для каждого нового дня это будет отдельный файл
            var fileName = LoggCatalog + "Журнал работы программы - " + CurrentDay + ".txt";
            // записываем информацию в файл
            using (var writer = new StreamWriter(fileName, true, Encoding.Unicode))
            {
                await writer.WriteLineAsync(DateTime.Now.ToLongTimeString() + " : " + str);  // асинхронная запись в файл
            }
        }
    }
}
