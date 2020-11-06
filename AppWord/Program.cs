using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Word = Microsoft.Office.Interop.Word; // добавили пространство имен для использования объектной модели Word
using Microsoft.Win32; //Для проверки установки Word на компьютере
using System.Windows;

namespace AppWord
{
    /// <summary>
    /// Приложение (библиотека) для работы с Microsoft Word
    /// часть исходников взята с http://wladm.narod.ru/C_Sharp/comword.html
    /// часть http://nullpro.info/2012/rabotaem-s-ms-word-iz-c-chast-1-otkryvaem-shablon-ishhem-tekst-vnutri-dokumenta/
    /// часть написана самостоятельно
    /// </summary>
    
    class Program
    {
        ///==================
        /// Блок глобальных переменных для работы приложения с Word
        ///==================
        /// 
        static Word.Application wordapp;
        // содержит ссылку на объект программы в исходнике было написано private, заменил на static т.к. ругался компилятор
        static Word.Documents worddocuments;
        //содержит ссылку на объект список документов
        static Word.Document worddocument;
        //содержит ссылку на объект документ
        static Word.Paragraphs wordparagraphs;
        //содержит ссылку на объект списка параграфов
        static Word.Paragraph wordparagraph;
        //содержит ссылку на объект параграфов
        private static Word.Range wordcellrange;
        // данная переменная содержит информацию о выбранном диапазоне ячеек

        ///===================
        /// Глобальные объекты для работы со свойствми и методами пространства имен Word
        ///===================
        /// 
        object missingObj = System.Reflection.Missing.Value;
        // содержит ссылку на специальный объект задающий значения по умолчанию
        object trueObj = true;
        // cодержит объект переменную указывающую на истинность значения
        object falseObj = false;
        // cодержит объект переменную указывающую на ложность значения
        static object oMissing = System.Reflection.Missing.Value;
        // содержит объект переменную указывающую на значение по умолчанию

        /// Глобальные переменные для работы метода Move и перемещение курсора
        /// пока как показала практика как глобальная переменная не работает
        /// object unit;
        /// содержит информацию о 
        /// object extend;
        /// содержит информацию о

        // создаем необходимые переменные для тестирования программы
        // Данные для заполнения шапок таблиц
        // Ведомость существующих зеленых насаждений
        static List<string> shList = new List<string>()
        {
            "Номер по плану", "Наименование породы", "Кол-во, шт.", "Высота, м", "Диаметр ствола, см",
            "Возраст, лет", "Декоративные качества", "Примечание"
        };

        // Ведомость пересаживаемых зеленых насаждений
        static List<string> prList = new List<string>()
        {
            "Номер по плану", "Наименование породы", "Кол-во, шт.", "Высота, м", "Диаметр ствола, см",
            "Декоративные качества", "Размер кома, м"
        };

        // Ведомости вырубаемых зеленых насаждений
        static List<string> vrList = new List<string>()
        {
            "Номер по плану", "Наименование породы", "Кол-во, шт.", "Высота, м", "Диаметр ствола, см",
            "Декоративные качества", "Компенсационные посадки"
        };



        static void Main(string[] args)
        {
            // создаем следующую последовательность работы:
            // - проверяем установлен ли ворд на компьютере если установлен то продолжаем работу если нет то выводим сообщение о ошибке
            // - запускаем ворд создаем документ и получаем ссылку на запущенное приложение
            // - добавляем в документ заданное количество параграфов
            // - добавляем в документ таблицу ведомости таксационных характеристик зеленых насаждений
            // - добавляем в документ таблицу ведомости удаляемых зеленых насаждений
            // - добавляем в документ таблицу ведомости пересаживаемых зеленых насаждений
            // - добавляем в документ таблицу ведомости баланса зеленых насаждений
            int b = 100;
            do
            {
                Console.WriteLine("Выберите опцию для работы:");
                Console.WriteLine("1 - проверка установки Word на компьютере");
                Console.WriteLine("2 - запуск экземпляра Word с созданием пустого документа");
                Console.WriteLine("3 - добавление в открытый документ таблицы таксационных характеристик");
                Console.WriteLine("4 - добавление в открытый документ таблицы удаляемых зеленых насаждений");
                Console.WriteLine("5 - добавление в открытый документ таблицы пересаживаемых зеленых насаждений");
                Console.WriteLine("6 - добавление в открытый документ таблицы баланса зеленых насаждений");
                Console.WriteLine("0 - Выход");
                string vvod = Console.ReadLine();
                int v = Convert.ToInt32(vvod);
                object pathTemplate = "";
                switch (v)
                {
                    case 1: IsInstallWord(); break;
                    case 2: StartApplicationWord(pathTemplate); break;
                    case 3: WordDocAddTablePlantProperties(shList); break;
                    case 4: WordDocAddTablePlantDelete(vrList); break;
                    case 5: WordDocAddTablePlantTransplantation(prList); break;
                    case 6: WordDocAddTablePlantBalans(); break;
                    case 0: b = 0; break; // после выхода из программы принудительно активируем Word чтобы он оставался видимым
                    default: break;
                }
            } while (b > 0);
            //var i = wordapp.Documents;
            //if (i != null)
            //    return;
            //wordapp.Activate();
        }

