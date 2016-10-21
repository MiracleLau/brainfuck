/*
 * Created by SharpDevelop.
 * User: Radiation
 * Date: 2016/10/20
 * Time: 12:14
 * Blog: http://b.zlweb.cc
 */
using System;
using System.Text;

namespace fuckbrain
{
	/// <summary>
	/// Description of fuckBrain.
	/// </summary>
	public class fuckBrain
	{
		public fuckBrain()
		{
			//do nothing
		}
		
		/// <summary>
		/// 将普通文本转换为brainfuck
		/// </summary>
		/// <param name="text">要编码的字符串</param>
		/// <returns>最后的结果</returns>
		public string text2FuckBrain(string text)
		{
			//当前位置
			int value=0;
			int i=0;
			int diff;
			string result="";
			int loop;
			for(i=0;i<text.Length;++i)
			{
				diff = ord(text[i].ToString())-value;
				value = ord(text[i].ToString());
				if(diff==0)
				{
					result+=">.<";
					continue;
				}
				if(Math.Abs(diff)<10)
				{
					if(diff>0)
						result+=">"+str_repeat("+",diff);
					else if(diff<0)
						result+=">"+str_repeat("-",Math.Abs(diff));
				}
				else
				{
					loop = (int)Math.Sqrt(Math.Abs(diff));
					result+=str_repeat("+",loop);
					if(diff > 0)
					{
						 result += "[->"+ str_repeat("+", loop) +"<]";
						 result += ">" + str_repeat("+", (int)(diff - Math.Pow(loop, 2)));
				    }
				    else if(diff < 0)
				    {
					     result += "[->" + str_repeat("-", loop) + "<]";
					     result += ">" + str_repeat("-", (int)(Math.Abs(diff) - Math.Pow(loop, 2)));
					}
				}
				result += ".<";
			}
			result = result.Replace("<>","");
			return(result);
		}
		
        /// <summary>
        /// 解释brainfuck
        /// </summary>
        /// <param name="script"></param>
        /// <returns></returns>
		public string FuckBrain2Text(string script)
        {
            char[] data = new char[30000];
            string output = "";
            // the index into the script
            int inst_p = 0;

            // the data pointer
            int data_p = 0;

            // process the script
            while (inst_p < script.Length)
            {
                switch (script[inst_p])
                {
                    case '>':               // increment the data pointer
                        data_p++;
                        break;
                    case '<':               // decrement the data pointer
                        data_p--;
                        break;
                    case '+':               // increment the data at the data pointer
                        data[data_p]++;
                        break;
                    case '-':               // decrement the data at the data pointer
                        data[data_p]--;
                        break;
                    case '.':               // print the data at the data pointer
                        output+=data[data_p];
                        break;
                    case ',':               // read a char and save it to data at the data pointer
                        data[data_p] = Convert.ToChar(0);
                        break;
                    case '[':               // skip forward to instruction after matching ]
                        if (data[data_p] == 0)  // only if data at data pointer is 0
                        {
                            // keep track of nested []
                            int level = 0;

                            // walk until we find the closing ]
                            while (++inst_p < script.Length)
                            {
                                if (script[inst_p] == ']')
                                {
                                    if (level == 0) break;
                                    else level--;
                                }
                                else if (script[inst_p] == '[') level++;
                            }
                        }
                        break;
                    case ']':               // skip backwards to instruction after matching [
                        if (data[data_p] != 0)  // only if data at data pointer is not 0
                        {
                            // keep track of nested []
                            int level = 0;

                            // walk until we find the closing [
                            while (--inst_p >= 0)
                            {
                                if (script[inst_p] == '[')
                                {
                                    if (level == 0) break;
                                    else level--;
                                }
                                else if (script[inst_p] == ']') level++;
                            }
                        }
                        break;
                    default:                // pass over any other character
                        break;
                }

                // go to next instruction
                inst_p++;
            }
            return (output);
        }
		
		public static int ord(string character)
		{
			ASCIIEncoding asciiEncoding = new ASCIIEncoding();
			int intAsciiCode = (int)asciiEncoding.GetBytes(character)[0];
			return(intAsciiCode);
		}
		
		/// <summary>
		/// 将字符串重复指定的次数
		/// </summary>
		/// <param name="str">要重复的字符</param>
		/// <param name="count">要重复的次数</param>
		/// <returns></returns>
		public string str_repeat(string str,int count)
		{
			int i;
			string result="";
			for(i=0;i<count;i++)
			{
				result+=str;
			}
			return (result);
		}
	}
}
