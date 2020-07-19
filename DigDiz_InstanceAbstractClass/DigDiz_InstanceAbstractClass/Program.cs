using System;
using System.Reflection;

namespace DigDiz_InstanceAbstractClass
{
    class Program
    {
        static void Main(string[] args)
        {
            Type type;
            type = typeof(MyAvatractClass);
            ConstructorInfo Constructor = type.GetConstructor(Type.EmptyTypes);
            object ClassObject = Constructor.Invoke(new object[] { });
        }
    }

    public abstract class MyAvatractClass
    {
        public MyAvatractClass()
        {

        }
        public static void Print()
        {
            Console.WriteLine("Hello!");
        }
    }
}
