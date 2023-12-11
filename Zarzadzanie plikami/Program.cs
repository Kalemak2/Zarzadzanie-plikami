namespace Zarzadzanie_plikami
{
    public class Program
    {
        public static void Main(string[] args)
        {

            try
            {
                Console.WriteLine("Podaj ścieżke do katalogu lub danego pliku (z rozszerzeniem):");
                string path = @Console.ReadLine();
                if (Path.GetExtension(path) == ".txt")
                {
                    if (File.Exists(path))
                    {

                        Console.WriteLine(File.ReadAllText(path));
                    }
                    else
                    {
                        Console.WriteLine("Podaj zawartość do tego pliku:");
                        string data1 = "";
                        do
                        {
                            string data = Console.ReadLine();
                            if (data != "END;;")
                            {
                                File.AppendAllText(path, (data + "\n"));
                            }
                            data1 = data;

                        } while (data1 != "END;;");
                        Console.WriteLine(File.ReadAllText(path));

                    }
                }
                else
                {
                    string[] dirs = Directory.GetFileSystemEntries(path);
                    foreach (string dir in dirs)
                    {
                        Console.WriteLine(dir);
                    }

                }
            }
            catch (IOException ex)
            {
                Console.Write(ex.Message);
            }
        }
    }
}