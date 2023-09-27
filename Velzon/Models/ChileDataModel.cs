using System.Collections.Generic;

public class ChileDataModel
{
    public string Name { get; set; }
    public List<RegionModel> Regions { get; set; }
}

public class RegionModel
{
    public string Name { get; set; }
    public string RomanNumber { get; set; }
    public string Number { get; set; }
    public List<CommuneModel> Communes { get; set; }
}

public class CommuneModel
{
    public string Name { get; set; }
}
