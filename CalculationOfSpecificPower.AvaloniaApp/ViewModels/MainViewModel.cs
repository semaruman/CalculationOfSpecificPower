using System.Collections.ObjectModel;
using CalculationOfSpecificPower.AvaloniaApp.Models;
using CalculationOfSpecificPower.AvaloniaApp.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CalculationOfSpecificPower.AvaloniaApp.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    private readonly CalculationService _calculationService = new();

    // --- Inputs (mirror WinForms fields) ---
    [ObservableProperty] private string _consumersCountText = string.Empty;
    [ObservableProperty] private ConsumerTypeOption? _selectedConsumerType;
    [ObservableProperty] private string _cosFText = "0,98";
    [ObservableProperty] private string _lepLengthText = string.Empty;
    [ObservableProperty] private string _powerText = string.Empty;
    [ObservableProperty] private string _sectionText = string.Empty;
    [ObservableProperty] private MaterialOption? _selectedMaterial;

    // --- Results ---
    [ObservableProperty] private string _specificPowerText = "—";
    [ObservableProperty] private string _fullPowerText = "—";
    [ObservableProperty] private string _currentText = "—";
    [ObservableProperty] private string _momentText = "—";
    [ObservableProperty] private string _lossesText = "—";

    [ObservableProperty] private double _vizSpecificPower;
    [ObservableProperty] private double _vizFullPower;
    [ObservableProperty] private double _vizCurrent;
    [ObservableProperty] private bool _hasResults;

    // --- Validation / UX ---
    [ObservableProperty] private bool _consumersCountHasError;
    [ObservableProperty] private bool _consumerTypeHasError;
    [ObservableProperty] private bool _cosFHasError;
    [ObservableProperty] private bool _lepLengthHasError;
    [ObservableProperty] private bool _powerHasError;
    [ObservableProperty] private bool _sectionHasError;
    [ObservableProperty] private bool _materialHasError;

    [ObservableProperty] private bool _hasNotification;
    [ObservableProperty] private string _notificationTitle = string.Empty;
    [ObservableProperty] private string _notificationMessage = string.Empty;
    [ObservableProperty] private string _statusText = "READY";
    [ObservableProperty] private bool _isBusy;

    public ObservableCollection<ConsumerTypeOption> ConsumerTypes { get; } = new()
    {
        // Exact WinForms strings — used by ConsumerData.GetDataList
        new("Природный газ", "природный газ"),
        new("Сжиженный газ", "сжиженный газ"),
        new("Электрические плиты", "электрические плиты"),
        new("Садовые домики", "садовые домики"),
    };

    public ObservableCollection<MaterialOption> Materials { get; } = new()
    {
        // Exact WinForms labels + coefficients
        new("Аллюминий", 44),
        new("Медь", 72),
    };

    public MainViewModel()
    {
        SelectedMaterial = Materials[0];
    }

    [RelayCommand]
    private void CalculatePower()
    {
        ClearErrors();
        ClearNotification();

        // Validation identical to MainForm.CalculateButton_Click
        if (!InputParser.TryParseInt(ConsumersCountText, out var consCount))
        {
            ConsumersCountHasError = true;
            ShowNotification("Неверный формат", "Количество потребителей должно быть числом");
            return;
        }

        if (SelectedConsumerType is null || string.IsNullOrEmpty(SelectedConsumerType.Value))
        {
            ConsumerTypeHasError = true;
            ShowNotification("Проверка ввода", "Вы не выбрали потребителя");
            return;
        }

        if (!InputParser.TryParseDouble(CosFText, out var cosF))
        {
            CosFHasError = true;
            ShowNotification("Неверный формат", "Косинус фи должен быть числом; вещественные числа отделяются запятой");
            return;
        }

        try
        {
            IsBusy = true;
            StatusText = "CALCULATING";

            var result = _calculationService.CalculatePower(consCount, SelectedConsumerType.Value, cosF);

            // Rounding identical to WinForms
            SpecificPowerText = InputParser.FormatRounded(result.SpecificPower, 3);
            FullPowerText = InputParser.FormatRounded(result.FullSpecificPower, 3);
            CurrentText = InputParser.FormatRounded(result.Current, 3);
            PowerText = InputParser.FormatPowerForReuse(result.FullSpecificPower);

            VizSpecificPower = result.SpecificPower;
            VizFullPower = result.FullSpecificPower;
            VizCurrent = result.Current;
            HasResults = true;
            StatusText = "READY";
        }
        catch (Exception ex)
        {
            StatusText = "ERROR";
            ShowNotification("Ошибка расчёта", ex.Message);
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    private void CalculateMoment()
    {
        ClearErrors();
        ClearNotification();

        // Same validation as MainForm.button1_Click
        if (!InputParser.TryParseDouble(PowerText, out var power))
        {
            PowerHasError = true;
            ShowNotification("Проверка ввода", "Мощность не расчитана. Вещественные числа отделяются запятой");
            return;
        }

        if (!InputParser.TryParseDouble(LepLengthText, out var length))
        {
            LepLengthHasError = true;
            ShowNotification("Неверный формат", "Длина ЛЭП должна быть числом");
            return;
        }

        try
        {
            IsBusy = true;
            StatusText = "CALCULATING";
            var result = _calculationService.CalculateMoment(length, power);
            MomentText = InputParser.FormatRounded(result.Moment, 3);
            StatusText = "READY";
        }
        catch (Exception ex)
        {
            StatusText = "ERROR";
            ShowNotification("Ошибка расчёта", ex.Message);
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    private void CalculateLosses()
    {
        ClearErrors();
        ClearNotification();

        // Same validation as MainForm.button2_Click
        if (!InputParser.TryParseDouble(PowerText, out var power))
        {
            PowerHasError = true;
            ShowNotification("Проверка ввода", "Мощность не расчитана. Вещественные числа отделяются запятой");
            return;
        }

        if (!InputParser.TryParseDouble(LepLengthText, out var length))
        {
            LepLengthHasError = true;
            ShowNotification("Неверный формат", "Длина ЛЭП должна быть числом");
            return;
        }

        if (!InputParser.TryParseDouble(SectionText, out var section))
        {
            SectionHasError = true;
            ShowNotification("Неверный формат", "Сечение должно быть числом; Вещественные числа отделяются запятой");
            return;
        }

        if (SelectedMaterial is null)
        {
            MaterialHasError = true;
            ShowNotification("Проверка ввода", "Не выбран коэффициент");
            return;
        }

        double C;
        try
        {
            // Exact WinForms if/else on display text
            C = CalculationService.GetMaterialCoefficient(SelectedMaterial.DisplayName);
        }
        catch (InvalidOperationException)
        {
            MaterialHasError = true;
            ShowNotification("Проверка ввода", "Не выбран коэффициент");
            return;
        }

        try
        {
            IsBusy = true;
            StatusText = "CALCULATING";
            var result = _calculationService.CalculateLosses(power, length, C, section);
            // WinForms: Math.Round(losses, 2).ToString()
            LossesText = Math.Round(result.Losses, 2).ToString();
            StatusText = "READY";
        }
        catch (Exception ex)
        {
            StatusText = "ERROR";
            ShowNotification("Ошибка расчёта", ex.Message);
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    private void DismissNotification()
    {
        ClearNotification();
    }

    private void ShowNotification(string title, string message)
    {
        NotificationTitle = title;
        NotificationMessage = message;
        HasNotification = true;
        StatusText = "CHECK INPUT";
    }

    private void ClearNotification()
    {
        HasNotification = false;
        NotificationTitle = string.Empty;
        NotificationMessage = string.Empty;
    }

    private void ClearErrors()
    {
        ConsumersCountHasError = false;
        ConsumerTypeHasError = false;
        CosFHasError = false;
        LepLengthHasError = false;
        PowerHasError = false;
        SectionHasError = false;
        MaterialHasError = false;
    }
}
