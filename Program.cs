using System;
using System.Collections;
using System.Linq;
using System.Text;

namespace CezarShifr
{
    class Program
    {
        static void Main(string[] args)
        { 
            
            string alphabet;
            int menuItem=0;
            string ru = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
            string eng = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            while (menuItem != 3)
            {
                Console.WriteLine("1)Зашифровать");
                Console.WriteLine("2)Расшифровать");
                Console.WriteLine("3)Выход");
                do
                {
                    menuItem = Convert.ToInt32(Console.ReadLine());
                } while (menuItem < 0 || menuItem > 3);

                switch (menuItem)
                {
                    case 1:
                    {
                        bool IsRu;
                        Console.WriteLine("Введите текст:");
                        StringBuilder text = new StringBuilder(Console.ReadLine().ToUpper());
                        Console.WriteLine("Введите сдвиг:");
                        int k = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Введите ключ");
                        string key = Console.ReadLine().ToUpper();
                       IsRu=CreateAlphabet(out alphabet, k, key);
                        if (key.Length== 0)
                        {
                            Console.WriteLine(alphabet);

                            for (int i = 0; i < text.Length; i++)
                            {
                                int indexNewSymbol = (k + alphabet.IndexOf(text[i])) % alphabet.Length;
                                if (text[i] == ' ')
                                    text[i] = '_';
                                else
                                    text[i] = alphabet[
                                        indexNewSymbol < 0 ? alphabet.Length + indexNewSymbol : indexNewSymbol];
                            }
                        }
                        else
                        {
                            
                            string temp = IsRu ? "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ" :"ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                            Console.WriteLine(temp);
                            Console.WriteLine(alphabet);
                            for (int i = 0; i < text.Length; i++)
                            {
                                if (char.IsLetter(text[i]))
                                    text[i] = alphabet[temp.IndexOf(text[i])];
                            }

                        }


                        Console.WriteLine(text);
                    }
                        break;
                    case 2:
                    {
                        bool IsRu;
                        Console.WriteLine("Введите текст:");
                        StringBuilder text = new StringBuilder(Console.ReadLine().ToUpper());
                        Console.WriteLine("Введите сдвиг:");
                        int k = Convert.ToInt32(Console.ReadLine()) * -1;
                        Console.WriteLine("Введите ключ");
                        string key = Console.ReadLine().ToUpper();
                        IsRu= CreateAlphabet(out alphabet, -k, key);
                        if (key.Length == 0)
                        {
                            Console.WriteLine(alphabet);

                            for (int i = 0; i < text.Length; i++)
                            {
                                int indexNewSymbol = (k + alphabet.IndexOf(text[i])) % alphabet.Length;

                                if (char.IsLetter(text[i]))
                                    text[i] = alphabet[
                                        indexNewSymbol < 0 ? alphabet.Length + indexNewSymbol : indexNewSymbol];
                            }
                        }
                        else
                        {
                            string temp = IsRu ? "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ" :"ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                            Console.WriteLine(temp);
                            Console.WriteLine(alphabet);
                            for (int i = 0; i < text.Length; i++)
                            {
                                if (char.IsLetter(text[i]))
                                    text[i] = temp[alphabet.IndexOf(text[i])];
                            }
                        }

                        Console.WriteLine(text);
                    }
                        break;
                }
            }
        }

        static bool CreateAlphabet(out string alphabet, int k = 0, string key = "")
        {
            alphabet = "";
            string ru = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
            string eng = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            bool res = true;
            for (int i = 0; i < ru.Length; i++)
            {
                alphabet += (char) i;
            }
            StringBuilder tempStr = new StringBuilder(alphabet);
            key =new string(key.Distinct().ToArray());
            for (int i = 0, j = k%tempStr.Length<0?tempStr.Length + k%tempStr.Length:k % tempStr.Length; i < key.Length; i++, j++)
            {
                tempStr[j % tempStr.Length] = key[i];
            }

            for (int i = key.Length>0? k + key.Length:0, j = 0; j < ru.Length; j++)
            {
                if (!tempStr.ToString().Contains(ru[j]))
                {
                    tempStr[i % tempStr.Length<0?tempStr.Length + i%tempStr.Length:i%tempStr.Length] = ru[j];
                    i++;
                }
            }

            Console.WriteLine("Алфавит Русский (+/-)");
            if (Console.ReadLine() == "-")
            {
                res = false;
                alphabet = "";
                for (int i = 0; i < eng.Length; i++)
                {
                    alphabet += (char) i;
                }
                tempStr = new StringBuilder(alphabet);
                for (int i = 0, j = k%tempStr.Length<0?tempStr.Length + k%tempStr.Length:k % tempStr.Length; i < key.Length; i++, j++)
                {
                    tempStr[j % tempStr.Length] = key[i];
                }

                for (int i = key.Length>0? k + key.Length:0, j = 0; j < eng.Length; j++)
                {
                    if (!tempStr.ToString().Contains(ru[j]))
                    {
                        tempStr[i % tempStr.Length<0?tempStr.Length + i%tempStr.Length:i%tempStr.Length] = eng[j];
                        i++;
                    }
                }
            }
            alphabet = tempStr.ToString();
            return res;
        }
    }
}
