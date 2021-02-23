# GSFS Developer Evaluation
Welcome! This repository contains everything you need to know in order to complete the developer evaluation. If you have questions along the way, please email the team members listed below. Otherwise, relax and have fun!

## Overview
The point of this evaulation is to give you an opportunity to show us what you do best! There aren't necessarily right or wrong answers. Think of it more as a way to demonstrate your ability to solve problems with well-written code.  We want to see your code in action! 

## Instructions
The evaluation is considered complete when you A) perform the setup tasks, B) complete each challenge, and C) submit your answers.

The answers you submit should build. Any tests written to validate your answers should pass.

### Requirements
In order to complete the evaluation you will need the following:

* Internet connectivity (at least once or twice)
* A computer with `git` installed

### Setup
Getting started is easy. Simply clone this repository and follow the instructions on each of the challenges. If you are unable to complete a challenge for any reason, just let us know when you submit your answers.

### Challenge One
The [electronic color code](https://en.wikipedia.org/wiki/Electronic_color_code) is used to indicate the values of ratings of electronic components. Most often, this system is used for thru-hole resistors. To complete this challenge, write a C# class that implements the following interface. Feel free to include supporting types or any other code you think would be helpful.

```csharp
public interface ICalculateOhmValues
{
    /// <summary>
    /// Calculates the Ohm value of a resistor based on the band colors.
    /// </summary>
    /// <param name="bandAColor">The color of the first figure of component value band.</param>
    /// <param name="bandBColor">The color of the second significant figure band.</param>
    /// <param name="bandCColor">The color of the decimal muliplier band.</param>
    /// <param name="bandDColor">The color of the tolerance value band.</param>
    int CalculateOhmValue(string bandAColor, string bandBColor, string bandCColor, string bandDColor)
}
```

### Challenge Two
Using your favorite unit test framework, write the unit tests you feel are necessary to test the code you write as your answer to the first challenge.

### Challenge Three
Write an alternative implementation of the following method in C#.

```csharp
/// <summary>
/// Gets a sub-item summary for a given item number.
/// </summary>
/// <param name="itemNumber">The item number of the item to get the sub-item summary of.</param>
public SubItemSummary[] GetSubItemSummary(string itemNumber)
{
    IEnumerable<Item> subItems = GetSubItems(itemNumber);

    List<SubItemSummary> subItemSummary = new List<SubItemSummary>();

    foreach (Item item in subItems)
    {
        IEnumerable<SubItemSummary> tempSummaries = TransformSubItems(item, item.GetSubItems());

        subItemSummary.AddRange(tempSummaries);
    }

    return subItemSummary.ToArray();
}
```

### Challenge Four
Write a JavaScript/TypeScript function that will return `true` if the parenthesis, brackets, and braces in a given string are all closed and `false` otherwise. For example:

```
([((({()})))])     // true
([((({()}))))      // false
```

### Challenge Five
Go nuts! Show us some code that you're particularly proud of. It could be an algorithm, an `npm` or NuGet library, some really wicked HTML/CSS, or even a whole application! Feel free to link to your public GitHub (or equivalent) repository if necessary.

### Submit
Please upload your work to a GitHub repository, and send us an email with a link to your GitHub repository. Send the email to the following addresses:

* jdentler@gsfsgroup.com
* shorton@gsfsgroup.com
* rjones@gsfsgroup.com
* hmcbride@gsfsgroup.com

If you choose to keep your repository private, please grant access to the following GitHub users:
* brian23bush
* gregmajor
* heatherRose
* jasondentler
* rickj33
* wshorton


