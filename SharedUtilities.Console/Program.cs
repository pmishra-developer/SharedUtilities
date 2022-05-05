// See https://aka.ms/new-console-template for more information

using SharedUtilities.Console;
using SharedUtilities.Extensions;

Console.WriteLine("Shared Utilities Demo");
Console.WriteLine("----------------------");
Console.WriteLine(Environment.NewLine);

var testValue = "not-started";
var statusEnumValue = testValue.GetEnumValueFromDescription<StatusEnum>();
Console.WriteLine($"Using Description Attribute: The Enum representation for {testValue} is {statusEnumValue}");





