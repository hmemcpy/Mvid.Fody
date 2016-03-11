## This is an add-in for [Fody](https://github.com/Fody/Fody/) 

![Icon](https://raw.github.com/hmemcpy/Mvid.Fody/master/Icons/package_icon.png)

Adds the ability to specify the assembly MVID (Module Version Id).

[Introduction to Fody](http://github.com/Fody/Fody/wiki/SampleUsage)

## The nuget package  [![NuGet Status](http://img.shields.io/nuget/v/Mvid.Fody.svg?style=flat)](https://www.nuget.org/packages/MethodTimer.Fody/)

https://nuget.org/packages/Mvid.Fody/

    PM> Install-Package Mvid.Fody
    
### Usage

Add the following definition to your code (typically, `AssemblyInfo.cs`):

    [assembly: Mvid("your-guid-string"]
    
The compiled assembly will have an MVID value of the specified Guid.

## Icon

Icon courtesy of [The Noun Project](http://thenounproject.com)
