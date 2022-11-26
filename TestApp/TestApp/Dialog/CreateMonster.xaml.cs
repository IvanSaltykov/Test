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

namespace TestApp.Dialog
{
    /// <summary>
    /// Логика взаимодействия для CreateMonster.xaml
    /// </summary>
    public partial class CreateMonster : Window
    {
        public CreateMonster()
        {
            InitializeComponent();
        }

        private void buttonCreateMonsterCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void buttonCreateMonster_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxCreareMonsterAttack.Text != "" && textBoxCreareMonsterProtection.Text != "" && textBoxCreareMonsterHealth.Text != "" && textBoxCreareMonsterDamageMax.Text != "" && textBoxCreareMonsterDamageMin.Text != "")
            {
                int attack = int.Parse(textBoxCreareMonsterAttack.Text);
                int protection = int.Parse(textBoxCreareMonsterProtection.Text);
                int health = int.Parse(textBoxCreareMonsterHealth.Text);
                int damageMax = int.Parse(textBoxCreareMonsterDamageMax.Text);
                int damageMin = int.Parse(textBoxCreareMonsterDamageMin.Text);
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
                    Manager.monsters.Add(new Monster(attack, protection, health, damageMin, damageMax));
                    DialogResult = true;
                }
            }
            else
                MessageBox.Show("Поля не должны быть пустыми");
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
