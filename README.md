## This is an add-in for [Fody](https://github.com/Fody/Fody/) 

![Icon](https://raw.github.com/hmemcpy/Mvid.Fody/master/Icons/package_icon.png)

Adds the ability to specify the assembly MVID (Module Version Id).

According to the [Standard ECMA 335 - Common Language Infrastructure (CLI)](http://www.ecma-international.org/publications/standards/Ecma-335.htm) specification, the MVID value should be a random Guid each time the assembly is rebuilt:

> The Mvid column shall index a unique GUID in the GUID heap (§24.2.5) that identifies this instance of the
> module.  The Mvid can be ignored on read by conforming implementations of the CLI. The Mvid should be
> newly generated for every module, using the algorithm specified in ISO/IEC 11578:1996 (Annex A) or another
> compatible algorithm.

`ECMA-335.pdf`, page 265.

This means, **USE AT YOUR OWN RISK!**

## The nuget package  [![NuGet Status](http://img.shields.io/nuget/v/Mvid.Fody.svg?style=flat)](https://www.nuget.org/packages/Mvid.Fody/)

https://nuget.org/packages/Mvid.Fody/

    PM> Install-Package Mvid.Fody
    
### Usage

Add the following declaration to your code (typically, `AssemblyInfo.cs`):

    [assembly: Mvid("your-guid-string)"]

Note: the GUID string can be in any format that is supported by [`Guid.Parse`](https://msdn.microsoft.com/en-us/library/system.guid.parse.aspx).
    
The compiled assembly will have an MVID value of the specified GUID, and the custom `MvidAttribute` will be removed from the assembly.

## Icon

Icon courtesy of [The Noun Project](http://thenounproject.com)
