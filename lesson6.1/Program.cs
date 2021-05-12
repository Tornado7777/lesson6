/*Написать консольное приложение Task Manager, которое выводит на экран запущенные 
 * процессы и позволяет завершить указанный процесс. Предусмотреть возможность 
 * завершения процессов с помощью указания его ID или имени процесса. В качестве 
 * примера можно использовать консольные утилиты Windows tasklist и taskkill.
 */
using System;
using System.Diagnostics;

namespace lesson6._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Process[] procces_list = Process.GetProcesses();
            Console.WriteLine("Имя процесса                             ID ");
            Console.WriteLine("===================================== ======== ");
            foreach (System.Diagnostics.Process process in procces_list)
            {
                string process_id = process.Id.ToString();
                string space = Lengh_space(process.ProcessName);
                Console.WriteLine(process.ProcessName + space + process_id);
            }
            Console.WriteLine("Введите имя процесса или его ID для его остановки и нажмите клавишу ВВОД:");
            string target_name = Console.ReadLine();
            string message = Kill_process(target_name);
            Console.WriteLine(message);

        }
        static string Kill_process(string target_name)
        {
            string message = "Процесс не найден";
            Process[] procces_list = Process.GetProcesses();
            foreach (System.Diagnostics.Process process in procces_list)
            {
                string process_name = process.ProcessName;
                int Id_process = 2_000_000;
                try
                {
                    Id_process = Convert.ToInt32(target_name);
                }
                catch
                {
                }
                if ( process_name == target_name || process.Id ==Id_process )
                {
                    try
                    {
                        process.Kill();
                        message = "Процесс закрыт";
                    }
                    catch (Exception mes)
                    {
                        message = mes.Message;
                    }
                }
            }
            return message;
        }
        static string Lengh_space(string process_name)
        {
            string space = "";
            for (int i=0; i<40-process_name.Length;i++)
            {
                space += " ";
            }
            return space;
        }
    }
}
