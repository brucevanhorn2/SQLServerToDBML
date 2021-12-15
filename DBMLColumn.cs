namespace SQLServerToDBML
{
    public class DBMLColumn{
        public string ColumnName {get; set;}
        public string Type {get; set;}
        public int MaxSize {get; set;}
        public bool IsPrimaryKey {get; set;}
        public string Note {get; set;}
    }
}