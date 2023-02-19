public class PartList
{
    public List<Part> Parts { get; set; }
}
public class Part
{
    public int Id { get; set; }
    public string Type { get; set; }
    public string Desc { get; set; }
    public string UOM { get; set; }
    public double MRP { get; set; }
}