using Avalonia.Controls;
using AvaloniaApplication.Extensions;
using System.Threading.Tasks;
using System;

namespace AvaloniaApplication.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    #region Overrides of WindowBase

    /// <inheritdoc />
    protected override async void OnOpened(EventArgs e)
    {
        base.OnOpened(e);

        var duration = TimeSpan.FromSeconds(3);
        bool reverse = false;
        int iteration = 0;

        while (true)
        {
            iteration++;

            TextBlock.Text = $"Iteration: {iteration}";

            if (!reverse)
            {
                LeftRectangle.StartFadeInAnimation(duration);
                RightRectangle.StartFadeOutAnimation(duration);
            }
            else
            {
                RightRectangle.StartFadeInAnimation(duration);
                LeftRectangle.StartFadeOutAnimation(duration);
            }

            await Task.Delay(duration);

            reverse = !reverse;
        }
    }

    #endregion
}