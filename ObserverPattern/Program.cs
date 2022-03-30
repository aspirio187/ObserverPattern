using ObserverPattern;

// Create the handler
SaleHandler saleHandler = new SaleHandler();

// Create the monitors and subscribe them to the handler
InventoryMonitor inventoryMonitor = new InventoryMonitor("Inventory-I2");
inventoryMonitor.Subscribe(saleHandler);
AccountingMonitor accountingMonitor = new AccountingMonitor("Account-A5");
accountingMonitor.Subscribe(saleHandler);

// Start the program

DisplayMenu();

int choice = EncodeInteger();

while (choice != 0)
{
    Order order = new Order()
    {
        Car = ChoseCar(),
        Quantity = ChoseQuantity(),
    };

    order.Price = DefinePrice(order.Car);

    saleHandler.MakeOrder(order);

    Console.ReadKey();

    DisplayMenu();

    choice = EncodeInteger();
}

static void DisplayMenu()
{
    Console.WriteLine("Car order");
    Console.WriteLine("---------");
    Console.WriteLine("1. Order car");
    Console.WriteLine("0. Exit");
}

static Brands ChoseCar()
{
    Console.Clear();
    Console.WriteLine("Car order : Car selection");
    Console.WriteLine("-------------------------");
    Console.WriteLine();

    int choice = -1;
    string[] brandNames = Enum.GetNames(typeof(Brands));

    while (choice < 0 || choice > brandNames.Length)
    {
        int i = 0;
        foreach (string car in brandNames)
        {
            Console.WriteLine($"{i} - {car}");
            i++;
        }

        Console.WriteLine("Chose a car by its id");
        choice = EncodeInteger();
    }

    return (Brands)choice;
}

static int ChoseQuantity()
{
    Console.Clear();
    Console.WriteLine("Order Car : Quantity definition");
    Console.WriteLine("-------------------------------");
    Console.WriteLine();
    Console.WriteLine("Chose quantity you want to buy");

    int quantity = EncodeInteger();
    while (quantity < 1)
    {
        Console.WriteLine("You need to order at least one car");
        quantity = EncodeInteger();
    }

    return quantity;
}

static decimal DefinePrice(Brands brand)
{
    switch (brand)
    {
        case Brands.Mercedes: return 95223.52M;
        case Brands.BMW: return 65453.23M;
        case Brands.Toyota: return 46444.25M;
        case Brands.Renault: return 15223.54M;
        case Brands.Ferrari: return 254653.23M;
        default:
            return 0;
    }
}

static int EncodeInteger()
{
    string? value = Console.ReadLine();
    int returnValue = -1;
    while (!int.TryParse(value, out returnValue))
    {
        Console.WriteLine("Please enter an integer value!");
        value = Console.ReadLine();
    }

    return returnValue;
}