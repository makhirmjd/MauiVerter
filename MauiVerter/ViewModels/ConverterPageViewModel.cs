using System.Collections.ObjectModel;
using UnitsNet;

namespace MauiVerter.ViewModels;

public class ConverterPageViewModel
{
    public string QuantityName { get; set; } = "Length";
    public ObservableCollection<string> FromMeasures { get; set; } = [];
    public ObservableCollection<string> ToMeasures { get; set; } = [];
    public string CurrentFromMeasure { get; set; } = "Meter";
    public string CurrentToMeasure { get; set; } = "Centimeter";

    public ConverterPageViewModel()
    {
        ObservableCollection<string> measures = LoadMeasures();
        FromMeasures = measures;
        ToMeasures = measures;
    }

    private ObservableCollection<string> LoadMeasures() =>
        new(
            Quantity.Infos
            .FirstOrDefault(x => x.Name == QuantityName)!
            .UnitInfos
            .Select(u => u.Name));
}
