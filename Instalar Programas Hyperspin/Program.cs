using System;
using System.Diagnostics;
using System.Threading;

namespace Instalar_Programas_Hyperspin
{
    class Program
    {
        private static string architecture = "x64";
        private static string windows = "Windows 10";//Microsoft Windows 10

        static void Main(string[] args)
        {

            architecture = HardwareInfo.GetOSInformation().Contains("64 bits") ? "x64" : "x86";
            windows = HardwareInfo.GetOSInformation().Contains("Microsoft Windows 10") ? "Windows 10" :
                HardwareInfo.GetOSInformation().Contains("Microsoft Windows 11") ? "Windows 11" : "Windows 7";

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Sistema de instalação automatica de programas do Hyperspin!");

            Console.WriteLine(string.Empty);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("|--------------------------------------------------------------|");
            Console.WriteLine("| Desenvolvido por: Lincon Viana                               |");
            Console.WriteLine("| Version: 0.0.1                                               |");
            Console.WriteLine("| Canal Youtube: @linconviana4013                              |");
            Console.WriteLine("|--------------------------------------------------------------|");

            Console.WriteLine(string.Empty);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("|----------------------------------------------------------------------------------------------|");
            Console.WriteLine(String.Format("| Sistema Operacional: {0}                           |", HardwareInfo.GetOSInformation()));
            Console.WriteLine(String.Format("| Processador: {0} |", HardwareInfo.GetProcessorInformation()));
            Console.WriteLine(String.Format("| Placa Mãe: {0}                                                                         |", HardwareInfo.GetBoardMaker()));
            Console.WriteLine(String.Format("| Usuario: {0}                                                                     |", HardwareInfo.GetComputerName()));
            Console.WriteLine("|----------------------------------------------------------------------------------------------|");
            Console.WriteLine(string.Empty);

            Process[] processosAtivos = Process.GetProcesses();
            foreach (var service in processosAtivos)
            {
                /// :: Fonte Bebas
                if (service.ProcessName == "fontview")
                    service.Kill();
                /// :: DirectX
                if (service.ProcessName == "directx_feb2010_redist")
                    service.Kill();
                /// :: Visual C++ 2005 x64
                if (service.ProcessName == "vcredist2005_x64")
                    service.Kill();
                /// :: Visual C++ 2008 x64
                if (service.ProcessName == "vcredist2008_x64")
                    service.Kill();
                /// :: Visual C++ 2010 x64
                if (service.ProcessName == "vcredist2010_x64")
                    service.Kill();
                /// :: Visual C++ 2012 x64
                if (service.ProcessName == "vcredist2012_x64")
                    service.Kill();
                /// :: Visual C++ 2013 x64
                if (service.ProcessName == "vcredist2013_x64")
                    service.Kill();
                /// :: Visual C++ 2015 x64
                if (service.ProcessName == "vcredist2015_2017_2019_x64")
                    service.Kill();

                /// :: Visual C++ 2005 x86
                if (service.ProcessName == "vcredist2005_x86")
                    service.Kill();
                /// :: Visual C++ 2008 x86
                if (service.ProcessName == "vcredist2008_x86")
                    service.Kill();
                /// :: Visual C++ 2010 x86
                if (service.ProcessName == "vcredist2010_x86")
                    service.Kill();
                /// :: Visual C++ 2012 x86
                if (service.ProcessName == "vcredist2012_x86")
                    service.Kill();
                /// :: Visual C++ 2013 x86
                if (service.ProcessName == "vcredist2013_x86")
                    service.Kill();
                /// :: Visual C++ 2015 x86
                if (service.ProcessName == "vcredist2015_2017_2019_x86")
                    service.Kill();
            }

            new Thread(new ThreadStart(new InstallSoftware(10000, architecture, windows).GetSoftware)).Start();

            /*Process processoAtual = Process.GetCurrentProcess();
                var processoRodando = (from proc in Process.GetProcesses()
                                       where proc.Id != processoAtual.Id &&
                                             proc.ProcessName == processoAtual.ProcessName
                                       select proc).FirstOrDefault();

                if (processoRodando != null)
                {
                    //MessageBox.Show("Já existe uma instancia do programa em execução");
                    return;
                }*/

            // Nome do processo atual
            /*string nomeProcesso = Process.GetCurrentProcess().ProcessName;

            // Obtém todos os processos com o nome do atual
            Process[] processes = Process.GetProcessesByName(nomeProcesso);

            // Maior do que 1, porque a instância atual também conta
            if (processes.Length > 1)
            {
                //MessageBox.Show("Já existe uma instancia do programa em execução");
                return;
            }*/


            /*var programsPath = String.Format(@"{0}\programas obrigatorios", Environment.CurrentDirectory);
            //var programsPath = @"C:\HyperSpin\Configuration\programas obrigatorios";

            Console.WriteLine(programsPath);       

            string[] rootDirectoryProgram = Directory.GetFiles(programsPath, "*.*", SearchOption.TopDirectoryOnly);

            if (rootDirectoryProgram.Length > 0)
            {
                foreach (var program in rootDirectoryProgram)
                {
                    if(currentProcess != program)
                    {
                        Process.Start(program);
                        currentProcess = program;
                    }

                    Process[] processosAtivos = Process.GetProcesses();
                    foreach (var service in processosAtivos)
                    {
                        /// :: Fonte Bebas
                        if (service.ProcessName == "fontview")
                        {
                            //service.Kill();
                        }
                    }

                        Console.WriteLine(program);
                }
            }

            Console.ReadKey();*/

            //System.Diagnostics.Process.Start(
            //@"C:\HyperSpin\RocketLauncher\Media\Fonts\BebasNeue.ttf");

            /*System.Diagnostics.Process.Start(
            @"C:\HyperSpin\HyperHQ");*/

            /*Process[] processos = Process.GetProcesses();

            foreach (var service in processos)
            {
                /// :: Fonte Bebas
                if (service.ProcessName == "fontview")
                {
                    service.Kill();
                }
                if (service.ProcessName == "HyperHQ")
                {
                    service.Kill();
                }
            }*/
        }
    }
}
