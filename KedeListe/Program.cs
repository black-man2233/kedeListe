﻿// See https://aka.ms/new-console-template for more information

using KedeListe.Models;
using Xunit.Sdk;


ChainList<string> test = new();
test.Add_First("asd");
test.Add_First("aa");
test.Add_First("first");
test.Add("last");


Console.WriteLine(test.To_String());