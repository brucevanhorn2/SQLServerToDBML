public class RawTable {
    public string tableName {get; set;}

    public string columnName {get; set;}
    public string dataType {get; set;}
    public int maxLength {get; set;}
    public float precision {get; set;}

    public RawTable(string tableName, string columnName, string dataType, int maxLength, float precision){
        this.tableName = tableName;
        this.columnName = columnName;
        this.dataType = dataType;
        this.maxLength = maxLength;
        this.precision = precision;
    }
}