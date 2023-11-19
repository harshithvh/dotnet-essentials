/*
when we talk about the CLR( Common Language Runtime) providing a "runtime environment," we mean that it provides the necessary 
services and features to manage the execution of code written in .NET programming languages.

CLR functionalities:
1. Memory management(allocation & de-allocation)
2. Convert MSIL code to Native code
3. Type safety
*/
/*
                           Section 2
Dynamic Link Library:
In C#, a .dll (Dynamic Link Library) is a file format used to store compiled code that can be used by other programs. A .dll file contains one or 
more compiled classes, functions, or resources that can be called and used by other programs.

When you compile a C# program, the compiler generates an executable (.exe) file that contains all the code and resources required to run the program. However, if you want to use some code from one program in another program, 
you can create a .dll file instead of an .exe file. The .dll file contains the code that you want to reuse, and you can reference it from other programs.

Using a .dll file can be helpful in situations where you have common code that is used in multiple programs, and you don't want to duplicate that code in each program. Instead, you can create a .dll file that
contains the common code and reference it from each program.

To use a .dll file in your C# program, you need to add a reference to the .dll file in your project. You can do this by right-clicking on your project in Solution Explorer, selecting "Add Reference," and browsing to the .dll file.
Once you have added the reference, you can use the classes, functions, and resources from the .dll file in your code.
*/
/*
                        Garbage Collector(GC)
In .NET, GC stands for "Garbage Collector". The Garbage Collector is a component of the .NET runtime that manages memory allocation and deallocation for managed code.

In a managed environment like .NET, the Garbage Collector automatically tracks and manages memory usage, so that developers don't need to manually allocate and deallocate memory. 
When an object is no longer being used, the Garbage Collector automatically frees up the memory it was using so that it can be used for other purposes.

GC works in the background
*/