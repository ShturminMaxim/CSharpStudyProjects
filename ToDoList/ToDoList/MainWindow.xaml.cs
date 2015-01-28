using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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

namespace ToDoList
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<TodoItem> todoItems = new List<TodoItem>();

        public MainWindow()
        {
            InitializeComponent();
            downloadData();
        }

        private void downloadData() {
            try
            {
                FileStream fs = new FileStream("todos.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                BinaryFormatter bf = new BinaryFormatter();
                todoItems = (List<TodoItem>)bf.Deserialize(fs);
                fs.Close();

                updateList();

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }
        private void saveData() {
            try
            {
                FileStream fs = new FileStream("todos.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                BinaryFormatter bf = new BinaryFormatter();

                bf.Serialize(fs, todoItems);
                fs.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            addElem();
        }
        private void NewTodoText_KeyUp(object sender, KeyEventArgs e)
        {       
            if (e.Key == Key.Enter)
            {
                addElem();
            }        
        }

        private void addElem(){
            string newTodoText = NewTodoText.Text;
            if (newTodoText.Length > 0)
            {
                int id = todoItems.Count();
                TodoItem newTodo = new TodoItem(newTodoText, id);
                todoItems.Add(newTodo);
                NewTodoText.Text = "";
            }
            updateList();
        }

        private void updateList() {
            ToDoList.Children.Clear();
            int position = 0;
            foreach (var item in todoItems) 
            {
                TextBlock textBlock = new TextBlock();
                Button delBtn = new Button();

                textBlock.Text = item.TodoName;
                textBlock.Margin = new Thickness(0, position, 0, 0);
                

                delBtn.Tag = item.Id;
                delBtn.Height = 22;
                delBtn.Width = 80;
                delBtn.Content = "del";
                delBtn.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
                delBtn.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                delBtn.Margin = new Thickness(0, position, 0, 0);
                delBtn.Click += delElem;

                ToDoList.Children.Add(textBlock);
                ToDoList.Children.Add(delBtn);

                position += 24;
            }
            saveData();
        }

        private void delElem(object sender, RoutedEventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                int itemId = Convert.ToInt32(btn.Tag);
                for (int i = 0; i < todoItems.Count; i++)
                {
                    if(todoItems[i].Id == itemId) {
                        todoItems.Remove(todoItems[i]);
                        updateList();
                        break;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
