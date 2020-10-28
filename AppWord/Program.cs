using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Word = Microsoft.Office.Interop.Word; // добавили пространство имен для использования объектной модели Word
using Microsoft.Win32; //Для проверки установки Word на компьютере

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
        /// <summary>
        /// Блок глобальных переменных для работы приложения с Word
        /// </summary>
        
        static Word.Application wordapp;
        /// содержит ссылку на объект программы в исходнике было написано private, заменил на static т.к. ругался компилятор
        static Word.Documents worddocuments;
        ///содержит ссылку на объект список документов
        static Word.Document worddocument;
        ///содержит ссылку на объект документ
        static Word.Paragraphs wordparagraphs;
        ///содержит ссылку на объект списка параграфов
        static Word.Paragraph wordparagraph;
        ///содержит ссылку на объект параграфов
        
        /// Глобальные объекты для работы со свойствми и методами пространства имен Word
        Object missingObj = System.Reflection.Missing.Value;
        /// содержит ссылку на специальный объект задающий значения по умолчанию
        Object trueObj = true;
        /// cодержит объект переменную указывающую на истинность значения
        Object falseObj = false;
        /// cодержит объект переменную указывающую на ложность значения

        /// Глобальные переменные для работы метода Move и перемещение курсора
        /// пока как показала практика как глобальная переменная не работает
        /// object unit;
        /// содержит информацию о 
        /// object extend;
        /// содержит информацию о 



        static void Main(string[] args)
        {
            Console.WriteLine("Выберите опцию для работы:");
            Console.WriteLine("1 - проверка установки Word на компьютере");
            Console.WriteLine("2 - запуск экземпляра Word");
            Console.WriteLine("3 - запуск экземпляра Word с открытием шаблона");
            Console.WriteLine("0 - Выход");
            string vvod = Console.ReadLine();
            int v = Convert.ToInt32(vvod);
            switch (v)
            {
                case 1: IsInstallWord(); break;
                case 2: StartAppWord(); break;
                case 3: StartAppWordTemplate(); break;
                case 0: wordapp.Activate(); break; // после выхода из программы принудительно активируем Word чтобы он оставался видимым
                default: break;
            }
        }


        /// <summary>
        /// Метод проверки наличия Word на компьютере в случае отсутствия его на компьютере
        /// возвращает false, иначе true
        /// вметод не передается никаких аргументов
        /// </summary>
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
        /// Тестовый метод запускает Word и открывает в нем указанный шаблон
        /// на данный момент шаблон прописан в самом методе в перспективе
        /// он будет передаваться в метод
        /// </summary>
        private static void StartAppWordTemplate()
        {
            #region MyRegion Запуск Word с созданием документа из заданного шаблона
            Console.WriteLine("Запускаем Word!");
            try
            {
                //Создаем объект Word - равносильно запуску Word
                wordapp = new Word.Application();
                //Делаем его видимым
                wordapp.Visible = true;
                // Создаем документы
                Object template = Type.Missing;
                Object newTemplate = false;
                Object documentType = Word.WdNewDocumentType.wdNewBlankDocument;
                Object visible = true;
                //Меняем шаблон
                template = @"D:\a1.docx";
                //Создаем документ worddocument в данном случае создаваемый объект 
                worddocument = wordapp.Documents.Add(ref template, ref newTemplate, ref documentType, ref visible);
            }
            catch (Exception ex)
            {
                string Text = ex.Message;
                Console.WriteLine(Text);
            }
            #endregion

            Console.ReadKey();
        }

        /// <summary>
        /// Метод запуска Word с использованием стандартного шаблона Normal.dot
        /// метод не получает никаких аргументов но возвращает указатель на объект
        /// приложения Word для дальнейшей работы
        /// </summary>
        private static void StartAppWord()
        {
            #region MyRegion Запуск Word с созданием документа по стандартному шаблону
            Console.WriteLine("Запускаем Word!");
            try
            {
                //Создаем объект Word - равносильно запуску Word
                wordapp = new Word.Application();
                //Делаем его видимым
                wordapp.Visible = true;
                // Создаем документы
                Object template = Type.Missing;
                Object newTemplate = false;
                Object documentType = Word.WdNewDocumentType.wdNewBlankDocument;
                Object visible = true;
                //Создаем документ
                wordapp.Documents.Add(ref template, ref newTemplate, ref documentType, ref visible);
                worddocuments = wordapp.Documents;
                // получаем указатель на активный документ
                worddocument = wordapp.ActiveDocument;

                // создаем несколько параграфов Используйте этот экземпляр Missing класса для представления отсутствующих значений, 
                // например при вызове методов, имеющих значения параметров по умолчанию.
                object oMissing = System.Reflection.Missing.Value;
                AppWordAddParagraph(10, ref oMissing);
                // получаем указатель на список параграфов
                wordparagraphs = worddocument.Paragraphs;

                // здесь будем создавать раздел в документе содержащий таблицу таксационных характеристик
                // добавляем заголовок таблицы
                // получаем указатель на 1 параграф
                wordparagraph = (Word.Paragraph)wordparagraphs[1];
                wordparagraph.Range.Font.Color = Word.WdColor.wdColorBlack;
                wordparagraph.Range.Font.Size = 14;
                wordparagraph.Range.Font.Name = "Arial";
                wordparagraph.Range.Font.Italic = 1;
                wordparagraph.Range.Font.Bold = 1;
                // записываем в параграф значение текста
                wordparagraph.Range.Text = "Ведомость таксационных характеристик зеленых насаждений";
                // Добавляем таблицу С указанием параграфа и положения таблицы в строке параграфа
                #region Вставка таблицы в заданный параграф и положению с строке
                Word.Table wordtable = AppWordAddTable(7, 10, 2);
                #endregion
                // Добавляем заголовок таблицы
                Word.Range wordcellrange = worddocument.Tables[1].Cell(1, 1).Range;
                wordcellrange.Text = "№ п/п";
                wordcellrange = worddocument.Tables[1].Cell(1, 2).Range;
                wordcellrange.Text = "Наиманование";
                wordcellrange = worddocument.Tables[1].Cell(1, 3).Range;
                wordcellrange.Text = "Количество";
                wordcellrange = worddocument.Tables[1].Cell(1, 4).Range;
                wordcellrange.Text = "Диаметр";
                wordcellrange = worddocument.Tables[1].Cell(1, 5).Range;
                wordcellrange.Text = "Высота";
                wordcellrange = worddocument.Tables[1].Cell(1, 6).Range;
                wordcellrange.Text = "Характеристика";
                wordcellrange = worddocument.Tables[1].Cell(1, 7).Range;
                wordcellrange.Text = "Примечание";
                // Следующий этап универсальной команды в которую передаются данные по заголовку таблицы и ее наполнению
                // Добавим еще одну таблицу в конец листа
                // установка положения курсора в конец текста
                object unit = Word.WdUnits.wdStory;
                object extend = Word.WdMovementType.wdMove;
                wordapp.Selection.EndKey(ref unit, ref extend);
               
                // заполнение шапки будем делать в цикле, в цикл передается список с содежимым
                List<string> shList = new List<string>()
                {
                    "Номер по плану", "Наименование породы", "Кол-во, шт.", "Высота, м", "Диаметр ствола, см",
                    "Возраст, лет", "Декоративные качества", "Примечание"
                };
                // получаем колличество элементов в списке
                var listCount = shList.Count();
                AppWordAddTable(listCount, 10, wordparagraphs.Count);
                // запускаем цикл заполнения шапки таблицы
                for (var i = 0; i < listCount; i++)
                {
                    wordcellrange = worddocument.Tables[2].Cell(1, i+1).Range;
                    wordcellrange.Font.Size = 12;
                    wordcellrange.Font.Bold = 1;
                    wordcellrange.Font.Italic = 1;
                    wordcellrange.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                    wordcellrange.Text = shList[i];
                }


                //// определяем количество паргарфов в текущем документе и записываем его в переменную text
                //string text = Convert.ToString(wordparagraphs.Count);
                //// получаем указатель на параграф
                //wordparagraph = (Word.Paragraph)wordparagraphs[5];
                //// записываем в параграф значение текста
                //wordparagraph.Range.Text = text;
                //// меняем параметры текста и параграфа
                //// устанавливаем значение цвета параграфа
                //wordparagraph.Range.Font.Color = Word.WdColor.wdColorBlue;
                //// устанавливаем значение размера шрифта
                //wordparagraph.Range.Font.Size = 20;
                //// устанавливаем значение шрифта
                //wordparagraph.Range.Font.Name = "Arial";
                //// устанавливаем значение написания шрифта
                //// наклон шрифта
                //wordparagraph.Range.Font.Italic = 1;
                //// толщина шрифта
                //wordparagraph.Range.Font.Bold = 1;
                //// можно подчеркнуть
                //wordparagraph.Range.Font.Underline = Word.WdUnderline.wdUnderlineSingle;
                //// цвет линии подчеркивания
                //wordparagraph.Range.Font.UnderlineColor = Word.WdColor.wdColorDarkRed;
                //// можно перечеркнуть
                //wordparagraph.Range.Font.StrikeThrough=1; 

                // Добавляем разрыв страницу


                object count;
                
                
                // установка положения курсора
                extend = Word.WdMovementType.wdMove;
                wordapp.Selection.EndKey(ref unit, ref extend);
                object oType;
                // вставка разрыва раздела
                //oType = Word.WdBreakType.wdSectionBreakNextPage;
                // вставка разрыва страницы
                oType = Word.WdBreakType.wdPageBreak;
                //И на новый лист
                wordapp.Selection.InsertBreak(ref oType);

                // Добавляем заголовок
                //wordparagraph = (Word.Paragraph)wordparagraphs[1];
                //wordparagraph.Range.Font.Color = Word.WdColor.wdColorBlack;
                //wordparagraph.Range.Font.Size = 14;
                //wordparagraph.Range.Font.Name = "Arial";
                //wordparagraph.Range.Font.Italic = 1;
                //wordparagraph.Range.Font.Bold = 1;
                //wordparagraph.Range.Text = "Ведомость таксационных характеристик зеленых насаждений";

                

                // переводим курсор в начало документа
                unit = Word.WdUnits.wdStory;
                extend = Word.WdMovementType.wdMove;
                wordapp.Selection.HomeKey(ref unit, ref extend);

                // Методы перемещение курсора
                // переводим курсор на третий параграф
                unit = Word.WdUnits.wdParagraph;
                count = 2;
                wordapp.Selection.Move(ref unit, ref count);

            }
            catch (Exception ex)
            {
                string Text = ex.Message;
                Console.WriteLine(Text);
            } 
            #endregion

            Console.ReadKey();
        }

        /// <summary>
        /// Метод для создания заданного количества параграфов в документе
        /// в метод передаются значение количества создаваемых параграфов и их свойства
        /// </summary>
        /// <param name="n"></param>
        /// <param name="val"></param>
        
        private static void AppWordAddParagraph(int n, ref object val)
        {
            for (var i=1; i<n; i++)
            {
                worddocument.Paragraphs.Add(ref val);
            }
            
        }

        /// <summary>
        /// Метод добавления таблицы в документ Word
        /// в метод передается диапазон места вставки таблицы и количество колонок и рядов в таблице
        /// </summary>
        /// <returns>Возвращает указатель на таблицу</returns>
        private static Word.Table AppWordAddTable(int columns, int rows, int pharagraph)
        {
            // получаем ссылку на параграф
            wordparagraph = worddocument.Paragraphs[pharagraph];
            // задаем положение таблицы в тексте
            int start = 10;
            int end = 11;
            // Получаем объект Range
            Word.Range wordrange = wordparagraph.Range;
            wordparagraph.Range.SetRange(start, end);
            // создаем вспомогательные объекты для создания таблицы
            Object defaultTableBehavior = Word.WdDefaultTableBehavior.wdWord9TableBehavior;
            Object autoFitBehavior = Word.WdAutoFitBehavior.wdAutoFitWindow;
            //Добавляем таблицу и получаем объект wordtable 
            return worddocument.Tables.Add(wordrange, rows, columns, ref defaultTableBehavior, ref autoFitBehavior);
        }
    }

}
