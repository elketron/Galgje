using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Gelgje2
{
    class Program
    {
        
        static int WindowHalfX = Console.WindowWidth/2;
        static int WindowHalfy = Console.WindowHeight/2;
        static string Head = "";
        static string lLimb = "";
        static string rLimb = "";

        static string Torso = "";
        static string Rope = "";
        static string uPoleH = "0---------------";
        static string lPoleH = "0--------------------";
        static string poleV = "";
       
        static void Main(string[] args)
        {
            char[] carr = Enumerable.Range((Int32)'a',26).Select(i => (Char)(i)).ToArray();
            bool Lost = false;
            bool Won = false;
            int FileI = 0;
            string[] sarr = new string[180115];
            Random r = new Random();
            string path = @"nederlands3.txt";
            if (File.Exists(path))
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    string s;
                    while ((s = sr.ReadLine()) != null)
                    {
                        sarr[FileI] = s;
                        FileI++;
                    }
                }
            }
            

            string InWord = sarr[r.Next(0,sarr.Length)];
            int ToWin = InWord.Length;
            Head +=  "0.---...";
            Head +=  "0/...\\.";
            Head +=  "0|...|..";
            Head +=  "0\\.../.";
            Head +=  "0.---...";
            Torso += "0..|....";
            Torso += "0..|....";
            Torso += "0..|....";
            Torso += "0..|....";
            lLimb += @"0\..";
            lLimb += @"0.\.";
            lLimb += @"0..\";
            rLimb +=  "0../";
            rLimb +=  "0./.";
            rLimb +=  "0/..";

            for (int i = 0; i < 21; i++)
            {
                poleV += "0|";
            }
            for (int i = 0; i < 4; i++)
            {
                Rope += "0|";
            }

            int iter = -1;
            Console.Clear();
            Console.ResetColor();
        
            drawAlphabet();
            DrawWord(InWord);

            while (!Lost && !Won){
                // ask input 
                Console.SetCursorPosition(0,0);
                char Choice = Convert.ToChar(Input("choose a letter: "));
                //logic for drawing next state
                if(InWord.ToLower().Contains(Choice)){
                    
                    // logica voor letter groen te maken
                    for (int i = 0; i < 26; i++)
                    {
                        if (Choice == carr[i])
                        {
                            Console.SetCursorPosition(i + i,5);
                            Console.BackgroundColor = ConsoleColor.DarkGreen;
                            Console.Write(carr[i].ToString().ToUpper());
                        }
                    }
                    Console.ResetColor();
                    // logica om de letter te tonen
                    for (int i = 0; i < InWord.Length; i++)
                    {
                        if (Choice == InWord[i])
                        {
                            Console.SetCursorPosition(i + i,25);
                            Console.Write(Choice);
                            ToWin--;
                        }
                    }
                }
                else{
                    //logica om letter rood te maken
                    for (int i = 0; i < 26; i++)
                    {
                        if (Choice == carr[i])
                        {
                            Console.SetCursorPosition(i + i,5);
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Write(carr[i].ToString().ToUpper());
                        }
                    }
                    Console.ResetColor();
                    // teken een deel van het mannetje en increment iter met 1
                    iter++;
                    switch (iter)
                    {
                        case 0: 
                            drawFigure(lPoleH,WindowHalfX - 10,25); 
                            break;
                        case 1:
                            drawFigure(poleV,WindowHalfX - 10,5);
                            break;
                        case 2:
                            drawFigure(uPoleH,WindowHalfX - 10,5);
                            break;
                        case 3:
                            drawFigure(Rope,WindowHalfX,6);
                            break;
                        case 4:
                            drawFigure(Head,WindowHalfX - 2,10);
                            break;
                        case 5: 
                            drawFigure(Torso,WindowHalfX - 2,15);
                            break;
                        case 6: 
                            drawFigure(lLimb,WindowHalfX + 1,15); // left arm
                            break;
                        case 7: 
                            drawFigure(rLimb,WindowHalfX - 3,15); // right arm
                            break;
                        case 8: 
                            drawFigure(lLimb,WindowHalfX + 1,19); // left leg
                            break;
                        case 9: 
                            drawFigure(rLimb,WindowHalfX - 3,19); // right leg
                            break;
                        default: break;
                    }
                }
                if (iter == 9) Lost = true;
                if(ToWin == 0) Won = true;    
            }
            if(Lost)
            {
                Console.Clear();
                Console.SetCursorPosition(WindowHalfX,WindowHalfy);
                Console.WriteLine($"The word was: {InWord}");
            }
            if (Won)
            {
                Console.Clear();
                Console.SetCursorPosition(WindowHalfX,WindowHalfy);
                Console.WriteLine("You won");
            }
        }
        static string Input(string inp){
            System.Console.Write(inp);
            string outp = Console.ReadLine();
            return outp;
        }
        static void drawFigure(string ToDraw, int xPos, int yPos)
        {
            int y = 0;
            foreach (char i in ToDraw)
            {
                if (i == '0')
                {
                    Console.SetCursorPosition(xPos,yPos+y);
                    y++;
                }
                else if (i == '.')
                {
                    Console.Write(" ");  
                }
                else
                {
                    Console.Write(i);
                }
            }
        }
        static void drawAlphabet()
        {
            Console.SetCursorPosition(0,5);
            for (int i = 65; i < 91; i++)
            {
                Console.Write(Convert.ToChar(i) + " ");
            }
        }

        static void DrawWord(string InWord){
            Console.SetCursorPosition(0,25);
            foreach (char i in InWord)
            {
                if (i == '\'')
                {
                    Console.Write("'");   
                }
                else
                {
                    Console.Write("_ ");
                }
                
            }
        }
    }
}
