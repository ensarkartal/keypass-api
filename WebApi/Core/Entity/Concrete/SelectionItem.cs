using WebApi.Core.Entity.Abstract;

namespace WebApi.Core.Entity.Concrete;

/// <summary>
/// Simple selectable lists have been created to return with a single schema through the API.
/// </summary>
public class SelectionItem : IDto
{
    public SelectionItem()
    {
            
    }
    public SelectionItem(dynamic id, string parentId, string label, bool isDisabled)
    {
        Id = id;
        ParentId = parentId;
        Label = label;
        IsDisabled = isDisabled;
    }


    public SelectionItem(dynamic id, string label, string parentId)
    {
        Id = id;
        Label = label;
        ParentId = parentId;
    }

    public string Id { get; set; }
    public string ParentId { get; set; }
    public string Label { get; set; }
    public bool IsDisabled { get; set; }
}