using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Обработчик события TextChanged для InputBox
        private void InputBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (ResultText != null) // Проверка на null
            {
                ResultText.Text = $"Вы ввели: {InputBox.Text}";
            }
        }

        // Обработчик события Click для кнопки "Преобразовать"
        private void ConvertButton_Click(object sender, RoutedEventArgs e)
        {
            if (ResultText != null) // Проверка на null
            {
                string input = InputBox.Text;
                ResultText.Text = $"Вы нажали кнопку. Введённые данные: {input}";
            }
        }

        // Остальные методы для выполнения задач
        private void BasicConversion_Click(object sender, RoutedEventArgs e)
        {
            if (ResultText != null) // Проверка на null
            {
                int intValue = 42;
                double doubleValue = 3.14;
                bool boolValue = true;
                DateTime dateValue = DateTime.Now;

                ResultText.Text = $"int: {intValue}\ndouble: {doubleValue}\nbool: {boolValue}\ndate: {dateValue}";
            }
        }

        private void ConvertToString_Click(object sender, RoutedEventArgs e)
        {
            int intValue = 42;
            bool boolValue = true;

            string intString1 = intValue.ToString();
            string intString2 = Convert.ToString(intValue);

            string boolString1 = boolValue.ToString();
            string boolString2 = Convert.ToString(boolValue);

            ResultText.Text = $"int.ToString() == Convert.ToString: {intString1 == intString2}\n" +
                             $"bool.ToString() == Convert.ToString: {boolString1 == boolString2}";
        }

        private void HandleNull_Click(object sender, RoutedEventArgs e)
        {
            object obj = null;
            string result = Convert.ToString(obj) ?? "значение отсутствует";
            ResultText.Text = result;
        }

        private void AsciiConversion_Click(object sender, RoutedEventArgs e)
        {
            byte[] byteArray = { 72, 101, 108, 108, 111 }; // ASCII коды для "Hello"
            string asciiString = Encoding.ASCII.GetString(byteArray);
            ResultText.Text = asciiString;
        }

        private void HexConversion_Click(object sender, RoutedEventArgs e)
        {
            byte[] byteArray = { 0x4A, 0x6F, 0x6E, 0x61, 0x74, 0x68, 0x61, 0x6E };
            string hexString = BitConverter.ToString(byteArray).Replace("-", "");
            ResultText.Text = hexString;
        }

        private void IntParse_Click(object sender, RoutedEventArgs e)
        {
            string input = InputBox.Text;

            try
            {
                int number = int.Parse(input);
                ResultText.Text = $"Вы ввели число: {number}";
            }
            catch (FormatException)
            {
                ResultText.Text = "Неверный формат числа.";
            }
        }

        private void TryParse_Click(object sender, RoutedEventArgs e)
        {
            string input = InputBox.Text;

            if (int.TryParse(input, out int parsedNumber))
            {
                ResultText.Text = $"Вы ввели число: {parsedNumber}";
            }
            else
            {
                ResultText.Text = "Неверный формат числа.";
            }
        }

        private void DateTimeParse_Click(object sender, RoutedEventArgs e)
        {
            string input = InputBox.Text;

            try
            {
                DateTime date = DateTime.ParseExact(input, "dd.MM.yyyy", null);
                ResultText.Text = $"Вы ввели дату: {date.ToShortDateString()}";
            }
            catch (FormatException)
            {
                ResultText.Text = "Неверный формат даты.";
            }
        }

        private void ConvertToDouble_Click(object sender, RoutedEventArgs e)
        {
            string input = InputBox.Text;

            try
            {
                double doubleNumber = Convert.ToDouble(input);
                ResultText.Text = $"Вы ввели число: {doubleNumber}";
            }
            catch (FormatException)
            {
                ResultText.Text = "Неверный формат числа.";
            }
            catch (OverflowException)
            {
                ResultText.Text = "Число слишком большое или слишком маленькое.";
            }
        }

        private void FormattedOutput_Click(object sender, RoutedEventArgs e)
        {
            double numberToFormat = 1234.5678;
            string formattedCurrency = numberToFormat.ToString("C2"); // Формат валюты
            string formattedFixedPoint = numberToFormat.ToString("F2"); // Фиксированное число знаков после запятой
            ResultText.Text = $"Формат валюты: {formattedCurrency}\nФиксированная точка: {formattedFixedPoint}";
        }

        private void BoolConversion_Click(object sender, RoutedEventArgs e)
        {
            bool boolValueToConvert = true;
            string boolString = boolValueToConvert.ToString();
            bool parsedBool = bool.Parse(boolString);
            ResultText.Text = $"Булевое значение: {boolString}\nОбратное преобразование: {parsedBool}";
        }

        private void CustomObjectToString_Click(object sender, RoutedEventArgs e)
        {
            Person person = new Person { Name = "Иван", Age = 30 };
            ResultText.Text = person.ToString();
        }

        private void PrecisionLoss_Click(object sender, RoutedEventArgs e)
        {
            double originalValue = 123.4567890123456789;
            string stringValue = originalValue.ToString();
            double convertedValue = double.Parse(stringValue);

            ResultText.Text = $"Оригинальное значение: {originalValue}\nПреобразованное значение: {convertedValue}\nПотеря точности: {originalValue != convertedValue}";
        }

        private void OverflowCheck_Click(object sender, RoutedEventArgs e)
        {
            int maxInt = int.MaxValue;

            try
            {
                checked
                {
                    int result = maxInt + 1;
                    ResultText.Text = result.ToString();
                }
            }
            catch (OverflowException ex)
            {
                ResultText.Text = $"Ошибка переполнения: {ex.Message}";
            }
        }

        private void ComplexTask_Click(object sender, RoutedEventArgs e)
        {
            string input = InputBox.Text;

            if (int.TryParse(input, out int intResult))
            {
                ResultText.Text = $"Вы ввели целое число: {intResult}";
            }
            else if (double.TryParse(input, out double doubleResult))
            {
                ResultText.Text = $"Вы ввели число с плавающей запятой: {doubleResult}";
            }
            else if (DateTime.TryParseExact(input, "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime dateResult))
            {
                ResultText.Text = $"Вы ввели дату: {dateResult.ToShortDateString()}";
            }
            else
            {
                ResultText.Text = "Не удалось определить тип введённых данных.";
            }
        }
    }

    // Класс для примера преобразования пользовательского объекта в строку
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return $"Имя: {Name}, Возраст: {Age}";
        }
    }
}