namespace ConsoleApp1;

public class FreezeContainer : Container
{
    public string AllowedProduct { get; set; }
    private double _minTemperature;

    public double MinTemperature
    {
        get => _minTemperature;
        set
        {
            if (value > _containerTemperature)
            {
                throw new ArgumentException("Nie można zmienić wymaganej temperatury na mniejszą niż obecna.");
            }
            _minTemperature = value;
        }
    }

    private double _containerTemperature;
    
    public double ContainerTemperature
    {
        get => _containerTemperature;
        set
        {
            if (value < _minTemperature)
            {
                throw new ArgumentException("Nie można zmienić temperatury na mniejszą od wymaganej.");
            }
            _containerTemperature = value;
        }
    }
    
    public FreezeContainer(int height, int weight, int depth, double maxCargoWeight, string allowedProduct, double minTemperature, double containerTemperature) : base(height, weight, depth, maxCargoWeight)
    {
        if (_containerTemperature < _minTemperature)
        {
            throw new ArgumentException("Temperatura w kontenerze chłodniczym mniejsza od wymaganej.");
        }
        SerialString = "KON-C-" + CurrentSerialNumber;
        CurrentSerialNumber++;
        AllowedProduct = allowedProduct;
        _minTemperature = minTemperature;
        _containerTemperature = containerTemperature;
    }

    public void LoadContainer(double loadWeight, string productName)
    {
        if (productName != AllowedProduct)
        {
            throw new ArgumentException($"Produkt o nazwie: {productName} nie może być przechowywany w tym kontenerze.");
        }
        base.LoadContainer(loadWeight);
    }
    public override void PrintInfo()
    {
        Console.WriteLine("Kontener chłodniczy");
        base.PrintInfo();
        Console.WriteLine("Dozwolony rodzaj produktu: " + AllowedProduct);
        Console.WriteLine("Temperatura w kontenerze: " + ContainerTemperature);
        Console.WriteLine("Minimalna temperatura: " + MinTemperature);
    }
}