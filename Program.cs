using System.Text;
using System.Globalization;
internal class Program
{
    private static void Main(string[] args)
    {
        // 文字コードを調べたい文字
        string str = "あ";

        // UTF-8
        // UTF-8文字コード(10進数)を計算
        int utf8Code = CalcCharacterCodeUTF8(str);

        // UTF-8文字コードを2進数に変換
        string utf8CodeBinaryStr = Convert.ToString(utf8Code, 2);

        // UTF-8文字コードを16進数に変換
        string utf8CodeHexStr = Convert.ToString(utf8Code, 16);



        // Shift_JIS
        // Shift_JIS文字コード(10進数)を計算
        int sjisCode = CalcCharacterCodeSJIS(str);

        // Shift_JIS文字コードを2進数に変換
        string sjisCodeBinaryStr = Convert.ToString(sjisCode, 2);

        // Shift_JIS文字コードを16進数に変換
        string sjisCodeHexStr = Convert.ToString(sjisCode, 16);


        // 結果を表示
        Console.WriteLine($"文字:{str}");
        Console.WriteLine();
        Console.WriteLine("UTF-8");
        Console.WriteLine($"2進数:{utf8CodeBinaryStr}");
        Console.WriteLine($"10進数:{utf8Code}");
        Console.WriteLine($"16進数:{utf8CodeHexStr}");
        Console.WriteLine();
        Console.WriteLine("Shift_JIS");
        Console.WriteLine($"2進数:{sjisCodeBinaryStr}");
        Console.WriteLine($"10進数:{sjisCode}");
        Console.WriteLine($"16進数:{sjisCodeHexStr}");
    }

    // UTF-8文字コードを計算するメソッド
    private static int CalcCharacterCodeUTF8(string s)
    {
        // UTF-8でエンコード
        Encoding utf8 = Encoding.GetEncoding("UTF-8");

        // 文字コードを計算(10進数)
        int code = 0;
        byte[] bytes = utf8.GetBytes(s);
        foreach (byte b in bytes)
        {
            code = b + code * 256;
        }

        return code;
    }


    // Shift_JIS文字コードを計算するメソッド
    private static int CalcCharacterCodeSJIS(string s)
    {
        // Shift_JISでエンコード
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        Encoding sjis = Encoding.GetEncoding("Shift_JIS");

        // 文字コードを計算(10進数)
        int code = 0;
        byte[] bytes = sjis.GetBytes(s);
        foreach (byte b in bytes)
        {
            code = b + code * 256;
        }

        return code;
    }
}