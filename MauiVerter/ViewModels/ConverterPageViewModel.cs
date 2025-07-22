using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using UnitsNet;

namespace MauiVerter.ViewModels;

public partial class ConverterPageViewModel : ObservableObject
{
    public string QuantityName { get; set; } = "Length";

    public ObservableCollection<string> FromMeasures { get; set; } = [];

    public ObservableCollection<string> ToMeasures { get; set; } = [];

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(ToValue))]
    private string currentFromMeasure  = "Meter";

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(ToValue))]
    private string currentToMeasure  = "Centimeter";

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(ToValue))]
    private double fromValue = 1;

    public double ToValue => Convert();

    public ConverterPageViewModel()
    {
        ObservableCollection<string> measures = LoadMeasures();
        FromMeasures = measures;
        ToMeasures = measures;
        Convert();
    }


    public double Convert() => UnitConverter.ConvertByName(FromValue, QuantityName, CurrentFromMeasure, CurrentToMeasure);

    private ObservableCollection<string> LoadMeasures() =>
        new(
            Quantity.Infos
            .FirstOrDefault(x => x.Name == QuantityName)!
            .UnitInfos
            .Select(u => u.Name));
}
