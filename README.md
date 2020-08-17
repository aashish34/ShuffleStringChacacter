# Random String Generator

Given an input string. It returns the same string with random order.

# Steps to execute the application

### Prerequisite
.Net Core 2.2

 1. Extract the zip to any location on your computer
 2. On command prompt type **cd {PATH_TO_THE_EXTRACTED_FILE}\RandomStringGenerator\RandomStringGenerator\bin\Debug\netcoreapp2.2**
 3. Type command "**dotnet.exe RandomStringGenerator.dll 
 4. Enter the string:

## Console Output

Hello world
====== Simple one line solution =========

 Generated Random String:rwlH lldooe


====== Using random solution =========

 Generated Random String:rwd Hlloeol


====== Thread safe solution =========

 Generated Random String:lldelo rHow



 
 ### NuGet Package

 #### ProximitySearch solution
 1. Added Microsoft.Extensions.DependencyInjections 
 2. Added Microsoft.CodeAnalysis.Metrics

  #### UnitTest solution
 1. Added NUnit 3.12
 2. Added Microsoft.NET.Test.Sdk 16.7
 3. Added NUnit3TestAdapter 3.17


# Application Architecture

```
Console ->> RequestValidator: Validate input data
Console ->> Shuffle String: Ranomized string using three solution
```
## Algorithm - Solution 1 - Simple one liner

# Explantion

Simple one liner Linq solution but  it will be slow with bigger list.
It uses slightly less code, that though comes as the expense of having less range - because it uses hex instead of base64 
it takes more characters to represent the same range compared the other solutions.
Here OrderBy uses a QuickSort variant to sort the items by their (ostensibly random) keys. QuickSort performance is O(N2).

**Time Complexity** : O(N2)
**Space Complexity:** O(n) (n is the no of words)

## Algorithm - Solution 2 - Using random solution

# Explantion

System.Random is not thread-safe. So if you use this code in a heavily concurrent system, it's possible for two requests to get the same value.
So it unsuitable for anything security related, such as creating passwords or tokens.
We can use this solution; it will be useful for gaming or internal validation etc.

**Time Complexity** : O(n log n)
**Space Complexity:** O(n) (n is the no of words

## Algorithm - Solution 3 - Thread safe Fisher yates solution ( The best solution)

# Explantion
 
This is the best solution. It is implemented with Fisher-Yates algoritham and it is the fasted one. It has a time complexity of O(N). 
It is implemnted with thread safe consideration. So any of the system use this code heavily with concurrent application even thought it will not generate duplicate values.
This is best to use with password generation, session id generation or handed out to untrusted parties etc.

**Time Complexity** : O(N)
**Space Complexity:** O(n) (n is the no of words)


**Cyclomatic Complexity of FindProximityMatchKeyword()**: 2

**Maintainability Index of Project** : 98

