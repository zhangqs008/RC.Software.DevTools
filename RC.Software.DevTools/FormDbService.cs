using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using RC.Software.Framework.Helper;

namespace RC.Software.DevTools
{
    public class FormDbService
    {
        public static List<DbInfo> GetDbs()
        {
            var config = ConfigHelper.GetConfig<DbConfig>();
            return config.Dbs ?? new List<DbInfo>();
        }

        public static DbInfo GetDb(int id)
        {
            var config = ConfigHelper.GetConfig<DbConfig>();
            foreach (DbInfo db in config.Dbs)
            {
                if (db.Id == id)
                {
                    return db;
                }
            }
            return new DbInfo();
        }
        public static void EditDb(DbInfo db)
        {
            if (db.Id == 0)
            {
                AddDb(db);
            }
            else
            {
                var config = ConfigHelper.GetConfig<DbConfig>();
                config.Dbs = config.Dbs ?? new List<DbInfo>();

                var list = new List<DbInfo>();
                foreach (DbInfo item in config.Dbs)
                {
                    list.Add(db.Id == item.Id ? db : item);
                }

                config.Dbs = list;
                ConfigHelper.UpdateConfig(config);
            }
        }

        public static void AddDb(DbInfo db)
        {
            var config = ConfigHelper.GetConfig<DbConfig>();
            config.Dbs = config.Dbs ?? new List<DbInfo>();
            var maxId = 0;
            foreach (DbInfo info in config.Dbs)
            {
                maxId = info.Id > maxId ? info.Id : maxId;
            }
            db.Id = maxId + 1;
            config.Dbs.Add(db);
            ConfigHelper.UpdateConfig(config);
        }

        public static void DelDb(int id)
        {
            var config = ConfigHelper.GetConfig<DbConfig>();
            config.Dbs = config.Dbs ?? new List<DbInfo>();

            var list = new List<DbInfo>();
            foreach (DbInfo item in config.Dbs)
            {
                if (item.Id != id)
                {
                    list.Add(item);
                }
            } 
            config.Dbs = list; 
            ConfigHelper.UpdateConfig(config);
        }

        public class DbConfig
        {
            public List<DbInfo> Dbs { get; set; }
        }


        public class DbInfo
        {
            public int Id { get; set; }
            public string Server { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }
            public string Database { get; set; }
        }

        public static string GetConnectionString(int id)
        {
            var db = GetDb(id);
            string conn = "Data Source={0};Initial Catalog={1};User ID={2};Password={3};";
            conn = string.Format(conn, db.Server.Trim(), db.Database.Trim(), db.UserName.Trim(), db.Password.Trim());
            return conn;
        }
    }
}