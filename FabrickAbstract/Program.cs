using System;

namespace FabrickAbstract {
abstract class Device
{
    public abstract string Name { get; }
}

class Laptop : Device
{
    public override string Name => "Laptop";
}

class Netbook : Device
{
    public override string Name => "Netbook";
}

class EBook : Device
{
    public override string Name => "EBook";
}

class Smartphone : Device
{
    public override string Name => "Smartphone";
}

abstract class DeviceFactory
{
    public abstract Device CreateDevice();
}

class IProneFactory : DeviceFactory
{
    public override Device CreateDevice()
    {
        return new Smartphone();
    }
}

class KiaomiFactory : DeviceFactory
{
    public override Device CreateDevice()
    {
        return new Laptop();
    }
}

class BalaxyFactory : DeviceFactory
{
    public override Device CreateDevice()
    {
        return new EBook();
    }
}

class Program
{
    static void Main(string[] args)
    {
        DeviceFactory factory1 = new IProneFactory();
        Device device1 = factory1.CreateDevice();

        DeviceFactory factory2 = new KiaomiFactory();
        Device device2 = factory2.CreateDevice();

        DeviceFactory factory3 = new BalaxyFactory();
        Device device3 = factory3.CreateDevice();

        Console.WriteLine($"Device 1: {device1.Name}");
        Console.WriteLine($"Device 2: {device2.Name}");
        Console.WriteLine($"Device 3: {device3.Name}");
    }
}
}