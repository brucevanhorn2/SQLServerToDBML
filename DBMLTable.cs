using System.Collections.Generic;


namespace SQLServerToDBML
{
    public class DBMLTable {
        public string Name {get; set;}
        public List<DBMLColumn> Columns {get;}


        public DBMLTable(){
            Columns = new List<DBMLColumn>();
        }
    }
}   