// // Hvad er en delegate
// // for at forstå delegates, skal man også forstå objekter og referencer.
// using System;

// class Program
// {
//     public static void Main(string[] args)
//     {
//         Person me = new Person();
//         me.GoShopping();
//     }
// }
// class Person
// {
//     public delegate void Buy(object o);
//     public delegate int BeautifulDelegate(int o);
//     public int moneyToBuyWith = 500;
//     public void GoShopping()
//     {
//         DairySection dairy = new DairySection(this);
//         SodaSection soda = new SodaSection(this);
//         // Makes delegate reference variable in current context.
//         Buy ToBuyList;
//         // Assigns method bodies to the delegate.
//         ToBuyList = dairy.BuyHam;
//         ToBuyList += soda.BuySoda;
//         ToBuyList += dairy.BuyCheese;
//     }

//     public void TestBeautifulDelegate()
//     {
//         BeautifulDelegate instance;
//         instance = ReturnFive;
//         instance += ReturnSomeValue;
//         Console.WriteLine(instance(7));
//     }
//     public int ReturnFive(int o)
//     {
//         if (o>5)
//         {
//             return 5;
//         }
//         o = -1;
//         return o;
//     }
//     public int ReturnSomeValue(int o)
//     {
//         return (o * o * o);
//     }
// }
// class SodaSection
// {
//     private Person personInSodaSection;
//     public SodaSection(Person thisPerson)
//     {
//         personInSodaSection = thisPerson;
//     }

//     public int moneyToBuyWith
//     {
//         get => personInSodaSection.moneyToBuyWith;
//         set => personInSodaSection.moneyToBuyWith = value;
//     }

//     public void BuySoda(object obj)
//     {
//         moneyToBuyWith -= 21;
//     }
// }
// class DairySection
// {
//     private Person personInDairySection;

//     public int moneyToBuyWith
//     {
//         get => personInDairySection.moneyToBuyWith;
//         set => personInDairySection.moneyToBuyWith = value;
//     }

//     public DairySection(Person thisPerson)
//     {
//         personInDairySection = thisPerson;
//     }
//     public void BuyHam(object o)
//     {
//         moneyToBuyWith -= 11;
//     }
//     public void BuyCheese(object o)
//     {
//         moneyToBuyWith -= 31;
//     }
// }