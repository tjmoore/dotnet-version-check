using System.Windows;

namespace DotNetVersionCheck
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public VersionInfo VersionInfo { get; set; }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            labelRuntimeVersion.Content = VersionInfo?.RuntimeVersion;
            labelTargetVersion.Content = VersionInfo?.TargetFramework;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
