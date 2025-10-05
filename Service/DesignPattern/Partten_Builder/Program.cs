using System;
using System.Runtime.InteropServices.WindowsRuntime;

public class Order
{
    public OrderType OrderType { get; }
    public BreadType BreadType { get; }
    public SauceType SauceType { get; }
    public VegetableType VegetableType { get; }

    public Order(OrderType orderType, BreadType breadType, SauceType sauceType, VegetableType vegetableType)
    {
        OrderType = orderType;
        BreadType = breadType;
        SauceType = sauceType;
        VegetableType = vegetableType;
    }

    public override string ToString()
    {
        return $"Order [OrderType={OrderType}, BreadType={BreadType}, SauceType={SauceType}, VegetableType={VegetableType}]";
    }
}

// ---------------------- Enums ----------------------
public enum BreadType
{
    SIMPLE, OMELETTE, FRIED_EGG, GRILLED_FISH, PORK, BEEF
}

public enum OrderType
{
    ON_SITE, TAKE_AWAY
}

public enum SauceType
{
    SOY_SAUCE, FISH_SAUCE, OLIVE_OIL, KETCHUP, MUSTARD
}
public enum VegetableType
{
    SALAD, CUCUMBER, TOMATO
}

// ---------------------- Builder ----------------------
public class OrderBuilder
{
    private OrderType orderType;
    private BreadType breadType;
    private SauceType sauceType;
    private VegetableType vegetableType;

    public OrderBuilder SetOrderType(OrderType orderType)
    {
        this.orderType = orderType;
        return this;
    }

    public OrderBuilder SetBreadType(BreadType breadType)
    {
        this.breadType = breadType;
        return this;
    }

    public OrderBuilder SetSauceType(SauceType sauceType)
    {
        this.sauceType = sauceType;
        return this;
    }

    public OrderBuilder SetVegetableType(VegetableType vegetableType)
    {
        this.vegetableType = vegetableType;
        return this;
    }

    public Order Build()
    {
        return new Order(orderType, breadType, sauceType, vegetableType);
    }
}
public interface IOrderBuilder
{
    IOrderBuilder OrderType(OrderType orderType);
    IOrderBuilder OrderBread(BreadType breadType);

    IOrderBuilder OrderSauce(SauceType sauceType);
    IOrderBuilder OrderVegetable(VegetableType vegetableType);
    Order Build();
}
public class FastFoodOrderBuilder : IOrderBuilder
{
    private OrderType _orderType;
    private BreadType _breadType;
    private SauceType _sauceType;
    private VegetableType _vegetableType;

    public IOrderBuilder OrderType(OrderType orderType)
    {
        _orderType = orderType;
        return this;
    }

    public IOrderBuilder OrderBread(BreadType breadType)
    {
        _breadType = breadType;
        return this;
    }

    public IOrderBuilder OrderSauce(SauceType sauceType)
    {
        _sauceType = sauceType;
        return this;
    }

    public IOrderBuilder OrderVegetable(VegetableType vegetableType)
    {
        _vegetableType = vegetableType;
        return this;
    }
    public Order Build()
    {
        return new Order(_orderType, _breadType, _sauceType, _vegetableType);
    }
}
// ---------------------- Client ----------------------
public class Program
{
    public static void Main(string[] args)
    {
        Order order = new OrderBuilder()
                        .SetOrderType(OrderType.ON_SITE)
                        .SetBreadType(BreadType.BEEF)
                        .SetSauceType(SauceType.KETCHUP)
                        .SetVegetableType(VegetableType.TOMATO)
                        .Build();
        Console.WriteLine(order);
        Console.ReadKey();
    }
}
