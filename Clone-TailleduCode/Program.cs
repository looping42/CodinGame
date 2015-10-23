using System;
using System.Collections.Generic;
using System.Linq;

namespace Clone_TailleduCode
{
    internal class Program
    {
        private static void Main(string[] args)
        {
string[] I = Console.ReadLine().Split(' ');         
int F = int.Parse(I[0]); 
int W = int.Parse(I[1]); 
int N = int.Parse(I[2]); 
int E = int.Parse(I[3]); 
int X = int.Parse(I[4]); 
int T = int.Parse(I[5]); 
int A = int.Parse(I[6]); 
int V = int.Parse(I[7]);
List<int> Y = new List<int>();
List<int> Z = new List<int>();
for (int i = 0; i < V; i++)
{
I = Console.ReadLine().Split(' ');
Z.Add(int.Parse(I[0]));
Y.Add(int.Parse(I[1])); 
}
       
while (true)
{
I = Console.ReadLine().Split(' ');
int U = int.Parse(I[0]);
int J = int.Parse(I[1]);
String B = I[2];

string r ="";
int L = 0;
int i = 0;

while (i < Z.Count())
{
if (Z[i] == U)
{
L = Y[i];
}
i = i + 1;
}

if ((J == -1) || (Y.Count() > 0) && (L == J))
{
r = "WAIT";
}
else if ((V == 0) && (A > 0))
{
r = "ELEVATOR";
A = A - 1;
Z.Add(U);
Y.Add(J);
}
else if (((B == "LEFT") && (J == 0))||(J == (W - 1)))
{
r = "BLOCK";
}
else
{

if ((U == E) && (J != L))
{
if ((J > X) && (B == "RIGHT")||(J < X) && (B == "LEFT"))
{
r = "BLOCK";
}
else
{
r = "WAIT";
}

}
else if (J != L)
{
if ((J > L) && (B == "RIGHT")||(J < L) && (B == "LEFT"))
{
r = "BLOCK";
}
else
{
r = "WAIT";
}

}
else
{
Console.WriteLine("WAIT");

}
}
Console.WriteLine(r);
}
        }
    }
    
}