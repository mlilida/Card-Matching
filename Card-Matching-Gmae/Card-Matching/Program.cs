using System;
using System.Security.Cryptography;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;

//헹 열 변수지정 
int raw = 0;
int col = 0;

//기본 ** 배열
string[,] secound = new string[5, 5];

//랜덤
Random random = new Random();

for (int i = 1; i < 5; i++)
{
    secound[0, i] = ($"{i,5}열");
    secound[i, 0] = ($"{i}행");

    for (int j = 1; j < 5; j++)
    {
        secound[i, j] = ($"{"**",5}");
    }
}

int number = 1;

//답지 만들기
string[,] answer = new string[5, 5];
for (int i = 1; i < 5; i++)
{
    for (int j = 1; j < 5; j++)
    {
        answer[i, j] = ($"[{number,5}]");
        number++;

        if (number > 8)
        {
            number = 1;
        }
    }
}

string chose1;
string chose2;
string[] chose3;
int answer1;
int answer2;
int answer3;
int answer4;
int count1 = 0;
int count2 = 0;

Shuffle();

for (; ; )
{
    Console.Clear();

    show();
    for (; ; )
    {
        Console.Write("첫 번째 카드를 선택하세요 (행 열): ");
        chose1 = Console.ReadLine();
        chose3 = chose1.Split(' ');
        if (NumberChoice(ref raw, ref col))
        {
            secound[raw, col] = answer[raw, col];
            answer1 = raw;
            answer2 = col;
            Console.Clear();
            show();
            break;
        }
        
    }
    


    for (; ; )
    {
        Console.Write("두 번째 카드를 선택하세요 (행 열): ");
        chose2 = Console.ReadLine();
        chose3 = chose2.Split(' ');
        if (NumberChoice(ref raw, ref col))
        {
            secound[raw, col] = answer[raw, col];
            answer3 = raw;
            answer4 = col;
            Console.Clear();
            show();
            count1++;
            break;
        }

        
    }
    

    if (answer[answer1, answer2] != answer[answer3, answer4])
    {
        Console.WriteLine("짝이 맞지 않습니다!");
        Thread.Sleep(3000);
        secound[answer1, answer2] = "**   ";
        secound[answer3, answer4] = "**   ";
    }
    else
    {
        Console.WriteLine("짝을 찾았습니다!");
        Thread.Sleep(3000);
        secound[answer1, answer2] = answer[answer1, answer2].Substring(1, 1);
        secound[answer3, answer4] = answer[answer3, answer4].Substring(1, 1);
        show();
        count2++;
    }
    if (count1 == 20)
    {
        Console.WriteLine("=== 게임 오버! ===");
        Console.WriteLine("시도 횟수를 모두 사용했습니다.");
        Console.WriteLine($"찾은 쌍: {count2}/4");
        break;
    }
    if (count2 == 4)
    {
        Console.WriteLine("=== 게임 클리어! ===");
        Console.WriteLine($"총 시도 횟수: {count1}");
    }
}




void show()
{
    Console.WriteLine("=== 카드 짝 맞추기 게임===");
    Console.WriteLine();

    for (int i = 0; i < 5; i++)
    {
        for (int j = 0; j < 5; j++)
        {
            Console.Write($"{secound[i, j]}   ");
        }
        Console.WriteLine();
    }
}


bool NumberChoice(ref int raw1, ref int col1)
{

    if (!int.TryParse(chose3[0], out int value1))
    {
        Console.WriteLine("숫자를 입력하세요.");
        return false;
    }
    if (!int.TryParse(chose3[1], out int value2))
    {
        Console.WriteLine("숫자를 입력하세요.");
        return false;
    }
    raw1 = value1;
    col1 = value2;
    if (chose3[1] == null)
    {
        Console.WriteLine("행과 열을 공백으로 구분하여 입력하세요. (예: 1, 3)");
        return false;
    }
    else if (value1 < 1 || value1 > 4 || value2 < 1 || value2 > 4)
    {
        Console.WriteLine("행은 1~4, 열은 1~4 범위로 입력하세요.");
        return false;
    }
    else if (secound[raw1, col1] != "**   ")
    {
        Console.WriteLine("이미 짝을 찾은 카드입니다. 다른 카드를 선택하세요.");
        return false;
    }
    else
    {

        return true;
    }

}

void Shuffle()
{
    for (int i = 0; i < 20; i++)
    {
        int raw1 = random.Next(1, 5);
        int col1 = random.Next(1, 5);

        int raw2 = random.Next(1, 5);
        int col2 = random.Next(1, 5);

        string temp = answer[raw1, col1];
        answer[raw1, col1] = answer[raw2, col2];
        answer[raw2, col2] = temp;
    }

}




