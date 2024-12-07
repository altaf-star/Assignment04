using System.Collections.ObjectModel;
using System.Windows;

namespace CricketTeamManager
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<string> Players { get; set; } = new ObservableCollection<string>();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this; // Set DataContext for data binding
        }

        private void AddPlayerButton_Click(object sender, RoutedEventArgs e)
        {
            string playerName = PlayerNameTextBox.Text.Trim();

            if (string.IsNullOrEmpty(playerName))
            {
                MessageBox.Show("Player name cannot be empty!", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (Players.Contains(playerName))
            {
                MessageBox.Show("This player is already in the roster!", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Players.Add(playerName);
            PlayerNameTextBox.Clear();
            MessageBox.Show($"{playerName} added to the team!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void RemovePlayerButton_Click(object sender, RoutedEventArgs e)
        {
            if (PlayersListBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a player to remove!", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string selectedPlayer = PlayersListBox.SelectedItem.ToString();
            Players.Remove(selectedPlayer);
            MessageBox.Show($"{selectedPlayer} removed from the team!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
