using System;
using System.Collections.Generic;
using System.Linq;
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
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string newTodoText = NewTodoText.Text;
            //MessageBox.Show(newTodoText.Length.ToString());
            if (newTodoText.Length > 0)
            {
                TodoItem newTodo = new TodoItem(newTodoText);
                todoItems.Add(newTodo);
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

                delBtn.Tag = item.TodoName;

                textBlock.Text = item.TodoName;
                textBlock.Margin = new Thickness(0, position, 0, 0);
                delBtn.Margin = new Thickness(10, position, 0, 0);

                ToDoList.Children.Add(textBlock);
                ToDoList.Children.Add(delBtn);

                position += 20;
            }
        }
    }
}
