using System;
using System.Threading;

class Program
{

    static void Main(string[] args)
    {
        I1 nu1 = new numbercruncher();
        I2 nu2 = new numbercruncher();
        ((I1)nu1).implementation(); //used number in IExcu, declared there, implemented in numbercruncher
        ((I2)nu2).implementation(); //used number in IExcu, declared there, implemented in numbercruncher
        numbercruncher nu = new numbercruncher();
        Console.Read();
        Thread.Sleep(200);
        Console.WriteLine("storage: " + ((IStorage)nu).number());//used number in IStorage, declared there, implemented in numbercruncher
        Console.Read();
        Console.WriteLine("Excu: " + ((IExcu)nu).number()); //used number in IExcu, declared there, implemented in numbercruncher
        Thread.Sleep(200);
        Console.Read();
        Console.Read();
        Console.WriteLine("Loose: " + (nu.LooseString())); //used number in IExcu, declared there, implemented in numbercruncher
        Console.Read();
        Console.Read();
    }
}

public class numbercruncher : I1, I2, IStorage, IExcu, ILoose
{
    int zooi1 = 1, zooi2 = 3, zooi3 = 8, zooi4 = 2;
    void I1.implementation()
    {
        Console.WriteLine("I1 implementation");
    }
    void I2.implementation()
    {
        Console.WriteLine("I2 implementation");
    }
    int IStorage.number()
    {
        return zooi1 + zooi2 + zooi3 + zooi4;
    }
    int IExcu.number()
    {
        return zooi1 + zooi2;
    }

    public string LooseString()
    {
        return "This is a string from ILoose.";
    }
}
public interface ILoose { string LooseString();}
public interface I1 { void implementation();}
public interface I2 { void implementation();}

public interface IStorage { int number(); }
public interface IExcu { int number(); }
