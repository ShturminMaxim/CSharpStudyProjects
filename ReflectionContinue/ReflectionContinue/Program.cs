using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionContinue
{
    class Program
    {
        static void Main(string[] args)
        {
            // Динамическое создание Сборки с классом

            // создаем сборку
            // класс AssemblyName
            // затем AssemblyBilder - аоздает сборку
            
            AssemblyName an = new AssemblyName("MyAssembly");
            // версия сборки
            an.Version = new Version("1.0.0.1");

            //Конструируется сборка
            AssemblyBuilder ab = AppDomain.CurrentDomain.DefineDynamicAssembly(an, AssemblyBuilderAccess.RunAndSave);

            //создаем модуль для сборки черезх нашу сборку
            ModuleBuilder mb = ab.DefineDynamicModule("MyModule", "MyAssembly.dll");

            //создаем тип для модуля
            TypeBuilder tb = mb.DefineType("MyClass", TypeAttributes.Public);

            //Создадим поля для класса
            FieldBuilder fb = tb.DefineField("number", typeof(int), FieldAttributes.Private);

            //Так же создадим аргументы для конструктора
            Type[] parameters = { typeof(int) };

            //нужно наполнять тип, изч  чего будет состоять класс.
            //создадим конструктор и добавим туда код.
            ConstructorBuilder cb1 = tb.DefineConstructor(MethodAttributes.Public, CallingConventions.Standard, parameters);

            //Добавим код в констурктор через IL генератор
            ILGenerator il1 = cb1.GetILGenerator();
            il1.EmitWriteLine("этот текст отобразится в консоли при создании экземпляра класса");
            
            //Ldarg(вызов аргументов) - получили первый параметр.
            il1.Emit(OpCodes.Ldarg_0);

            //вызов базового контруктора Object-a
            il1.Emit(OpCodes.Call, typeof(object).GetConstructor(Type.EmptyTypes));
            il1.Emit(OpCodes.Ldarg_0);
            il1.Emit(OpCodes.Ldarg_1);

            //Устанавливаем значение поля
            il1.Emit(OpCodes.Stfld, fb);
            il1.EmitWriteLine(fb);

            //необходимо выполнить завершение для IL конструкции
            // Ret - return осуществляет выход из конструктора
            il1.Emit(OpCodes.Ret);

            //когда тип уже создан, создаем его
            tb.CreateType();

            //сохраняем сборку в файл
            ab.Save("MyAssembly.dll");
        }
    }
}
