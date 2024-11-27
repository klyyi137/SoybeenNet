namespace XsoaApi.Core;

public static class SqlsugarSetup
{
    public static void AddSqlsugarSetup(this IServiceCollection services)
    {
        //数据库链接,修改配置里面的SqlServerConnection的字符串
        //var ConnectionString = AppSettings.SqlServerConnection;

        //var configConnection = new ConnectionConfig
        //{
        //    DbType = DbType.SqlServer,
        //    ConnectionString = ConnectionString,
        //    IsAutoCloseConnection = true,
        //    ConfigId = 1
        //};

        var configConnection = App.GetConfig<List<ConnectionConfig>>("ConnectionConfigs");

        //SqlSugarScope线程是安全的
        var sqlSugar = new SqlSugarScope(configConnection, Sqlclient);

        //这边是SqlSugarScope用AddSingleton
        services.AddSingleton<ISqlSugarClient>(sqlSugar);

        // 注册 SqlSugar 仓储
        services.AddScoped(typeof(SqlSugarRepository<>));
        return;

        // 文档地址：https://www.donet5.com/Home/Doc?typeId=1204
        void Sqlclient(SqlSugarClient db)
        {
            // 打印SQL语句
            db.Aop.OnLogExecuting = (sql, parameters) =>
            {
                var originColor = Console.ForegroundColor;
                if (sql.StartsWith("SELECT", StringComparison.OrdinalIgnoreCase)) Console.ForegroundColor = ConsoleColor.Green;
                if (sql.StartsWith("UPDATE", StringComparison.OrdinalIgnoreCase) || sql.StartsWith("INSERT", StringComparison.OrdinalIgnoreCase)) Console.ForegroundColor = ConsoleColor.Yellow;
                if (sql.StartsWith("DELETE", StringComparison.OrdinalIgnoreCase)) Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("【" + DateTime.Now + "——执行SQL】\r\n" + UtilMethods.GetSqlString(db.CurrentConnectionConfig.DbType, sql, parameters) + "\r\n");
                Console.ForegroundColor = originColor;
            };
        }
    }

}