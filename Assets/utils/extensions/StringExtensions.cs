using System;
using System.Text;

public static class StringExtensions 
{ 
   /// <summary> 
   /// Humanize a "CamelCasedString" into "Camel Cased String". 
   /// </summary> 
   /// <param name="source"></param> 
   /// <returns></returns> 
   public static string Humanize(this string source ) 
    { 
       StringBuilder sb =new StringBuilder(); 

       char last = char.MinValue; 
       foreach (char c in source ) 
        { 
           if (char.IsLower( last ) ==true &&char.IsUpper( c ) ==true ) 
            { 
                sb.Append(' '); 
            } 
            sb.Append( c ); 
            last = c; 
        } 
       return sb.ToString(); 
    } 

    public static string Alienate(this string source, bool shouldStartUppercase = true )
    {
        char[] chars = source.ToCharArray();
        string[] letters = new string[ chars.Length ];

        for( int i = 0; i < chars.Length; i++ )
        {
            string s = chars[i].ToString();
            bool makeUppercase = ( shouldStartUppercase ) ? i % 2 == 0 : (i+1) % 2 == 0 ; 
            letters[i] = ( makeUppercase ) ? s.ToUpper() : s.ToLower();
        }

        return string.Join( "", letters );
    }
}
