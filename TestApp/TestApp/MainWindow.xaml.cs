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
using TestApp.Dialog;

namespace TestApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Manager.monsters = new List<Monster>();
            listViewMonsters.ItemsSource = Manager.monsters;
            textBlockHealthPlayer.Text = Manager.player.Health.ToString();
            textBlockHealingCountPlayer.Text = Manager.player.countHealing.ToString();
        }

        private void buttonAttackPlayerItem_Click(object sender, RoutedEventArgs e)
        {
            var monster = (sender as Button).DataContext as Monster;
            monster.takingDamage(Manager.player.Attack, Manager.player.attackDamage());
            if (monster.Health <= 0)
                Manager.monsters.Remove(monster);
            listViewMonsters.Items.Refresh();
        }

        private void buttonAttackMonsterItem_Click(object sender, RoutedEventArgs e)
        {
            var monster = (sender as Button).DataContext as Monster;
            Manager.player.takingDamage(monster.Attack, monster.attackDamage());
            if (Manager.player.Health <= 0)
            {
                MessageBox.Show("Вы погибли");
                this.Close();
            }     
            textBlockHealthPlayer.Text = Manager.player.Health.ToString();
        }

        private void buttonCreateMonster_Click(object sender, RoutedEventArgs e)
        {
            CreateMonster createMonster = new CreateMonster();
            createMonster.ShowDialog();
            if (createMonster.DialogResult == true)
                listViewMonsters.Items.Refresh();
        }

        private void buttonHealingPlayer_Click(object sender, RoutedEventArgs e)
        {
            Manager.player.healing();
            textBlockHealthPlayer.Text = Manager.player.Health.ToString();
            textBlockHealingCountPlayer.Text = Manager.player.countHealing.ToString();
        }
    }
}
