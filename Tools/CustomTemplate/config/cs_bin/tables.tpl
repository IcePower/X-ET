using Bright.Serialization;
using System;

{{
    name = x.name
    namespace = x.namespace
    tables = x.tables

}}
namespace {{namespace}}
{
   
public partial class {{name}}
{   
    private System.Collections.Generic.Dictionary<string, IConfigCategory> tables;

    public {{name}}(System.Func<string, ByteBuf> loader)
    {
        tables = new System.Collections.Generic.Dictionary<string, IConfigCategory>();
        {{~for table in tables ~}}
        {{table.full_name}} {{table.name}} = new {{table.full_name}}(loader("{{table.output_data_file}}")); 
        tables.Add("{{table.full_name}}", {{table.name}});
        {{~end~}}

        PostInit();
        {{~for table in tables ~}}
        {{table.name}}.Resolve(tables); 
        {{~end~}}
        PostResolve();
    }
    
    public void LoadOneConfig(Type type, Func<string, ByteBuf> loader)
    {
        tables[type.Name] = Activator.CreateInstance(type, loader(type.Name.ToString().ToLower())) as IConfigCategory;
    }

    public void TranslateText(System.Func<string, string, string> translator)
    {
        {{~for table in tables ~}}
        {{table.name}}.Instance.TranslateText(translator); 
        {{~end~}}
    }
    
    partial void PostInit();
    partial void PostResolve();
}

}