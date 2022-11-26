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

namespace TestApp
{
    /// <summary>
    /// Логика взаимодействия для CreatePlayer.xaml
    /// </summary>
    public partial class CreatePlayer : Window
    {
        public CreatePlayer()
        {
            InitializeComponent();
        }
        private void buttonCreatePlayer_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxCrearePlayerAttack.Text != "" && textBoxCrearePlayerProtection.Text != "" && textBoxCrearePlayerHealth.Text != "" && textBoxCrearePlayerDamageMax.Text != "" && textBoxCrearePlayerDamageMin.Text != "")
            {
                int attack = int.Parse(textBoxCrearePlayerAttack.Text);
                int protection = int.Parse(textBoxCrearePlayerProtection.Text);
                int health = int.Parse(textBoxCrearePlayerHealth.Text);
                int damageMax = int.Parse(textBoxCrearePlayerDamageMax.Text);
                int damageMin = int.Parse(textBoxCrearePlayerDamageMin.Text);
                bool error = false;
                if (attack > 20 || protection > 20 || attack <= 0 || protection <= 0)
                {
                    MessageBox.Show("Атака и защита имеют значения от 1 до 20");
                    error = true;
                }
                if (damageMax <= damageMin)
                {
                    MessageBox.Show("Максимальный урон больше минимального урона");
                    error = true;
                }
                if (!error)
                {
                    Manager.player = new Player(attack, protection, health, damageMin, damageMax);
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    Close();
                }
            }
            else
                MessageBox.Show("Поля не должны быть пустыми");
        }

        private void buttonCreatePlayerCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }
    }
}
