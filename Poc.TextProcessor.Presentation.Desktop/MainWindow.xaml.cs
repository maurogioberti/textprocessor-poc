using Poc.TextProcessor.CrossCutting.Enums;
using Poc.TextProcessor.CrossCutting.Globalization;
using Poc.TextProcessor.ResourceAccess.Contracts;
using Poc.TextProcessor.Services.Abstractions;
using System.Windows;

namespace Poc.TextProcessor.Presentation.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ITextService _textService;
        private readonly ITextSortService _textSortService;

        // TODO: As an alternative, we could use a Rest API call using the collaborator pattern, which would handle these calls.
        // We opted for the service layer for practicality and to avoid a direct dependency on the API.

        public MainWindow(ITextService textService, ITextSortService textSortService)
        {
            _textService = textService;
            _textSortService = textSortService;

            InitializeComponent();
            FillSortOptions();
        }

        private void SortButton_Click(object sender, RoutedEventArgs e)
        {
            if (!IsInputValid())
                return;

            var selectedOption = SortOptions.SelectedItem as Sort;
            var selectedOptionEnum = (SortOption)Enum.Parse(typeof(SortOption), selectedOption.Option);
            var sortedText = _textSortService.Sort(TextInput.Text, selectedOptionEnum);
            MessageBox.Show(sortedText);
        }

        private void CountButton_Click(object sender, RoutedEventArgs e)
        {
            var statistics = _textService.GetStatistics(TextInput.Text);
            var message = $"Hyphens: {statistics.Hypens}, Words: {statistics.Words}, Spaces: {statistics.Spaces}";
            MessageBox.Show(message);
        }

        private void RandomTextButton_Click(object sender, RoutedEventArgs e)
        {
            var text = _textService.GetRandom();
            TextInput.Text = text.Content;
        }

        private void FillSortOptions()
        {
            var orderOptions = _textSortService.List();
            SortOptions.ItemsSource = orderOptions.Items;
            SortOptions.DisplayMemberPath = "Option";
        }

        private bool IsInputValid()
        {
            if (string.IsNullOrWhiteSpace(TextInput.Text))
            {
                MessageBox.Show(Messages.InputFieldEmpty);
                return false;
            }

            if (!(SortOptions.SelectedItem is Sort))
            {
                MessageBox.Show(Messages.SortFieldEmpty);
                return false;
            }

            return true;
        }
    }
}