using System.Collections.Generic;


namespace SQLServerToDBML
{
    public class DBMLDatabase{
        public string DatabaseName {get; set;}
        public List<DBMLTable> Tables {get; set;}

        public DBMLDatabase(){
            this.Tables = new List<DBMLTable>();
        }
    }

}