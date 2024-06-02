using System;
using System.Collections.Generic;

abstract class Subscription
{
    public double MonthlyFee { get; protected set; }
    public int MinimumSubscriptionPeriod { get; protected set; }
    public List<string> IncludedChannels { get; protected set; }

    public Subscription(double monthlyFee, int minimumSubscriptionPeriod, List<string> includedChannels)
    {
        MonthlyFee = monthlyFee;
        MinimumSubscriptionPeriod = minimumSubscriptionPeriod;
        IncludedChannels = includedChannels;
    }
}

class DomesticSubscription : Subscription
{
    public DomesticSubscription() : base(10.99, 1, new List<string> { "News", "Entertainment" })
    {
    }
}

class EducationalSubscription : Subscription
{
    public EducationalSubscription() : base(15.99, 6, new List<string> { "Documentary", "Educational" })
    {
    }
}

class PremiumSubscription : Subscription
{
    public PremiumSubscription() : base(29.99, 12, new List<string> { "All Channels", "On-demand" })
    {
    }
}

interface ISubscriptionFactory
{
    Subscription CreateSubscription();
}

class WebSite : ISubscriptionFactory
{
    public Subscription CreateSubscription()
    {
        return new DomesticSubscription();
    }
}

class MobileApp : ISubscriptionFactory
{
    public Subscription CreateSubscription()
    {
        return new EducationalSubscription();
    }
}

class ManagerCall : ISubscriptionFactory
{
    public Subscription CreateSubscription()
    {
        return new PremiumSubscription();
    }
}

class Program
{
    static void Main(string[] args)
    {
        ISubscriptionFactory websiteFactory = new WebSite();
        Subscription websiteSubscription = websiteFactory.CreateSubscription();

        ISubscriptionFactory appFactory = new MobileApp();
        Subscription appSubscription = appFactory.CreateSubscription();

        ISubscriptionFactory callFactory = new ManagerCall();
        Subscription callSubscription = callFactory.CreateSubscription();

        Console.WriteLine("Website Subscription:");
        DisplaySubscriptionInfo(websiteSubscription);

        Console.WriteLine("\nMobile App Subscription:");
        DisplaySubscriptionInfo(appSubscription);

        Console.WriteLine("\nManager Call Subscription:");
        DisplaySubscriptionInfo(callSubscription);
    }

    static void DisplaySubscriptionInfo(Subscription subscription)
    {
        Console.WriteLine($"Monthly Fee: {subscription.MonthlyFee}");
        Console.WriteLine($"Minimum Subscription Period: {subscription.MinimumSubscriptionPeriod} months");
        Console.WriteLine("Included Channels:");
        foreach (var channel in subscription.IncludedChannels)
        {
            Console.WriteLine($"- {channel}");
        }
    }
}
