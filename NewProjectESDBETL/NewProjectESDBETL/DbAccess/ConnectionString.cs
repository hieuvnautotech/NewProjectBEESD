﻿namespace NewProjectESDBETL.DbAccess
{
    public class ConnectionString
    {
        public const string CONNECTIONSTRING = $"data source=118.69.130.73,1435;initial catalog=hieuESD;persist security info=True;user id=sa;password=YFemGoN1mCoYP7hrfUY5Re5z1YIe0hVG2R76R4pj5O7k2YQnM3;MultipleActiveResultSets=True;";
        //public const string CONNECTIONSTRING = $"data source=localhost;initial catalog=ESD;persist security info=True;user id=sa;password=MMeulbSqnONxoC8G41ddrXgWUO6IbrshoqVvmQj4JWhD1rP6fD;MultipleActiveResultSets=True;";

        public const string CONNECTIONSTRINGEDI = $"data source=118.69.130.73,1435;initial catalog=DongSungEDI;persist security info=True;user id=sa;password=YFemGoN1mCoYP7hrfUY5Re5z1YIe0hVG2R76R4pj5O7k2YQnM3;MultipleActiveResultSets=True;";
        //public const string CONNECTIONSTRINGEDI = $"data source=localhost;initial catalog=DongSungEDI;persist security info=True;user id=sa;password=MMeulbSqnONxoC8G41ddrXgWUO6IbrshoqVvmQj4JWhD1rP6fD;MultipleActiveResultSets=True;";

        // bộ 3 bên dưới dùng để mã hóa token
        public static readonly string SECRET = $"eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJqdGkiOiJiOGIyMTJjZi03ZjY4LTRmNjktYTA1Zi1hY2NhZjU4MjQxMWYiLCJpYXQiOjE2NTEyMjE3NDAsInN1YiI6Ikp3dEF1dGhlbnRpY2F0aW9uU2VydmljZUFjY2Vzc1Rva2VuIiwibmFtZWlkIjoibmFtIiwicm9sZSI6IlJPT1QiLCJuYmYiOjE2NTEyMjE3NDAsImV4cCI6MTY1MTIyMTgzMCwiaXNzIjoiSnd0QXV0aGVudGljYXRpb25TZXJ2ZXIiLCJhdWQiOiJKd3RBdXRoZW50aWNhdGlvblNlcnZpY2VQb3N0bWFuQ2xpZW50In0.yzey7IxENVJwilmvSneL8Ftf6a2QAjeDpXTsgiRXUDM";
        public const string ISSUER = "JwtAuthenticationServer";
        public const string AUDIENCE = "JwtAuthenticationServicePostmanClient";

        //public const string CLIENT = $"http://hl.autonsi.com";
        //public static readonly string CLIENT = $"http://localhost:3001";
    }
}
