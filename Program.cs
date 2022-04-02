using System;
namespace Lab_graph
{
    internal class Program
    {
      
        public static int ResiveMumnerOfVertcies()
        {
            int reseveNumberVertex; bool success = false;
           
            Console.WriteLine(" Enter number of vertices");
            do{
                success = int.TryParse(Console.ReadLine(), out reseveNumberVertex);
                if (!success)
                    Console.WriteLine(" Please Enter a correct value");
            }while(!success);
            return reseveNumberVertex;
        }
        public static int vertex= ResiveMumnerOfVertcies();
        public static UndirectGraph undirectGraph = new UndirectGraph(vertex);
        public static void  EnterVertex()
        {
            int[] arr;int vert;
           
             bool success = false;
          
            arr = new int[vertex];
            for (int i = 0; i < vertex; i++)
            {
                Console.WriteLine(" Enter vertex number " + (i+1));
                do
                {
                    success = int.TryParse(Console.ReadLine(), out vert);
                    if (!success)
                        Console.WriteLine(" Please Enter a correct value");
                } while (!success);
                arr[i] = vert;
            }

            for (int i = 0; i < vertex; i++)
                Console.Write(arr[i] + " ");
            Console.WriteLine();
            int u, v, edges;
            Console.WriteLine(" Enter number of Edges ");
            do
            {
                success = int.TryParse(Console.ReadLine(), out edges);
                if (!success)
                    Console.WriteLine(" Please Enter a correct value");
            } while (!success);
            for (int i = 0;i < edges; i++)
            {
                Console.Write(" From   : ");
                do
                {
                    success = int.TryParse(Console.ReadLine(), out u);
                    if (!success)
                        Console.WriteLine(" Please Enter a correct value");
                } while (!success);
                Console.Write("  To   : ");
                do
                {
                    success = int.TryParse(Console.ReadLine(), out v);
                    if (!success)
                        Console.WriteLine(" Please Enter a correct value");
                } while (!success);
                Console.WriteLine();
                undirectGraph.AddEdge(u, v);
            }
        }
        public static void work()
        {
            char res;
            EnterVertex();
            res = undirectGraph.test();
            if (res == 'n')
                return;
            undirectGraph.PrintEulerTour();
            Console.WriteLine(undirectGraph.temp);
        }
       public  static void Main(string[] args)
        {
            work();
            Console.ReadKey();
        }
    }
}
