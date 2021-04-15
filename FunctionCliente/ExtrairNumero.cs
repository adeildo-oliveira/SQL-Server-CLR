using Microsoft.SqlServer.Server;
using System.Data.SqlTypes;
using System.Text;

public partial class UserDefinedFunctions
{
    [SqlFunction]
    public static SqlString ExtrairNumero(string parametro) => new SqlString(ExtracaoLinear.NumberOfString(parametro).ToString());

    internal readonly struct ExtracaoLinear
    {
        private static readonly StringBuilder sb = new StringBuilder();

        public static StringBuilder NumberOfString(string input)
        {
            sb.Clear();

            if (string.IsNullOrWhiteSpace(input))
                return sb.Append("0");

            for (var i = 0; i < input.Length; i++)
            {
                if (char.IsDigit(input[i]))
                    sb.Append(input[i]);
            }

            return sb;
        }
    }
}
