namespace XsoaApi.Core;

public class UserRote
{
    public List<Route> Routes { get; set; }
    public string Home { get; set; }
}

public class Route
{
    public string Name { get; set; }
    public string Path { get; set; }
    public string Component { get; set; }
    public bool? Props { get; set; } = null;
    public Meta Meta { get; set; }
    public List<Route> Children { get; set; }
}

#nullable enable
public class Meta
{
    public string Title { get; set; }
    public string? I18nKey { get; set; } = null;
    public int? Order { get; set; } = null;
    public bool? KeepAlive { get; set; } = null;
    public bool? Constant { get; set; } = null;
    public string? Icon { get; set; } = null;
    public string? LocalIcon { get; set; } = null;
    public string? Href { get; set; } = null;
    public bool? HideInMenu { get; set; } = null;
    public string? ActiveMenu { get; set; } = null;
    public bool? MultiTab { get; set; } = null;

    public int? FixedIndexInTab { get; set; } = null;

    public List<Query> Query { get; set; } = [];
    public List<Buttons> Buttons { get; set; } = [];
}

public class Query
{
    public string Key { get; set; }
    public string Value { get; set; }
}

public class Buttons
{
    public string Desc { get; set; }
    public string Code { get; set; }
}