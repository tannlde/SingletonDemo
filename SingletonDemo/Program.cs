using System;

namespace SingletonDemo
{
    class Program
    {
        class KeyboardWindow
        {
            public int Height { get; set; }
            public int Width { get; set; }

            private static KeyboardWindow _keyboardWindow;
            private static readonly Object padlock = new();

            private KeyboardWindow()
            {
                Console.WriteLine("Create a window!");
            }

            public void Print()
            {
                Console.WriteLine($"{Height}, {Width}");
            }

            public static KeyboardWindow NewKeyboardWindow
            {
                get
                {
                    lock (padlock)
                    {
                        if (_keyboardWindow == null)
                        {
                            _keyboardWindow = new KeyboardWindow();
                        }
                        return _keyboardWindow;
                    }
                }
            }

        }
        static void Main(string[] args)
        {
            KeyboardWindow k1 = KeyboardWindow.NewKeyboardWindow;
            k1.Height = 1;
            k1.Width = 2;
            k1.Print();

            KeyboardWindow k2 = KeyboardWindow.NewKeyboardWindow;
            k2.Height = 10;
            k2.Width = 20;
            k2.Print();

            k1.Print();

        }
    }
}
