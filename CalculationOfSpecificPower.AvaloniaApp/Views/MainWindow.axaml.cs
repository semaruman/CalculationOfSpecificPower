using Avalonia;
using Avalonia.Animation;
using Avalonia.Animation.Easings;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Media;
using Avalonia.Styling;
using Avalonia.Threading;

namespace CalculationOfSpecificPower.AvaloniaApp.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        Opened += async (_, _) => await PlayEntranceAsync();
    }

    private async Task PlayEntranceAsync()
    {
        try
        {
            MainScene.Opacity = 0;
            await AnimateEntranceAsync(MainScene, 480);
        }
        catch
        {
            // fallback below
        }
        finally
        {
            EnsureSceneVisible();
        }
    }

    private void EnsureSceneVisible()
    {
        MainScene.Opacity = 1;
        MainScene.RenderTransform = null;
    }

    private static async Task AnimateEntranceAsync(Control control, int ms)
    {
        control.Opacity = 0;

        var animation = new Animation
        {
            Duration = TimeSpan.FromMilliseconds(ms),
            Easing = new CubicEaseOut(),
            FillMode = FillMode.Forward,
            Children =
            {
                new KeyFrame
                {
                    Cue = new Cue(0),
                    Setters = { new Setter(OpacityProperty, 0d) }
                },
                new KeyFrame
                {
                    Cue = new Cue(1),
                    Setters = { new Setter(OpacityProperty, 1d) }
                }
            }
        };

        await animation.RunAsync(control);
    }

    private void TitleBar_OnPointerPressed(object? sender, PointerPressedEventArgs e)
    {
        if (e.ClickCount == 2)
        {
            WindowState = WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
            return;
        }

        BeginMoveDrag(e);
    }

    private void Minimize_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e) =>
        WindowState = WindowState.Minimized;

    private void Maximize_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e) =>
        WindowState = WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;

    private void Close_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e) => Close();
}
