[![Six.BankMaster NuGet package](https://img.shields.io/nuget/v/Six.BankMaster?logo=nuget&logoColor=white)](https://www.nuget.org/packages/Six.BankMaster/) [![Build status](https://img.shields.io/appveyor/build/0xced/six-bankmaster/main?logo=appveyor&logoColor=white)](https://ci.appveyor.com/project/0xced/six-bankmaster/branch/main)

# About

**Six.BankMaster** is a Refit-based C# client to access [SIX Bank Master data](https://www.six-group.com/en/products-services/banking-services/interbank-clearing/online-services/download-bank-master.html). It targets .NET Standard 2.0 and is thus usable from both .NET Framework and .NET Core.

# Usage

Here is some sample code that demonstates how to list all banks retrieved from the Bank Master service.

```csharp
using System;
using System.Linq;
using System.Threading.Tasks;
using Six.BankMaster;

namespace SampleCode
{
    class Program
    {
        private static async Task<int> Main()
        {
            try
            {
                var client = BankMasterClientFactory.CreateSystemTextJsonClient();
                var masterData = await client.GetMasterDataAsync();

                Console.WriteLine($"Valid for {masterData.MetaData.ValidForClearingDay}");
                foreach (var bank in masterData.Entries.Where(b => b.IidType == IidType.Headquarters))
                {
                    Console.WriteLine($"{bank.Iid} {bank.BankOrInstitutionName} / {bank.CountryCode}-{bank.ZipCode} {bank.PostalAddress ?? bank.DomicileAddress}");
                }
                return 0;
            }
            catch (Exception exception)
            {
                Console.Error.WriteLine(exception);
                return 1;
            }
        }
    }
}
```

# Release Notes

## Version 1.0.1

Fixed metadata for NuGet publishing (description and tags)

## Version 1.0.0

Initial release