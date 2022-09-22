using System;
using System.Windows;

namespace Project09
{
    /// <summary>
    /// 3.4	Лабораторная работа №5. Тема: «Оптимальное построение структуры данных» Вариант №22 https://github.com/Hawinar
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public static int[] massive;

        private void btFindLvl_Click(object sender, RoutedEventArgs e)
        {
            if (massive != null)
            {
                string target = tbTargetToLvl.Text;
                string[] tmp = new string[massive.Length];
                for(int i = 0; i < massive.Length; i++)
                {
                    if (massive[i].ToString() == target)
                    {
                        tmp[i] = i.ToString();
                    }
                }
                if(EmptinessCheck(tmp) == false)
                {
                    string message = string.Empty;
                    for (int i = 0; i < tmp.Length; i++)
                    {
                        if (tmp[i] != null)
                        {
                            message += ($"{tmp[i]}, ");
                        }
                    }
                    message = message.Remove(message.Length - 2);
                    MessageBox.Show($"Число {target} обнаружено на уровне под номером: {message}");
                }
                else
                {
                    MessageBox.Show($"Число {target} не было обнаружено");
                }
            }
            else
            {
                MessageBox.Show("Ну вам стоило бы для начала создать массив");
            }
        }

        private void btFindDeep_Click(object sender, RoutedEventArgs e)
        {
            if (massive != null)
            {
                MessageBox.Show($"{massive[massive.Length-1]} является глубиной дерева");
            }
            else
            {
                MessageBox.Show("Ну вам стоило бы для начала создать массив");
            }
        }

        private void btFindLenght_Click(object sender, RoutedEventArgs e)
        {
            if (massive != null)
            {
                int sum = 0;
                for (int i = 0; i < massive.Length; i++)
                {
                    sum += massive[i];
                }
                MessageBox.Show($"Длина массива {massive.Length}. Сумма чисел в массиве {sum}");
            }
            else
            {
                MessageBox.Show("Ну вам стоило бы для начала создать массив");
            }

        }

        private void btGenerateMassive_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int lenght = int.Parse(tbMassLenght.Text);
                GenerateMassive(lenght);
            }
            catch (Exception)
            {
                MessageBox.Show("Убедитесь, что вы верно ввели границы чисел и их количество (только целочисленные)");
            }
        }
        public void GenerateMassive(int length)
        {
            try
            {
                int minNumber = int.Parse(tbMinNumber.Text);
                int maxNumber = 1 + int.Parse(tbMaxNumber.Text);

                massive = new int[length];

                lbMassive.Text = string.Empty;

                Random rnd = new Random();
                for (int i = 0; i < length; i++)
                {
                    massive[i] = rnd.Next(minNumber, maxNumber);
                    lbMassive.Text += $"{massive[i]}, ";
                }
                string tmp = lbMassive.Text.ToString();
                lbMassive.Text = tmp.Remove(tmp.Length - 2);

            }
            catch (Exception)
            {
                MessageBox.Show("Убедитесь, что вы верно ввели границы чисел и их количество (только целочисленные)");
            }
        }
        public bool EmptinessCheck(string[] tmp)
        {
            for(int i = 0; i < tmp.Length; i++)
            {
                if(tmp[i] != null)
                    return false;
            }
            return true;
        }
    }
}
