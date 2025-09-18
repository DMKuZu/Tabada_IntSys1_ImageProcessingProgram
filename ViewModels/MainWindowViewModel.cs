using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SkiaSharp;
using Tabada_ImageProcessing_Program.Models;

namespace Tabada_ImageProcessing_Program.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private readonly ImageProcessor _processor = new();

    [ObservableProperty]
    private Bitmap? _basicImage;

    [ObservableProperty]
    private Bitmap? _processedImage;

    public MainWindowViewModel()
    {
        CopyCommand = new RelayCommand(OnCopy);
        GrayscaleCommand = new RelayCommand(OnGrayscale);
        SepiaCommand = new RelayCommand(OnSepia);
        InvertCommand = new RelayCommand(OnInvert);
        HistogramCommand = new RelayCommand(OnHistogram);
        ResetCommand = new RelayCommand(OnReset);
        LoadBasicImageCommand = new AsyncRelayCommand(OnLoadBasicImage);
        SaveImageCommand = new AsyncRelayCommand(OnSaveImage);
    }

    public ICommand CopyCommand { get; }
    public ICommand GrayscaleCommand { get; }
    public ICommand SepiaCommand { get; }
    public ICommand InvertCommand { get; }
    public ICommand HistogramCommand { get; }
    public ICommand ResetCommand { get; }
    public ICommand LoadBasicImageCommand { get; }
    public ICommand SaveImageCommand { get; }

    private async Task OnLoadBasicImage()
    {
        var dialog = new OpenFileDialog
        {
            Filters =
            {
                new FileDialogFilter { Name = "Images", Extensions = { "png", "jpg", "jpeg" } }
            }
        };

        var result = await dialog.ShowAsync(GetMainWindow());
        if (result != null && result.Length > 0)
        {
            var bmp = _processor.LoadImage(result[0]);
            BasicImage = ConvertToAvaloniaBitmap(bmp);
        }
    }

    private async Task OnSaveImage()
    {
        var dialog = new SaveFileDialog
        {
            Filters =
            {
                new FileDialogFilter { Name = "PNG Image", Extensions = { "png" } }
            }
        };

        var path = await dialog.ShowAsync(GetMainWindow());
        if (!string.IsNullOrEmpty(path))
            _processor.SaveImage(path);
    }

    private void OnCopy()
    {
        _processor.Copy();
        UpdateProcessed();
    }

    private void OnGrayscale()
    {
        _processor.Grayscale();
        UpdateProcessed();
    }

    private void OnSepia()
    {
        _processor.Sepia();
        UpdateProcessed();
    }

    private void OnInvert()
    {
        _processor.Invert();
        UpdateProcessed();
    }

    private void OnHistogram()
    {
        _processor.DrawHistogram();
        UpdateProcessed();
    }

    private void OnReset()
    {
        _processor.Reset();
        BasicImage = null;
        ProcessedImage = null;
        UpdateProcessed();
    }

    private void UpdateProcessed()
    {
        var bmp = _processor.GetImage();
        if (bmp != null)
            ProcessedImage = ConvertToAvaloniaBitmap(bmp);
    }

    private static Bitmap? ConvertToAvaloniaBitmap(SKBitmap? skBmp)
    {
        if (skBmp == null) return null;

        using var image = SKImage.FromBitmap(skBmp);
        using var data = image.Encode(SKEncodedImageFormat.Png, 100);
        using var ms = new MemoryStream(data.ToArray());
        return new Bitmap(ms);
    }
    
    private static Window GetMainWindow()
    {
        return (Application.Current?.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)
            ?.MainWindow!;
    }
}