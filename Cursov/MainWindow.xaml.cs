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
using System.IO;
using System.ComponentModel;
using System.Windows.Threading;
using System.Timers;

namespace Cursov
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool isDataDirty = false;
        string s;
        List<Button> buttons;
        List<Button> buttonsProverbs;
        List<Button> ChoosenButtons;
        List<Button> Delete;
        List<string> namesToSearch=new List<string>();
        List<CheckBox> boxes;
        Proverbs p = new Proverbs();
        public MainWindow()
        {
            InitializeComponent();
            File.WriteAllText(@"E:/Cursov/final.txt", string.Empty);

        }
        private void next_Click(object sender, RoutedEventArgs e)
        {
            next.Visibility = Visibility.Collapsed;
            textBox.Visibility = Visibility.Collapsed;
            Main.Visibility = Visibility.Visible;
            Search.Visibility = Visibility.Visible;
            Add.Visibility = Visibility.Visible;
            CreateButtons(1);
           
        }
        private void CreateButtons(int whichArr)
        {            
            string[] arr = Names(whichArr);
            buttons = new List<Button>();
            for (int i = 0; i < arr.Length; i++)
            {
                Button b = new Button()
                {
                    Content = arr[i] ,
                    MinHeight=30 ,
                    Background= new SolidColorBrush(Color.FromRgb(222, 184, 135))
                };               
                b.Click += b_Click;              
                sc.Children.Add(b);
                buttons.Add(b);
            }
        }
        private void DeleteButtons()
        {
            if (buttons != null )
            {
                foreach (Button btn in buttons)
                {
                    sc.Children.Remove(btn);
                    g.Children.Remove(btn);
                }
              
            }
            if (buttonsProverbs != null)
            {                
                foreach (Button btn in buttonsProverbs)
                {
                    sc.Children.Remove(btn);                   
                }
            }
            if (boxes != null)
            {
                foreach(CheckBox c in boxes)
                {
                    g.Children.Remove(c);
                }
            }
            if (Delete != null)
            {
                foreach (Button b in Delete)
                {
                    sc.Children.Remove(b);
                }
            }
            

        }
        private void b_Click(object sender, RoutedEventArgs e)
        {
            Main.Visibility = Visibility.Collapsed;
            Back.Visibility = Visibility.Visible;
            Button b = (Button)sender;
            switch (b.Content.ToString())
            {
                case "Родина":
                    DeleteButtons();
                    CreateButtons(2);
                    break;
                case "Знання і наука":
                    DeleteButtons();
                    CreateButtons(3);
                    break;
                case "Афоризми авторів":
                    DeleteButtons();
                    CreateButtons(4);
                    break;
                case "Афоризми з книжок":
                    DeleteButtons();
                    CreateButtons(5);
                    break;
                case "Відносини":
                    DeleteButtons();
                    CreateButtons(6);
                    break;
                case "Різне":
                    DeleteButtons();
                    CreateButtons(7);
                    break;
                default:
                    show.Visibility = Visibility.Visible;              
                  
                    DeleteButtons();
                    CreateButtonsForProverbs(p.CreateArray(b.Content.ToString().ToLower()));                                                
                    break;
            }
        }
        private string[] Names(int num)
        {
            switch (num)
            {
                case -1:
                    string[] scheck = new string[5]
                    {
                        "Про мову","Афоризми з фільмів","Про працю","Про книгу","Про здоров'я",
                    };
                    return scheck;
                case 0:
                    string[] s0 = new string[6]
                    {
                        "Родина","Знання і наука","Афоризми авторів", "Афоризми з книжок","Відносини","Різне"
                    };
                    return s0;
                case 1:
                    string[] s = new string[11]
                    {
                       "Родина","Про мову","Знання і наука","Афоризми авторів","Афоризми з фільмів",
                        "Афоризми з книжок","Про працю","Про книгу","Про здоров'я","Відносини","Різне"
                    };
                    return s;
                case 2:
                    string[] s1 = new string[4]
                                        {
                       "Про батька","Про матір","Про сім'ю","Про виховання"
                                        };
                    return s1;
                case 3:
                    string[] s2 = new string[2]
                                        {
                       "Про науку знання та розум","Про старість та досвід"
                                        };
                    return s2;
                case 4:
                    string[] s3 = new string[10]
                                        {
                       "Антон Макаренко","Арістотель","Василь Сухомлинський","Вільям Шекспір",
                        "Марк Твен","Луцій Сенека","Григорій Сковорода","Ліна Костенко",
                        "Омар Хайям","Гете"
                                        };
                    return s3;
                case 5:
                    string[] s4 = new string[5]
                                        {
                       "Аліса в країні чудес","Біблія","Майстер і Маргарита","Пропала грамота","Чорне і червоне"
                                        };
                    return s4;
                case 6:
                    string[] s5 = new string[9]
                                        {
                       "Про взаємини","Про гордість","Про добро","Про дружбу і друзів","Про жадібність","Про заздрість",
                          "Про мужність та боягузництво","Про обережність","Про чесність"                                        };
                    return s5;
                case 7:
                    string[] s6 = new string[16]
                                        {
                       "Про багатство","Про Батьківщину","Про біду","Про воду","Про господарство і господарів",
                       "Про гроші","Про життя","Про їжу та хліб","Про пісню","Про любов",
                       "Про правду","Про природу","Про птахів","Про сусідів","Про тварини","Про час"                                        };
                    return s6;
                default:
                    string[] s7 = new string[0];
                    return s7;

            }

        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {

            Button b = (Button)sender;
            DeleteButtons();
            show.Visibility = Visibility.Collapsed;
            Main.Visibility = Visibility.Visible;
            Back.Visibility = Visibility.Collapsed;
            searchDoc.Visibility = Visibility.Collapsed;
            searchInDoc.Visibility = Visibility.Collapsed;
            Choose.Visibility = Visibility.Collapsed;
            back_Choose.Visibility = Visibility.Collapsed;
            CreateButtons(1);
        }
        private void Main_Click(object sender, RoutedEventArgs e)
        {
            DeleteButtons();
            Add.Visibility = Visibility.Collapsed;
            show.Visibility = Visibility.Collapsed;
            searchDoc.Visibility = Visibility.Collapsed;
            searchInDoc.Visibility = Visibility.Collapsed;
            next.Visibility = Visibility.Visible;
            textBox.Visibility = Visibility.Visible;
            Main.Visibility = Visibility.Collapsed;
            Search.Visibility = Visibility.Collapsed;
            Choose.Visibility = Visibility.Collapsed;
        }
        private void Search_Click(object sender, RoutedEventArgs e)
        {
            DeleteButtons();
            Main.Visibility = Visibility.Collapsed;
            searchDoc.Visibility = Visibility.Visible;
            searchInDoc.Visibility = Visibility.Visible;
            show.Visibility = Visibility.Visible;
            Choose.Visibility = Visibility.Visible;
            Back.Visibility = Visibility.Visible;
            g.Visibility = Visibility.Visible;         
        }
        private void Choose_Click(object sender, RoutedEventArgs e)
        {           
            DeleteButtons();
            Main.Visibility = Visibility.Collapsed;
            searchDoc.Visibility = Visibility.Visible;
            searchInDoc.Visibility = Visibility.Visible;
            show.Visibility = Visibility.Visible;
            CreateMenu(0);
            CreateCheckBoxes(-1);           
        }
        private void searchInDoc_Click(object sender, RoutedEventArgs e)
        {
            DeleteButtons();
            string Show="";
            if (namesToSearch != null)
            { List<Proverb> arr = new List<Proverb>();
                foreach (string name in namesToSearch)
                {                   
                    arr.AddRange(p.CreateArray(name));                   
                }
                CreateButtonsForProverbs(arr);
            }            
                string from = searchDoc.Text;
            if (from != "Введіть слово або сполучення слів" && from!=" ")
            {
                searchDoc.Text = from;               
                List<Proverb> show = new List<Proverb>();                
                show.AddRange(p.Search(from, "all"));
                CreateButtonsForProverbs(show);
            }else
            {
                show.Text = Show;
            }
            namesToSearch = new List<string>();
        }
        private void DataWindow_Closing(object sender, CancelEventArgs e)
        {

            if (this.isDataDirty )
            {
                string msg = "Зберегти вибрані крилаті вислови?";
                MessageBoxResult result =
                  MessageBox.Show(
                    msg,
                    "Data App",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning);
                if (result == MessageBoxResult.No)
                {
                    e.Cancel = false;
                }
                else
                {
                    string path = @"E:/Cursov/final.txt";
                    if (!File.Exists(path))
                    {
                        using (StreamWriter sw = File.CreateText(path))
                        {
                            if (ChoosenButtons != null)
                            {
                                foreach (Button b in ChoosenButtons)
                                {
                                    sw.WriteLine(b.Content.ToString());
                                }
                            }
                        }
                    }
                    using (StreamWriter sw = File.AppendText(path))
                    {
                        if (ChoosenButtons != null)
                        {
                            foreach (Button b in ChoosenButtons)
                            {
                                sw.WriteLine(b.Content.ToString());
                            }
                        }
                    }
                }
            }
                MessageBoxResult result1 = MessageBox.Show(
                        "Ви впевнені у виході",
                        "Data App",
                        MessageBoxButton.YesNo,
                        MessageBoxImage.Warning);
                if (result1 == MessageBoxResult.No)
                {
                    e.Cancel = true;
                }
            
        }
        private void CreateButtonsForProverbs(List<Proverb> list)
        {
            buttonsProverbs = new List<Button>();
            for (int i = 0; i < list.Count; i++)
            {
                Button b1 = new Button()
                {
                    Content = list[i].Text,
                    Background = new SolidColorBrush(Color.FromRgb(222, 184, 135)),
                     ToolTip = "Вибрати?"
                };

                b1.Click += b1_Click;               
                sc.Children.Add(b1);
                buttonsProverbs.Add(b1);
            }
        }      
        private void b1_Click(object sender, RoutedEventArgs e)
        {
            isDataDirty = true;
            Main.Visibility = Visibility.Collapsed;
            Back.Visibility = Visibility.Visible;
            Button b = (Button)sender;
            b.Background = new SolidColorBrush(Color.FromRgb(255, 248, 220));
            ChoosenButtons = new List<Button>();
            ChoosenButtons.Add(b);
            s += b.Content.ToString() + "\n";
           
            //MessageBox.Show("Додано");          
        }      
        private void Add_Click(object sender, RoutedEventArgs e)
        {           
            DeleteButtons();
            Main.Visibility = Visibility.Collapsed;
            Back.Visibility = Visibility.Visible;
            back_Choose.Visibility = Visibility.Collapsed;
            Choose.Visibility = Visibility.Collapsed;
            searchDoc.Visibility = Visibility.Collapsed;
            searchInDoc.Visibility = Visibility.Collapsed;
            g.Visibility = Visibility.Collapsed;           
            CreateButtonsForDelete();   
        }      
        private void CreateButtonsForDelete()
        {
            isDataDirty = true;
            string s3 = "";
            Delete = new List<Button>();
            if (s != null)
            {
                for (int i = 0; i < s.Length; i++)
                {

                    if (s[i] != '\n')
                    {
                        s3 += s[i];
                    }
                    else
                    {
                        Button b2 = new Button()
                        {
                            Content = s3,
                            Background = new SolidColorBrush(Color.FromRgb(222, 184, 135))
                            
                        };

                        b2.Click += b2_Click;
                        sc.Children.Add(b2);
                        s3 = "";
                        Delete.Add(b2);
                    }
                }
            }else
            {
                show.Visibility = Visibility.Visible;
            }
        }
        private void b2_Click(object sender, RoutedEventArgs e)
        {
            Main.Visibility = Visibility.Collapsed;
            Back.Visibility = Visibility.Visible;
            string msg = "Ви впевненні у видаленні?";
            MessageBoxResult result =
              MessageBox.Show(
                msg,
                "Data App",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
               
           
                Button b = (Button)sender;               
                ChoosenButtons.Remove(b);
                sc.Children.Remove(b);
                MessageBox.Show("Видалено");
            }         
        }
        private void CreateMenu(int whichArr)
        {
            string[] arr = Names(whichArr);
            buttons = new List<Button>();
            for (int i = 0; i < arr.Length; i++)
            {

                Button b3 = new Button()
                {
                    Content = arr[i],
                    Height=20,                    
                    Width=150,
                    Background = new SolidColorBrush(Color.FromRgb(222, 184, 135))
                };
                b3.Click += b3_Click;
                b3.VerticalAlignment = VerticalAlignment.Stretch;
                g.Columns = 4;
                g.Children.Add(b3);
                buttons.Add(b3);                             
            }        
         }
        private void b3_Click(object sender, RoutedEventArgs e)
        {
            Main.Visibility = Visibility.Collapsed;
            Back.Visibility = Visibility.Visible;
            Button b = (Button)sender;
            switch (b.Content.ToString())
            {
                case "Родина":
                    //DeleteButtons();
                    CreateCheckBoxes(2);
                    break;
                case "Знання і наука":
                    //DeleteButtons();
                    CreateCheckBoxes(3);
                    break;
                case "Афоризми авторів":
                   // DeleteButtons();
                    CreateCheckBoxes(4);
                    break;
                case "Афоризми з книжок":
                   // DeleteButtons();
                    CreateCheckBoxes(5);
                    break;
                case "Відносини":
                    ////////DeleteButtons();
                    CreateCheckBoxes(6);
                    break;
                case "Різне":
                   // DeleteButtons();
                    CreateCheckBoxes(7);
                    break;
                default:
                    show.Visibility = Visibility.Visible;                 
                    Back.Visibility = Visibility.Visible;
                    DeleteButtons();
                    CreateButtonsForProverbs(p.CreateArray(b.Content.ToString().ToLower()));                                                
                    break;
            }
            back_Choose.Visibility = Visibility.Visible;
        }
        private void back_Choose_Click(object sender, RoutedEventArgs e)
        {
            //DeleteButtons();
            CreateMenu(0);
            CreateCheckBoxes(-1);
            back_Choose.Visibility = Visibility.Collapsed;

        }
        private void CreateCheckBoxes(int whichArr)
        {
            boxes = new List<CheckBox>();
            string[] arr = Names(whichArr);            
            for (int i = 0; i < arr.Length; i++)
            {
                CheckBox check = new CheckBox()
                {
                    Content = arr[i],
                    Height = 20,                   
                    Width = 200                           
                };
                check.Checked += check_Checked;
                check.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                g.Columns = 4;
                g.Children.Add(check);
                boxes.Add(check);                
            }
        }
        private void check_Checked(object sender, RoutedEventArgs e)
        {
           
            CheckBox chBox = (CheckBox)sender;
            chBox.IsChecked = true;
            namesToSearch.Add(chBox.Content.ToString().ToLower());

        }



    }
}