        /// <summary>
        /// Метод проверки наличия Word на компьютере в метод не передается никаких аргументов
        /// </summary>
        /// <returns>в случае отсутствия его на компьютере возвращает false, иначе true</returns>

        private static bool IsInstallWord()
        {
            using (var regWord = Registry.ClassesRoot.OpenSubKey("Word.Application"))
            {
                if (regWord == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        /// <summary>
        /// Метод запускает Word с созданием документа и добавлением двух параграфов
        /// в качестве аргумента передается путь шаблона по которому необходимо создать документ
        /// или null если необходимо создать документ с шаблоном по умолчанию 
        /// </summary>
        /// <remarks>pathTemplate - переменная типа Object содержащая путь к нужному шаблону</remarks>
        /// <returns>Возвращает указатель на запущенное приложение Word или null</returns>

        private static Word.Application StartApplicationWord(object pathTemplate)
        {
            try
            {
                //Создаем объект Word - равносильно запуску Word
                wordapp = new Word.Application
                {
                    //Делаем его видимым
                    Visible = true
                };
                // Создаем необходимые параметры для создания документа
                object newTemplate = false;
                object documentType = Word.WdNewDocumentType.wdNewBlankDocument;
                object visible = true;

                // Создаем документ
                worddocument = wordapp.Documents.Add(ref pathTemplate, ref newTemplate, ref documentType, ref visible);
                // создаем минимальное количество параграфов
                AppWordAddParagraph(3, ref oMissing);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                wordapp = null;
            }
            return wordapp;
        }

        /// <summary>
        /// Метод для создания заданного количества параграфов в документе
        /// в метод передаются значение количества создаваемых параграфов и их свойства
        /// n - колличество параграфов
        /// val - переменная типа object для значений по умолчанию
        /// например oMissing = System.Reflection.Missing.Value;
        /// </summary>
        /// <returns>Ничего</returns>

        private static void AppWordAddParagraph(int n, ref object val)
        {
            for (var i = 1; i < n; i++)
            {
                worddocument.Paragraphs.Add(ref val);
            }

        }

        /// <summary>
        /// Метод добавления таблицы в документ Word в метод передается 
        /// диапазон места вставки таблицы и количество колонок и рядов в таблице и ее название и шапка таблицы
        /// </summary>
        /// <returns>Возвращает указатель на таблицу</returns>

        private static Word.Table AppWordAddTable(int columns, int rows, int pharagraph, List<string> shList)
        {
            // получаем ссылку на параграф надо проверять необходимость этого действия
            wordparagraph = worddocument.Paragraphs[pharagraph];
            // задаем положение таблицы в тексте
            int start = pharagraph;
            int end = pharagraph;
            // Получаем объект Range
            wordparagraph.Range.SetRange(start, end);
            Word.Range wordrange = wordparagraph.Range;
            // создаем вспомогательные объекты для создания таблицы
            object defaultTableBehavior = Word.WdDefaultTableBehavior.wdWord9TableBehavior;
            object autoFitBehavior = Word.WdAutoFitBehavior.wdAutoFitWindow;
            //Добавляем таблицу и получаем объект table
            var table = worddocument.Tables.Add(wordrange, rows, columns, ref defaultTableBehavior, ref autoFitBehavior);
            // запускаем настройки таблицы
            table.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
            // заполняем шапку таблицы
            for (var i = 0; i < shList.Count; i++)
            {
                table.Cell(1, i + 1).Range.Font.Size = 12;
                table.Cell(1, i + 1).Range.Font.Bold = 1;
                table.Cell(1, i + 1).Range.Font.Italic = 1;
                table.Cell(1, i + 1).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                table.Cell(1, i + 1).Range.Text = shList[i];
            }
            return table;
        }

        /// <summary>
        /// метод добавления в ранее созданный документ таблицы таксационных характеристик зеленных насаждений
        /// в метод передается шапка таблицы и список зеленых насаждений с характеристиками
        /// </summary>
        /// <returns>Ничего</returns>

        private static void WordDocAddTablePlantProperties(List<string> shList)
        {
            // добавляем заголовок таблицы
            // получаем указатель на 1 параграф
            wordparagraph = worddocument.Paragraphs[1];
            wordparagraph.Range.Font.Color = Word.WdColor.wdColorBlack;
            wordparagraph.Range.Font.Size = 14;
            wordparagraph.Range.Font.Name = "Arial";
            wordparagraph.Range.Font.Italic = 1;
            wordparagraph.Range.Font.Bold = 1;
            // записываем в параграф значение текста
            wordparagraph.Range.Text = "Ведомость таксационных характеристик зеленых насаждений";
            // создаем таблицу исходя из переданных параметров
            var wTableAllPlant = AppWordAddTable(shList.Count, 10, 2, shList);
        }

        /// <summary>
        /// метод добавления в ранее созданный документ таблицы удаляемых зеленых насаждений
        /// в метод передается шапка таблицы и список зеленых насаждений с характеристиками
        /// </summary>
        /// <returns>Ничего</returns>

        private static void WordDocAddTablePlantDelete(List<string> vrList)
        {
            // добавляем заголовок таблицы
            // получаем указатель на 1 параграф
            wordparagraph = worddocument.Paragraphs[1];
            wordparagraph.Range.Font.Color = Word.WdColor.wdColorBlack;
            wordparagraph.Range.Font.Size = 14;
            wordparagraph.Range.Font.Name = "Arial";
            wordparagraph.Range.Font.Italic = 1;
            wordparagraph.Range.Font.Bold = 1;
            // записываем в параграф значение текста
            wordparagraph.Range.Text = "Ведомость удаляемых зеленых насаждений";
            // создаем таблицу исходя из переданных параметров
            var wTableAllPlant = AppWordAddTable(vrList.Count, 10, 2, vrList);
        }

        /// <summary>
        /// метод добавления в ранее созданный документ таблицы пересаживаемых зеленых насаждений
        /// в метод передается шапка таблицы и список зеленых насаждений с характеристиками
        /// </summary>
        /// <returns>Ничего</returns>

        private static void WordDocAddTablePlantTransplantation(List<string> prList)
        {
            // добавляем заголовок таблицы
            // получаем указатель на 1 параграф
            wordparagraph = worddocument.Paragraphs[1];
            wordparagraph.Range.Font.Color = Word.WdColor.wdColorBlack;
            wordparagraph.Range.Font.Size = 14;
            wordparagraph.Range.Font.Name = "Arial";
            wordparagraph.Range.Font.Italic = 1;
            wordparagraph.Range.Font.Bold = 1;
            // записываем в параграф значение текста
            wordparagraph.Range.Text = "Ведомость пересаживаемых зеленых насаждений";
            // создаем таблицу исходя из переданных параметров
            var wTableAllPlant = AppWordAddTable(prList.Count, 10, 2, prList);
        }

        /// <summary>
        /// метод добавления в ранее созданный документ таблицы баланса зеленых насаждений
        /// в метод передается список с данными о балансе зеленых насаждений
        /// </summary>
        /// <returns>Ничего</returns>

        private static void WordDocAddTablePlantBalans()
        {
            // добавляем заголовок таблицы
            // получаем указатель на 1 параграф
            wordparagraph = worddocument.Paragraphs[1];
            wordparagraph.Range.Font.Color = Word.WdColor.wdColorBlack;
            wordparagraph.Range.Font.Size = 14;
            wordparagraph.Range.Font.Name = "Arial";
            wordparagraph.Range.Font.Italic = 1;
            wordparagraph.Range.Font.Bold = 1;
            // записываем в параграф значение текста
            wordparagraph.Range.Text = "Ведомость баланса зеленых насаждений";
            // получаем ссылку на параграф надо проверять необходимость этого действия
            wordparagraph = worddocument.Paragraphs[2];
            // задаем положение таблицы в тексте
            int start = 2;
            int end = 2;
            // Получаем объект Range
            wordparagraph.Range.SetRange(start, end);
            Word.Range wordrange = wordparagraph.Range;
            // создаем вспомогательные объекты для создания таблицы
            object defaultTableBehavior = Word.WdDefaultTableBehavior.wdWord9TableBehavior;
            object autoFitBehavior = Word.WdAutoFitBehavior.wdAutoFitWindow;
            // создаем таблицу баланса
            var wTableBalans = worddocument.Tables.Add(wordrange, 7, 8, ref defaultTableBehavior, ref autoFitBehavior);
            // объединяем и заполняем ячейки шапки таблицы
            // объединяем ячейки для поля Проектные предложения
            object begCell = wTableBalans.Cell(1, 1).Range.Start;
            object endCell = wTableBalans.Cell(3, 1).Range.End;
            wordcellrange = worddocument.Range(ref begCell, ref endCell);
            wordcellrange.Select();
            wordapp.Selection.Cells.Merge();
            wTableBalans.Cell(1, 1).Range.Text = "Проектные предложения";
            // объединяем ячейки для поля Деревья
            begCell = wTableBalans.Cell(1, 2).Range.Start;
            endCell = wTableBalans.Cell(1, 5).Range.End;
            wordcellrange = worddocument.Range(ref begCell, ref endCell);
            wordcellrange.Select();
            wordapp.Selection.Cells.Merge();
            wTableBalans.Cell(1, 2).Range.Text = "Деревья";

            // объединяем ячейки для поля Всего
            begCell = wTableBalans.Cell(2, 2).Range.Start;
            endCell = wTableBalans.Cell(3, 2).Range.End;
            wordcellrange = worddocument.Range(ref begCell, ref endCell);
            wordcellrange.Select();
            wordapp.Selection.Cells.Merge();
            wTableBalans.Cell(2, 2).Range.Text = "Всего";

            // объединяем ячейки для поля В том числе
            begCell = wTableBalans.Cell(2, 3).Range.Start;
            endCell = wTableBalans.Cell(2, 5).Range.End;
            wordcellrange = worddocument.Range(ref begCell, ref endCell);
            wordcellrange.Select();
            wordapp.Selection.Cells.Merge();
            wTableBalans.Cell(2, 3).Range.Text = "в том числе";

            // объединяем ячейки для поля Кустарники
            begCell = wTableBalans.Cell(1, 3).Range.Start;
            endCell = wTableBalans.Cell(1, 5).Range.End;
            wordcellrange = worddocument.Range(ref begCell, ref endCell);
            wordcellrange.Select();
            wordapp.Selection.Cells.Merge();
            wTableBalans.Cell(1, 3).Range.Text = "Кустарники";

            // объединяем ячейки для поля Всего
            begCell = wTableBalans.Cell(2, 4).Range.Start;
            endCell = wTableBalans.Cell(3, 6).Range.End;
            wordcellrange = worddocument.Range(ref begCell, ref endCell);
            wordcellrange.Select();
            wordapp.Selection.Cells.Merge();
            wTableBalans.Cell(2, 4).Range.Text = "Всего";

            // объединяем ячейки для поля В том числе
            begCell = wTableBalans.Cell(2, 5).Range.Start;
            endCell = wTableBalans.Cell(2, 6).Range.End;
            wordcellrange = worddocument.Range(ref begCell, ref endCell);
            wordcellrange.Select();
            wordapp.Selection.Cells.Merge();
            wTableBalans.Cell(2, 5).Range.Text = "в том числе";

            // заполняем ячейку поля Сохраняемые
            wTableBalans.Cell(4, 1).Range.Text = "Сохраняемые";
            // заполняем ячейку поля Пересаживаемые
            wTableBalans.Cell(5, 1).Range.Text = "Пересживаемые";
            // заполняем ячейку поля Вырубаемые
            wTableBalans.Cell(6, 1).Range.Text = "Сохраняемые";
            // заполняем ячейку поля Итого
            wTableBalans.Cell(7, 1).Range.Text = "Итого";
            // заполняем ячейку поля Декративно-лиственные
            wTableBalans.Cell(3, 3).Range.Text = "Декративно-лиственные";
            // заполняем ячейку поля Плодовые
            wTableBalans.Cell(3, 4).Range.Text = "Плодовые";
            // заполняем ячейку поля Хвойные
            wTableBalans.Cell(3, 5).Range.Text = "Хвойные";
            // заполняем ячейку поля В группах
            wTableBalans.Cell(3, 7).Range.Text = "в группах";
            // заполняем ячейку поля В живой изгороди
            wTableBalans.Cell(3, 8).Range.Text = "в живой изгороди";
            //заполняем ячейки таблицы
        }
    }
}
