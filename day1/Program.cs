/*
                                        SECTION 1
In C#, the keyword "static" is used to declare a member of a class that belongs to the type itself, rather than to a specific instance of that type.

Static members are shared by all instances of the class and can be accessed without creating an instance of the class. This makes them useful for creating utility methods or constants that are used throughout the program.

There are several types of static members in C#, including:

Static fields - These are variables that are shared by all instances of a class. They are initialized only once, when the class is first accessed.
Static methods - These are methods that can be called without creating an instance of a class. They can only access static members of the class.
Static constructors - These are special methods that are called only once, when the class is first accessed. They are used to initialize static members of the class.

Here is an example of how to declare a static member in C#:
*/
public class MyClass1
{
    public static int MyStaticField = 42;

    public static void MyStaticMethod()
    {
        Console.WriteLine("Hello from MyStaticMethod!");
    }

    static MyClass1()
    {
        Console.WriteLine("MyClass constructor called.");
    }
}
// In this example, "MyStaticField" is a static field, "MyStaticMethod" is a static method, and the "MyClass" constructor is a static constructor.
/*
                                      SECTION 2
If you do not use the "static" keyword when declaring a member of a class, that member will be an instance member. This means that it belongs to a specific instance of the class, rather than to the class itself.

Each instance of the class will have its own copy of the instance member, and changes made to the member will only affect that particular instance. This is in contrast to a static member, which is shared by all instances of the class.

Here is an example to illustrate the difference between static and instance members:
*/
public class MyClass2
{
    public int MyInstanceField = 42;
    public static int MyStaticField = 123;

    public void MyInstanceMethod()
    {
        Console.WriteLine("Hello from MyInstanceMethod! MyInstanceField = {0}", MyInstanceField);
    }

    public static void MyStaticMethod()
    {
        Console.WriteLine("Hello from MyStaticMethod! MyStaticField = {0}", MyStaticField);
    }
}

/*
In this example, "MyInstanceField" and "MyInstanceMethod" are instance members, while "MyStaticField" and "MyStaticMethod" are static members.

To access an instance member, you need to create an instance of the class:
MyClass obj = new MyClass();
obj.MyInstanceMethod();

To access a static member, you can use the class name directly:
MyClass.MyStaticMethod(); // output: "Hello from MyStaticMethod! MyStaticField = 123"
*/
