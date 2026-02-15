// 250214_code
// 250214_documentation

using System.Windows;
using Scruppy.Database;

namespace Scruppy;
/// <summary>Entry class for Scruppy.</summary>
public partial class MainWindow : Window
{
    /// <summary>Entry method for Scruppy.</summary>
    public MainWindow()
    {
        InitializeComponent();

        SetEventHandlers();
    }

    private void UpdateDatabaseClicked()
    {
        var updateWindow = new UpdateWindow();
        updateWindow.Show();
    }

    /* EVENT HANDLERS */

    private void SetEventHandlers()
    {
        btnUpdateDatabase.Click += btnUpdateDatabase_Clicked;
        ////btnDownloadIcons.Click += BtnDownloadIcons_Click;
    }

    private void btnUpdateDatabase_Clicked(object sender, RoutedEventArgs e) => UpdateDatabaseClicked();
}