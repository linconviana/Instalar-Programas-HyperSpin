using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Instalar_Programas_Hyperspin
{
    public class InstallSoftware
    {
        private string currentProcess = string.Empty;
        private bool installFinishing = false;
        private bool startProgram = false;
        private bool fontBebas = false;
        private bool directX = false;
        private bool netFramework20 = false;
        private bool netFramework45 = false;

        private bool vcredist2005x86 = false;
        private bool vcredist2008x86 = false;
        private bool vcredist2010x86 = false;
        private bool vcredist2012x86 = false;
        private bool vcredist2013x86 = false;
        private bool vcredist2015x86 = false;

        private bool vcredist2005x64 = false;
        private bool vcredist2008x64 = false;
        private bool vcredist2010x64 = false;
        private bool vcredist2012x64 = false;
        private bool vcredist2013x64 = false;
        private bool vcredist2015x64 = false;

        public int Milliseconds { get; set; }
        public string Architecture { get; set; }
        public string Windows { get; set; }

        public InstallSoftware(int Milliseconds, string Architecture, string Windows) 
        {
            this.Milliseconds = Milliseconds;
            this.Architecture = Architecture;
            this.Windows = Windows;
        }

        public void GetSoftware()
        {
            try
            {
                while (true)
                {
                    fGetInslalledProgram("Microsoft Visual C++ 2005 Redistributable (x64)");

                    //var hyperspinPath = Environment.CurrentDirectory;
                    //hyperspinPath = String.Format(@"{0}\HyperSpin.exe", hyperspinPath.Substring(0, hyperspinPath.Length - 14));

                    var hyperspinPath = @"C:\HyperSpin\Configuration\programas obrigatorios";
                    hyperspinPath = String.Format(@"{0}\HyperSpin.exe", hyperspinPath.Substring(0, hyperspinPath.Length - 37));
                    //Console.WriteLine(hyperspinPath);
                    //Console.WriteLine("Tamanho: " + hyperspinPath.Length);
                    //Console.ReadKey();
                    //Console.WriteLine(hyperspinPath.Substring(0, hyperspinPath.Length - 37));

                    //var programsPath = String.Format(@"{0}\programas obrigatorios", Environment.CurrentDirectory);
                    var programsPath = @"C:\HyperSpin\Configuration\programas obrigatorios";
                    if (!startProgram)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine(programsPath);
                        Console.WriteLine(string.Empty);

                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("SERÁ INSTALADO ALGUNS PROGRAMAS PARA QUE SEU HYPERSPIN FUNCIONE CORRETAMENTE:");
                        Console.WriteLine(string.Empty);
                        Console.WriteLine("FONTE BEBAS NEUE, DIRECTX, VISUAL C++ 2005, VISUAL C++ 2008");
                        Console.WriteLine("VISUAL C++ 2010, VISUAL C++ 2012, VISUAL C++ 2013, VISUAL C++ 2015, NET FRAMEWORK");
                        Console.WriteLine(string.Empty);

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("ATENÇÂO: NÃO FECHE O PROGRAMA ATE É FINALIZAR TODAS AS INSTALAÇÕES!");
                        Console.WriteLine(string.Empty);

                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.WriteLine("APERTE ENTER PARA CONTINUAR AS INSTALAÇÕES!");
                        Console.ReadKey();
                        Console.WriteLine(string.Empty);
                        startProgram = true;
                    }

                    string[] rootDirectoryProgram = Directory.GetFiles(programsPath, "*.*", SearchOption.TopDirectoryOnly);

                    if (rootDirectoryProgram.Length > 0)
                    {
                        foreach (var program in rootDirectoryProgram)
                        {
                            /// :: INSTALAÇÃO FONTE BEBASNEUE
                            if (!fontBebas && program.Contains("BebasNeue.ttf"))
                            {
                                currentProcess = "Fonte Bebas Neue";
                                Process.Start(program);
                                fontBebas = true;
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("Inicializou a instalação da Fonte Bebas para RocketLauncher");
                                Console.WriteLine(string.Empty);
                                Console.ForegroundColor = ConsoleColor.Gray;
                                Console.WriteLine(program + " ainda esta sendo executado!");
                            }

                            Process[] processesFontBebas = Process.GetProcessesByName("fontview");

                            bool activeFontBebas = false;
                            if (processesFontBebas.Length > 0)
                                activeFontBebas = processesFontBebas[0].ProcessName == "fontview" ? true : false;
                            /// :: INSTALAÇÃO FONTE BEBASNEUE

                            /// :: INSTALAÇÃO DIRECTX
                            if (!directX && fontBebas && !activeFontBebas && program.Contains("directx_feb2010_redist.exe"))
                            {
                                currentProcess = "DirectX";
                                Process.Start(program);
                                directX = true;
                                Console.WriteLine(string.Empty);
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine("Inicializou a instalação do directX");
                                Console.WriteLine(string.Empty);
                                Console.ForegroundColor = ConsoleColor.Gray;
                                Console.WriteLine(program + " ainda esta sendo executado!");
                            }

                            Process[] processesDirectX = Process.GetProcessesByName("directx_feb2010_redist");

                            bool activeDirectX = false;
                            if (processesDirectX.Length > 0)
                                activeDirectX = processesDirectX[0].ProcessName == "directx_feb2010_redist" ? true : false;
                            /// :: INSTALAÇÃO DIRECTX


                            /// :: INSTALAÇÃO VISUAL C++ (2005 A 2015)
                            if (directX && fontBebas && !activeFontBebas && !activeDirectX && this.Architecture == "x64")
                            {
                                /// :: INSTALAÇÃO VISUAL C++ 2005
                                if (!vcredist2005x64 && program.Contains("vcredist2005_x64.exe") && Architecture == "x64")
                                {
                                    currentProcess = "Visual C++ 2005 x64";
                                    Process.Start(program);
                                    vcredist2005x64 = true;
                                    Console.WriteLine(string.Empty);
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Inicializou a instalação do Visual C++ 2005 x64");
                                    Console.WriteLine(string.Empty);
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                    Console.WriteLine(program + " ainda esta sendo executado!");
                                }

                                // Obtém todos os processos com o nome do atual
                                Process[] processesVisualC2005 = Process.GetProcessesByName("vcredist2005_x64");

                                bool activeVisualCPlus2005 = false;
                                if (processesVisualC2005.Length > 0)
                                    activeVisualCPlus2005 = processesVisualC2005[0].ProcessName == "vcredist2005_x64" ? true : false;
                                /// :: INSTALAÇÃO VISUAL C++ 2005

                                /// :: INSTALAÇÃO VISUAL C++ 2008
                                if (!vcredist2008x64 && !activeVisualCPlus2005 && program.Contains("vcredist2008_x64.exe") && Architecture == "x64")
                                {
                                    currentProcess = "Visual C++ 2008 x64";
                                    Process.Start(program);
                                    vcredist2008x64 = true;
                                    Console.WriteLine(string.Empty);
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.WriteLine("Inicializou a instalação do Visual C++ 2008 x64");
                                    Console.WriteLine(string.Empty);
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                    Console.WriteLine(program + " ainda esta sendo executado!");
                                }

                                // Obtém todos os processos com o nome do atual
                                Process[] processesVisualC2008 = Process.GetProcessesByName("vcredist2008_x64");

                                bool activeVisualCPlus2008 = false;
                                if (processesVisualC2008.Length > 0)
                                    activeVisualCPlus2008 = processesVisualC2008[0].ProcessName == "vcredist2008_x64" ? true : false;
                                /// :: INSTALAÇÃO VISUAL C++ 2008

                                /// :: INSTALAÇÃO VISUAL C++ 2010
                                if (!vcredist2010x64 && !activeVisualCPlus2005 && !activeVisualCPlus2008 && program.Contains("vcredist2010_x64.exe") && Architecture == "x64")
                                {
                                    currentProcess = "Visual C++ 2010 x64";
                                    Process.Start(program);
                                    vcredist2010x64 = true;
                                    Console.WriteLine(string.Empty);
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Inicializou a instalação do Visual C++ 2010 x64");
                                    Console.WriteLine(string.Empty);
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                    Console.WriteLine(program + " ainda esta sendo executado!");
                                }

                                // Obtém todos os processos com o nome do atual
                                Process[] processesVisualC2010 = Process.GetProcessesByName("vcredist2010_x64");

                                bool activeVisualCPlus2010 = false;
                                if (processesVisualC2010.Length > 0)
                                    activeVisualCPlus2010 = processesVisualC2010[0].ProcessName == "vcredist2010_x64" ? true : false;
                                /// :: INSTALAÇÃO VISUAL C++ 2010

                                /// :: INSTALAÇÃO VISUAL C++ 2012
                                if (!vcredist2012x64 && !activeVisualCPlus2005 && !activeVisualCPlus2008 && !activeVisualCPlus2010 && program.Contains("vcredist2012_x64.exe") && Architecture == "x64")
                                {
                                    currentProcess = "Visual C++ 2012 x64";
                                    Process.Start(program);
                                    vcredist2012x64 = true;
                                    Console.WriteLine(string.Empty);
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.WriteLine("Inicializou a instalação do Visual C++ 2012 x64");
                                    Console.WriteLine(string.Empty);
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                    Console.WriteLine(program + " ainda esta sendo executado!");
                                }

                                // Obtém todos os processos com o nome do atual
                                Process[] processesVisualC2012 = Process.GetProcessesByName("vcredist2012_x64");

                                bool activeVisualCPlus2012 = false;
                                if (processesVisualC2012.Length > 0)
                                    activeVisualCPlus2012 = processesVisualC2012[0].ProcessName == "vcredist2012_x64" ? true : false;
                                /// :: INSTALAÇÃO VISUAL C++ 2012

                                /// :: INSTALAÇÃO VISUAL C++ 2013
                                if (!vcredist2013x64 && !activeVisualCPlus2005 && !activeVisualCPlus2008 && !activeVisualCPlus2010 && !activeVisualCPlus2012 && program.Contains("vcredist2013_x64.exe") && Architecture == "x64")
                                {
                                    currentProcess = "Visual C++ 2013 x64";
                                    Process.Start(program);
                                    vcredist2013x64 = true;
                                    Console.WriteLine(string.Empty);
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("Inicializou a instalação do Visual C++ 2013 x64");
                                    Console.WriteLine(string.Empty);
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                    Console.WriteLine(program + " ainda esta sendo executado!");
                                }

                                // Obtém todos os processos com o nome do atual
                                Process[] processesVisualC2013 = Process.GetProcessesByName("vcredist2013_x64");

                                bool activeVisualCPlus2013 = false;
                                if (processesVisualC2013.Length > 0)
                                    activeVisualCPlus2013 = processesVisualC2013[0].ProcessName == "vcredist2013_x64" ? true : false;
                                /// :: INSTALAÇÃO VISUAL C++ 2013

                                /// :: INSTALAÇÃO VISUAL C++ 2015
                                if (!vcredist2015x64 && !activeVisualCPlus2005 && !activeVisualCPlus2008 && !activeVisualCPlus2010 && !activeVisualCPlus2012 && !activeVisualCPlus2013 && program.Contains("vcredist2015_2017_2019_x64.exe") && Architecture == "x64")
                                {
                                    currentProcess = "Visual C++ 2015 x64";
                                    Process.Start(program);
                                    vcredist2015x64 = true;
                                    Console.WriteLine(string.Empty);
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine("Inicializou a instalação do Visual C++ 2015 x64");
                                    Console.WriteLine(string.Empty);
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                    Console.WriteLine(program + " ainda esta sendo executado!");
                                    //installFinishing = true;
                                }

                                // Obtém todos os processos com o nome do atual
                                Process[] processesVisualC2015 = Process.GetProcessesByName("vcredist2015_2017_2019_x64");

                                bool activeVisualCPlus2015 = false;
                                if (processesVisualC2015.Length > 0)
                                    activeVisualCPlus2015 = processesVisualC2015[0].ProcessName == "vcredist2015_2017_2019_x64" ? true : false;

                                if (!activeVisualCPlus2005 && !activeVisualCPlus2008 && !activeVisualCPlus2010 && !activeVisualCPlus2012 
                                    && !activeVisualCPlus2013 && !activeVisualCPlus2015 && Architecture == "x64")
                                {
                                    if ((this.Windows == "Windows 10" || this.Windows == "Windows 11") && !netFramework20)
                                    {
                                        MessageBox.Show("O sistema que estou utilizando é Windows 10 e estou esperendo o: " + this.Windows);
                                        if (program.Contains("NDP451-KB2858728-x86-x64-AllOS-ENU.exe"))
                                        {
                                            //Process.Start(program);
                                            netFramework20 = true;
                                            Console.WriteLine(string.Empty);
                                            Console.ForegroundColor = ConsoleColor.Yellow;
                                            Console.WriteLine("Inicializou a instalação do Net Framework 2.0");
                                            Console.WriteLine(string.Empty);
                                            Console.ForegroundColor = ConsoleColor.Gray;
                                            Console.WriteLine(program + " ainda esta sendo executado!");
                                            installFinishing = true;
                                        }
                                    }
                                    if (this.Windows == "Windows 7" && !netFramework45)
                                    {
                                        MessageBox.Show("O sistema que estou utilizando é Windows 7 e estou esperendo o: " + this.Windows);
                                        if (program.Contains("NDP451-KB2858728-x86-x64-AllOS-ENU.exe"))
                                        {
                                            Process.Start(program);
                                            netFramework45 = true;
                                            Console.WriteLine(string.Empty);
                                            Console.ForegroundColor = ConsoleColor.Yellow;
                                            Console.WriteLine("Inicializou a instalação do Net Framework 4.5");
                                            Console.WriteLine(string.Empty);
                                            Console.ForegroundColor = ConsoleColor.Gray;
                                            Console.WriteLine(program + " ainda esta sendo executado!");
                                            installFinishing = true;
                                        }
                                    }
                                }

                                /// :: Windows 10
                                // Obtém todos os processos com o nome do atual
                                Process[] processesNetFramework20 = Process.GetProcessesByName("net framework 2.0 e 3.0");

                                bool activeNetFramework20 = false;
                                if (processesNetFramework20.Length > 0 && (this.Windows == "Windows 10" || this.Windows == "Windows 11"))
                                    activeNetFramework20 = processesNetFramework20[0].ProcessName == "net framework 2.0 e 3.0" ? true : false;


                                /// :: Windows 7
                                // Obtém todos os processos com o nome do atual
                                Process[] processesNetFramework45 = Process.GetProcessesByName("NDP451-KB2858728-x86-x64-AllOS-ENU");

                                bool activeNetFramework45 = false;
                                if (processesNetFramework45.Length > 0 && this.Windows == "Windows 7")
                                    activeNetFramework45 = processesNetFramework45[0].ProcessName == "NDP451-KB2858728-x86-x64-AllOS-ENU" ? true : false;


                                /// :: else if(!activeVisualCPlus2015 && installFinishing) 
                                else if (installFinishing) 
                                {
                                    Console.WriteLine(string.Empty);
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.WriteLine("Parabéns, você instalou todos os programas necessários para que seu Hyperspin funcione corretamente!");
                                    Console.WriteLine("Agora basta executar seu Hyperspin e desfrute de seus games favoritos!");
                                    Console.WriteLine(string.Empty);

                                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                    Console.WriteLine("OBS: LEMBRANDO QUE VOCÊ PRECISA CONFIGURAR OS SISTEMAS DOS JOGOS!");
                                    Console.WriteLine("SE NÃO SABE COMO FAZER ISSO, SEM PROBLEMAS VISITE MEU CANAL NO YOUTUBE!");
                                    Console.WriteLine("LÁ VOCÊ ENCONTRA UM PLAYLIST COMPLETA PASSO A PASSO DE COMO INSTALAR CADA SISTEMA,");
                                    Console.WriteLine("BEM COMO OS LINKS NA DESCRIÇÃO DE PROGRAMAS, E EMULADORES NECESSARIOS PARA A CONFIGURAÇÃO!");
                                    Console.WriteLine("CANAL YOUTUBE: @linconviana4013");
                                    Console.WriteLine(string.Empty);

                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine("APERTE ENTER PARA PROSSEGUIR");
                                    Console.ReadKey();
                                    Console.WriteLine(string.Empty);

                                    Process.Start(hyperspinPath);

                                    Environment.Exit(0);
                                    Console.ReadKey(true);

                                }
                                /// :: INSTALAÇÃO VISUAL C++ 2015

                            }
                            else if (directX && fontBebas && !activeFontBebas && !activeDirectX && this.Architecture == "x86")
                            {
                                /// :: INSTALAÇÃO VISUAL C++ 2005
                                if (!vcredist2005x86 && program.Contains("vcredist2005_x86.exe") && Architecture == "x86")
                                {
                                    Process.Start(program);
                                    vcredist2005x86 = true;
                                    Console.WriteLine(string.Empty);
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Inicializou a instalação do Visual C++ 2005 x86");
                                    Console.WriteLine(string.Empty);
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                    Console.WriteLine(program + " ainda esta sendo executado!");
                                }

                                // Obtém todos os processos com o nome do atual
                                Process[] processesVisualC2005 = Process.GetProcessesByName("vcredist2005_x86");

                                bool activeVisualCPlus2005 = false;
                                if (processesVisualC2005.Length > 0)
                                    activeVisualCPlus2005 = processesVisualC2005[0].ProcessName == "vcredist2005_x86" ? true : false;
                                /// :: INSTALAÇÃO VISUAL C++ 2005

                                /// :: INSTALAÇÃO VISUAL C++ 2008
                                if (!vcredist2008x86 && !activeVisualCPlus2005 && program.Contains("vcredist2008_x86.exe") && Architecture == "x86")
                                {
                                    Process.Start(program);
                                    vcredist2008x86 = true;
                                    Console.WriteLine(string.Empty);
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.WriteLine("Inicializou a instalação do Visual C++ 2008 x86");
                                    Console.WriteLine(string.Empty);
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                    Console.WriteLine(program + " ainda esta sendo executado!");
                                }

                                // Obtém todos os processos com o nome do atual
                                Process[] processesVisualC2008 = Process.GetProcessesByName("vcredist2008_x86");

                                bool activeVisualCPlus2008 = false;
                                if (processesVisualC2008.Length > 0)
                                    activeVisualCPlus2008 = processesVisualC2008[0].ProcessName == "vcredist2008_x86" ? true : false;
                                /// :: INSTALAÇÃO VISUAL C++ 2008

                                /// :: INSTALAÇÃO VISUAL C++ 2010
                                if (!vcredist2010x86 && !activeVisualCPlus2005 && !activeVisualCPlus2008 && program.Contains("vcredist2010_x86.exe") && Architecture == "x86")
                                {
                                    Process.Start(program);
                                    vcredist2010x86 = true;
                                    Console.WriteLine(string.Empty);
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Inicializou a instalação do Visual C++ 2010 x86");
                                    Console.WriteLine(string.Empty);
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                    Console.WriteLine(program + " ainda esta sendo executado!");
                                }

                                // Obtém todos os processos com o nome do atual
                                Process[] processesVisualC2010 = Process.GetProcessesByName("vcredist2010_x86");

                                bool activeVisualCPlus2010 = false;
                                if (processesVisualC2010.Length > 0)
                                    activeVisualCPlus2010 = processesVisualC2010[0].ProcessName == "vcredist2010_x86" ? true : false;
                                /// :: INSTALAÇÃO VISUAL C++ 2010

                                /// :: INSTALAÇÃO VISUAL C++ 2012
                                if (!vcredist2012x86 && !activeVisualCPlus2005 && !activeVisualCPlus2008 && !activeVisualCPlus2010 && program.Contains("vcredist2012_x86.exe") && Architecture == "x86")
                                {
                                    Process.Start(program);
                                    vcredist2012x86 = true;
                                    Console.WriteLine(string.Empty);
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.WriteLine("Inicializou a instalação do Visual C++ 2012 x86");
                                    Console.WriteLine(string.Empty);
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                    Console.WriteLine(program + " ainda esta sendo executado!");
                                }

                                // Obtém todos os processos com o nome do atual
                                Process[] processesVisualC2012 = Process.GetProcessesByName("vcredist2012_x86");

                                bool activeVisualCPlus2012 = false;
                                if (processesVisualC2012.Length > 0)
                                    activeVisualCPlus2012 = processesVisualC2012[0].ProcessName == "vcredist2012_x86" ? true : false;
                                /// :: INSTALAÇÃO VISUAL C++ 2012

                                /// :: INSTALAÇÃO VISUAL C++ 2013
                                if (!vcredist2013x86 && !activeVisualCPlus2005 && !activeVisualCPlus2008 && !activeVisualCPlus2010 && !activeVisualCPlus2012 && program.Contains("vcredist2013_x86.exe") && Architecture == "x86")
                                {
                                    Process.Start(program);
                                    vcredist2013x86 = true;
                                    Console.WriteLine(string.Empty);
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("Inicializou a instalação do Visual C++ 2013 x86");
                                    Console.WriteLine(string.Empty);
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                    Console.WriteLine(program + " ainda esta sendo executado!");
                                }

                                // Obtém todos os processos com o nome do atual
                                Process[] processesVisualC2013 = Process.GetProcessesByName("vcredist2013_x86");

                                bool activeVisualCPlus2013 = false;
                                if (processesVisualC2013.Length > 0)
                                    activeVisualCPlus2013 = processesVisualC2013[0].ProcessName == "vcredist2013_x86" ? true : false;
                                /// :: INSTALAÇÃO VISUAL C++ 2013

                                /// :: INSTALAÇÃO VISUAL C++ 2015
                                if (!vcredist2015x86 && !activeVisualCPlus2005 && !activeVisualCPlus2008 && !activeVisualCPlus2010 && !activeVisualCPlus2012 && !activeVisualCPlus2013 && program.Contains("vcredist2015_2017_2019_x86.exe") && Architecture == "x86")
                                {
                                    Process.Start(program);
                                    vcredist2015x86 = true;
                                    Console.WriteLine(string.Empty);
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine("Inicializou a instalação do Visual C++ 2015 x86");
                                    Console.WriteLine(string.Empty);
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                    Console.WriteLine(program + " ainda esta sendo executado!");
                                    installFinishing = true;
                                }

                                // Obtém todos os processos com o nome do atual
                                Process[] processesVisualC2015 = Process.GetProcessesByName("vcredist2015_2017_2019_x86");

                                bool activeVisualCPlus2015 = false;
                                if (processesVisualC2015.Length > 0)
                                    activeVisualCPlus2015 = processesVisualC2015[0].ProcessName == "vcredist2015_2017_2019_x86" ? true : false;
                                else if (!activeVisualCPlus2015 && installFinishing)
                                {
                                    Console.WriteLine(string.Empty);
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.WriteLine("Parabéns, você instalou todos os programas necessários para que seu Hyperspin funcione corretamente!");
                                    Console.WriteLine("Agora basta executar seu Hyperspin e desfrute de seus games favoritos!");
                                    Console.WriteLine(string.Empty);

                                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                    Console.WriteLine("OBS: LEMBRANDO QUE VOCÊ PRECISA CONFIGURAR OS SISTEMAS DOS JOGOS!");
                                    Console.WriteLine("SE NÃO SABE COMO FAZER ISSO, SEM PROBLEMAS VISITE MEU CANAL NO YOUTUBE!");
                                    Console.WriteLine("LÁ VOCÊ ENCONTRA UM PLAYLIST COMPLETA PASSO A PASSO DE COMO INSTALAR CADA SISTEMA,");
                                    Console.WriteLine("BEM COMO OS LINKS NA DESCRIÇÃO DE PROGRAMAS, E EMULADORES NECESSARIOS PARA A CONFIGURAÇÃO!");
                                    Console.WriteLine("CANAL YOUTUBE: @linconviana4013");
                                    Console.WriteLine(string.Empty);

                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine("APERTE ENTER PARA PROSSEGUIR");
                                    Console.ReadKey();
                                    Console.WriteLine(string.Empty);

                                    Process.Start(hyperspinPath);

                                    Environment.Exit(0);
                                    Console.ReadKey(true);

                                }
                                /// :: INSTALAÇÃO VISUAL C++ 2015
                            }
                            /// :: INSTALAÇÃO VISUAL C++ (2005 A 2015)


                            /*
                             /// :: NET FRAMEWORK 2.0 e 3.0
                            if (this.Windows == "Windows 10" || this.Windows == "Windows 11")
                            {
                                if (directX && fontBebas && !activeFontBebas && !activeDirectX && !netFramework2e3 && program.Contains("net framework 2.0 e 3.0.exe"))
                                {
                                    Process.Start(program);
                                    netFramework2e3 = true;
                                    Console.WriteLine(string.Empty);
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("Inicializou a instalação do Net Framework 2.0");
                                    Console.WriteLine(string.Empty);
                                }
                            }

                            Process[] processesNetFramework20 = Process.GetProcessesByName("dotnetfx35");

                            bool activeNetFramework20 = false;
                            if (processesNetFramework20.Length > 0)
                                activeNetFramework20 = processesNetFramework20[0].ProcessName == "dotnetfx35" ? true : false;
                            /// :: NET FRAMEWORK 2.0 e 3.0

                            /// :: NET FRAMEWORK 4.5
                            if (this.Windows == "Windows 7")
                            {
                                if (!activeDirectX && program.Contains("NDP451-KB2858728-x86-x64-AllOS-ENU.exe"))
                                {
                                    Process.Start(program);
                                    fontBebas = true;
                                    Console.WriteLine(string.Empty);
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("Inicializou a instalação do Net Framework 4.5");
                                    Console.WriteLine(string.Empty);
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                    Console.WriteLine(program + " ainda esta sendo executado!");
                                }
                            }

                            Process[] processesNetFramework45 = Process.GetProcessesByName("NDP451-KB2858728-x86-x64-AllOS-ENU");

                            bool activeNetFramework45 = false;
                            if (processesNetFramework45.Length > 0)
                                activeNetFramework45 = processesNetFramework45[0].ProcessName == "NDP451-KB2858728-x86-x64-AllOS-ENU" ? true : false;
                            /// :: NET FRAMEWORK 4.5
                             */

                        }
                    }
                    else
                    {
                        var message = "A pasta de programas esta vazia!";

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(message);
                    }

                    //Console.ReadKey();
                    /// :: Thread sleep timer.
                    Thread.Sleep(this.Milliseconds);
                }
            }
            catch (Exception)
            {
                var message = String.Format("A instalação do <{0}> é necessaria para o funcionamento do HyperSpin!", currentProcess);

                if (currentProcess.Contains("Visual C++ 2008 x64") || currentProcess.Contains("Visual C++ 2010 x64"))
                    message += "Caso ja tenha instalado e seja a versão 2008 e 2010 do visual c++, clique em Yes e depois cancele a instalação para prosseguir!";
                
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(string.Empty);
                Console.WriteLine(message);
                Console.WriteLine(string.Empty);
            }
            finally{
                GetSoftware();
            }
        }

        public static bool fGetInslalledProgram(String sProgramName)
        {
            String regkey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(regkey))
            {
                var query = from a in
                                 key.GetSubKeyNames()
                            let r = key.OpenSubKey(a)
                            select new
                            {
                                Application = r.GetValue("DisplayName")
                            };
                foreach (var item in query)
                {
                    if (item.Application != null)
                    {
                        if(item.Application.ToString().Contains("Microsoft .NET")){
                            var teste = 0;
                        }
                        if (item.Application.ToString().Contains(sProgramName))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        /*
         public static bool fGetInslalledProgram(String sProgramName)
        {
            String sUninstall = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
            using (RegistryKey rk = Registry.LocalMachine.OpenSubKey(sUninstall))
            {
                foreach (String skName in rk.GetSubKeyNames())
                {
                    using (RegistryKey sk = rk.OpenSubKey(skName))
                    {
                        var program = sk.GetValue("DisplayName").ToString();
                        if(program == "Microsoft Visual C++ 2005 Redistributable(x64)" &&
                            program.Length == sProgramName.Length)
                        {
                            return true;
                        }
                        /*if (Left(sk.GetValue("DisplayName").ToString(), sProgramName.Length) == sProgramName)
                        {
                            return true;
                        }
                        }
                    }
                    return false;
                }
            }
         */

        /*
         public static bool fGetInslalledProgram(String sProgramName)
        {
            String sUninstall = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
            using (RegistryKey rk = Registry.LocalMachine.OpenSubKey(sUninstall))
            {
                foreach (String skName in rk.GetSubKeyNames())
                {
                    using (RegistryKey sk = rk.OpenSubKey(skName))
                    {
                        if (Left(sk.GetValue("DisplayName").ToString(), sProgramName.Length) == sProgramName)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
        }
         */
    }
}
