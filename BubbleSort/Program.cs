using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleSort
{
    static class ArrayExtensions

    {
        public static int[] sortArray(this int[] array)
        {
            int limit = array.Length;
            for (int j = 0; j < limit; j++)
            {
                for (int i = 0; i + 1 != array.Length; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        int n = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = n;
                    }
                }
            }
            return array;
        }
        public static  int []DecresentArray(this int[] array)
        {
            int[] temp = new int[array.Length];           
            for (int i = 0; i <= array.Length-1;i++)
            {
                temp[i] = array[(array.Length - 1) - i];             
            }
           
            return temp;       
           }
        public static int[] fillWithRandonNumber(this int[] array,int min,int max)
        {
            Random rnd = new Random();
            for (int i = 0; i < array.Length; i++) { array[i] = (int)rnd.Next(min, max); }
            return array;
        }
        public static void ShowArray (this int[] array)
        {
            foreach (int i in array)
            {
                Console.Write(i + " ");
            }
            
        }
        public static int BynarySearch (this int[] array,int numberToFind)
        {
            int positionFound = (int)Math.Floor((double)array.Length / 2);
            int maxRange = array.Length - 1;
            int minRange = 0;
            while (minRange != maxRange)
            {
                positionFound = (maxRange + minRange) / 2;
               // Console.WriteLine("The number in position " + positionFound + " is " + array[positionFound]);
                if (array[positionFound] > numberToFind)
                {
                    maxRange = positionFound;
                }
                else if (array[positionFound] < numberToFind)
                {
                    minRange = positionFound;
                }
                else
                {                    
                   // Console.WriteLine("The closest number to " + numberToFind + " is " + array[positionFound] + " in position " + positionFound);
                    break;
                }
            }
            return positionFound;
        }
        public static int find (this int[]array,int numbertoFind)
        {
            int position = -99;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == numbertoFind)
                {
                    position = i;
                    break;
                }
            }
            if (position == -99)
                return 0;
            return position;
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            user[] usuarios = new user[10];
            for (int i=0;i<usuarios.Length;i++)
            {
                usuarios[i] = new user("Player" + i, i * 50);
            }
            while (true)
            {
                Console.WriteLine("Digite o nome do usuario");
                string Name = Console.ReadLine();
                Console.WriteLine("Digite a pontuação do " + Name);

                int points =new int();
                try
                {
                    points=  int.Parse(Console.ReadLine());                    
                }
                catch
                {
                    Console.WriteLine("Numero Invalido");
                    Console.WriteLine("Aperte uma tecla para continuar");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }
                user newuser = new user(Name,points);
                addUser(newuser, usuarios);
                showHighscore(usuarios);
                Console.WriteLine("Aperte uma tecla para continuar");
                Console.ReadKey();
                Console.Clear();
            }
        }
        static string find(int pontos, user[] array,int oldPoints)
        {                        
            for (int i = 0; i < array.Length; i++)
            {
                
                if (pontos == array[i].Points)
                {       
                    if (pontos==oldPoints)
                    {                       
                        return array[i + 1].Name;                                              
                    }    
                    else         
                    return array[i].Name;
                }
            }            
             return "nada";
        }
        static void showHighscore(user[] usuarios)
        {
            int[] pontos = new int[10];
            string[] nomes = new string[10];
            for (int i = 0; i < pontos.Length; i++)
            {
                pontos[i] = usuarios[i].Points;
            }
            pontos.sortArray();
            pontos = pontos.DecresentArray();


            for (int i = 0; i < usuarios.Length; i++)
            {
                int oldpoints= new int();
                if (i >= 1) oldpoints = pontos[i - 1];
                    
                nomes[i] = find(pontos[i], usuarios,oldpoints);
                Console.WriteLine(nomes[i] + " " + pontos[i]);
            }
        }
        static void addUser (user newuser,user[] usuarios)
        {
            int[] pontos = new int[10];
            for (int i = 0; i < pontos.Length; i++)
            {
                pontos[i] = usuarios[i].Points;
            }
            pontos.sortArray();
            if (pontos[0] < newuser.Points)
            {
                for (int i = 0; i < usuarios.Length; i++)
                {
                    if (usuarios[i].Points == pontos[0])
                    {
                        usuarios[i] = newuser;
                        break;
                    }
                }
            }
        }
    }
    class user
    {
        public user (string name, int points)
        {
             Name= name;
            Points= points;
        }
        public string Name;
        public int Points;
    }
}

