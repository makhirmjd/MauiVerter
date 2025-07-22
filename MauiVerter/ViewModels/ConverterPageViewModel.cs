using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using UnitsNet;

namespace MauiVerter.ViewModels;

public partial class ConverterPageViewModel : ObservableObject
{
    public string QuantityName { get; set; } = default!;

    public ObservableCollection<string> FromMeasures { get; set; } = [];

    public ObservableCollection<string> ToMeasures { get; set; } = [];

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(ToValue))]
    private string currentFromMeasure;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(ToValue))]
    private string currentToMeasure;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(ToValue))]
    private double fromValue;

    public double ToValue => Convert();

    public void SetMeasure(string measure)
    {
        QuantityName = measure;
        ObservableCollection<string> measures = LoadMeasures();
        FromMeasures.Clear();
        ToMeasures.Clear();
        measures.ToList().ForEach(m =>
        {
            FromMeasures.Add(m);
            ToMeasures.Add(m);
        });
        CurrentFromMeasure = FromMeasures.FirstOrDefault() ?? string.Empty;
        CurrentToMeasure = ToMeasures.Skip(1).FirstOrDefault() ?? string.Empty;
        FromValue = 1;
    }


    public double Convert()
    {
        if (string.IsNullOrEmpty(CurrentFromMeasure) || string.IsNullOrEmpty(CurrentToMeasure))
            return 0;
        return UnitConverter.ConvertByName(FromValue, QuantityName, CurrentFromMeasure, CurrentToMeasure);
    }

    private ObservableCollection<string> LoadMeasures() =>
        new(
            Quantity.Infos
            .FirstOrDefault(x => x.Name == QuantityName)!
            .UnitInfos
            .Select(u => u.Name));
}
