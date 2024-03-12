namespace MLaw.UserServices;

public static class UserServicesConsts
{
    public const string DbTablePrefix = "App";

    public readonly struct KafkaTopic
    {
        public const string CERT_CRT = "giis.cert.create";
    }
    public readonly struct DbSchema
    {
        public const string Schema = "dbo";
    }
    public readonly struct ConnectionStringName
    {
        public const string Default = "Default";
    }
}
