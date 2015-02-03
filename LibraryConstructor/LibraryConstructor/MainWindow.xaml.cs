using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LibraryConstructor
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<ClassField> fieldsList = new List<ClassField>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem typeItem = (ComboBoxItem)HowManyFields.SelectedItem;
            string value = typeItem.Content.ToString();

            CreateItems(Convert.ToInt32(value));
            //MessageBox.Show(value);
        }

        public void CreateItems(int count) {
            int counter;
            if (fieldsList.Count == 0)
            {
                //add all new items
                counter = count;
                AddItems(counter);
            }
            else if (fieldsList.Count < count) {
                //add some additional items
                counter = count - fieldsList.Count;
                AddItems(counter);
            }
            else if (fieldsList.Count > count) {
                counter = fieldsList.Count - count;
                RemoveItems(counter);
            }

            UpdateView();
        }

        public void AddItems(int count) {
            for (int i = 0; i < count; i++)
            {
                ClassField newItem = new ClassField();
                fieldsList.Add(newItem);
            }
        }
        public void RemoveItems(int count)
        {
            if (fieldsList.Count >= count) {
                for (int i = 0; i < count; i++)
                {
                    fieldsList.RemoveAt(fieldsList.Count-1);
                }
            }
        }


        public void UpdateView()
        {
            int horisontalPoosition = 50;
            int verticalPosition = 0;

            ListWrapper.Children.Clear();

            for (int i = 0; i < fieldsList.Count; i++)
            {
                TextBox textBlock = new TextBox();
                ComboBox selectBox = new ComboBox();

                FillComboBox(selectBox);

                textBlock.Width = 90;
                textBlock.Text = fieldsList[i].name;
                textBlock.Tag = i;
                textBlock.Margin = new Thickness(0, verticalPosition, 0, 0);

                textBlock.KeyUp += textBlock_KeyUp;

                selectBox.Height = 22;
                selectBox.Width = 80;
                selectBox.Tag = i;

                selectBox.SelectionChanged += typeSelectBox_SelectionChanged;

                textBlock.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                textBlock.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                selectBox.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
                selectBox.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                selectBox.Margin = new Thickness(horisontalPoosition, verticalPosition, 0, 0);

                ListWrapper.Children.Add(textBlock);
                ListWrapper.Children.Add(selectBox);

                verticalPosition += 24;   
            }
            //ListWrapper
        }

        public void FillComboBox(ComboBox box)
        {
            ComboBoxItem intType = new ComboBoxItem();
            intType.Content = "int";
            ComboBoxItem stringType = new ComboBoxItem();
            stringType.Content = "string";
            ComboBoxItem boolType = new ComboBoxItem();
            boolType.Content = "bool";

            box.Items.Add(intType);
            box.Items.Add(stringType);
            box.Items.Add(boolType);
        }

        public void textBlock_KeyUp(object sender, RoutedEventArgs e)
        {
            TextBox block = (TextBox)sender;
            int index = Convert.ToInt32(block.Tag);
            //MessageBox.Show(index);
            fieldsList[index].name = block.Text;
        }

        public void typeSelectBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            ComboBox box = (ComboBox)sender;
            int index = Convert.ToInt32(box.Tag);
            ComboBoxItem item = (ComboBoxItem)box.SelectedItem;
            fieldsList[index].type = item.Content.ToString();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string classname = UserClassName.Text;
            
            // Динамическое создание Сборки с классом

            // создаем сборку
            // класс AssemblyName
            // затем AssemblyBilder - аоздает сборку

            AssemblyName an = new AssemblyName("MyAssembly");
            // версия сборки
            an.Version = new Version("1.0.0.1");

            //Конструируется сборка
            AssemblyBuilder ab = AppDomain.CurrentDomain.DefineDynamicAssembly(an, AssemblyBuilderAccess.RunAndSave);

            //создаем модуль для сборки черезх нашу сборку
            ModuleBuilder mb = ab.DefineDynamicModule("MyModule", "newLibrary.dll");

            //создаем тип для модуля
            TypeBuilder tb = mb.DefineType(classname, TypeAttributes.Public);

            //Так же создадим аргументы для конструктора
            Type[] parameters = {};

            //нужно наполнять тип, изч  чего будет состоять класс.
            //создадим конструктор и добавим туда код.
            ConstructorBuilder cb1 = tb.DefineConstructor(MethodAttributes.Public, CallingConventions.Standard, parameters);

            //Создадим поля для класса
            for (int i = 0; i < fieldsList.Count; i++)
            {
                string currFieldName = fieldsList[i].name;
                string currFieldType = fieldsList[i].type;
                switch (currFieldType)
                {
                    case "int":
                        tb.DefineField(currFieldName, typeof(int), FieldAttributes.Public);
                        break;
                    case "string":
                        tb.DefineField(currFieldName, typeof(string), FieldAttributes.Public);
                        break;
                    case "bool":
                        tb.DefineField(currFieldName, typeof(bool), FieldAttributes.Public);
                        break;
                    default:
                        break;
                }
            }

            //Добавим код в констурктор через IL генератор
            ILGenerator il1 = cb1.GetILGenerator();
            il1.EmitWriteLine("этот текст отобразится в консоли при создании экземпляра класса");

            //Ldarg(вызов аргументов) - получили первый параметр.
            il1.Emit(OpCodes.Ldarg_0);

            //вызов базового контруктора Object-a
            il1.Emit(OpCodes.Call, typeof(object).GetConstructor(Type.EmptyTypes));
            il1.Emit(OpCodes.Ldarg_0);
            il1.Emit(OpCodes.Ldarg_1);
            //необходимо выполнить завершение для IL конструкции
            // Ret - return осуществляет выход из конструктора
            il1.Emit(OpCodes.Ret);

            //когда тип уже создан, создаем его
            tb.CreateType();

            //сохраняем сборку в файл
            ab.Save("newLibrary.dll");
        }
    }
}
