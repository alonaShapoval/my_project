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
using System.Windows.Shapes;

namespace Cursov
{
    /// <summary>
    /// Логика взаимодействия для Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        public Window3()
        {
            InitializeComponent();
            CreateMenu(1);
        }
        List<Button> buttons;
        private void CreateMenu(int whichArr)
        {
            string[] arr = Names(whichArr);
            buttons = new List<Button>();
            for (int i = 0; i < arr.Length; i++)
            {

                Button b3 = new Button()
                {
                    Content = arr[i],
                    Height = 20,
                    Name = "b" + i,
                    Width = 150
                };
                b3.Click += b3_Click;
                b3.VerticalAlignment = VerticalAlignment.Stretch;
                sc.Children.Add(b3);                              
            }


        }
        private void b3_Click(object sender, RoutedEventArgs e)
        {           
            Button b = (Button)sender;
            switch (b.Content.ToString())
            {
                case "Родина":
                    DeleteButtons();
                    CreateCheckBoxes(2);
                    break;
                case "Знання і наука":
                    DeleteButtons();
                    CreateCheckBoxes(3);
                    break;
                case "Афоризми авторів":
                    DeleteButtons();
                    CreateCheckBoxes(4);
                    break;
                case "Афоризми з книжок":
                    DeleteButtons();
                    CreateCheckBoxes(5);
                    break;
                case "Відносини":
                    DeleteButtons();
                    CreateCheckBoxes(6);
                    break;
                case "Різне":
                    DeleteButtons();
                    CreateCheckBoxes(7);
                    break;
                default:                    
                    DeleteButtons();                   
                    break;
            }
        }
        private void CreateCheckBoxes(int whichArr)
        {
            string[] arr = Names(whichArr);
            for (int i = 0; i < arr.Length; i++)
            {

                CheckBox check = new CheckBox()
                {
                    Content = arr[i],
                    Height = 20,
                    Name = "b" + i,
                    Width = 100


                };
                check.Checked += check_Checked;
                check.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));

                sc.Children.Add(check);

            }
        }
        private void check_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox chBox = (CheckBox)sender;
            MessageBox.Show(chBox.Content.ToString() + " отмечен");
            
        }
        private void DeleteButtons()
        {
            if (buttons != null)
            {
                foreach (Button btn in buttons)
                {
                    sc.Children.Remove(btn);
                }

            }
           
        }
        private string[] Names(int num)
        {

            switch (num)
            {
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
                    string[] s3 = new string[12]
                                        {
                       "Антон Макаренко","Арістотель","Василь Сухомлинський","Вільям Шекспір",
                        "Марк Твен","Луцій Сенека","Григорій Сковорода","Ліна Костенко",
                        "Максим Рильський","Омар Хайям","Гете","Тарас Шевченко"
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
                          "Про мужність та боягузництво","Про обережність","Про чесність"
                                        };
                    return s5;
                case 7:
                    string[] s6 = new string[16]
                                        {
                       "Про багатство","Про Батьківщину","Про біду","Про воду","Про господарство і господарів",
                       "Про гроші","Про життя","Про їжу та хліб","Про пісню","Про любов",
                       "Про правду","Про природу","Про птахів","Про сусідів","Про тварини","Про час"
                                        };
                    return s6;
                default:
                    string[] s7 = new string[0];
                    return s7;

            }

        }
    }
}
