using Avalonia;
using Avalonia.Animation;
using Avalonia.Animation.Easings;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Media;
using Avalonia.Styling;
using Avalonia.Threading;
using Avalonia.VisualTree;

namespace CalculationOfSpecificPower.AvaloniaApp.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        Opened += async (_, _) => await PlayEntranceAsync();
        PropertyChanged += (_, e) =>
        {
            if (e.Property == WindowStateProperty)
                UpdateMaximizeButtonGlyph();
        };
    }

    private void UpdateMaximizeButtonGlyph()
    {
        if (MaximizeButton is null) return;
        MaximizeButton.Content = WindowState == WindowState.Maximized ? "❐" : "□";
        ToolTip.SetTip(MaximizeButton,
            WindowState == WindowState.Maximized ? "Восстановить" : "Развернуть");
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
        // Ignore if click landed on an interactive chrome control
        if (e.Source is Visual source && source.FindAncestorOfType<Button>() is not null)
            return;

        if (e.GetCurrentPoint(this).Properties.IsLeftButtonPressed == false)
            return;

        if (e.ClickCount == 2)
        {
            WindowState = WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
            e.Handled = true;
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
