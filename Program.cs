using System;
using Sorter;

namespace Sorter{
    class Item{
        public string Value { get; set; }
        public int Count { get; set; }
    }
    internal class Program{
        
        private static string Source="input.txt", Output="output "+DateTime.Now.ToString($"dd/mm/yyyy HH:mm:ss")+".txt";
        private static char Seprator='\n';
        private static long TotalNumber=0, PointerNumber=0;
        private static bool NotTotalyDone=true;
        private static List<Item> items = new List<Item>();

        async static void Process()
        {
            var file = File.ReadAllText(Source);
            TotalNumber = file.Split(Seprator).Length;
            for (int i = 0; i < file.Split(Seprator).Length; i++)
            {
                bool donedoing = false;
                PointerNumber=i;
                var element = file.Split(Seprator)[i];
                for (int j = 0; j < items.Count; j++)
                {
                    if (items[j].Value == element.Trim())
                    {
                        items[j].Count+=1;
                        donedoing=true;
                        break;
                    }
                }
                if(!donedoing)
                    items.Add(new Item(){Value=element.Trim(),Count=1});
            }
            NotTotalyDone=false;
        }

        public static void Main(string[] args){
            
            Console.WriteLine("Hello there!");
            Console.WriteLine("Welcome to Sorter.");
            Console.WriteLine("This app will sort every texts and counts same texts.");
            if(args.Length>0){
                for (int i = 0; i < args.Length; i++)
                {
                    switch (args[i])
                    {
                        case "--help":
                        case "-h":
                            Console.WriteLine();
                            Console.WriteLine("    Usage:	sorter [source] [output] [seprator character]");
                            Console.WriteLine("		sorter [options]");
                            Console.WriteLine();
                            Console.WriteLine("    Options:");
                            Console.WriteLine();
                            Console.WriteLine("	-c <file>, --input <file>, --source <file>	Specify source file to be analysed.");
                            Console.WriteLine("	-o <file>, --output <file>			Specify output file");
                            Console.WriteLine("	-s <character>, --seprator <character>		Specify seperator of every item.");
                            Console.WriteLine();
                            Environment.Exit(0);
                            break;

                        case "--source":
                        case "--input":
                        case "-c":
                            i++;
                            if(Path.Exists(args[i])){
                                Source = args[i];
                            }else{
                                Error.Throw(ErrorType.ERROR,1,$"Having problems with accessing file '{args[i]}'.");
                            }
                            break;

                        case "--seprator":
                        case "-s":
                            i++;
                            if(args[i]=="\n"){
                                Seprator = '\n';
                            }else{
                                Seprator = args[i].ToCharArray()[0];
                            }
                            break;

                        case "--output":
                        case "-o":
                            i++;
                            Output = args[i];
                            break;

                        default:
                            if (i==0)
                            {
                                if(Path.Exists(args[0])){
                                    Source = args[0];
                                }else{
                                    Error.Throw(ErrorType.ERROR,1,$"Having problems with accessing file '{args[0]}'.");
                                }
                            }else if(i==1){
                                Output = args[1];
                            }else if(i==2)
                            {
                                if(args[2]=="\n"){
                                    Seprator = '\n';
                                }else{
                                    Seprator = args[2].ToCharArray()[0];
                                }
                            }
                            break;
                    }
                }
            }else{
                Console.Write($"What is the input file? ({Source}) ");
                string inp = Console.ReadLine();
                if(!Path.Exists(inp)){
                    Error.Throw(ErrorType.ERROR,1,$"Having problems with accessing '{inp}'.");
                }
                if(inp != "" && inp != null && inp != "\n")
                    Source = inp;
                Console.Write($"What is the output file? ({Output}) ");
                string outp = Console.ReadLine();
                if(outp != "" && outp != null && outp != "\n")
                    Source = outp;
            }
            
            var progress = new Thread(Process);
            
            progress.Start();
            while (NotTotalyDone)
            {
                if(TotalNumber!=0){
                    Console.Write($"Progress: {PointerNumber}/{TotalNumber} ({PointerNumber/TotalNumber*100}%) \r");
                    Thread.Sleep(100);
                }
            }
            progress.Join();
            Console.WriteLine();
            string outputFileContent = "";
            for (int i = 0; i < items.Count; i++)
            {
                outputFileContent+=$"'{items[i].Value}' ~> {items[i].Count}\n";
            }
            if(!Path.Exists(Output))
            {
                var f = File.Create(Output);
                f.Close();
            }
            File.WriteAllText(Output,outputFileContent);
            Console.WriteLine("All Done!");
            Console.WriteLine($"{items.Count} lines.");
            Console.WriteLine($"Output: {Output}");
            Console.ReadKey();
        }
    }
}