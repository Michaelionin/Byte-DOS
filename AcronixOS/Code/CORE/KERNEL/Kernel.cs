using System;
using Sys = Cosmos.System;
using AcronixOS.Code.CORE.terminal;
using AcronixOS.Code.CORE.System32.HARDWARE.MEMCOUNT;
using AcronixOS.Code.CORE.System32.HARDWARE.FAT;
using AcronixOS.Code.CORE.System32.HARDWARE.Network;
using AcronixOS.Code.CORE.System32.Configurations;


namespace Kernel
{
    public class Kernel : Sys.Kernel
    {

        protected override void BeforeRun()
        {
            Console.Clear(); // Очищаем дисплей
            Console.WriteLine("[INFO] Byte-DOS Kernel Version "+ registry32.OS_Version+" loaded.");
            Console.WriteLine("[INFO] Checking system ram amount..."); 
            MEMCOUNT.Initialize(); // Подсчитываем ОЗУ
            Console.WriteLine("[INFO] Command prompt loading...");
            CommandManager.Initialize(); // Инициализания Терминала
            Console.WriteLine("[INFO] Loading the IDE Controller...");
            Sys.Global.Init(GetTextScreen(), false, false, false, true); // Инициализацмя IDE-Дисков
            Console.WriteLine("[INFO] IDE controller initialized");
            Console.WriteLine("[INFO] Initializing the virtual file system...");
            PMFAT.Initialize(); // Инициализация дискового пространства
            Console.WriteLine("[INFO] Attempting DHCP autoconfig...");
            DHCP.Initialize(); // Инициализация сети
        }

        protected override void Run()
        {
            Console.Clear(); // Очищаем дисплей
            Console.WriteLine("Welcome to Byte-DOS  v" + registry32.OS_Version, Console.ForegroundColor = ConsoleColor.Green);
            Console.Write("To display a list of commands, type: ", Console.ForegroundColor = ConsoleColor.White); Console.WriteLine("HELP", Console.ForegroundColor = ConsoleColor.Green);
            

            CommandManager.GetInput(); // Получение строки терминала
        }





    }
}
